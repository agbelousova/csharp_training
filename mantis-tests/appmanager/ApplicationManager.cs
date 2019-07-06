﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace mantis_tests
{
    public class ApplicationManager : TestBase
    {
        protected IWebDriver driver;
        protected string baseURL;

        private static ThreadLocal<ApplicationManager> app = new ThreadLocal<ApplicationManager>();

        private ApplicationManager()
        {
            driver = new FirefoxDriver();
            baseURL = "http://localhost";
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);

            Registration = new RegistrationHelper(this);

            Ftp = new FtpHelper(this);
            James = new JamesHelper(this);
            Mail = new MailHelper(this);

            Project = new ProjectHelper(this);

        }

        ~ApplicationManager()
        {
            try
            {
                Driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
                
            }
        }
        public static ApplicationManager GetInstance()
        {
            if(!app.IsValueCreated)
            {
                ApplicationManager newInstance = new ApplicationManager();
                newInstance.driver.Url = "http://localhost/mantisbt-1.2.17/login_page.php";
                app.Value = newInstance;
                
            }
            return app.Value;
        } 

        public IWebDriver Driver
        {
            get
            {
                return driver;
            }
        }

        public RegistrationHelper Registration { get; set; }
        public FtpHelper Ftp { get; set; }

        public JamesHelper James { get; set; }

        public MailHelper Mail { get; set; }

        public ProjectHelper Project { get; set; }
        public object API { get; internal set; }
    }
}
