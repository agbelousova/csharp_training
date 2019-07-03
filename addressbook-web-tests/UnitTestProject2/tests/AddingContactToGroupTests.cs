using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;


namespace WebAddressbookTests
{
    public class AddingContactToGroupTests :AuthTestBase
    {
        [Test]

        public void TestAddingContactToGroup ()
        {

            app.Contacts.ContactExists();
            app.Groups.GroupExists();
            ContactData contact;

            GroupData group = GroupData.GetAll()[0];//Предполагаем, что нашего контакта нет в группе с индектом 0
            List<ContactData> oldList = group.GetContacts(); //Запоминаем старый список контактов


            if (GroupData.GetAll().Count == oldList.Count) //То есть если в данную группу добавлены ВСЕ контакты
            {
                contact = new ContactData("55555"); //Создаем новый контакт
                app.Contacts.CreateContact(contact);

            }
         
                contact = ContactData.GetAll().Except(oldList).First();
                app.Contacts.AddContactToGroup(contact, group);

                List<ContactData> newList = group.GetContacts();
                oldList.Add(contact);
                oldList.Sort();
                newList.Sort();

                Assert.AreEqual(oldList, newList);
            
        }
    }
}
