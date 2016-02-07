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

namespace Razzil.Workflow
{
    public class StepContext : DomainObject
    {
        public StepContext(string bankName)
        {
            using (var db = new Entities())
            {
                var bank = db.Banks.Where(x => x.Name == bankName).FirstOrDefault();
                if(bank != null)
                {
                    Logger = LogManager.GetCurrentClassLogger();
                    WebDriver = new ChromeDriver();
                    WaitDriver = new WebDriverWait(WebDriver, new TimeSpan(0, 0, bank.TimeOut.Value));
                    ShortWaitDriver = new WebDriverWait(WebDriver, new TimeSpan(0, 0, bank.TimeOut.Value / 2));
                    Client = new HttpClient() { Timeout = new TimeSpan(0, 0, bank.TimeOut.Value) };
                }
            }
        }

        public Logger Logger { get; private set; }
        public ChromeDriver WebDriver { get; private set; }
        public WebDriverWait WaitDriver { get; private set; }
        public WebDriverWait ShortWaitDriver { get; private set; }
        public HttpClient Client { get; private set; }
        public int BankId { get; set; }
        public string LastPage { get; set; }
        public StatusCode StatusCode { get; set; }
        public bool IsSuccessful { get; set; }
        public BankTransactionModel TransferModel { get; set; }
        public Encoding Encoding { get; set; }
        public Dictionary<string, string> Params { get; set; }
    }
}
