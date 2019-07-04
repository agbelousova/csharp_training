using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace addressbook_tests_autoit
{
    public class GroupHelper : HelperBase
    {
        public static string GROUPWINTITLE = "Group editor";
        public GroupHelper(ApplicationManager manager) : base(manager) { }

        public List<GroupData> GetGroupList()
        {
            List<GroupData> list = new List<GroupData>();
            OpenGroupsDialogue();
            string count = aux.ControlTreeView(GROUPWINTITLE, "", "WindowsForms10.SysTreeView32.app.0.2c908d51",
                "GetItemCount", "#0", "");
            for (int i = 0; i < int.Parse(count); i++)
            {
                string item = aux.ControlTreeView(GROUPWINTITLE, "", "WindowsForms10.SysTreeView32.app.0.2c908d51",
                    "GetText", "#0|#" + i, "");
                list.Add(new GroupData()
                {
                    Name = item
                });
            }

            CloseGroupDialogue();
            return list;
        }

        public GroupData Remove(int i, GroupData group)
        {
            OpenGroupsDialogue();
           // aux.ControlClick(GROUPWINTITLE, "", "WindowsForms10.BUTTON.app.0.2c908d512");
           // aux.ControlClick("Group editor", "", "WindowsForms10.BUTTON.app.0.2c908d53");

            aux.ControlTreeView(GROUPWINTITLE, "", "WindowsForms10.SysTreeView32.app.0.2c908d51", "Select", "#0|#" + i, "");

            group.Name = aux.ControlTreeView(GROUPWINTITLE, "", "WindowsForms10.SysTreeView32.app.0.2c908d51", "GetText", "#0|#" + i, "");
            aux.ControlClick(GROUPWINTITLE, "", "WindowsForms10.BUTTON.app.0.2c908d51");
            aux.WinWait("Delete group");
            aux.ControlClick("Delete group", "", "WindowsForms10.BUTTON.app.0.2c908d51");

            aux.ControlClick("Delete group", "", "WindowsForms10.BUTTON.app.0.2c908d53");
            CloseGroupDialogue();
            return group;
        }

        public void Add(GroupData newGroup)
        {
            OpenGroupsDialogue();
           // aux.ControlClick(GROUPWINTITLE, "", "WindowsForms10.BUTTON.app.0.2c908d512");
            aux.ControlClick("Group editor", "", "WindowsForms10.BUTTON.app.0.2c908d53");
            aux.Send(newGroup.Name);
            aux.Send("{ENTER}");
            CloseGroupDialogue();

        }

        private void CloseGroupDialogue()
        {
            aux.ControlClick(GROUPWINTITLE, "", "WindowsForms10.BUTTON.app.0.2c908d54");
        }

        private void OpenGroupsDialogue()
        {
            aux.ControlClick(WINTITLE, "", "WindowsForms10.BUTTON.app.0.2c908d512");
            aux.WinWait(GROUPWINTITLE);
        }
    }
}