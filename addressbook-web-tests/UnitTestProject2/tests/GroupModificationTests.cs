using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests

{
    [TestFixture]
    public class GroupModificationTests : GroupTestBase
    {
        [Test]
        public void GroupModificationTest()
        {


            app.Groups.GroupExists();

            GroupData nawData = new GroupData("zzz");
            nawData.Header = "444";
            nawData.Footer = "4447";

            List<GroupData> oldGroups = GroupData.GetAll();
            GroupData toBeModifi = oldGroups[0];


            app.Groups.Modify(toBeModifi, nawData);

            Assert.AreEqual(oldGroups.Count, app.Groups.GetGroupCount());

            List<GroupData> newGroups = GroupData.GetAll();
            toBeModifi.Name = nawData.Name;
           oldGroups.Sort();
           newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);

            foreach (GroupData group in newGroups)
            {
                if (group.Id == toBeModifi.Id)
                {
                    Assert.AreEqual(nawData.Name, group.Name);
                }
            }
        }
    }
}
