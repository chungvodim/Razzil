//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.Data.Entity;
//using System.Linq;
//using System.Net;
//using System.Web;
//using System.Web.Mvc;
//using Razzil.DataAccess.Repository;
//using System.Threading.Tasks;
//using System.IO;
//using System.Data.Entity.Validation;
//using System.Diagnostics;

//namespace Razzil.Web.Controllers
//{
//    [Authorize]
//    public class CaptchaController : Controller
//    {
//        private Entities db = new Entities();
//        // GET: Captcha
//        [HttpGet]
//        public ActionResult Input()
//        {
//            return View();
//        }
//        [HttpPost]
//        public ActionResult Input(int Id, string Result)
//        {
//            var captchaModel = db.Captchas.Where(x => x.Id == Id).FirstOrDefault();
//            captchaModel.Result = Result;
//            db.Entry(captchaModel).State = EntityState.Modified;
//            db.SaveChanges();
//            var captchaModels = db.Captchas.Where(x => x.Passed == false).ToList();
//            return View(captchaModels);
//        }
//        //[HttpGet]
//        //public string GetUnPassedCapchas()
//        //{
//        //    using (var db = new Entities())
//        //    {
//        //        JavaScriptSerializer TheSerializer = new JavaScriptSerializer();
//        //        List<CaptchaViewModel> captchaViewModels = new List<CaptchaViewModel>();
//        //        foreach (var captcha in db.Captchas.Where(x => x.Passed == false).ToList())
//        //        {
//        //            captchaViewModels.Add(new CaptchaViewModel()
//        //            {
//        //                Id = captcha.Id,
//        //                Image = captcha.Image,
//        //                CreatedTime = captcha.CreatedTime.ToString()
//        //            });
//        //        }
//        //        TheSerializer.MaxJsonLength = 50000000;
//        //        var TheJson = TheSerializer.Serialize(captchaViewModels);
//        //        // Ajax will recieve json data
//        //        return TheJson;
//        //    }
//        //}
//        [HttpGet]
//        public ActionResult GetUnPassedCapchas()
//        {
//            // Ajax will recieve html data (dataType: "html")
//            return View("_CaptchaPartial", db.Captchas.Where(x => x.Passed == false).ToList());
//        }
//        [HttpPost]
//        public async Task<string> Upload(HttpPostedFileBase captcha)
//        {
//            if (ModelState.IsValid)
//            {
//                try
//                {
//                    if (captcha != null)
//                    {
//                        using (MemoryStream ms = new MemoryStream())
//                        {
//                            captcha.InputStream.CopyTo(ms);
//                            var captchaModel = new Captcha()
//                            {
//                                Image = ms.GetBuffer(),
//                                Passed = false,
//                                CreatedTime = DateTime.Now
//                            };
                                
//                            db.Captchas.Add(captchaModel);
//                            db.SaveChanges();
//                            var captchaResult = await GetCaptChaResult(captchaModel.Id);
//                            return Utils.Serialize(captchaResult);
//                        }
//                    }
//                }
//                catch (DbEntityValidationException e)
//                {
//                    foreach (var eve in e.EntityValidationErrors)
//                    {
//                        Debug.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",eve.Entry.Entity.GetType().Name, eve.Entry.State);
//                        foreach (var ve in eve.ValidationErrors)
//                        {
//                            Debug.WriteLine("- Property: \"{0}\", Error: \"{1}\"",ve.PropertyName, ve.ErrorMessage);
//                        }
//                    }
//                }
//            }
//            return "";
//        }

//        private async Task<CaptchaViewModel> GetCaptChaResult(int Id)
//        {
//            return await Task.Run(() =>
//            {
//                while (true)
//                {
//                    using (var db = new Entities())
//                    {
//                        var captchaModel = db.Captchas.Where(x => x.Id == Id).FirstOrDefault();
//                        if (captchaModel != null && !string.IsNullOrWhiteSpace(captchaModel.Result))
//                        {
//                            captchaModel.Passed = true;
//                            db.Entry(captchaModel).State = EntityState.Modified;
//                            db.SaveChanges();
//                            CaptchaViewModel captchaViewModel = new CaptchaViewModel()
//                            {
//                                Status = ResponseCode.Success,
//                                Data = captchaModel.Result
//                            };
//                            return captchaViewModel;
//                        }
//                        Task.Delay(1000);
//                    }
//                }
//            });
//        }

//        protected override void Dispose(bool disposing)
//        {
//            if (disposing)
//            {
//                db.Dispose();
//            }
//            base.Dispose(disposing);
//        }
//    }
//}