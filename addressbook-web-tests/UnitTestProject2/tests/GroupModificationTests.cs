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

            app.Groups.Modify(1, nawData);

        }
    }
}
