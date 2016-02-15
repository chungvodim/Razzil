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
using OpenQA.Selenium.PhantomJS;
using Razzil.Models;
using OpenQA.Selenium;

namespace Razzil.Workflow
{
    public class StepContext : DomainObject
    {
        public StepContext(int bankId)
        {
            using (var db = new Entities())
            {
                // To Do: Init TransactionModel
                //this.TransactionModel = 
                this.BankId = bankId;
                var bank = db.Banks.Where(x => x.Id == bankId).FirstOrDefault();
                if(bank != null)
                {
                    
                    switch (bank.WebBrowser.Name.ToLower())
                    {
                        case "chrome":
                            WebDriver = new ChromeDriver();
                            break;
                        case "phantomjs":
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
                            break;
                        default:
                            WebDriver = new ChromeDriver();
                            break;
                    }
                    
                    WaitDriver = new WebDriverWait(WebDriver, new TimeSpan(0, 0, bank.TimeOut.Value));
                    ShortWaitDriver = new WebDriverWait(WebDriver, new TimeSpan(0, 0, bank.TimeOut.Value / 2));

                    httpClient = new HttpClient() { Timeout = new TimeSpan(0, 0, bank.TimeOut.Value) };
                    TransactionModel = new BankTransaction();
                }
            }
        }
        public void InitTransactionModel(string fromAccountNumber, int fromBankId, string toAccountNumber, int toBankId,
            decimal amount, string content)
        {
            using (var db = new Entities())
            {
                var account = db.Accounts.Where(x => x.AccountNumber == fromAccountNumber && x.BankId == fromBankId).FirstOrDefault();
                if(account != null)
                {
                    this.TransactionModel.UserName = account.UserName;
                    this.TransactionModel.Password = account.Password;

                    this.TransactionModel.FromAccountName = fromAccountNumber;
                    this.TransactionModel.FromBankId = fromBankId;
                    this.TransactionModel.ToAccountNumber = toAccountNumber;
                    this.TransactionModel.ToBankId = toBankId;
                    this.TransactionModel.Amount = amount;
                    this.TransactionModel.Content = content;
                }
            }
                
        }
        public IWebDriver WebDriver { get; private set; }
        public WebDriverWait WaitDriver { get; private set; }
        public WebDriverWait ShortWaitDriver { get; private set; }
        public HttpClient httpClient { get; private set; }
        public int BankId { get; set; }
        public string LastPage { get; set; }
        public StatusCode StatusCode { get; set; }
        public bool IsSuccessful { get; set; }
        public BankTransaction TransactionModel { get; set; }
        public Encoding Encoding { get; set; }
        public Dictionary<string, string> Params { get; set; }
    }
}
