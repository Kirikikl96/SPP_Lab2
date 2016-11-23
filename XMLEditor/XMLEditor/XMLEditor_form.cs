using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace XMLEditor
{
    public partial class XMLEditor_form : Form
    {
        private bool isDoubleClick = false;
        private bool isOpen = false;
        private TreeNodeMouseClickEventArgs treeNode;
        private object tree;
        private Regex numberText = new Regex(@"(0|[1-9]\d*)");
        public XMLEditor_form()
        {
            InitializeComponent();
            EditBlock();
            CloseXML.Enabled = false;
        }


        private void OpenFile_Click(object sender, EventArgs e)
        {
            Openfile();
        }

        private void Openfile()
        {
            DialogResult resultOpen = openFileDialog.ShowDialog();
            if (resultOpen != DialogResult.OK)
                return;
            string filePath = openFileDialog.FileNames[0];

            TabPage tabPage = GetTab(filePath);
            if (tabPage != null)
            {
                tabControl.SelectedTab = tabPage;
                return;
            }

            FileInformation file = new FileInformation(filePath);
            file.Document = LoadFile(filePath);
            if (file.Document == null)
                return;
            string fileName = file.fileName;
            tabPage = new TabPage(fileName);
            tabPage.Tag = file;
            TreeView treeView = XMLTree.GetTreeView(file.Document);
            if (treeView.Nodes.Count == 0)
            {
                MessageBox.Show("Не удалось прочитать файл \"{0}\".", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            file.isSave = true;

            treeView.Dock = DockStyle.Fill;
            tabPage.Controls.Add(treeView);
            treeView.NodeMouseDoubleClick += EditNode;

            treeView.MouseDown += MouseDownEvent;
            treeView.BeforeCollapse += CollapseEvent;
            treeView.BeforeExpand += ExpandEvent;

            tabControl.TabPages.Add(tabPage);
            tabControl.SelectTab(tabPage);
            CheckNumberTabs();
        }
        private TabPage GetTab(string filePath)
        {
            FileInformation fileInfo = null;
            foreach (TabPage tabPage in tabControl.TabPages)
            {
                fileInfo = (tabPage.Tag as FileInformation);
                if (fileInfo != null)
                {
                    if (fileInfo.filePath == filePath)
                    {
                        return tabPage;
                    }
                }
            }
            return null;
        }

        private void EditBlock()
        {
            txtbName.Enabled = false;
            txtbPackage.Enabled = false;
            txtbParams.Enabled = false;
            txtbTime.Enabled = false;
            bttnOK.Enabled = false;
            bttnCancel.Enabled = false;
        }

        private void EditRelease()
        {
            txtbName.Enabled = true;
            txtbPackage.Enabled = true;
            txtbParams.Enabled = true;
            txtbTime.Enabled = true;
            bttnOK.Enabled = true;
            bttnCancel.Enabled = true;
        }

        private void CheckNumberTabs()
        {
            if (tabControl.SelectedIndex == -1)
            {
                SaveAs.Enabled = false;
                SaveFile.Enabled = false;
                CloseXML.Enabled = false;
            }
            else 
            {
                SaveAs.Enabled = true;
                SaveFile.Enabled = true;
                CloseXML.Enabled = true;
            }
        
        }

        private void CollapseEvent(object sender, TreeViewCancelEventArgs e)
        {
            if (isDoubleClick == true && e.Action == TreeViewAction.Collapse)
                e.Cancel = true;
        }

        private void ExpandEvent(object sender, TreeViewCancelEventArgs e)
        {
            if (isDoubleClick == true && e.Action == TreeViewAction.Expand)
                e.Cancel = true;
        }

        private void MouseDownEvent(object sender, MouseEventArgs e)
        {
            if (e.Clicks > 1)
                isDoubleClick = true;
            else
                isDoubleClick = false;
        }

        private void EditNode(object sender, TreeNodeMouseClickEventArgs e)
        {
            treeNode = e;
            tree = sender;
            XmlElement element = (treeNode.Node.Tag as XmlElement);
            if (element == null)
            {
                return;
            }

            if (element.Name == "thread")
            {
                return;
            }
            LoadData(element);
            isOpen = true; 
          
        }
        private void LoadData(XmlElement element)
        {
            txtbName.Text = element.Attributes["name"].Value;
            txtbParams.Text = element.Attributes["params"].Value;
            txtbPackage.Text = element.Attributes["package"].Value;
            txtbTime.Text = element.Attributes["time"].Value;
            EditRelease();
        }
        private XmlDocument LoadFile(string fileName)
        {
            XmlDocument resultLoad = null;
            XmlDocument document = new XmlDocument();
            try
            {
                document.Load(fileName);
                resultLoad = document;
            }
            catch (XmlException)
            {
                resultLoad = null;
                MessageBox.Show("Не удалось загрузить файл \"{0}\".", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return resultLoad;
        }


        private void bttnCancel_Click(object sender, EventArgs e)
        {
            isOpen = false;
            ClearTxtB();
            EditBlock();
        }

        private void bttnOK_Click(object sender, EventArgs e)
        {
            bool changed = EditAttribute(treeNode.Node);
            if (changed == false)
            {
                isOpen = false;
                ClearTxtB();
                return;
            }

            TreeView treeView = (tree as TreeView);

            treeView.BeginUpdate();
            XMLTree.UpdateTime(treeNode.Node);
            treeView.EndUpdate();

            TabPage tabPage = tabControl.SelectedTab;
            FileInformation fileInfo = (tabPage.Tag as FileInformation);
            if (fileInfo != null)
            {
                fileInfo.isSave = false;
                tabPage.Text = fileInfo.fileName + "*";
            }
            isOpen = false;
            ClearTxtB();
        }

        private void ClearTxtB()
        {
            txtbName.Clear();
            txtbParams.Clear();
            txtbPackage.Clear();
            txtbTime.Clear();
        
        }

        private bool EditAttribute(TreeNode node)
        {
            XmlElement element = (node.Tag as XmlElement);
            bool isChange = false;
            if (CheckNewData())
            {
                MessageBox.Show("Введенные данные некорректны", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                EditBlock();
            }
            else
            {
                if (CheckChange(element))
                    isChange = false;
                else
                {
                    isChange = true;
                    UpdateAttribute(element);
                }
            }
            return isChange;
        }

        private bool CheckNewData()
        {
            bool result = false;

            result |= !(numberText.Match(txtbParams.Text.Trim()).Value== txtbParams.Text.Trim());
            result |= !(numberText.Match(txtbTime.Text.Trim()).Value == txtbTime.Text.Trim());
            
            return result;
        }

        private bool CheckChange(XmlElement element)
        {
            bool result = true;
            result &= (txtbName.Text.Trim() == element.Attributes["name"].Value);
            result &= (txtbParams.Text.Trim() == element.Attributes["params"].Value);
            result &= (txtbPackage.Text.Trim() == element.Attributes["package"].Value);
            result &= (txtbTime.Text.Trim() == element.Attributes["time"].Value);
            return result;
        }

        private void UpdateAttribute(XmlElement element)
        {
            element.SetAttribute("name", txtbName.Text.Trim());
            element.SetAttribute("params", txtbParams.Text.Trim());
            element.SetAttribute("package", txtbPackage.Text.Trim());
            element.SetAttribute("new-time", txtbTime.Text);
            EditBlock();
        }

        private void SaveFile_Click(object sender, EventArgs e)
        {
            TabPage tabPage = tabControl.SelectedTab;
            if (tabPage == null)
            {
                return;
            }

            FileInformation infoFile = (tabPage.Tag as FileInformation);
            infoFile.isSave = Save(infoFile);
            if (infoFile.isSave)
            {
                tabPage.Text = infoFile.fileName;
            }
        }

        private bool Save(FileInformation file)
        {
            bool isSave = false;
            try
            {
                file.Document.Save(file.filePath);
                isSave = true;
            }
            catch (XmlException)
            {
                isSave = false;
                MessageBox.Show(String.Format("Файл \"{0}\" не сохранен",file.filePath), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return isSave;
        }
        private void SaveAs_Click(object sender, EventArgs e)
        {
            TabPage tabPage = tabControl.SelectedTab;
            if (tabPage == null)
            {
                return;
            }

            FileInformation infoFile = (tabPage.Tag as FileInformation);
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            DialogResult dialogResult = saveFileDialog.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileNames[0];
                infoFile.filePath = filePath;
                infoFile.isSave = Save(infoFile);
            }
            if (infoFile.isSave)
            {
                tabPage.Text = infoFile.fileName;
            }
            
        }

        private bool CloseTab(int selectedIndex)
        {
            TabPage tabPage = tabControl.TabPages[tabControl.SelectedIndex];
            bool isSave = SaveCloseTab(tabPage);
            if (isSave)
            {
                if (tabControl.SelectedIndex > 0)
                {
                    tabControl.SelectedIndex = (tabControl.SelectedIndex - 1);
                }
                tabControl.TabPages.Remove(tabPage);
            }
            return isSave;
        }

        private bool SaveCloseTab(TabPage tabPage)
        {
            bool isCanClose = true;
            if (tabPage != null)
            {
                FileInformation fileInfo = (tabPage.Tag as FileInformation);
                if (fileInfo != null)
                {
                    isCanClose = AskSave(fileInfo);
                }
            }
            return isCanClose;
        }

        private bool AskSave(FileInformation fileInfo)
        {
            bool isCanClose = fileInfo.isSave;
            if (!isCanClose)
            {
                DialogResult dialogResult = MessageBox.Show(String.Format("Хотели бы вы сохранить перед закрытием файл \"{0}\" ?", fileInfo.filePath), "Сохранение", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation);
                switch (dialogResult)
                {
                    case DialogResult.Cancel:
                        isCanClose = false;
                        break;

                    case DialogResult.No:
                        isCanClose = true;
                        break;

                    case DialogResult.Yes:
                        isCanClose = Save(fileInfo);
                        break;
                }
            }
            return isCanClose;
        }

        private void CloseProgram_Click(object sender, EventArgs e)
        {
            foreach (TabPage tabPage in tabControl.TabPages)
            {
                tabControl.SelectedTab = tabPage;
                CloseTab(tabControl.SelectedIndex);
            }
            Close();
        }


        private void XMLEditor_form_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach (TabPage tabPage in tabControl.TabPages)
            {
                tabControl.SelectedTab = tabPage;
                CloseTab(tabControl.SelectedIndex);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CloseTab(tabControl.SelectedIndex);
            CheckNumberTabs();
        }
    }
}
