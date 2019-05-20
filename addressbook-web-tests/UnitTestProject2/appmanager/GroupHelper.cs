using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
    public class GroupHelper : HalperBase
    {

        public GroupHelper(ApplicationManager manager) : base(manager)
        {
        }

        public GroupHelper Remove(int v)
        {
            manager.Navigator.GoToGroupsPage();

            SelectGroup(v);
            RemoveGroup();
            ReturnToGroupsPage();
            return this;
        }

        public List<GroupData> GetGroupList()
        {
            List<GroupData> groups = new List<GroupData>();
            manager.Navigator.GoToGroupsPage();
            ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("span.group"));

            foreach (IWebElement element in elements)
            {
                groups.Add(new GroupData(element.Text));
            }

            return groups;

        }

        public GroupHelper GroupExists()
        {
            manager.Navigator.GoToGroupsPage();

            if (!IsElementPresent(By.Name("selected[]")))
            {
                GroupData group = new GroupData("aaa");
                group.Header = "111";
                group.Footer = "000";

                Create(group);
                
            }
            return this;
        }

        public GroupHelper Modify(int v, GroupData nawData)
        {
            manager.Navigator.GoToGroupsPage();

            SelectGroup(v);
            InitGroupModification();
            FillGroupForm(nawData);
            SubmitGroupModification();
            ReturnToGroupsPage();

            return this;
        }



        public GroupHelper Create (GroupData group)
        {
            manager.Navigator.GoToGroupsPage();

            InitGroupCreation();
            FillGroupForm(group);
            SubmitGroupCreation();
            ReturnToGroupsPage();
            return this;
        }


        public GroupHelper InitGroupCreation()
        {

            driver.FindElement(By.Name("new")).Click();
            return this;
        }
        public GroupHelper FillGroupForm(GroupData group)
        {

            Type(By.Name("group_name"), group.Name);
            Type(By.Name("group_header"), group.Header);
            Type(By.Name("group_footer"), group.Footer);
            return this;
        }

       

        public GroupHelper SubmitGroupCreation()
        {

            driver.FindElement(By.Name("submit")).Click();
            driver.FindElement(By.Id("header")).Click();
            return this;
        }
        public GroupHelper ReturnToGroupsPage()
        {

            driver.FindElement(By.LinkText("groups")).Click();
            return this;
        }
        public GroupHelper RemoveGroup()
        {
            driver.FindElement(By.Name("delete")).Click();
            return this;

        }
        public GroupHelper SelectGroup(int v)
        {

            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + (v+1) + "]")).Click();
            return this;
        }


        public GroupHelper SubmitGroupModification()
        {
            driver.FindElement(By.Name("update")).Click();
            return this;
        }

        public GroupHelper InitGroupModification()
        {
            driver.FindElement(By.Name("edit")).Click();
            return this;
        }



    }
}
