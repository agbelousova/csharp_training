using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactModificationTests : TestBase
    {
        [Test]
        public void ContactModificationTest()
        {
            ContactData nawData = new ContactData("Petr", "Ivanov");
            nawData.Company = "ОТР";

            app.Contacts.ModifyContact(1, nawData);

        }
    }
}
