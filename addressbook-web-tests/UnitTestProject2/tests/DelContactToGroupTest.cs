using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    public class DelContactToGroupTest : AuthTestBase
    {
        [Test]

        public void DelContactToGroup()
        {
            GroupData group = GroupData.GetAll()[0];
            List<ContactData> oldList = group.GetContacts();
            ContactData contact = oldList[0];

            List<GroupData> groupAll = contact.GetGroup();


            if (groupAll == null)
            {
                app.Groups.GroupExists();
                app.Contacts.ContactExists();
            }
            else
            {
                app.Contacts.DelContactToGroup(contact, group);

                List<ContactData> newList = group.GetContacts();
                oldList.Add(contact);
                oldList.Sort();
                newList.Sort();

                Assert.AreNotEqual(oldList, newList);
            }
        }
    }
}
