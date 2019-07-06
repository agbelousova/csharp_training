using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using System.Text.RegularExpressions;

namespace mantis_tests
{
    public class RegistrationHelper : HalperBase
    {
        public RegistrationHelper(ApplicationManager manager) : base(manager) { }


        public void Register(AccountData account)
        {
            OpenMainPage();
            OpenRegistrationForm();
            FillRegistrationForm(account);
            // SubmitRegistration();
            SubmitOneButtonForm();

            String url = GetConfirmationURL(account); 
            FillPasswordForm(url, account);
            //SubmitPasswordForm();
            SubmitOneButtonForm();

        }

        public void SubmitOneButtonForm()
        {
            driver.FindElement(By.CssSelector("input.button")).Click();

        }

        private void SubmitPasswordForm()
        {
            driver.FindElement(By.CssSelector("input.button")).Click();
        }

        private void FillPasswordForm(string url, AccountData account)
        {
            driver.Url = url;

            driver.FindElement(By.Name("password")).SendKeys(account.Password);
            driver.FindElement(By.Name("password_confirm")).SendKeys(account.Password);

        }

        internal void InitLogOut()
        {
            driver.FindElement(By.XPath("/html/body/table[2]/tbody/tr/td[1]/a[9]")).Click(); //Клик по кнопке Логаут
        }

        private string GetConfirmationURL(AccountData account)
        {
            String message = manager.Mail.GetLastMail(account);
            Match match = Regex.Match(message, @"http://\S*");
            return match.Value;
        }

        private void OpenRegistrationForm()
        {
             driver.FindElements(By.CssSelector("span.bracket-link"))[0].Click();
        }

      //  public void SubmitRegistration()
      //  {
      //      driver.FindElement(By.CssSelector("input.button")).Click();
      //  }

        public void FillRegistrationForm(AccountData account)
        {
            driver.FindElement(By.Name("username")).SendKeys(account.Name);
            driver.FindElement(By.Name("email")).SendKeys(account.Email);
        }

        public void OpenMainPage()
        {
            manager.Driver.Url = "http://localhost/mantisbt-1.2.17/login_page.php";
        }

        public void FillAuthForm(AccountData admin)
        {
            driver.FindElement(By.Name("username")).SendKeys(admin.Name);
            driver.FindElement(By.Name("password")).SendKeys(admin.Password);

        }
    }
}
