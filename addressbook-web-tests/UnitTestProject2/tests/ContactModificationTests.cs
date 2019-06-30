using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactModificationTests : ContactTestBase
    {
        [Test]
        public void ContactModificationTest()
        {
            app.Contacts.ContactExists();

            ContactData nawData = new ContactData("Ivanov", "Pet0000r");

            List<ContactData> oldContacts = ContactData.GetAll();

            ContactData toBeModifiCon = oldContacts[0];

            app.Contacts.ModifyContact(toBeModifiCon, nawData);

            //Assert.AreEqual(oldContacts.Count, app.Contacts.GetContactCount());

            List<ContactData> newContacts = ContactData.GetAll();
            toBeModifiCon = nawData;
            oldContacts.Sort();
            newContacts.Sort();

            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}
