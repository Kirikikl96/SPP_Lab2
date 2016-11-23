using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace XMLEditor
{
    static class XMLTree
    {
        public static TreeView GetTreeView(XmlDocument document)
        {
            TreeView treeView = new TreeView();
            XmlElement element = document.FirstChild as XmlElement;
            if (element != null)
            {
                try
                {
                    foreach (var childNode in element.ChildNodes)
                    {
                        treeView.Nodes.Add(GetTreeNode(childNode as XmlElement));
                    }
                }
                catch (XmlException)
                {
                    treeView.Nodes.Clear();
                }
            }
            return treeView;
        }

        private static TreeNode GetTreeNode(XmlElement element)
        {
            TreeNode treeNode = new TreeNode();
            if (element != null)
            {
                treeNode.Tag = element;
                treeNode.Text = GetNodeText(element);
                foreach (var childNode in element.ChildNodes)
                {
                    treeNode.Nodes.Add(GetTreeNode(childNode as XmlElement));
                }
            }
            else
                treeNode = null;
            return treeNode;
        }
        private static string GetNodeText(XmlElement element)
        {
            string name = element.Name;
            if (name == "method")
            {
                name = element.Attributes["name"].Value;
            }
            return name + " (" + AttributesToSting(element) + ")";
        }

        private static string AttributesToSting(XmlElement node)
        {
            string result = "";
            if (node.Name == "thread")
            {
                result += "id" + "=";
                result += node.Attributes["id"].Value + ", ";

                result += "time" + "=";
                result += node.Attributes["time"].Value;
            }
            else if (node.Name == "method")
            {
                result += "params" + "=";

                string paramsCount = "0";
                if (node.HasAttribute("params"))
                {
                    paramsCount = node.Attributes["params"].Value;
                }
                else
                {
                    node.SetAttribute("params", "0");
                }
                result += paramsCount + ", ";

                result += "package" + "=";
                result += node.Attributes["package"].Value + ", ";

                result += "time" + "=";
                result += node.Attributes["time"].Value;
            }
            return result;
        }

        public static void UpdateTime(TreeNode treeNode)
        {
            XmlElement element = (treeNode.Tag as XmlElement);
            if (element == null)
            {
                return;
            }

            long newTime = Convert.ToInt64(element.Attributes["new-time"].Value);
            long oldTime = Convert.ToInt64(element.Attributes["time"].Value);
            long updateTime = newTime - oldTime;

            element.SetAttribute("time", element.Attributes["new-time"].Value);
            element.RemoveAttribute("new-time");

            treeNode.Text = GetNodeText(element);
            do
            {
                treeNode = treeNode.Parent;
                element = (treeNode.Tag as XmlElement);
                if (element == null)
                {
                    return;
                }
                oldTime = Convert.ToInt64(element.Attributes["time"].Value);
                newTime = oldTime + updateTime;
                element.SetAttribute("time", Convert.ToString(newTime));

                treeNode.Text = GetNodeText(element);
            } while (treeNode.Parent != null);
        }
    }
}
