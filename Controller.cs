using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using ANDREICSLIB;
using ANDREICSLIB.NewControls;

namespace FolderView
{
    public class Controller
    {
        private const string dummyname = "zzzzzzzzdef";

        public static String Clean(String s)
        {
            String outputpath = s;
            outputpath = outputpath.Replace('\\', '-');
            outputpath = outputpath.Replace('/', '-');
            outputpath = outputpath.Replace(':', '-');
            outputpath = outputpath.Replace('*', '-');
            outputpath = outputpath.Replace('?', '-');
            outputpath = outputpath.Replace('\"', '-');
            outputpath = outputpath.Replace('<', '-');
            outputpath = outputpath.Replace('>', '-');
            outputpath = outputpath.Replace('|', '-');
            return outputpath;
        }

        public static void RemoveDoubles(ref String input, char charact)
        {
            int len = -1;
            do
            {
                len = input.Length;
                input = input.Replace("--", "-");
            } while (len != input.Length);
        }

        public static string GetFilePath(string outputdir)
        {
            var OFD = new OpenFileDialog();
            OFD.Title = "Select a folder structure file to view";
            OFD.InitialDirectory = Path.GetDirectoryName(Application.ExecutablePath) + "\\" + outputdir;

            DialogResult DR = OFD.ShowDialog();
            if (DR == DialogResult.Cancel)
                return null;

            return OFD.FileName;
        }

        public static void GetRatings(TreeListView outputtree, TreeListView mainTV)
        {
            if (outputtree.SelectedItems.Count == 0)
                return;
            //first clear all sizes for selected items
            foreach (TreeListViewItem TLVI in outputtree.SelectedItems)
            {
                var TLVI2 = treelistviewfuncs.getItemByName(mainTV, TLVI.Name);
                if (TLVI2 == null)
                    continue;
                TLVI2.rating = treelistviewfuncs.getRating(TLVI);
                //if (TLVI2.rating>-1)
                //TLVI2.SubItems[3].Text = TLVI2.rating.ToString();
            }
        }

        public static void ClearSelections(List<TreeNode> selectedNodes)
        {
            try
            {
                retry:
                foreach (TreeNode tn in selectedNodes)
                {
                    if (tn.Checked)
                    {
                        tn.Checked = false;
                        goto retry;
                    }
                }
            }
            finally
            {
                selectedNodes.Clear();
            }
        }

        public static void Refreshtree(System.Windows.Forms.TreeView multiselecttree, TreeNode TX = null)
        {
            if (multiselecttree.Nodes.Count == 0)
            {
                multiselecttree.Nodes.Clear();
                foreach (String s in Directory.GetLogicalDrives())
                {
                    TreeNode TN = multiselecttree.Nodes.Add(s);
                    //dummy item
                    try
                    {
                        if (Directory.GetDirectories(TN.Text).Count() > 0)
                            TN.Nodes.Add(dummyname).Name = dummyname;
                    }
                    catch
                    {
                        continue;
                    }
                }
            }
            else
            {
                foreach (TreeNode TN in multiselecttree.Nodes)
                {
                    Expandnodes(TN, TX);
                }
            }
        }

        public static void Expandnodes(TreeNode TN, TreeNode TX = null)
        {
            if (TN.IsExpanded || TN == TX)
            {
                //Remove dummu
                if (TN.Nodes[dummyname] != null)
                {
                    TreeNode TN2 = TN.Nodes[dummyname];
                    TN.Nodes.Remove(TN2);
                }
                if (TN.Nodes.Count == 0)
                {
                    Expandnode(TX);
                }
                foreach (TreeNode TN2 in TN.Nodes)
                    Expandnodes(TN2, TX);
            }
        }

        public static void Expandnode(TreeNode TN)
        {
            try
            {
                foreach (String subdir in Directory.GetDirectories(TN.Text))
                {
                    TreeNode TX2 = TN.Nodes.Add(subdir);
                    TX2.Name = subdir;
                    if (Directory.GetDirectories(subdir).Count() > 0)
                        TX2.Nodes.Add(dummyname).Name = dummyname;
                }
            }
            catch
            {
            }
        }

        public static bool Errorcontinue(String error)
        {
            var options = new List<string> { "Yes", "No" };
            var MMB = new ANDREICSLIB.NewControls.MultipleMessageBox("Continue?",
                                             "Error:\n" + error + "\nDo you wish to continue?", options);
            MMB.ShowDialog();
            return MMB.Result.Equals("Yes");
        }

        public static bool Rem(ref TreeListView T, String FullPath)
        {
            for (int a = 0; a < T.Items.Count; a++)
            {
                if (T.Items[a].fullPath.Equals(FullPath))
                {
                    T.Items.RemoveAt(a);
                    return true;
                }

                if (T.Items.Count > 0)
                {
                    var newT = new TreeListViewItem();
                    treelistviewfuncs.CopyNode(T.Items[a], ref newT);
                    if (Rem(ref newT, FullPath))
                    {
                        T.Items.RemoveAt(a);
                        T.Items.Add(newT);
                    }
                }
            }
            return false;
        }

        public static bool Rem(ref TreeListViewItem T, String FullPath)
        {
            for (int a = 0; a < T.Items.Count; a++)
            {
                if (T.Items[a].fullPath.Equals(FullPath))
                {
                    T.Items.RemoveAt(a);
                    return true;
                }

                if (T.Items.Count > 0)
                {
                    var newT = new TreeListViewItem();
                    treelistviewfuncs.CopyNode(T.Items[a], ref newT);
                    if (Rem(ref newT, FullPath))
                    {
                        T.Items.RemoveAt(a);
                        T.Items.Add(newT);
                        return true;
                    }
                }
            }
            return false;
        }

        public static void SetImages(TreeListView TLV, bool showicon, ref ImageList imageList1)
        {
            foreach (TreeListViewItem TLVI in TLV.Items)
            {
                SetImage(TLVI, showicon, ref imageList1);
                SetImages(TLVI.Items, showicon, ref imageList1);
            }
        }

        public static void SetImages(TreeListViewItemCollection TLVIC, bool showicon, ref ImageList imageList1)
        {
            foreach (TreeListViewItem TLVI2 in TLVIC)
            {
                SetImage(TLVI2, showicon, ref imageList1);
                SetImages(TLVI2.Items, showicon, ref imageList1);
            }
        }

        public static void CopySelectedToClipboard(TreeListView outputtree)
        {
            String SC = "";

            foreach (TreeListViewItem TLVI in outputtree.SelectedItems)
            {
                SC += TLVI.fullPath + Environment.NewLine;
            }

            if (string.IsNullOrEmpty(SC) == false)
                Clipboard.SetText(SC);
            else
                MessageBox.Show("No items were copied - are they accessible?");
        }

        public static void ClearAndRecalculate(bool recursive, TreeListView outputtree, TreeListView mainTV)
        {
            if (outputtree.SelectedItems.Count > 0)
            {
                //first clear all sizes for selected items
                foreach (TreeListViewItem TLVI in outputtree.SelectedItems)
                {
                    treelistviewfuncs.clearSizes(treelistviewfuncs.getItemByName(mainTV, TLVI.Name), false);
                }

                //then repopulate
                foreach (TreeListViewItem TLVI in outputtree.SelectedItems)
                {
                    treelistviewfuncs.recalculateSizes(treelistviewfuncs.getItemByName(mainTV, TLVI.Name));
                }
            }
            else
            {
                treelistviewfuncs.clearSizes(ref mainTV);
                treelistviewfuncs.recalculateSizes(mainTV);
            }
        }

        public static void SetImage(TreeListViewItem TLVI, bool showicon, ref ImageList imageList1)
        {
            if (TLVI.Visible == false)
                return;

            if (TLVI.isfolder)
            {
                if (TLVI.Items.Count >= 1 && TLVI.Items[0].Visible)
                    TLVI.ImageIndex = 0;
                else
                    TLVI.ImageIndex = 1;
                return;
            }

            if (showicon)
            {
                try
                {
                    int x = ShellIcon.getSetImage(TLVI.Text, ref imageList1, false);
                    if (x != -1)
                        TLVI.ImageIndex = x;
                }
                catch
                {
                    TLVI.ImageIndex = 2;
                }
            }
            else
                TLVI.ImageIndex = 2;
        }

        public static List<TreeListViewItem> GetDups(Form1.IncrementStatusDel incrementStatus, TreeListViewItem TLVI, bool fuzzy)
        {
            //get a list of all the files at this level
            var ret = new List<TreeListViewItem>();
            var retout = new List<TreeListViewItem>();
            foreach (TreeListViewItem TLVI2 in TLVI.Items)
            {
                if (TLVI2.isfolder == false)
                    ret.Add(TLVI2);
                if (TLVI2.Items.Count > 0)
                {
                    retout.AddRange(GetDups(incrementStatus, TLVI2, fuzzy));
                }
            }

            //go through and get the dups
            foreach (TreeListViewItem R1 in ret)
            {
                incrementStatus(true);
                foreach (TreeListViewItem R2 in ret)
                {
                    if (R1 == R2)
                        continue;
                    String r11 = R1.Text;
                    GetString(ref r11);

                    String r22 = R2.Text;
                    GetString(ref r22);

                    if ((r11.Equals(r22) && fuzzy) || R1.Text.Equals(R2.Text) && fuzzy == false)
                    {
                        if (retout.Contains(R1) == false)
                        {
                            retout.Add(R1);
                            incrementStatus();
                        }
                        if (retout.Contains(R2) == false)
                            retout.Add(R2);
                    }
                }
            }
            return retout;
        }

        public static void GetString(ref String i)
        {
            i = Clean(i);
            i = i.Replace('.', '-');
            i = i.ToLower();
            String o = "";
            foreach (char c in i)
            {
                if ((c < 'a' || c > 'z') && c != '-')
                    break;
                else if (c != '-')
                    o = o + c;
            }
            i = o;
        }

        public static List<TreeListViewItem> GetMatches(TreeListViewItem TLVI, string livesearchtext)
        {
            //get a list of all the files at this level
            var ret = new List<TreeListViewItem>();
            var retout = new List<TreeListViewItem>();
            foreach (TreeListViewItem TLVI2 in TLVI.Items)
            {
                if (TLVI2.isfolder == false)
                    ret.Add(TLVI2);
                if (TLVI2.Items.Count > 0)
                {
                    ret.AddRange(GetMatches(TLVI2, livesearchtext));
                }
            }

            //go through and get the dups
            foreach (TreeListViewItem node in ret)
            {
                String regx = "";
                if (node.Text.StartsWith("^") == false)
                    regx = ".*";

                String x = livesearchtext;
                x = x.Replace(@"\", @"\\");

                regx += x;
                if (node.Text.EndsWith("$"))
                    regx += ".*";

                var r = new Regex(regx, RegexOptions.IgnoreCase);
                bool match = r.IsMatch(node.Text);

                if (match)
                {
                    retout.Add(node);
                }
            }
            return retout;
        }

        public static void AddNode(TreeListViewItem TLVI, ref TreeListView sendto)
        {
            var parenttree = new List<TreeListViewItem>();
            TreeListViewItem curr = TLVI;
            while (curr != null)
            {
                parenttree.Add(curr);
                curr = curr.Parent;
            }

            //initial folder

            TreeListViewItem pop = parenttree[parenttree.Count - 1];
            TreeListViewItem createin = treelistviewfuncs.getItemByText(sendto, pop.Text);
            if (createin == null)
            {
                var create = new TreeListViewItem();
                treelistviewfuncs.BaseCopy(pop, ref create);

                sendto.Items.Add(create);
                createin = treelistviewfuncs.getItemByText(sendto, pop.Text);
            }
            parenttree.RemoveAt(parenttree.Count - 1);

            while (parenttree.Count > 0)
            {
                pop = parenttree[parenttree.Count - 1];
                TreeListViewItem pop2 = treelistviewfuncs.getItemByText(createin, pop.Text);
                if (pop2 == null)
                {
                    var create = new TreeListViewItem();
                    treelistviewfuncs.BaseCopy(pop, ref create);

                    createin.Items.Add(create);
                    createin = treelistviewfuncs.getItemByText(createin, pop.Text);
                }
                else
                    createin = pop2;

                parenttree.RemoveAt(parenttree.Count - 1);
            }
        }

        public static String TimeFileName(String basestr, string fileext)
        {
            String t = DateTime.Now.ToString();
            return basestr + t + "." + fileext;
        }

        public static void CollapseTLVI(TreeListView TLV)
        {
            TLV.CollapseAll();
        }

        public static void ExpandTLVI(TreeListView TLV)
        {
            TLV.ExpandAll();
        }

        public static void DisplayTreeListViewFile(Form1.IncrementStatusDel incrementStatus, TreeListView TV, String path)
        {
            TV.Items.Clear();
            try
            {
                serialisation.DeserializeTreeListView(incrementStatus, TV, path);
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an error opening the file:" + ex);
            }
        }

        public static void UpdateFileList(System.Windows.Forms.CheckedListBox filelist, string outputdir, string fileext)
        {
            Directory.SetCurrentDirectory(Path.GetDirectoryName(Application.ExecutablePath));
            filelist.Items.Clear();

            if (Directory.Exists(outputdir) == false && File.Exists(outputdir) == false)
                Directory.CreateDirectory(outputdir);

            var di = new DirectoryInfo(outputdir);
            FileInfo[] rgFiles = di.GetFiles("*." + fileext);
            foreach (FileInfo fi in rgFiles)
            {
                filelist.Items.Add(fi.Name);
            }
        }

        public static void SavepathsF(System.Windows.Forms.CheckedListBox filelist, List<string> input, int maxDepth, ref string outputdir, string fileext, bool savefilesize)
        {
            foreach (String fp in input)
            {
                String outputpathFinal = "";

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

                    String outputpath = Clean(fp);

                    RemoveDoubles(ref outputpath, '-');

                    String t = DateTime.Now.ToString();
                    t = Clean(t);
                    outputpath = outputpath + " " + t;
                    outputpath = outputpath + "." + fileext;

                    outputpathFinal = outputdir + "/" + outputpath;
                }

                catch (Exception ex)
                {
                    MessageBox.Show("There was an error opening the file:" + ex);
                    return;
                }

                TreeListView tv = treelistviewfuncs.getDirectoryTree(fp, null, 0, maxDepth, savefilesize);

                try
                {
                    serialisation.SerializeTreeListView(tv, outputpathFinal);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("There was an error saving the tree to the file:" + ex);
                    return;
                }
                UpdateFileList(filelist, outputdir, fileext);
            }
        }
    }
}
