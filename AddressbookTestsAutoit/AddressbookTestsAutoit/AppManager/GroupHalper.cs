using System;
using System.Collections.Generic;

namespace AddressbookTestsAutoit
{
    public class GroupHalper : HalperBase
    {
        // Since it is often needed in the code, we move it into a variable.
        public static string GROUPWINTITLE = "Group editor";

        public GroupHalper(ApplicationManager manager) : base(manager) { }

        public List<GroupData> GetGroupList()
        {
            List<GroupData> groupList = new List<GroupData>();

            OpenGroupsDialogue();
            //  см. https://autoit-script.ru/docs   Путь             Id                                           что сделать    От какого элемента (от родительского)
            string count = aux.ControlTreeView(GROUPWINTITLE, "", "WindowsForms10.SysTreeView32.app.0.2c908d51", "GetItemCount", "#0", "");

            for (int i = 0; i < Convert.ToInt32(count); i++)
            {
                //  Аутоит всегда возвращает стринг                      id                                          дать текст от родительского элемента перебирая дочерние
                string item = aux.ControlTreeView(GROUPWINTITLE, "", "WindowsForms10.SysTreeView32.app.0.2c908d51", "GetText", "#0|#" + i, "");

                groupList.Add(new GroupData() { Name = item });
            }

            CloseGroupsDialogue();

            return groupList;
        }

        public void Add(GroupData newGroup)
        {
            OpenGroupsDialogue();
            aux.ControlClick(GROUPWINTITLE, "", "WindowsForms10.BUTTON.app.0.2c908d53");
            aux.Send(newGroup.Name); // We write down the name of the group
            aux.Send("{ENTER}"); // Emulate pressing "Enter"
            CloseGroupsDialogue();
        }

        private void CloseGroupsDialogue()
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