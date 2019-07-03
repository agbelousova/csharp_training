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
            List<GroupData> oldGroups = app.Groups.GetGroupList();
            GroupData toBeRemoved = oldGroups[0];

            app.Groups.Remove(toBeRemoved);

            List<GroupData> newGroups = app.Groups.GetGroupList();

            oldGroups.Sort();
            newGroups.Sort();

            Assert.AreNotEqual(oldGroups, newGroups);
        }
    }
}
