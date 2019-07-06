using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using System.IO;
using System.Net.FtpClient;

namespace mantis_tests 
{
    [TestFixture]
    public class AccountCreationTests : TestBase
    {
            [SetUp]
            public void SetupConfig()
            {
                app.Ftp.BackupFile("/config_inc.php");
                using (Stream localFile = File.Open("C:/Users/Павел/source/repos/agbelousova/csharp_training/mantis-tests/config_inc.php", FileMode.Open))
                {
                    app.Ftp.Upload("/config_inc.php", localFile);

                }

            }

            [Test]
        public void TestAccountRegistration()
        {
            AccountData account = new AccountData()
            {
                Name = "testuser",
                Password = "password",
                Email = "testuser@localhost.localdomain"
            };

            app.James.Delete(account);
            app.James.Add(account);

            app.Registration.Register(account);

        }

        [TearDown]
        public void restoreConfig()
        {
            app.Ftp.RestoreBackupFile("/config_inc.php");
        }
    }
}
