using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Net;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Data;
using System.Xml;
using System.Text;
using System.IO;
using System.Collections.Generic;
using System.Configuration;
using ANDREICSLIB;
using ANDREICSLIB.ClassExtras;

namespace FolderView
{
    public static class treelistviewfuncs
    {
        public static Form1 baseform;

        public static int getRating(TreeListViewItem TLVI)
        {
            //string apiKey = ConfigurationManager.AppSettings["ApiKey"];
            String search = TLVI.Text;
            if (search.Contains("."))
                search = search.Substring(0, search.LastIndexOf('.')).Replace('.', ' ');
            String regx = "^[a-z ]+";
            var r = new Regex(regx, RegexOptions.IgnoreCase);

            Match m = r.Match(search);

            String hit = m.Groups[0].Value;

            var url = String.Format(@"http://www.rottentomatoes.com/search/?search={0}&sitesearch=rt", hit);
            string response;

            try
            {
                using (var client = new WebClient())
                {
                    response = client.DownloadString(url);
                }

                //we need to choose a movie if it doesnt go direct
                response = response.Replace("\n", "");
                response = response.Replace("\t", "");
                response = response.Replace("  ", " ");
                Regex.Replace(response, @"[\w]+", "");
                String w = "property=\"v:average\">";
                String res = response.Substring(response.IndexOf(w) + w.Length, 3);
                if (String.IsNullOrEmpty(res))
                {
                    String chooseone = "<span class=\"movieposter\"><a href=\"";

                }
                if (res[2] == '<')
                    res = res.Substring(0, 2);

                return int.Parse(res);
            }
            catch (Exception)
            {

            }
            return -1;
        }

        private static long getSize(String path)
        {
            FileInfo f = null;
            try
            {
                f = new FileInfo(path);
            }
            catch
            {
                return -1;
            }

            if (f.Exists == false)
                return -1;

            long s1 = f.Length;
            return (long)Math.Ceiling(((double)Math.Ceiling((double)s1 / 1024)));
        }

        private static long getSize(TreeListViewItem TLVI)
        {
            if (TLVI.isfolder == false)
            {
                if (TLVI.nodeSize.kb == -1)
                    return getSize(TLVI.fullPath);
                else
                    return TLVI.nodeSize.kb;
            }

            long sizekb = 0;
            foreach (TreeListViewItem TLVI2 in TLVI.Items)
            {
                if (TLVI2.nodeSize.kb == -1)
                    TLVI2.nodeSize.kb = getSize(TLVI2);

                if (TLVI2.nodeSize.kb != -1)
                {
                    sizekb += TLVI2.nodeSize.kb;
                    if (TLVI2.SubItems.Count >= 2)
                        TLVI2.SubItems[1].Text = TLVI2.nodeSize.getSizeString();
                    else
                        TLVI2.SubItems.Add(TLVI2.nodeSize.getSizeString());
                }
            }
            return sizekb;
        }

        public static string getRelativePath(String fullpath)
        {
            String rp = fullpath;
            int removeLength2 = rp.LastIndexOf('\\') + 1;
            //if its a drive letter, we dont want to remove the \'s
            if (removeLength2 != rp.Length)
            {
                rp = rp.Remove(0, removeLength2);
            }
            return rp;
        }

        //create treeview from file
        public static TreeListViewItem getFileInfo(String file, bool saveFileSize)
        {
            TreeListViewItem FN = new TreeListViewItem();
            FN.BackColor = Color.White;
            FN.ForeColor = Color.Black;

            String relativePath2 = getRelativePath(file);

            if (saveFileSize)
                FN.nodeSize.kb = getSize(file);

            FN.Text = relativePath2;
            FN.Name = file;
            FN.fullPath = getFullPath(file);
            FN.isfolder = Directory.Exists(file);

            return FN;
        }

        private static string getFullPath(string parentPath)
        {
            return parentPath;
        }

        public static TreeListView getDirectoryTree(String parentPath, TreeListViewItem Parent, int currentDepth, int maxDepth, bool saveFileSize)
        {
            if (maxDepth != -1 && currentDepth >= maxDepth)
                return null;
            TreeListView TV = new TreeListView();

            TreeListViewItem TN = new TreeListViewItem();

            String relativePath = getRelativePath(parentPath);

            TN.Text = relativePath;
            TN.Name = parentPath;
            TN.fullPath = getFullPath(parentPath);
            TN.isfolder = Directory.Exists(parentPath);

            TN.BackColor = Color.White;
            TN.ForeColor = Color.Black;

            foreach (String s in Directory.GetFiles(parentPath))
            {
                TreeListViewItem FN = getFileInfo(s, saveFileSize);
                TN.Items.Add(FN);
            }

            if (Parent != null)
                Parent.Items.Add(TN);

            try
            {
                foreach (String d in Directory.GetDirectories(parentPath))
                {
                    getDirectoryTree(d, TN, currentDepth + 1, maxDepth, saveFileSize);
                }
            }
            catch
            {
            }

            TN.nodeSize.kb = getSize(TN);

            TV.Items.Add(TN);
            return TV;
        }

        public static void recalculateSizes(TreeListViewItem TLVI)
        {
            TLVI.nodeSize.kb = getSize(TLVI);
            TLVI.SubItems[1].Text = TLVI.nodeSize.getSizeString();

            foreach (TreeListViewItem T in TLVI.Items)
            {
                T.nodeSize.kb = getSize(T);
                T.SubItems[1].Text = T.nodeSize.getSizeString();
            }
        }

        public static void recalculateSizes(TreeListView TLV)
        {
            foreach (TreeListViewItem T in TLV.Items)
            {
                T.nodeSize.kb = getSize(T);
                T.SubItems[1].Text = T.nodeSize.getSizeString();
            }
        }

        public static void clearSizes(ref TreeListView T)
        {
            foreach (TreeListViewItem TI in T.Items)
            {
                TI.nodeSize = new TreeListViewItem.sizecl();
                clearSizes(TI, true);
            }
        }

        public static void clearSizes(TreeListViewItem T, bool recursive)
        {
            T.nodeSize = new TreeListViewItem.sizecl();

            if (recursive == false)
                return;

            foreach (TreeListViewItem TI in T.Items)
            {
                TI.nodeSize = new TreeListViewItem.sizecl();
                clearSizes(TI, true);
            }
        }

        public static void spaceToDot(Form1.IncrementStatusDel incrementStatus, ref TreeListView change, ref TreeListView fromthis, char replacethis, char withthis)
        {
            for (int a = 0; a < fromthis.Items.Count; a++)
            {
                String s = fromthis.Items[a].Text.Replace(replacethis, withthis);
                TreeListViewItem TLVI = getItemByName(change, fromthis.Items[a].fullPath);
                if (TLVI != null)
                    TLVI.Text = s;
                fromthis.Items[a].Text = s;

                incrementStatus();
                spaceToDot(incrementStatus, ref change, fromthis.Items[a], replacethis, withthis);
            }
        }

        public static void spaceToDot(Form1.IncrementStatusDel incrementStatus, ref TreeListView change, TreeListViewItem fromthis, char replacethis, char withthis)
        {
            for (int a = 0; a < fromthis.Items.Count; a++)
            {
                String s = fromthis.Items[a].Text.Replace(replacethis, withthis);
                TreeListViewItem TLVI = getItemByName(change, fromthis.Items[a].fullPath);
                if (TLVI != null)
                    TLVI.Text = s;
                fromthis.Items[a].Text = s;

                incrementStatus();
                spaceToDot(incrementStatus, ref change, fromthis.Items[a], replacethis, withthis);
            }
        }

        public static void camelcase(Form1.IncrementStatusDel incrementStatus, ref TreeListView change, ref TreeListView fromthis)
        {
            for (int a = 0; a < fromthis.Items.Count; a++)
            {
                String s = StringExtras.ToCamelCase(fromthis.Items[a].Text, true, null);
                TreeListViewItem TLVI = getItemByName(change, fromthis.Items[a].fullPath);
                if (TLVI != null)
                    TLVI.Text = s;
                fromthis.Items[a].Text = s;

                incrementStatus();
                camelcase(incrementStatus, ref change, fromthis.Items[a]);
            }
        }

        public static void camelcase(Form1.IncrementStatusDel incrementStatus, ref TreeListView change, TreeListViewItem fromthis)
        {
            for (int a = 0; a < fromthis.Items.Count; a++)
            {
                String s = StringExtras.ToCamelCase(fromthis.Items[a].Text, true, null);
                TreeListViewItem TLVI = getItemByName(change, fromthis.Items[a].fullPath);
                if (TLVI != null)
                    TLVI.Text = s;
                fromthis.Items[a].Text = s;

                incrementStatus();
                camelcase(incrementStatus, ref change, fromthis.Items[a]);
            }
        }

        public static void lowercase(Form1.IncrementStatusDel incrementStatus, ref TreeListView change, ref TreeListView fromthis)
        {
            for (int a = 0; a < fromthis.Items.Count; a++)
            {
                String s = fromthis.Items[a].Text.ToLower();
                TreeListViewItem TLVI = getItemByName(change, fromthis.Items[a].fullPath);
                if (TLVI != null)
                    TLVI.Text = s;
                fromthis.Items[a].Text = s;

                incrementStatus();
                camelcase(incrementStatus, ref change, fromthis.Items[a]);
            }
        }

        public static void lowercase(Form1.IncrementStatusDel incrementStatus, ref TreeListView change, TreeListViewItem fromthis)
        {
            for (int a = 0; a < fromthis.Items.Count; a++)
            {
                String s = fromthis.Items[a].Text.ToLower();
                TreeListViewItem TLVI = getItemByName(change, fromthis.Items[a].fullPath);
                if (TLVI != null)
                    TLVI.Text = s;
                fromthis.Items[a].Text = s;

                incrementStatus();
                camelcase(incrementStatus, ref change, fromthis.Items[a]);
            }
        }

        public static void resetRelativePath(Form1.IncrementStatusDel incrementStatus, ref TreeListView change, ref TreeListView fromthis)
        {
            for (int a = 0; a < fromthis.Items.Count; a++)
            {
                String s = getRelativePath(fromthis.Items[a].fullPath);
                TreeListViewItem TLVI = getItemByName(change, fromthis.Items[a].fullPath);
                if (TLVI != null)
                    TLVI.Text = s;
                fromthis.Items[a].Text = s;

                incrementStatus();
                resetRelativePath(incrementStatus, ref change, fromthis.Items[a]);
            }
        }

        public static void resetRelativePath(Form1.IncrementStatusDel incrementStatus, ref TreeListView change, TreeListViewItem fromthis)
        {
            for (int a = 0; a < fromthis.Items.Count; a++)
            {
                String s = getRelativePath(fromthis.Items[a].fullPath);
                TreeListViewItem TLVI = getItemByName(change, fromthis.Items[a].fullPath);
                if (TLVI != null)
                    TLVI.Text = s;
                fromthis.Items[a].Text = s;

                incrementStatus();
                resetRelativePath(incrementStatus, ref change, fromthis.Items[a]);
            }
        }

        public static void CopyNodes(TreeListView from, TreeListView to, bool clearFirst, int ignoreLevels)
        {
            if (clearFirst)
                to.Items.Clear();

            foreach (TreeListViewItem node in from.Items)
            {
                bool exists = getItemByText(to, node.Text) != null;
                bool existsFull = false;
                if (exists)
                    existsFull = getItemByName(to, node.fullPath) != null;

                //if file
                if (node.isfolder == false)
                {
                    //if same file, then do not create
                    if (existsFull)
                        continue;

                    //create
                    TreeListViewItem newI = new TreeListViewItem();
                    BaseCopy(node, ref newI);
                    newI.SubItems[1].Text = newI.nodeSize.getSizeString();
                    to.Items.Add(newI);
                    continue;
                }
                else
                {
                    //if a folder with that name does not exist
                    if (exists == false)
                    {
                        if (ignoreLevels > 0)
                        {
                            ignoreLevels--;
                            CopyNodes(node, to, false, ignoreLevels);
                            return;
                        }
                        else
                        {
                            TreeListViewItem newI = new TreeListViewItem();
                            BaseCopy(node, ref newI);
                            newI.SubItems[1].Text = newI.nodeSize.getSizeString();
                            to.Items.Add(newI);
                        }
                    }

                    //if the node we are copying has subitems, we need to set the folders size after
                    if (node.Items.Count > 0)
                    {
                        CopyNodes(node, getItemByText(to, node.Text), false, ignoreLevels);

                        //only recalc size if the folder didnt exist before
                        //if (exists)
                        //{
                        TreeListViewItem TLVI = getItemByText(to, node.Text);
                        //clearSizes(TLVI, false);
                        recalculateSizes(TLVI);
                        TLVI.SubItems[1].Text = TLVI.nodeSize.getSizeString();
                        //}
                    }
                }
            }
        }

        public static void CopyNodes(TreeListViewItem from, TreeListView to, bool clearFirst, int ignoreLevels)
        {
            if (clearFirst)
                to.Items.Clear();

            foreach (TreeListViewItem node in from.Items)
            {
                bool exists = getItemByText(to, node.Text) != null;
                bool existsFull = false;
                if (exists)
                    existsFull = getItemByName(to, node.fullPath) != null;

                //if file
                if (node.isfolder == false)
                {
                    //if same file, then do not create
                    if (existsFull)
                        continue;

                    //create
                    TreeListViewItem newI = new TreeListViewItem();
                    BaseCopy(node, ref newI);
                    newI.SubItems[1].Text = newI.nodeSize.getSizeString();
                    to.Items.Add(newI);
                    continue;
                }
                else
                {
                    //if a folder with that name does not exist
                    if (exists == false)
                    {
                        if (ignoreLevels > 0)
                        {
                            ignoreLevels--;
                            CopyNodes(node, to, false, ignoreLevels);
                            return;
                        }
                        else
                        {
                            TreeListViewItem newI = new TreeListViewItem();
                            BaseCopy(node, ref newI);
                            newI.SubItems[1].Text = newI.nodeSize.getSizeString();
                            to.Items.Add(newI);
                        }
                    }

                    //if the node we are copying has subitems, we need to set the folders size after
                    if (node.Items.Count > 0)
                    {
                        CopyNodes(node, getItemByText(to, node.Text), false, ignoreLevels);

                        //only recalc size if the folder didnt exist before
                        //if (exists)
                        //{
                        TreeListViewItem TLVI = getItemByText(to, node.Text);
                        //clearSizes(TLVI, false);
                        recalculateSizes(TLVI);
                        TLVI.SubItems[1].Text = TLVI.nodeSize.getSizeString();
                        //}
                    }
                }
            }
        }

        public static void CopyNodes(TreeListViewItem from, TreeListViewItem to, bool clearFirst, int ignoreLevels)
        {
            if (clearFirst)
                to.Items.Clear();

            foreach (TreeListViewItem node in from.Items)
            {
                bool exists = getItemByText(to, node.Text) != null;
                bool existsFull = false;
                if (exists)
                    existsFull = getItemByName(to, node.fullPath) != null;

                //if file
                if (node.isfolder == false)
                {
                    //if same file, then do not create
                    if (existsFull)
                        continue;

                    //create
                    TreeListViewItem newI = new TreeListViewItem();
                    BaseCopy(node, ref newI);
                    newI.SubItems[1].Text = newI.nodeSize.getSizeString();
                    to.Items.Add(newI);
                    continue;
                }
                else
                {
                    //if a folder with that name does not exist
                    if (exists == false)
                    {
                        if (ignoreLevels > 0)
                        {
                            ignoreLevels--;
                            CopyNodes(node, to, false, ignoreLevels);
                            return;
                        }
                        else
                        {
                            TreeListViewItem newI = new TreeListViewItem();
                            BaseCopy(node, ref newI);
                            newI.SubItems[1].Text = newI.nodeSize.getSizeString();
                            to.Items.Add(newI);
                        }
                    }

                    //if the node we are copying has subitems, we need to set the folders size after
                    if (node.Items.Count > 0)
                    {
                        CopyNodes(node, getItemByText(to, node.Text), false, ignoreLevels);

                        //only recalc size if the folder didnt exist before
                        //if (exists)
                        //{
                        TreeListViewItem TLVI = getItemByText(to, node.Text);
                        //clearSizes(TLVI, false);
                        recalculateSizes(TLVI);
                        TLVI.SubItems[1].Text = TLVI.nodeSize.getSizeString();
                        //}
                    }
                }
            }
        }

        public static void CopyNodes(TreeListView from, TreeListViewItem to, bool clearFirst, int ignoreLevels)
        {
            if (clearFirst)
                to.Items.Clear();

            foreach (TreeListViewItem node in from.Items)
            {
                bool exists = getItemByText(to, node.Text) != null;
                bool existsFull = false;
                if (exists)
                    existsFull = getItemByName(to, node.fullPath) != null;

                //if file
                if (node.isfolder == false)
                {
                    //if same file, then do not create
                    if (existsFull)
                        continue;

                    //create
                    TreeListViewItem newI = new TreeListViewItem();
                    BaseCopy(node, ref newI);
                    newI.SubItems[1].Text = newI.nodeSize.getSizeString();
                    to.Items.Add(newI);
                    continue;
                }
                else
                {
                    //if a folder with that name does not exist
                    if (exists == false)
                    {
                        if (ignoreLevels > 0)
                        {
                            ignoreLevels--;
                            CopyNodes(node, to, false, ignoreLevels);
                            return;
                        }
                        else
                        {
                            TreeListViewItem newI = new TreeListViewItem();
                            BaseCopy(node, ref newI);
                            newI.SubItems[1].Text = newI.nodeSize.getSizeString();
                            to.Items.Add(newI);
                        }
                    }

                    //if the node we are copying has subitems, we need to set the folders size after
                    if (node.Items.Count > 0)
                    {
                        CopyNodes(node, getItemByText(to, node.Text), false, ignoreLevels);

                        //only recalc size if the folder didnt exist before
                        //if (exists)
                        //{
                        TreeListViewItem TLVI = getItemByText(to, node.Text);
                        //clearSizes(TLVI, false);
                        recalculateSizes(TLVI);
                        TLVI.SubItems[1].Text = TLVI.nodeSize.getSizeString();
                        //}
                    }
                }
            }
        }

        public static void BaseCopy(TreeListViewItem from, ref TreeListViewItem to)
        {
            to = (TreeListViewItem)from.Clone();
            to.fullPath = from.fullPath;
            to.Name = from.fullPath;
            to.nodeSize = from.nodeSize;
            to.isfolder = from.isfolder;
            to.rating = from.rating;
            while (to.SubItems.Count < 4)
            {
                to.SubItems.Add("");
            }
            to.SubItems[1].Text = to.nodeSize.getSizeString();
            to.SubItems[2].Text = to.fullPath;
            if (to.rating > -1)
                to.SubItems[3].Text = to.rating.ToString();
        }

        public static void CopyNode(TreeListViewItem from, ref TreeListViewItem to)
        {
            BaseCopy(from, ref to);
            CopyNodes(from, to, false, 0);
        }

        public static Dictionary<int, bool> onScreen(TreeListViewItem TLVI, TreeListView TLV)
        {
            Dictionary<int, bool> onScreen = new Dictionary<int, bool>();

            for (int i = TLV.TopItem.Index + 1; i < TLV.Items.Count; i++)
            {
                if (TLV.ClientRectangle.Contains(TLV.Items[i].Bounds))
                    onScreen.Add(TLV.Items[i].Index, true);
                else
                {
                    break;
                }
            }
            return onScreen;
        }

        public static TreeListViewItem getItemByName(TreeListView TLV, String name)
        {
            foreach (TreeListViewItem T in TLV.Items)
            {
                if (T.Name.Equals(name))
                    return T;
                if (T.Items.Count > 0)
                {
                    TreeListViewItem xex = getItemByName(T, name);
                    if (xex != null)
                        return xex;
                }
            }
            return null;
        }


        public static TreeListViewItem getItemByName(TreeListViewItem incoll, String name)
        {
            foreach (TreeListViewItem T in incoll.Items)
            {
                if (T.Name.Equals(name))
                    return T;
                if (T.Items.Count > 0)
                {
                    TreeListViewItem xex = getItemByName(T, name);
                    if (xex != null)
                        return xex;
                }
            }
            return null;
        }

        //
        public static TreeListViewItem getItemByText(TreeListView TLV, String name, bool recursive = false)
        {
            foreach (TreeListViewItem T in TLV.Items)
            {
                if (T.Text.Equals(name))
                    return T;
                if (recursive)
                {
                    if (T.Items.Count > 0)
                    {
                        TreeListViewItem xex = getItemByText(T, name);
                        if (xex != null)
                            return xex;
                    }
                }
            }
            return null;
        }

        public static TreeListViewItem getItemByText(TreeListViewItem incoll, String name, bool recursive = false)
        {
            foreach (TreeListViewItem T in incoll.Items)
            {
                if (T.Text.Equals(name))
                    return T;
                if (recursive)
                {
                    if (T.Items.Count > 0)
                    {
                        TreeListViewItem xex = getItemByText(T, name);
                        if (xex != null)
                            return xex;
                    }
                }
            }
            return null;
        }

        public static TreeListViewItem getItemByIndex(TreeListView TLV, int indexi)
        {
            foreach (TreeListViewItem T in TLV.Items)
            {
                if (T.Index.Equals(indexi))
                    return T;
                if (T.Items.Count > 0)
                {
                    TreeListViewItem xex = getItemByIndex(T, indexi);
                    if (xex != null)
                        return xex;
                }
            }
            return null;
        }

        public static TreeListViewItem getItemByIndex(TreeListViewItem TLV, int indexi)
        {
            foreach (TreeListViewItem T in TLV.Items)
            {
                if (T.Index.Equals(indexi))
                    return T;
                if (T.Items.Count > 0)
                {
                    TreeListViewItem xex = getItemByIndex(T, indexi);
                    if (xex != null)
                        return xex;
                }
            }
            return null;
        }


    }
}
