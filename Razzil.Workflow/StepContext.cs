using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Razzil.DataAccess;
using System.Net.Http;
using Razzil.DataAccess.Repository;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using NLog;
using OpenQA.Selenium.PhantomJS;
using Razzil.Models;
using OpenQA.Selenium;

namespace Razzil.Workflow
{
    public class StepContext : DomainObject
    {
        public StepContext(string bankName)
        {
            using (var db = new Entities())
            {
                // To Do: Init TransactionModel
                //this.TransactionModel = 
                this.BankName = bankName;
                var bank = db.Banks.Where(x => x.Name == bankName).FirstOrDefault();
                if(bank != null)
                {
                    Logger = LogManager.GetCurrentClassLogger();
                    bool isDebugMode = false;
                    if (isDebugMode)
                    {
                        WebDriver = new ChromeDriver();
                    }
                    else
                    {
                        PhantomJSOptions options = new PhantomJSOptions();
                        if (!string.IsNullOrWhiteSpace(bank.UserAgent))
                        {
                            //"Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/37.0.2062.120 Safari/537.36"
                            options.AddAdditionalCapability("phantomjs.page.settings.userAgent", bank.UserAgent);
                        }
                        PhantomJSDriverService defaultService = PhantomJSDriverService.CreateDefaultService();
                        defaultService.HideCommandPromptWindow = true;
                        defaultService.LoadImages = false;
                        WebDriver = new PhantomJSDriver(defaultService, options);
                    }
                    
                    WaitDriver = new WebDriverWait(WebDriver, new TimeSpan(0, 0, bank.TimeOut.Value));
                    ShortWaitDriver = new WebDriverWait(WebDriver, new TimeSpan(0, 0, bank.TimeOut.Value / 2));

                    Client = new HttpClient() { Timeout = new TimeSpan(0, 0, bank.TimeOut.Value) };
                    TransactionModel = new BankTransactionModel();
                }
            }
        }

        public Logger Logger { get; private set; }
        public IWebDriver WebDriver { get; private set; }
        public WebDriverWait WaitDriver { get; private set; }
        public WebDriverWait ShortWaitDriver { get; private set; }
        public HttpClient Client { get; private set; }
        public string BankName { get; set; }
        public string LastPage { get; set; }
        public StatusCode StatusCode { get; set; }
        public bool IsSuccessful { get; set; }
        public BankTransactionModel TransactionModel { get; set; }
        public Encoding Encoding { get; set; }
        public Dictionary<string, string> Params { get; set; }
    }
}
