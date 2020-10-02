using System;
using System.Collections.Generic;
using TestStack.White;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.TreeItems;
using TestStack.White.UIItems.WindowItems;
using System.Windows.Automation;
using TestStack.White.InputDevices;
using TestStack.White.WindowsAPI;

namespace AddressbookTestsWhite
{
    public class GroupHalper : HalperBase
    {
        // Since it is often needed in the code, we move it into a variable.
        public static string GROUPWINTITLE = "Group editor";

        public GroupHalper(ApplicationManager manager) : base(manager) { }

        public List<GroupData> GetGroupList()
        {
            List<GroupData> groupList = new List<GroupData>();

            Window dialog = OpenGroupsDialogue();

            // Get the tree of window elements // Take automation id window tree from VisualUIAVerify
            Tree tree = dialog.Get<Tree>("uxAddressTreeView");

            // The "nodes" property returns all root elements (we have only one)
            TreeNode root = tree.Nodes[0];
                                // list of children of the root element
            foreach (TreeNode node in root.Nodes)
            {
                groupList.Add(new GroupData() { Name = node.Text });
            }

            CloseGroupsDialogue(dialog);

            return groupList;
        }

        public void Add(GroupData newGroup)
        {
            Window dialog = OpenGroupsDialogue();
            dialog.Get<Button>("uxNewAddressButton").Click();

            // To plug UIAutomationClient and UIAutomatipnTypes in References
            // To plug using TestStack.White.UIItems.Finders;

            // The node has neither a name nor an auto hell, but it is a text box, and we will 
            // search for it by type, nd throw at him using
            // using System.Windows.Automation;
                                                                                // Found an editable field
            TextBox textBox =  (TextBox)dialog.Get(SearchCriteria.ByControlType(ControlType.Edit));
            textBox.Enter(newGroup.Name); // Enter group name

            // Info for White https://archive.codeplex.com/ section "discussions"
            Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.RETURN); // press "enter"
            
            CloseGroupsDialogue(dialog);
        }

        private void CloseGroupsDialogue(Window dialog)
        {
            // In the transmitted window, click the button
            dialog.Get<Button>("uxCloseAddressButton").Click();
        }

        // We will return the opened window
        private Window OpenGroupsDialogue()
        {
            // Clic button "Edit groups"
            manager.MainWindow.Get<Button>("groupButton").Click();
            // Return window "Group editor"
            return manager.MainWindow.ModalWindow(GROUPWINTITLE);
        }
    }
}