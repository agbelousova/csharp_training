using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests

{
    [TestFixture]
    public class GroupModificationTests : AuthTestBase
    {
        [Test]
        public void GroupModificationTest()
        {


            app.Groups.GroupExists();

            GroupData nawData = new GroupData("zzz");
            nawData.Header = null;
            nawData.Footer = null;

            List<GroupData> oldGroups = app.Groups.GetGroupList();

            app.Groups.Modify(0, nawData);

            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups[0].Name = nawData.Name;
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);

        }
    }
}
