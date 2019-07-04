using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using System.Collections.Generic;

namespace addressbook_tests_autoit
{

    [TestFixture]
    public class GroupDelTests : TestBase
    {
        [Test]
        public void GroupRemovalTest()
        {
            int numGroup = 1;
            List<GroupData> oldGroups = app.Groups.GetGroupList();

            if (oldGroups == null)
                if (oldGroups.Count < 2)
                {
                    GroupData newGroup = new GroupData()
                    {
                        Name = "Gruppa Name"
                    };
                    app.Groups.Add(newGroup);
                }
            GroupData dellGroup = new GroupData();
            app.Groups.Remove(numGroup, dellGroup);
            List<GroupData> newGroups = app.Groups.GetGroupList();

            oldGroups.Remove(dellGroup);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);

        
    }
    }
}
