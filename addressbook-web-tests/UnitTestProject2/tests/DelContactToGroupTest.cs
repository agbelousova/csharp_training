﻿using System;
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

            app.Groups.GroupExists();
            app.Contacts.ContactExists();
            ContactData contact;

            GroupData group = GroupData.GetAll()[0];
            List<ContactData> oldList = group.GetContacts();
           

            if (GroupData.GetAll().Count != oldList.Count) //То есть если в данную группу добавлены не все контакты
            {

                contact = ContactData.GetAll().Except(oldList).First();
                app.Contacts.AddContactToGroup(contact, group);

            }

            contact = oldList[0];
            List<GroupData> groupAll = contact.GetGroup();

            app.Contacts.DelContactToGroup(contact, group);

                List<ContactData> newList = group.GetContacts();
                oldList.Add(contact);
                oldList.Sort();
                newList.Sort();

                Assert.AreNotEqual(oldList, newList);
            }
        }
 }