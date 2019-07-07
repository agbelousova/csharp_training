using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using NUnit.Framework;
namespace mantis_tests
{
    [TestFixture]
    public class MantisProjectTests : TestBase
    {

        [SetUp] 
        public void LoginAsAdmin()
        {
            AccountData admin = new AccountData
            {
                Name = "administrator",
                Password = "root"
            };
            app.Registration.OpenMainPage(); 
            app.Registration.FillAuthForm(admin); 
            app.Registration.SubmitOneButtonForm();
        }
        [Test]
        public void MantisProjectAdding()
        {
            
            AccountData admin = new AccountData
            {
                Name = "administrator",
                Password = "root"
            };

            List<ProjectData> oldprojects = new List<ProjectData>(); 
            oldprojects = app.API.APIGetProjectList(admin);

            ProjectData project = new ProjectData
            {
                Name = "112",
                Description = "112"
            };

            app.Project.AddMantisProject(project);

            oldprojects.Add(project);

            List<ProjectData> newprojects = app.API.APIGetProjectList(admin);
            oldprojects.Sort();
            newprojects.Sort();

            Assert.AreEqual(oldprojects, newprojects);

        }

        [Test]
        public void MantisProjectRemoving()
        {
            int N = 2;
            AccountData admin = new AccountData
            {
                Name = "administrator",
                Password = "root"
            };

            List<ProjectData> oldprojects = new List<ProjectData>();
            oldprojects = app.Project.GetProjectList();

            if (oldprojects.Count == 0)
            {
                ProjectData project = new ProjectData
                {
                    Name = "555",
                    Description = "555"
                };

                app.API.APIAddMantisProject(admin, project);
                oldprojects = app.API.APIGetProjectList(admin);
                N = 0;
            }
            else if (oldprojects.Count < N)
            {
                N = oldprojects.Count - 1;
            }

            ProjectData removedProject = oldprojects[N];

            app.Project.RemoveMantisProject(N);

            oldprojects.Remove(removedProject);
            List<ProjectData> newprojects = app.API.APIGetProjectList(admin);

            oldprojects.Sort();
            newprojects.Sort();
            Assert.AreEqual(oldprojects, newprojects);
        }

        [TearDown] 
        public void Loguot()
        {
            app.Registration.InitLogOut();
        }
    }
}