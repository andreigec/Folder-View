using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using ANDREICSLIB;

namespace FolderView
{
	public partial class Form1 : Form
	{
		private static string fileext = "xml";
		public static string notSet = "-";
		private static string outputdir = "folderStructures";
		private readonly List<TreeNode> selectedNodes = new List<TreeNode>();

		public ImageList imageList1;

		private TreeListView mainTV = new TreeListView();
		private String mainTVFilePath = "";
		public int totalCount;

        #region licensing

        private const string AppTitle = "Folder View";
        private const double AppVersion = 4.6;

        #region hs
        public String HelpString =
            @"--Folder View Help--
1.	Overview}
Folderview is an application that saves directory information for later reading. Note: it only saves a files metadata, not the file itself.
After saving the directory information, you can view this offline later (away from the machine it was saved from)
2.		How to use
2.1		Saving a directory tree
Basic Use:
-Go to tab 'Save'.
-Browse to the folder you want to save using the 'Browse' button or select the folders you want to save in the treeview
-Press the 'Save Folder Structure to File' button.
Advanced Use:
-The save file size button does just that, note it may take more time to create extensive directory structures.
-Max folder depth limits the maximum depth of directory saving.

2.2		Viewing a directory tree
Basic Use:
-Go to tab 'View'
-To select a saved file, press the 'Browse' Button. All the directories you have previously saved will be in here in the format (Path,Creation Time) separated by hyphens.
-Press 'View Folder Structure in File' button.
Advanced Use:
-Show file icons will get the proper explorer icon for each file in the tree. This is merely eye candy, and can slow down viewing significantly in certain situations with many files.
-Expand and Collapse tree mirrors the function in explorer. Note that expanding a tree with many items can be very slow.
-Auto resize columns will optimize the width of the columns for viewing.

2.2.1	Searching
Basic Use:
-View a file following the relevant steps
-In the field left of the button 'Search' enter text relating to the file you want to search for.
-Press the 'Search' button.
Advanced Use:
-Searching utilises Regular Expression.
-Found files will appear in the directory tree based on their path, which can be different to normally viewing the file.

2.2.2	Right Click Menu
-'Select in explorer' will open the file in explorer.
-'Remove item from list' will remove the item from the list. Note: it will not delete the actual file unless the option -remove file from source is chosen
-'Recalculate file sizes>all subitems', will recalculate the sizes of the selected items and their subitems. Note: This requires a connection with the computer where the files were originally saved from.
-'Recalculate file sizes>selecte only', will recalculate the size of just the selected items. Note: This requires a connection with the computer where the files were originally saved from.
-'Add File to List' will insert a selected item into the list view.
-'Add Folder to List' will insert a selected folder into the list view. Note: this is the same as merging two folders together as in section 2.3
-'Copy Selected Files to Clipboard' will copy the selected files to the clipboard for copying in windows.
-'Get duplicate files' can be used to find duplicate files over the folders added.

2.3		Merging Files
Purpose:
You can either merge files through this menu, or manually add the directory through the right click menu in the view tab via section 2.2.2
Note:
Merging files requires at least 2 saved directories as created in the previous relevant section.
Basic Use:
-Enter the 'Merge' tab
-Select the previously created lists you want to merge on the left by clicking on the grey check box for each item.
-Press the merge button. This will create a file with the name of the text in the top right text box 'Enter output filename'
Advanced Use:
-Select all/none will do that for the check box items
-Get current time will automatically generate a file name using the current time. Note: this is done automatically when the 'Merge' tab is entered.
-Remove base directories eg c:/a/b/c will become a/b/c/ when viewed in the 'View' tab. Note: this is useful when merging two separate drive structures.

2.4		Other Options
'Menu Bar>Options>autosave tree on item change'. When items are removed from the view, having this checked will mean the directory file is saved immediately so these changes will still be in the list when re-viewing the file.
'Menu Bar>Options>dont save form options'. When the form is closed, all the check options in the menu bar are saved. Having this item checked means the form will always have the default checked values on load. Note: ironically this still requires a saved value in the config file.
'Menu Bar>Tools>Replace all spaces with dots'. When this item is checked, all spaces in file names will be changed to dots. Note: this is just for the viewed name, the path to the actual file will not have spaces changed. Also note that these changes will not be saved unless the autosave item is checked as above.
'Menu Bar>Tools>revert to proper name' will reset all items to their proper name.
'Help>Check for updates' will contact the home server to get the newest version of the application
";
#endregion hs

        private const String UpdatePath = "https://github.com/EvilSeven/Folder-View/zipball/master";
        private const String VersionPath = "https://raw.github.com/EvilSeven/Folder-View/master/INFO/version.txt";
        private const String ChangelogPath = "https://raw.github.com/EvilSeven/Folder-View/master/INFO/changelog.txt";

        private readonly String OtherText =
            @"©" + DateTime.Now.Year +
            @" Andrei Gec (http://www.andreigec.net)

Licensed under GNU LGPL (http://www.gnu.org/)

Zip Assets © SharpZipLib (http://www.sharpdevelop.net/OpenSource/SharpZipLib/)
";
        #endregion

		public Form1()
		{
			InitializeComponent();
		}

		private void selectfolder_Click(object sender, EventArgs e)
		{
			var FBD = new FolderBrowserDialog();

			FBD.Description = "Select a folder to save to a file";

			DialogResult DR = FBD.ShowDialog();
			if (DR == DialogResult.Cancel)
				return;

			foldertext.Text = FBD.SelectedPath;
		}
		
		private void savebutton_Click(object sender, EventArgs e)
		{
			var savepaths = new List<string>();
			foreach (TreeNode TN in selectedNodes)
			{
				savepaths.Add(TN.Text);
			}
			if (String.IsNullOrEmpty(foldertext.Text) == false)
			{
				savepaths.Add(foldertext.Text);
			}

            foreach (String fp in savepaths)
            {
                if (String.IsNullOrEmpty(fp))
                {
                    MessageBox.Show("Please enter a path of a folder to save to a file");
                    return;
                }

                if (Directory.Exists(fp) == false)
                {
                    MessageBox.Show("Folder:" + fp + " does not exist, please enter a folder that exists for serialisation");
                    return;
                }
            }

		    int md = 1;
		    try
		    {
		        md = int.Parse(maxdepth.Text);
		    }
		    catch (Exception ex)
		    {
		       MessageBox.Show("defaulting to max depth of 1"); 
		    }

			Controller.SavepathsF(filelist,savepaths,md,ref outputdir,fileext,savefilesize.Checked);
			Controller.ClearSelections(selectedNodes);
		}

		private void viewfolder_Click(object sender, EventArgs e)
		{
			String s = Controller.GetFilePath(outputdir);
			if (String.IsNullOrEmpty(s) == false)
				viewpath.Text = s;
		}

		private void viewfilebutton_Click(object sender, EventArgs e)
		{
			if (String.IsNullOrEmpty(viewpath.Text))
			{
				MessageBox.Show("Please enter a path of the file to view");
				return;
			}

			if (File.Exists(viewpath.Text) == false)
			{
				MessageBox.Show("File does not exist, please enter a file that exists for viewing");
				return;
			}
			mainTVFilePath = viewpath.Text;
			viewButton();
		}

        private void viewButton()
        {
            outputtree.Hide();
            //setting this here will force a recount
            Status2.Text = notSet;
            allowAbort();
            Controller.DisplayTreeListViewFile(IncrementStatusF, mainTV, mainTVFilePath);

            treelistviewfuncs.CopyNodes(mainTV, outputtree, true, 0);
            CSSTLVI(outputtree);

            totalCount = int.Parse(Status2.Text);
            Status1.Text = notSet;
        }
        
        private void CSSTLVI(TreeListView TLV, bool expand = false)
        {
            mainTV.doSort = true;
            toolStripProgressBar1.Value = 0;
            outputtree.doSort = true;

            TLV.Sort();
            if (expand)
                Controller.ExpandTLVI(TLV);
            else
                Controller.CollapseTLVI(TLV);

            Controller.SetImages(TLV,showicon.Checked,ref imageList1);
            TLV.Show();
            menuStrip1.Enabled = true;
            TC.Enabled = true;
        }

		private void Form1_Load(object sender, EventArgs e)
		{
			treelistviewfuncs.baseform = this;


			serialisation.baseform = this;
			maxdepth.SelectedIndex = 4;
            outputfilename.Text = Controller.TimeFileName("merge", fileext);
			serialisation.loadConfig();

			outputtree.Items.Clear();
			baselevelsremove.SelectedIndex = 0;

			var ToolTip1 = new ToolTip();
			ToolTip1.SetToolTip(baselevelsremove,
								"C:/folder1/folder2/file.txt will become folder1/folder2/file.txt with one level of removal");

			ToolTip1 = new ToolTip();
			ToolTip1.SetToolTip(showicon, "Warning, can be very slow for many files");

            Licensing.CreateLicense(this, HelpString, AppTitle, AppVersion, OtherText, VersionPath, UpdatePath, ChangelogPath, menuStrip1);

			try
			{
				Directory.SetCurrentDirectory(Path.GetDirectoryName(Application.ExecutablePath));
				if (Directory.Exists(outputdir) == false)
				{
					try
					{
						Directory.CreateDirectory(outputdir);
					}
					catch (Exception ex)
					{
						MessageBox.Show("Could not create directory:" + outputdir + "\nError:" + ex);
						return;
					}
				}
			}
			catch
			{
			}
			Controller.Refreshtree(multiselecttree);
		}
		
		private void expandbutton_Click(object sender, EventArgs e)
		{
			Controller.ExpandTLVI(outputtree);
		}

		private void collapsebutton_Click(object sender, EventArgs e)
		{
            Controller.CollapseTLVI(outputtree);
		}

		private void exitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}

        private int getMatches()
        {
            Status1.Text = notSet;
            Status2.Text = notSet;

            var dup = new List<TreeListViewItem>();
            foreach (TreeListViewItem TLVI in mainTV.Items)
            {
                dup.AddRange(Controller.GetMatches(TLVI,livesearch.Text));
            }

            foreach (TreeListViewItem T in dup)
            {
                Controller.AddNode(T, ref outputtree);
            }
            return dup.Count;
        }

        private void applyLiveSearch()
        {
            if (mainTV.Items.Count == 0)
                return;

            if (livesearch.Text.Length == 0)
            {
                Status1.Text = notSet;
                treelistviewfuncs.CopyNodes(mainTV, outputtree, true, 0);
                CSSTLVI(outputtree);
                return;
            }

            outputtree.Items.Clear();

            Status2.Text = notSet;
            allowAbort();
            int count = getMatches();
            Status2.Text = totalCount.ToString();

            treelistviewfuncs.recalculateSizes(outputtree);

            if (count <= 100)
                CSSTLVI(outputtree, true);
            else
                CSSTLVI(outputtree, false);
        }

		private void mergebutton_Click(object sender, EventArgs e)
		{
			allowAbort();
			if (filelist.Items.Count == 0)
				return;

			if (string.IsNullOrEmpty(outputfilename.Text))
			{
				MessageBox.Show("the output filename cannot be blank");
				return;
			}

			if (File.Exists(outputfilename.Text))
			{
				MessageBox.Show(
					"there is already a file called the output filename, please choose a non existing name for the new merged file");
				return;
			}
			Directory.SetCurrentDirectory(Path.GetDirectoryName(Application.ExecutablePath));
			Directory.SetCurrentDirectory(outputdir);

			var newmerge = new TreeListView();

			foreach (String s in filelist.CheckedItems)
			{
				var newTV = new TreeListView();
				Controller.DisplayTreeListViewFile(IncrementStatusF, newTV, s);

				treelistviewfuncs.CopyNodes(newTV, newmerge, false, int.Parse(baselevelsremove.Text));
			}

			try
			{
				String s = Controller.Clean(outputfilename.Text);
				serialisation.SerializeTreeListView(newmerge, s);
			}
			catch (Exception ex)
			{
				MessageBox.Show("There was an error saving the tree to the file:" + ex);
				return;
			}

            Controller.UpdateFileList(filelist,outputdir,fileext);
			CSSTLVI(outputtree);
		}

		private void randomname_Click(object sender, EventArgs e)
		{
			outputfilename.Text = Controller.TimeFileName("merge",fileext);
		}

		private void searchbutton_Click(object sender, EventArgs e)
		{
			applyLiveSearch();
		}

		private void livesearch_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == 13)
				applyLiveSearch();
		}

		private void openBaseFolderInExplorerToolStripMenuItem_Click(object sender, EventArgs e)
		{
			TreeListViewItem TLVI = outputtree.SelectedItems[0];
			{
				if (outputtree.SelectedItems.Count == 1)
				{
					if ((TLVI.isfolder == false && File.Exists(TLVI.fullPath) == false) ||
						(TLVI.isfolder && Directory.Exists(TLVI.fullPath) == false))
					{
						MessageBox.Show("The file cannot be accessed");
						return;
					}
				}
				string argument = @"/select, " + TLVI.fullPath;
				Process.Start("explorer.exe", argument);
			}
		}

		private void viewContextStrip_Opening(object sender, CancelEventArgs e)
		{
			if (outputtree.SelectedItems.Count != 1)
			{
				openBaseFolderInExplorerToolStripMenuItem.Enabled = false;
			}
			else
			{
				openBaseFolderInExplorerToolStripMenuItem.Enabled = true;
			}

			if (outputtree.SelectedItems.Count == 0)
			{
				copySelectedFilesToClipboardToolStripMenuItem.Enabled = false;
				removeItemFromListToolStripMenuItem.Enabled = false;
				recalculateSelectedOnlyToolStripMenuItem.Enabled = false;
				getRatingsToolStripMenuItem.Enabled = false;
			}
			else
			{
				copySelectedFilesToClipboardToolStripMenuItem.Enabled = true;
				removeItemFromListToolStripMenuItem.Enabled = true;
				recalculateSelectedOnlyToolStripMenuItem.Enabled = true;
				getRatingsToolStripMenuItem.Enabled = true;
			}

			if (outputtree.SelectedItems.Count > 1)
			{
				addFileToTreeToolStripMenuItem.Enabled = false;
				addFolderToTreeToolStripMenuItem.Enabled = false;
			}
			else
			{
				addFileToTreeToolStripMenuItem.Enabled = true;
				addFolderToTreeToolStripMenuItem.Enabled = true;
			}
		}

		private void outputtree_AfterExpand(object sender, TreeListViewEventArgs e)
		{
            Controller.SetImages(outputtree,showicon.Checked,ref imageList1);
		}

		private void outputtree_AfterCollapse(object sender, TreeListViewEventArgs e)
		{
            Controller.SetImages(outputtree, showicon.Checked, ref imageList1);
		}

		private void baselevelsremove_KeyPress(object sender, KeyPressEventArgs e)
		{
			if ((e.KeyChar < '0' || e.KeyChar > '9') && e.KeyChar != 8)
				e.Handled = true;
		}
		
		private void RemoveClick(bool deleteToo)
		{
			outputtree.Hide();
			allowAbort();

			//get the next selected index
			foreach (int a in outputtree.SelectedIndices)
			{
				int b = a - 1;
				if (b < 0)
					b = a + 1;

				//in case this item is being deleted as well
				if (outputtree.SelectedIndices.Contains(b))
					continue;

				TreeListViewItem selectnext = treelistviewfuncs.getItemByIndex(outputtree, b);
				if (selectnext == null)
					continue;

				break;
			}

			foreach (TreeListViewItem T in outputtree.SelectedItems)
			{
				if (deleteToo)
				{
					try
					{
						if (T.isfolder && Directory.Exists(T.fullPath))
						{
							Directory.Delete(T.fullPath, true);
						}
						else if (T.isfolder == false)
						{
							if (File.Exists(T.fullPath))
								File.Delete(T.fullPath);
							else if (Controller.Errorcontinue(T.fullPath + " doesnt exist") == false)
							{
								CSSTLVI(outputtree);
								return;
							}
							else
								continue;
						}
					}
					catch (Exception e)
					{
                        if (Controller.Errorcontinue(e.ToString()) == false)
						{
							CSSTLVI(outputtree);
							return;
						}
						else
							continue;
					}
				}

				mainTV.Items.Remove(treelistviewfuncs.getItemByName(mainTV, T.Name));
				IncrementStatusF(false, 5);
				Controller.Rem(ref mainTV, T.fullPath);
				treelistviewfuncs.clearSizes(T, true);
			}

			treelistviewfuncs.CopyNodes(mainTV, outputtree, true, 0);

			treelistviewfuncs.recalculateSizes(mainTV);

			treelistviewfuncs.CopyNodes(mainTV, outputtree, true, 0);

			if (autosave.Checked)
			{
				serialisation.SerializeTreeListView(mainTV, mainTVFilePath);
			}

			CSSTLVI(outputtree);
		}

		private void removeItemFromListToolStripMenuItem_Click(object sender, EventArgs e)
		{
			RemoveClick(false);
		}

		private void deleteSourceFileAsWellToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (warnondelete.Checked)
			{
				String outstr = "";
				int count = 0;
				foreach (TreeListViewItem T in outputtree.SelectedItems)
				{
					if (count > 10)
					{
						outstr = outstr + "...";
						break;
					}
					outstr = outstr + T.fullPath + "\n";
					count++;
				}

				DialogResult DR =
					MessageBox.Show(
						"Warning, you are about to delete the following REAL FILE(S)/FOLDER(S). Are you sure you want to do this?\n" +
						outstr, "warning", MessageBoxButtons.YesNo);
				if (DR != DialogResult.Yes)
					return;
			}
			RemoveClick(true);
		}

		private void autosave_Click(object sender, EventArgs e)
		{
			autosave.Checked = !autosave.Checked;
		}

		private void baselevelsremove_TextChanged(object sender, EventArgs e)
		{
			try
			{
				int a = int.Parse(baselevelsremove.Text);
				if (a < 0)
					baselevelsremove.Text = "0";
			}
			catch
			{
				baselevelsremove.Text = "0";
			}
		}

		private void tabPage1_Enter(object sender, EventArgs e)
		{
			Controller.UpdateFileList(filelist,outputdir,fileext);
			outputfilename.Text = Controller.TimeFileName("merge",fileext);
		}

		private void addFileToTreeToolStripMenuItem_Click(object sender, EventArgs e)
		{
			var OFD = new OpenFileDialog();
			OFD.Multiselect = true;
			OFD.InitialDirectory = Application.ExecutablePath;
			OFD.Title = "Select a file to add to the selected location";

			DialogResult DR = OFD.ShowDialog();

			if (DR != DialogResult.OK)
				return;

			//get information
			outputtree.Hide();
			foreach (String fn in OFD.FileNames)
			{
				TreeListViewItem TLVI = treelistviewfuncs.getFileInfo(fn, true);

				//specific location				
				if (outputtree.SelectedItems.Count == 1)
				{
					treelistviewfuncs.getItemByName(mainTV, outputtree.SelectedItems[0].Name).Items.Add(TLVI);
				}
				else
				{
					mainTV.Items.Add(TLVI);
				}
			}

			treelistviewfuncs.CopyNodes(mainTV, outputtree, true, 0);
			CSSTLVI(outputtree);

			if (autosave.Checked)
			{
				serialisation.SerializeTreeListView(mainTV, mainTVFilePath);
			}
		}

		private void addFolderToTreeToolStripMenuItem_Click(object sender, EventArgs e)
		{
			var FBD = new FolderBrowserDialog();
			//FBD.RootFolder = Environment.SpecialFolder.

			DialogResult DR = FBD.ShowDialog();

			if (DR != DialogResult.OK)
				return;

			//get information
			TreeListView TLV = treelistviewfuncs.getDirectoryTree(FBD.SelectedPath, null, 0, 5, true);
			//specific location

			outputtree.Hide();

			if (outputtree.SelectedItems.Count == 1)
				treelistviewfuncs.CopyNodes(TLV, treelistviewfuncs.getItemByName(mainTV, outputtree.SelectedItems[0].Name), false, 0);
			else
				treelistviewfuncs.CopyNodes(TLV, mainTV, false, 0);

			treelistviewfuncs.recalculateSizes(mainTV);

			treelistviewfuncs.CopyNodes(mainTV, outputtree, true, 0);
			CSSTLVI(outputtree);

			if (autosave.Checked)
			{
				serialisation.SerializeTreeListView(mainTV, mainTVFilePath);
			}
		}

		private void recalculateAllSubitemsAsWellToolStripMenuItem_Click(object sender, EventArgs e)
		{
			outputtree.Hide();

			Controller.ClearAndRecalculate(true,outputtree,mainTV);

			//clear and copy back to output
			treelistviewfuncs.CopyNodes(mainTV, outputtree, true, 0);

			if (autosave.Checked)
			{
				serialisation.SerializeTreeListView(mainTV, mainTVFilePath);
			}

			CSSTLVI(outputtree);
		}

		private void recalculateSelectedOnlyToolStripMenuItem_Click(object sender, EventArgs e)
		{
			outputtree.Hide();

            Controller.ClearAndRecalculate(false,outputtree,mainTV);

			//clear and copy back to output
			treelistviewfuncs.CopyNodes(mainTV, outputtree, true, 0);

			if (autosave.Checked)
			{
				serialisation.SerializeTreeListView(mainTV, mainTVFilePath);
			}

			CSSTLVI(outputtree);
		}

		private void selectall_Click(object sender, EventArgs e)
		{
			for (int a = 0; a < filelist.Items.Count; a++)
			{
				filelist.SetItemCheckState(a, CheckState.Checked);
			}
		}

		private void selectnone_Click(object sender, EventArgs e)
		{
			for (int a = 0; a < filelist.Items.Count; a++)
			{
				filelist.SetItemCheckState(a, CheckState.Unchecked);
			}
		}

		private void autoresize_Click(object sender, EventArgs e)
		{
			outputtree.autoResize();
		}

		public void allowAbort()
		{
			Status1.Text = "0";
			if (Status2.Text.Equals(notSet))
				Status2.Text = "0";

			mainTV.doSort = false;
			outputtree.doSort = false;

			menuStrip1.Enabled = false;
			TC.Enabled = false;
		}
		
		private void replace(char char1, char char2)
		{
			outputtree.Hide();

			allowAbort();

			treelistviewfuncs.spaceToDot(IncrementStatusF, ref mainTV, ref outputtree, char1, char2);

			if (autosave.Checked)
			{
				serialisation.SerializeTreeListView(mainTV, mainTVFilePath);
			}

			CSSTLVI(outputtree, livesearch.Text.Length > 0);
		}

		private void replaceAllCharactersWithLowerCaseInRelativePathsToolStripMenuItem_Click_1(object sender, EventArgs e)
		{
			outputtree.Hide();

			allowAbort();

            treelistviewfuncs.lowercase(IncrementStatusF, ref mainTV, ref outputtree);

			if (autosave.Checked)
			{
				serialisation.SerializeTreeListView(mainTV, mainTVFilePath);
			}

			CSSTLVI(outputtree, livesearch.Text.Length > 0);
		}

		private void useCamelCaseWithAllRelativePathCharactersToolStripMenuItem_Click_1(object sender, EventArgs e)
		{
			outputtree.Hide();

			allowAbort();

            treelistviewfuncs.camelcase(IncrementStatusF, ref mainTV, ref outputtree);

			if (autosave.Checked)
			{
				serialisation.SerializeTreeListView(mainTV, mainTVFilePath);
			}

			CSSTLVI(outputtree, livesearch.Text.Length > 0);
		}


		private void replaceAllDotsWithSpacesInRelativePathsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			replace('.', ' ');
		}

		private void replaceAllSpacesWithDotsInTheRelativePathToolStripMenuItem_Click(object sender, EventArgs e)
		{
			replace(' ', '.');
		}

		private void revertRelativePathsToProperNameToolStripMenuItem_Click(object sender, EventArgs e)
		{
			outputtree.Hide();

			allowAbort();

            treelistviewfuncs.resetRelativePath(IncrementStatusF, ref mainTV, ref outputtree);

			if (autosave.Checked)
			{
				serialisation.SerializeTreeListView(mainTV, mainTVFilePath);
			}

			CSSTLVI(outputtree, livesearch.Text.Length > 0);
		}

		private void Form1_FormClosing(object sender, FormClosingEventArgs e)
		{
			try
			{
				serialisation.saveConfig();
			}
			catch
			{
			}
		}

		private void outputtree_DoubleClick(object sender, EventArgs e)
		{
			if (outputtree.SelectedItems.Count != 1)
				return;

			TreeListViewItem TLVI = outputtree.SelectedItems[0];

			if (TLVI.isfolder)
				return;

			if (outputtree.SelectedItems.Count == 1)
			{
				if ((TLVI.isfolder == false && File.Exists(TLVI.fullPath) == false) ||
					(TLVI.isfolder && Directory.Exists(TLVI.fullPath) == false))
				{
					MessageBox.Show("The file cannot be accessed");
					return;
				}

				//check extension
				String ext = TLVI.fullPath.Substring(TLVI.fullPath.LastIndexOf('.') + 1);
				if (ext.Equals("exe") || ext.Equals("com") || ext.Equals("bat") || ext.Equals("js"))
				{
					DialogResult DR = MessageBox.Show("Warning, this file:" + TLVI.fullPath + "\n is an executable, are you sure you want to run this?",
													  "Question", MessageBoxButtons.YesNo);
					if (DR == DialogResult.No)
						return;
				}
			}
			Process.Start(TLVI.fullPath);
		}

		private void copySelectedFilesToClipboardToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Controller.CopySelectedToClipboard(outputtree);
		}

		private void outputtree_KeyUp(object sender, KeyEventArgs e)
		{
			if ((e.KeyValue == 'c' || e.KeyValue == 'C') && e.Modifiers == Keys.Control)
			{
				Controller.CopySelectedToClipboard(outputtree);
			}
		}

		private void findDups(bool fuzzy)
		{
			Status2.Text = notSet;
			allowAbort();
			outputtree.Items.Clear();
			Status1.Text = notSet;
			Status2.Text = notSet;

			var dup = new List<TreeListViewItem>();
			foreach (TreeListViewItem TLVI in mainTV.Items)
			{
                dup.AddRange(Controller.GetDups(IncrementStatusF, TLVI, fuzzy));
			}

			foreach (TreeListViewItem T in dup)
			{
				Controller.AddNode(T, ref outputtree);
			}

			if (dup.Count < 100)
				CSSTLVI(outputtree, true);
			else
				CSSTLVI(outputtree, false);
		}

		private void exactNameMatchesOnlyToolStripMenuItem_Click(object sender, EventArgs e)
		{
			findDups(false);
		}

		private void fuzzyNameMatchesOnlyToolStripMenuItem_Click(object sender, EventArgs e)
		{
			findDups(true);
		}

		private void refreshtreebutton_Click(object sender, EventArgs e)
		{
			selectedNodes.Clear();
			multiselecttree.Nodes.Clear();
			Controller.Refreshtree(multiselecttree);
		}

		private void multiselecttree_BeforeExpand(object sender, TreeViewCancelEventArgs e)
		{
			Controller.Refreshtree(multiselecttree, e.Node);
		}

		private void unselectallbutton_Click(object sender, EventArgs e)
		{
			Controller.ClearSelections(selectedNodes);
		}

		private void multiselecttree_AfterCheck(object sender, TreeViewCancelEventArgs e)
		{
			if (selectedNodes.Contains(e.Node))
			{
				selectedNodes.Remove(e.Node);
			}
			else
			{
				selectedNodes.Add(e.Node);
			}
		}

		private void getRatingsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			outputtree.Hide();

			Controller.GetRatings(outputtree,mainTV);

			//clear and copy back to output
			treelistviewfuncs.CopyNodes(mainTV, outputtree, true, 0);

			if (autosave.Checked)
			{
				serialisation.SerializeTreeListView(mainTV, mainTVFilePath);
			}

			CSSTLVI(outputtree);
		}
		
		private void outputtree_DragDrop(object sender, DragEventArgs e)
		{
			string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
			if (files.Count() > 1)
				return;
			String file = files[0];

			viewpath.Text = file;
		}

		private void outputtree_DragEnter(object sender, DragEventArgs e)
		{
			e.Effect = DragDropEffects.Copy;
		}

		private void outputtree_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
		{
			Status1.Text = outputtree.SelectedItems.Count.ToString();
		}

	    public delegate void IncrementStatusDel(bool setMax = false, int refresh = 100);

        public void IncrementStatusF(bool setMax = false, int refresh = 100)
        {
            int a = 0;
            try
            {
                if (setMax == false)
                    a = int.Parse(Status1.Text);
                else
                    a = int.Parse(Status2.Text);
            }
            catch
            {
                a = 0;
            }

            a++;
            if (a % refresh == 0)
            {
                try
                {
                    if (setMax == false)
                    {
                        toolStripProgressBar1.Value = a;
                    }
                    toolStripProgressBar1.Maximum = totalCount;
                }
                catch
                {
                }

                Application.DoEvents();
            }
            if (setMax == false)
                Status1.Text = a.ToString();
            else
                Status2.Text = a.ToString();
        }
	}
}