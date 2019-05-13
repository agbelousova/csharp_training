using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
    public class LoginHelper : HalperBase
    {


        public LoginHelper(ApplicationManager manager) : base(manager)
        {
        }
        public void Login(AccountData account)
        {
            if (IsLoggetIn())
            {
                if (IsLoggetIn(account))
                {
                    return;
                }
                Logout();
            }
            Type(By.Name("user"), account.Username);
            Type(By.Name("pass"), account.Password);
            driver.FindElement(By.XPath("//input[@value='Login']")).Click();
        }

        public void Logout()
        {
            if (IsLoggetIn())
            {
                driver.FindElement(By.LinkText("Logout")).Click();
            }
        }

        public bool IsLoggetIn()
        {
            return IsElementPresent(By.Name("logout"));
        }

        public bool IsLoggetIn(AccountData account)
        {
            return IsLoggetIn()
                && driver.FindElement(By.Name("logout")).FindElement(By.TagName("b")).Text 
                == "(" + account.Username + ")";
        }
    }
}
