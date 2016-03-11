using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Xml;
using System.Text;
using System.IO;
using ANDREICSLIB.Helpers;

namespace FolderView
{
	class serialisation
	{
		public static Form1 baseform = null;

		private static string XmlNodeTag = "node";

		private static string XmlNodeFullPath = "fullpath";
		private static string XmlNodeRelativePath = "relativepath";

		private static string XmlNodeIsFolderAtt = "isfolder";
		private static string XmlNodeRating = "rating";
		//private static string XmlNodeBackColourAtt = "backcolour";
		//private static string XmlNodeForeColourAtt = "forecolour";
		private static string XmlNodeSizeAtt = "Size";

		private static string configPath = "folderview.cfg";
		
		//from file to tree
		public static void DeserializeTreeListView(Form1.IncrementStatusDel incrementStatus, TreeListView TreeListView, string fileName)
		{
			XmlTextReader reader = null;
			try
			{
				// disabling re-drawing of TreeListView till all nodes are added
				TreeListView.BeginUpdate();
				reader = new XmlTextReader(fileName);
				TreeListViewItem parentNode = null;
				while (reader.Read())
				{
					if (reader.NodeType == XmlNodeType.Element)
					{
						if (reader.Name == XmlNodeTag)
						{
							TreeListViewItem newNode = new TreeListViewItem();
							bool isEmptyElement = reader.IsEmptyElement;

							// loading node attributes
							int attributeCount = reader.AttributeCount;
							if (attributeCount > 0)
							{
								for (int i = 0; i < attributeCount; i++)
								{
									reader.MoveToAttribute(i);
									SetAttributeValue(newNode, reader.Name, reader.Value);
								}
							}
							newNode.SubItems.Add(newNode.nodeSize.getSizeString());
							newNode.SubItems.Add(newNode.fullPath);
							newNode.Name = newNode.fullPath;

							incrementStatus(true);

							// add new node to Parent Node or TreeListView
							if (parentNode != null)
								parentNode.Items.Add(newNode);
							else
								TreeListView.Items.Add(newNode);

							// making current node 'ParentNode' if its not empty
							if (!isEmptyElement)
							{
								parentNode = newNode;
							}
						}
					}
					// moving up to in TreeListView if end tag is encountered
					else if (reader.NodeType == XmlNodeType.EndElement)
					{
						if (reader.Name == XmlNodeTag)
						{
							parentNode = parentNode.Parent;
						}
					}
				}
			}
			finally
			{
				// enabling redrawing of TreeListView after all nodes are added
				TreeListView.EndUpdate();
				reader.Close();
			}
		}

		private static void SetAttributeValue(TreeListViewItem node,
					 string propertyName, string value)
		{
			if (propertyName == XmlNodeFullPath)
			{
				node.fullPath = value;
			}
			else if (propertyName == XmlNodeSizeAtt)
			{
				node.nodeSize.kb = long.Parse(value);
			}
			
			else if (propertyName == XmlNodeIsFolderAtt)
			{
				node.isfolder = bool.Parse(value);
			}
			else if (propertyName == XmlNodeRelativePath)
			{
				node.Text = value;
			}
			else if (propertyName == XmlNodeRating)
			{
				node.rating = int.Parse(value);
			}

		}

		//tree to file
		public static void SerializeTreeListView(TreeListView TreeListView, string fileName)
		{
			try
			{
				XmlTextWriter textWriter = new XmlTextWriter(fileName,
											  System.Text.Encoding.ASCII);
				// writing the xml declaration tag
				textWriter.WriteStartDocument();
				//textWriter.WriteRaw("\r\n");
				// writing the main tag that encloses all node tags
				textWriter.WriteStartElement("TreeListView");

				// save the nodes, recursive method
				TreeListView.Sort();
				SaveNodes(TreeListView.Items, textWriter);

				textWriter.WriteEndElement();

				textWriter.Close();
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error writing file:" + ex.ToString());
				return;
			}
		}

		private static void SaveNodes(TreeListViewItemCollection nodesCollection, XmlTextWriter textWriter)
		{
			for (int i = 0; i < nodesCollection.Count; i++)
			{
				TreeListViewItem node = nodesCollection[i];

				//relative path

				textWriter.WriteStartElement(XmlNodeTag);

				textWriter.WriteAttributeString(XmlNodeFullPath, node.fullPath);
				textWriter.WriteAttributeString(XmlNodeIsFolderAtt, node.isfolder.ToString());
				textWriter.WriteAttributeString(XmlNodeRelativePath, node.Text);
				textWriter.WriteAttributeString(XmlNodeRating, node.rating.ToString());

				textWriter.WriteAttributeString(XmlNodeSizeAtt, node.nodeSize.kb.ToString());

				if (node.Items.Count > 0)
				{
					SaveNodes(node.Items, textWriter);
				}

				textWriter.WriteEndElement();
			}
		}

		public static void saveConfig()
		{
			System.Collections.Generic.List<Control> savethese1 = new System.Collections.Generic.List<Control>();			
			System.Collections.Generic.List<ToolStripItem> savethese2 = new System.Collections.Generic.List<ToolStripItem>();

			if (baseform.dontsave.Checked)
			{
				savethese2.Add(baseform.dontsave);
			}
			else
			{
				//controls on the tabs
				savethese1.Add(baseform.showicon);
				savethese1.Add(baseform.savefilesize);
				
				//items in the tool strip
				savethese2.Add(baseform.autosave);
				savethese2.Add(baseform.existcopyonly);
				savethese2.Add(baseform.warnondelete);
			}
			FormConfigRestore.SaveConfig(baseform,configPath,savethese1, savethese2);			
		}

		public static void loadConfig()
		{
            FormConfigRestore.LoadConfig(baseform, configPath);
		}

		

	}
}
