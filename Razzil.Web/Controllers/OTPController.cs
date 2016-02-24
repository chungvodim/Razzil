using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Razzil.DataAccess.Repository;
using System.Threading.Tasks;
using System.IO;
using System.Data.Entity.Validation;
using System.Diagnostics;
using Razzil.Utils;
using Razzil.Models;

namespace Razzil.Web.Controllers
{
    public class OTPController : Controller
    {
        private Entities db = new Entities();
        // GET: Captcha
        [HttpGet]
        public ActionResult Input()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Input(int Id, string Ref, string Result)
        {
            try
            {
                var OTPModel = db.OTPs.Where(x => x.Id == Id).FirstOrDefault();
                OTPModel.Ref = Ref;
                OTPModel.Result = Result;
                db.Entry(OTPModel).State = EntityState.Modified;
                db.SaveChanges();
            }
            catch(Exception ex)
            {
                DebugHelper.Error(ex);
            }
            var OTPModels = db.OTPs.Where(x => x.Passed == false).ToList();
            return View(OTPModels);
        }
        [HttpGet]
        public ActionResult GetUnPassedOTPs()
        {
            // Ajax will recieve html data (dataType: "html")
            return PartialView("_OTPPartial", db.OTPs.Where(x => x.Passed == false).ToList());
        }
        /// <summary>
        /// Receive OTP sms from phone
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="content"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        [HttpPost]
        public void Receive(string from, string to, string content, string date)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (!string.IsNullOrEmpty(content))
                    {
                        var OTPModel = new OTP()
                        {
                            Content = content,
                            Passed = false,
                            CreatedTime = DateTime.Parse(date),
                            From = from,
                            To = to
                        };
                        ParseOTP(OTPModel);
                        db.OTPs.Add(OTPModel);
                        db.SaveChanges();
                    }
                }
                catch (Exception ex)
                {
                    DebugHelper.Error(ex);
                }
            }
        }
        /// <summary>
        /// Robot request OTP
        /// </summary>
        /// <param name="phoneNumber"></param>
        /// <param name="Reference"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<string> Fetch(string phoneNumber, string Reference)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(phoneNumber))
                {
                    var OTPResult = await GetOTPResult(phoneNumber, Reference);
                    return SerializerHelper.SerializeJsonObject(OTPResult);
                }
            }
            catch (Exception ex)
            {
                DebugHelper.Error(ex);
            }
            return "";
        }
        /// <summary>
        /// Parse OTP by Regular Expression
        /// </summary>
        /// <param name="OTPModel"></param>
        private void ParseOTP(OTP OTPModel)
        {
            // There aren't any parser yet 
            OTPModel.Ref = "";
            OTPModel.Result = "";
        }

        private async Task<ResponseResult> GetOTPResult(string PhoneNumber, string Reference)
        {
            return await Task.Run(() =>
            {
                while (true)
                {
                    using (var db = new Entities())
                    {
                        var OTPModel = db.OTPs.Where(x => x.To == PhoneNumber && x.Ref == Reference && x.Passed == false).FirstOrDefault();
                        if (OTPModel != null && !string.IsNullOrWhiteSpace(OTPModel.Result))
                        {
                            OTPModel.Passed = true;
                            db.Entry(OTPModel).State = EntityState.Modified;
                            db.SaveChanges();
                            ResponseResult ResponseResult = new ResponseResult()
                            {
                                Status = ResponseStatusEnum.Successful,
                                Data = OTPModel.Result
                            };
                            return ResponseResult;
                        }
                        Task.Delay(1000);
                    }
                }
            });
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}