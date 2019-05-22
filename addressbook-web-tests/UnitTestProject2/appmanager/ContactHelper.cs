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
    public class ContactHelper : HalperBase
    {

        public ContactHelper(ApplicationManager manager) : base(manager)
        {
        }

        public List<ContactData> GetContactList()
        {
            List<ContactData> contacts = new List<ContactData>();
            manager.Navigator.GoToHomePage();
            ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("span.entry"));

            foreach (IWebElement element in elements)
            {
                var lastName = element.FindElement(By.XPath(".//tr[@name='entry']/td[2]"));
                var firstName = element.FindElement(By.XPath(".//tr[@name='entry']/td[3]"));
                contacts.Add(new ContactData(firstName.Text, lastName.Text));
            }

            return contacts;

        }

        public ContactHelper ModifyContact(int v, ContactData nawData)
        {

            manager.Navigator.GoToHomePage();
            InitContactModification(v);
            FillContactForm(nawData);
            SubmitContactModification();
            manager.Navigator.GoToHomePage();

            return this;
        }

        public ContactHelper SubmitContactModification()
        {
            driver.FindElement(By.Name("update")).Click();
            return this;
        }

        public ContactHelper InitContactModification(int v)
        {
            driver.FindElement(By.XPath("(//img[@alt='Edit'])[" + v + "]")).Click();
            return this;
        }

        public ContactHelper Remove(int v)
        {

            manager.Navigator.GoToHomePage();
            SelectContact(v);
            RemoveContact();

            manager.Navigator.GoToHomePage();

            return this;
        }

        public ContactHelper ContactExists()
        {
            if (!IsElementPresent(By.Name("selected[]")))
            {
                ContactData contact = new ContactData("Bory", "DDDDDD");
                CreateContact(contact);
            }
            return this;
        }

        public ContactHelper RemoveContact()
        {
            
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            driver.SwitchTo().Alert().Accept();
            return this;
        }




 

        public ContactHelper CreateContact(ContactData contact)
        {
            manager.Navigator.GoToContactPage();

            FillContactForm(contact);
               SubmitContactCreation();
            return this;
        }

        public ContactHelper SelectContact(int index)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + index + "]")).Click();
            return this;
        }
        public ContactHelper SubmitContactCreation()
        {
            driver.FindElement(By.XPath("(//input[@name='submit'])[2]")).Click();
            return this;
        }

        public ContactHelper FillContactForm(ContactData contact)
        {
            Type(By.Name("firstname"), contact.FirstName);
            Type(By.Name("lastname"), contact.LastName);
            return this;
        }
    }
}
