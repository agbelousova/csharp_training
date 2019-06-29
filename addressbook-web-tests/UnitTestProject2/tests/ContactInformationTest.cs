using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Generic;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactInformationTest : ContactTestBase
    {
        [Test]
        public void TestContactInformation()
        {
            ContactData formTable = app.Contacts.GetContactInformationFormTable(0);
            ContactData formForm = app.Contacts.GetContactInformationFormEditForm(0);

            Assert.AreEqual(formTable, formForm);
            Assert.AreEqual(formTable.Address, formForm.Address);
            Assert.AreEqual(formTable.AllPhones, formForm.AllPhones);
            Assert.AreEqual(formTable.AllEmail, formForm.AllEmail);

        }
    }
}
