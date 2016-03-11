
namespace FolderView
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
			System.Windows.Forms.TreeListViewItemCollection.TreeListViewItemCollectionComparer treeListViewItemCollectionComparer1 = new System.Windows.Forms.TreeListViewItemCollection.TreeListViewItemCollectionComparer();
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.dontsave = new System.Windows.Forms.ToolStripMenuItem();
			this.autosave = new System.Windows.Forms.ToolStripMenuItem();
			this.existcopyonly = new System.Windows.Forms.ToolStripMenuItem();
			this.warnondelete = new System.Windows.Forms.ToolStripMenuItem();
			this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.replaceAllDotsWithSpacesInRelativePathsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.replaceAllSpacesWithDotsInTheRelativePathToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.useCamelCaseWithAllRelativePathCharactersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.replaceAllCharactersWithLowerCaseInRelativePathsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.revertRelativePathsToProperNameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.TC = new System.Windows.Forms.TabControl();
			this.savetabpage = new System.Windows.Forms.TabPage();
			this.panel1 = new System.Windows.Forms.Panel();
			this.savebutton = new System.Windows.Forms.Button();
			this.savefilesize = new System.Windows.Forms.CheckBox();
			this.maxdepth = new System.Windows.Forms.ComboBox();
			this.label3 = new System.Windows.Forms.Label();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.unselectallbutton = new System.Windows.Forms.Button();
			this.refreshtreebutton = new System.Windows.Forms.Button();
			this.multiselecttree = new System.Windows.Forms.TreeView();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.foldertext = new System.Windows.Forms.TextBox();
			this.selectfolder = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.viewtabpage = new System.Windows.Forms.TabPage();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
			this.Status1 = new System.Windows.Forms.ToolStripStatusLabel();
			this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
			this.Status2 = new System.Windows.Forms.ToolStripStatusLabel();
			this.autoresize = new System.Windows.Forms.Button();
			this.showicon = new System.Windows.Forms.CheckBox();
			this.searchbutton = new System.Windows.Forms.Button();
			this.viewContextStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.openBaseFolderInExplorerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.removeItemFromListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.justRemoveItemFromListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.deleteSourceFileAsWellToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.recalculateFileSizesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.recalculateAllSubitemsAsWellToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.recalculateSelectedOnlyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.addFileToTreeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.addFolderToTreeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.copySelectedFilesToClipboardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.getDuplicateFilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.exactNameMatchesOnlyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.fuzzyNameMatchesOnlyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.getRatingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.livesearch = new System.Windows.Forms.TextBox();
			this.viewfilebutton = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.collapsebutton = new System.Windows.Forms.Button();
			this.viewpath = new System.Windows.Forms.TextBox();
			this.viewfolder = new System.Windows.Forms.Button();
			this.expandbutton = new System.Windows.Forms.Button();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.selectnone = new System.Windows.Forms.Button();
			this.selectall = new System.Windows.Forms.Button();
			this.label4 = new System.Windows.Forms.Label();
			this.baselevelsremove = new System.Windows.Forms.ComboBox();
			this.filelist = new System.Windows.Forms.CheckedListBox();
			this.randomname = new System.Windows.Forms.Button();
			this.mergebutton = new System.Windows.Forms.Button();
			this.outputfilename = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.outputtree = new System.Windows.Forms.TreeListView();
			this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.menuStrip1.SuspendLayout();
			this.TC.SuspendLayout();
			this.savetabpage.SuspendLayout();
			this.panel1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.viewtabpage.SuspendLayout();
			this.statusStrip1.SuspendLayout();
			this.viewContextStrip.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.SuspendLayout();
			// 
			// imageList1
			// 
			this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
			this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
			this.imageList1.Images.SetKeyName(0, "OPENFOLD.ICO");
			this.imageList1.Images.SetKeyName(1, "CLSDFOLD.ICO");
			this.imageList1.Images.SetKeyName(2, "FILE.ICO");
			// 
			// menuStrip1
			// 
			this.menuStrip1.BackColor = System.Drawing.Color.Silver;
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.optionsToolStripMenuItem,
            this.toolsToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(678, 24);
			this.menuStrip1.TabIndex = 12;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
			this.fileToolStripMenuItem.Text = "File";
			// 
			// exitToolStripMenuItem
			// 
			this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			this.exitToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
			this.exitToolStripMenuItem.Text = "Exit";
			this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
			// 
			// optionsToolStripMenuItem
			// 
			this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dontsave,
            this.autosave,
            this.existcopyonly,
            this.warnondelete});
			this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
			this.optionsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
			this.optionsToolStripMenuItem.Text = "Options";
			// 
			// dontsave
			// 
			this.dontsave.CheckOnClick = true;
			this.dontsave.Name = "dontsave";
			this.dontsave.Size = new System.Drawing.Size(289, 22);
			this.dontsave.Text = "Don\'t save form options";
			// 
			// autosave
			// 
			this.autosave.Checked = true;
			this.autosave.CheckState = System.Windows.Forms.CheckState.Checked;
			this.autosave.Name = "autosave";
			this.autosave.Size = new System.Drawing.Size(289, 22);
			this.autosave.Text = "Autosave tree on item change";
			this.autosave.Click += new System.EventHandler(this.autosave_Click);
			// 
			// existcopyonly
			// 
			this.existcopyonly.Checked = true;
			this.existcopyonly.CheckOnClick = true;
			this.existcopyonly.CheckState = System.Windows.Forms.CheckState.Checked;
			this.existcopyonly.Name = "existcopyonly";
			this.existcopyonly.ShowShortcutKeys = false;
			this.existcopyonly.Size = new System.Drawing.Size(289, 22);
			this.existcopyonly.Text = "Do not copy inaccessible files to clipboard";
			// 
			// warnondelete
			// 
			this.warnondelete.Checked = true;
			this.warnondelete.CheckOnClick = true;
			this.warnondelete.CheckState = System.Windows.Forms.CheckState.Checked;
			this.warnondelete.Name = "warnondelete";
			this.warnondelete.Size = new System.Drawing.Size(289, 22);
			this.warnondelete.Text = "Warn on delete actual file";
			// 
			// toolsToolStripMenuItem
			// 
			this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.replaceAllDotsWithSpacesInRelativePathsToolStripMenuItem,
            this.replaceAllSpacesWithDotsInTheRelativePathToolStripMenuItem,
            this.useCamelCaseWithAllRelativePathCharactersToolStripMenuItem,
            this.replaceAllCharactersWithLowerCaseInRelativePathsToolStripMenuItem,
            this.revertRelativePathsToProperNameToolStripMenuItem});
			this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
			this.toolsToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
			this.toolsToolStripMenuItem.Text = "Tools";
			// 
			// replaceAllDotsWithSpacesInRelativePathsToolStripMenuItem
			// 
			this.replaceAllDotsWithSpacesInRelativePathsToolStripMenuItem.Name = "replaceAllDotsWithSpacesInRelativePathsToolStripMenuItem";
			this.replaceAllDotsWithSpacesInRelativePathsToolStripMenuItem.Size = new System.Drawing.Size(321, 22);
			this.replaceAllDotsWithSpacesInRelativePathsToolStripMenuItem.Text = "Replace all dots with spaces in relative paths";
			this.replaceAllDotsWithSpacesInRelativePathsToolStripMenuItem.Click += new System.EventHandler(this.replaceAllDotsWithSpacesInRelativePathsToolStripMenuItem_Click);
			// 
			// replaceAllSpacesWithDotsInTheRelativePathToolStripMenuItem
			// 
			this.replaceAllSpacesWithDotsInTheRelativePathToolStripMenuItem.Name = "replaceAllSpacesWithDotsInTheRelativePathToolStripMenuItem";
			this.replaceAllSpacesWithDotsInTheRelativePathToolStripMenuItem.Size = new System.Drawing.Size(321, 22);
			this.replaceAllSpacesWithDotsInTheRelativePathToolStripMenuItem.Text = "Replace all spaces with dots in relative paths";
			this.replaceAllSpacesWithDotsInTheRelativePathToolStripMenuItem.Click += new System.EventHandler(this.replaceAllSpacesWithDotsInTheRelativePathToolStripMenuItem_Click);
			// 
			// useCamelCaseWithAllRelativePathCharactersToolStripMenuItem
			// 
			this.useCamelCaseWithAllRelativePathCharactersToolStripMenuItem.Name = "useCamelCaseWithAllRelativePathCharactersToolStripMenuItem";
			this.useCamelCaseWithAllRelativePathCharactersToolStripMenuItem.Size = new System.Drawing.Size(321, 22);
			this.useCamelCaseWithAllRelativePathCharactersToolStripMenuItem.Text = "Use CamelCase with all relative path characters";
			this.useCamelCaseWithAllRelativePathCharactersToolStripMenuItem.Click += new System.EventHandler(this.useCamelCaseWithAllRelativePathCharactersToolStripMenuItem_Click_1);
			// 
			// replaceAllCharactersWithLowerCaseInRelativePathsToolStripMenuItem
			// 
			this.replaceAllCharactersWithLowerCaseInRelativePathsToolStripMenuItem.Name = "replaceAllCharactersWithLowerCaseInRelativePathsToolStripMenuItem";
			this.replaceAllCharactersWithLowerCaseInRelativePathsToolStripMenuItem.Size = new System.Drawing.Size(321, 22);
			this.replaceAllCharactersWithLowerCaseInRelativePathsToolStripMenuItem.Text = "Use lowercase with all relative path characters";
			this.replaceAllCharactersWithLowerCaseInRelativePathsToolStripMenuItem.Click += new System.EventHandler(this.replaceAllCharactersWithLowerCaseInRelativePathsToolStripMenuItem_Click_1);
			// 
			// revertRelativePathsToProperNameToolStripMenuItem
			// 
			this.revertRelativePathsToProperNameToolStripMenuItem.Name = "revertRelativePathsToProperNameToolStripMenuItem";
			this.revertRelativePathsToProperNameToolStripMenuItem.Size = new System.Drawing.Size(321, 22);
			this.revertRelativePathsToProperNameToolStripMenuItem.Text = "Revert relative paths to proper name";
			this.revertRelativePathsToProperNameToolStripMenuItem.Click += new System.EventHandler(this.revertRelativePathsToProperNameToolStripMenuItem_Click);
			// 
			// TC
			// 
			this.TC.Controls.Add(this.savetabpage);
			this.TC.Controls.Add(this.viewtabpage);
			this.TC.Controls.Add(this.tabPage1);
			this.TC.Dock = System.Windows.Forms.DockStyle.Fill;
			this.TC.Location = new System.Drawing.Point(0, 24);
			this.TC.Name = "TC";
			this.TC.SelectedIndex = 0;
			this.TC.Size = new System.Drawing.Size(678, 596);
			this.TC.TabIndex = 13;
			// 
			// savetabpage
			// 
			this.savetabpage.Controls.Add(this.panel1);
			this.savetabpage.Controls.Add(this.groupBox2);
			this.savetabpage.Controls.Add(this.groupBox1);
			this.savetabpage.Location = new System.Drawing.Point(4, 22);
			this.savetabpage.Name = "savetabpage";
			this.savetabpage.Padding = new System.Windows.Forms.Padding(3);
			this.savetabpage.Size = new System.Drawing.Size(670, 570);
			this.savetabpage.TabIndex = 0;
			this.savetabpage.Text = "Save";
			this.savetabpage.UseVisualStyleBackColor = true;
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.savebutton);
			this.panel1.Controls.Add(this.savefilesize);
			this.panel1.Controls.Add(this.maxdepth);
			this.panel1.Controls.Add(this.label3);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel1.Location = new System.Drawing.Point(3, 467);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(664, 100);
			this.panel1.TabIndex = 9;
			// 
			// savebutton
			// 
			this.savebutton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.savebutton.Location = new System.Drawing.Point(6, 72);
			this.savebutton.Name = "savebutton";
			this.savebutton.Size = new System.Drawing.Size(649, 23);
			this.savebutton.TabIndex = 3;
			this.savebutton.Text = "Save Folder Structure to File";
			this.savebutton.UseVisualStyleBackColor = true;
			this.savebutton.Click += new System.EventHandler(this.savebutton_Click);
			// 
			// savefilesize
			// 
			this.savefilesize.AutoSize = true;
			this.savefilesize.Checked = true;
			this.savefilesize.CheckState = System.Windows.Forms.CheckState.Checked;
			this.savefilesize.Location = new System.Drawing.Point(6, 9);
			this.savefilesize.Name = "savefilesize";
			this.savefilesize.Size = new System.Drawing.Size(93, 17);
			this.savefilesize.TabIndex = 4;
			this.savefilesize.Text = "Save File Size";
			this.savefilesize.UseVisualStyleBackColor = true;
			// 
			// maxdepth
			// 
			this.maxdepth.FormattingEnabled = true;
			this.maxdepth.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "10"});
			this.maxdepth.Location = new System.Drawing.Point(6, 45);
			this.maxdepth.MaxLength = 3;
			this.maxdepth.Name = "maxdepth";
			this.maxdepth.Size = new System.Drawing.Size(57, 21);
			this.maxdepth.TabIndex = 5;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(3, 29);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(94, 13);
			this.label3.TabIndex = 6;
			this.label3.Text = "Max Folder Depth:";
			// 
			// groupBox2
			// 
			this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox2.Controls.Add(this.unselectallbutton);
			this.groupBox2.Controls.Add(this.refreshtreebutton);
			this.groupBox2.Controls.Add(this.multiselecttree);
			this.groupBox2.Location = new System.Drawing.Point(3, 99);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(661, 362);
			this.groupBox2.TabIndex = 8;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Multiple Selection";
			// 
			// unselectallbutton
			// 
			this.unselectallbutton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.unselectallbutton.Location = new System.Drawing.Point(87, 330);
			this.unselectallbutton.Name = "unselectallbutton";
			this.unselectallbutton.Size = new System.Drawing.Size(75, 23);
			this.unselectallbutton.TabIndex = 2;
			this.unselectallbutton.Text = "Unselect all";
			this.unselectallbutton.UseVisualStyleBackColor = true;
			this.unselectallbutton.Click += new System.EventHandler(this.unselectallbutton_Click);
			// 
			// refreshtreebutton
			// 
			this.refreshtreebutton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.refreshtreebutton.Location = new System.Drawing.Point(6, 330);
			this.refreshtreebutton.Name = "refreshtreebutton";
			this.refreshtreebutton.Size = new System.Drawing.Size(75, 23);
			this.refreshtreebutton.TabIndex = 1;
			this.refreshtreebutton.Text = "Refresh";
			this.refreshtreebutton.UseVisualStyleBackColor = true;
			this.refreshtreebutton.Click += new System.EventHandler(this.refreshtreebutton_Click);
			// 
			// multiselecttree
			// 
			this.multiselecttree.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.multiselecttree.CheckBoxes = true;
			this.multiselecttree.Location = new System.Drawing.Point(6, 19);
			this.multiselecttree.Name = "multiselecttree";
			this.multiselecttree.Size = new System.Drawing.Size(649, 306);
			this.multiselecttree.TabIndex = 0;
			this.multiselecttree.BeforeCheck += new System.Windows.Forms.TreeViewCancelEventHandler(this.multiselecttree_AfterCheck);
			this.multiselecttree.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.multiselecttree_BeforeExpand);
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox1.Controls.Add(this.foldertext);
			this.groupBox1.Controls.Add(this.selectfolder);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Location = new System.Drawing.Point(3, 6);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(661, 87);
			this.groupBox1.TabIndex = 7;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Individual Selection";
			// 
			// foldertext
			// 
			this.foldertext.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.foldertext.Location = new System.Drawing.Point(6, 37);
			this.foldertext.MaxLength = 200;
			this.foldertext.Name = "foldertext";
			this.foldertext.Size = new System.Drawing.Size(552, 20);
			this.foldertext.TabIndex = 2;
			// 
			// selectfolder
			// 
			this.selectfolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.selectfolder.Location = new System.Drawing.Point(564, 35);
			this.selectfolder.Name = "selectfolder";
			this.selectfolder.Size = new System.Drawing.Size(91, 23);
			this.selectfolder.TabIndex = 1;
			this.selectfolder.Text = "Browse";
			this.selectfolder.UseVisualStyleBackColor = true;
			this.selectfolder.Click += new System.EventHandler(this.selectfolder_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(3, 21);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(107, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Select folder to save:";
			// 
			// viewtabpage
			// 
			this.viewtabpage.Controls.Add(this.statusStrip1);
			this.viewtabpage.Controls.Add(this.autoresize);
			this.viewtabpage.Controls.Add(this.showicon);
			this.viewtabpage.Controls.Add(this.searchbutton);
			this.viewtabpage.Controls.Add(this.outputtree);
			this.viewtabpage.Controls.Add(this.livesearch);
			this.viewtabpage.Controls.Add(this.viewfilebutton);
			this.viewtabpage.Controls.Add(this.label2);
			this.viewtabpage.Controls.Add(this.collapsebutton);
			this.viewtabpage.Controls.Add(this.viewpath);
			this.viewtabpage.Controls.Add(this.viewfolder);
			this.viewtabpage.Controls.Add(this.expandbutton);
			this.viewtabpage.Location = new System.Drawing.Point(4, 22);
			this.viewtabpage.Name = "viewtabpage";
			this.viewtabpage.Padding = new System.Windows.Forms.Padding(3);
			this.viewtabpage.Size = new System.Drawing.Size(670, 570);
			this.viewtabpage.TabIndex = 1;
			this.viewtabpage.Text = "View";
			this.viewtabpage.UseVisualStyleBackColor = true;
			// 
			// statusStrip1
			// 
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripProgressBar1,
            this.Status1,
            this.toolStripStatusLabel2,
            this.Status2});
			this.statusStrip1.Location = new System.Drawing.Point(3, 545);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(664, 22);
			this.statusStrip1.TabIndex = 28;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// toolStripProgressBar1
			// 
			this.toolStripProgressBar1.Name = "toolStripProgressBar1";
			this.toolStripProgressBar1.Size = new System.Drawing.Size(100, 16);
			// 
			// Status1
			// 
			this.Status1.Name = "Status1";
			this.Status1.Size = new System.Drawing.Size(12, 17);
			this.Status1.Text = "-";
			// 
			// toolStripStatusLabel2
			// 
			this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
			this.toolStripStatusLabel2.Size = new System.Drawing.Size(12, 17);
			this.toolStripStatusLabel2.Text = "/";
			// 
			// Status2
			// 
			this.Status2.Name = "Status2";
			this.Status2.Size = new System.Drawing.Size(12, 17);
			this.Status2.Text = "-";
			// 
			// autoresize
			// 
			this.autoresize.Location = new System.Drawing.Point(205, 112);
			this.autoresize.Name = "autoresize";
			this.autoresize.Size = new System.Drawing.Size(116, 23);
			this.autoresize.TabIndex = 27;
			this.autoresize.Text = "Auto Resize Columns";
			this.autoresize.UseVisualStyleBackColor = true;
			this.autoresize.Click += new System.EventHandler(this.autoresize_Click);
			// 
			// showicon
			// 
			this.showicon.AutoSize = true;
			this.showicon.Location = new System.Drawing.Point(8, 54);
			this.showicon.Name = "showicon";
			this.showicon.Size = new System.Drawing.Size(101, 17);
			this.showicon.TabIndex = 26;
			this.showicon.Text = "Show File Icons";
			this.showicon.UseVisualStyleBackColor = true;
			// 
			// searchbutton
			// 
			this.searchbutton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.searchbutton.Location = new System.Drawing.Point(589, 112);
			this.searchbutton.Name = "searchbutton";
			this.searchbutton.Size = new System.Drawing.Size(75, 23);
			this.searchbutton.TabIndex = 25;
			this.searchbutton.Text = "Search (Regex)";
			this.searchbutton.UseVisualStyleBackColor = true;
			this.searchbutton.Click += new System.EventHandler(this.searchbutton_Click);
			// 
			// viewContextStrip
			// 
			this.viewContextStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openBaseFolderInExplorerToolStripMenuItem,
            this.removeItemFromListToolStripMenuItem,
            this.recalculateFileSizesToolStripMenuItem,
            this.addFileToTreeToolStripMenuItem,
            this.addFolderToTreeToolStripMenuItem,
            this.copySelectedFilesToClipboardToolStripMenuItem,
            this.getDuplicateFilesToolStripMenuItem,
            this.getRatingsToolStripMenuItem});
			this.viewContextStrip.Name = "viewContextStrip";
			this.viewContextStrip.Size = new System.Drawing.Size(248, 180);
			this.viewContextStrip.Opening += new System.ComponentModel.CancelEventHandler(this.viewContextStrip_Opening);
			// 
			// openBaseFolderInExplorerToolStripMenuItem
			// 
			this.openBaseFolderInExplorerToolStripMenuItem.Name = "openBaseFolderInExplorerToolStripMenuItem";
			this.openBaseFolderInExplorerToolStripMenuItem.Size = new System.Drawing.Size(247, 22);
			this.openBaseFolderInExplorerToolStripMenuItem.Text = "Select In Explorer";
			this.openBaseFolderInExplorerToolStripMenuItem.Click += new System.EventHandler(this.openBaseFolderInExplorerToolStripMenuItem_Click);
			// 
			// removeItemFromListToolStripMenuItem
			// 
			this.removeItemFromListToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.justRemoveItemFromListToolStripMenuItem,
            this.toolStripSeparator1,
            this.deleteSourceFileAsWellToolStripMenuItem});
			this.removeItemFromListToolStripMenuItem.Name = "removeItemFromListToolStripMenuItem";
			this.removeItemFromListToolStripMenuItem.Size = new System.Drawing.Size(247, 22);
			this.removeItemFromListToolStripMenuItem.Text = "Remove Item From List";
			// 
			// justRemoveItemFromListToolStripMenuItem
			// 
			this.justRemoveItemFromListToolStripMenuItem.Name = "justRemoveItemFromListToolStripMenuItem";
			this.justRemoveItemFromListToolStripMenuItem.Size = new System.Drawing.Size(219, 22);
			this.justRemoveItemFromListToolStripMenuItem.Text = "Just Remove Item From List";
			this.justRemoveItemFromListToolStripMenuItem.Click += new System.EventHandler(this.removeItemFromListToolStripMenuItem_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(216, 6);
			// 
			// deleteSourceFileAsWellToolStripMenuItem
			// 
			this.deleteSourceFileAsWellToolStripMenuItem.Name = "deleteSourceFileAsWellToolStripMenuItem";
			this.deleteSourceFileAsWellToolStripMenuItem.Size = new System.Drawing.Size(219, 22);
			this.deleteSourceFileAsWellToolStripMenuItem.Text = "Delete Source File As Well";
			this.deleteSourceFileAsWellToolStripMenuItem.Click += new System.EventHandler(this.deleteSourceFileAsWellToolStripMenuItem_Click);
			// 
			// recalculateFileSizesToolStripMenuItem
			// 
			this.recalculateFileSizesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.recalculateAllSubitemsAsWellToolStripMenuItem,
            this.recalculateSelectedOnlyToolStripMenuItem});
			this.recalculateFileSizesToolStripMenuItem.Name = "recalculateFileSizesToolStripMenuItem";
			this.recalculateFileSizesToolStripMenuItem.Size = new System.Drawing.Size(247, 22);
			this.recalculateFileSizesToolStripMenuItem.Text = "Recalculate File Sizes";
			// 
			// recalculateAllSubitemsAsWellToolStripMenuItem
			// 
			this.recalculateAllSubitemsAsWellToolStripMenuItem.Name = "recalculateAllSubitemsAsWellToolStripMenuItem";
			this.recalculateAllSubitemsAsWellToolStripMenuItem.Size = new System.Drawing.Size(238, 22);
			this.recalculateAllSubitemsAsWellToolStripMenuItem.Text = "Recalculate all subitems as well";
			this.recalculateAllSubitemsAsWellToolStripMenuItem.Click += new System.EventHandler(this.recalculateAllSubitemsAsWellToolStripMenuItem_Click);
			// 
			// recalculateSelectedOnlyToolStripMenuItem
			// 
			this.recalculateSelectedOnlyToolStripMenuItem.Name = "recalculateSelectedOnlyToolStripMenuItem";
			this.recalculateSelectedOnlyToolStripMenuItem.Size = new System.Drawing.Size(238, 22);
			this.recalculateSelectedOnlyToolStripMenuItem.Text = "Recalculate selected only";
			this.recalculateSelectedOnlyToolStripMenuItem.Click += new System.EventHandler(this.recalculateSelectedOnlyToolStripMenuItem_Click);
			// 
			// addFileToTreeToolStripMenuItem
			// 
			this.addFileToTreeToolStripMenuItem.Name = "addFileToTreeToolStripMenuItem";
			this.addFileToTreeToolStripMenuItem.Size = new System.Drawing.Size(247, 22);
			this.addFileToTreeToolStripMenuItem.Text = "Add File To List";
			this.addFileToTreeToolStripMenuItem.Click += new System.EventHandler(this.addFileToTreeToolStripMenuItem_Click);
			// 
			// addFolderToTreeToolStripMenuItem
			// 
			this.addFolderToTreeToolStripMenuItem.Name = "addFolderToTreeToolStripMenuItem";
			this.addFolderToTreeToolStripMenuItem.Size = new System.Drawing.Size(247, 22);
			this.addFolderToTreeToolStripMenuItem.Text = "Add Folder To List";
			this.addFolderToTreeToolStripMenuItem.Click += new System.EventHandler(this.addFolderToTreeToolStripMenuItem_Click);
			// 
			// copySelectedFilesToClipboardToolStripMenuItem
			// 
			this.copySelectedFilesToClipboardToolStripMenuItem.Name = "copySelectedFilesToClipboardToolStripMenuItem";
			this.copySelectedFilesToClipboardToolStripMenuItem.Size = new System.Drawing.Size(247, 22);
			this.copySelectedFilesToClipboardToolStripMenuItem.Text = "Copy Selected Files To Clipboard";
			this.copySelectedFilesToClipboardToolStripMenuItem.Click += new System.EventHandler(this.copySelectedFilesToClipboardToolStripMenuItem_Click);
			// 
			// getDuplicateFilesToolStripMenuItem
			// 
			this.getDuplicateFilesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exactNameMatchesOnlyToolStripMenuItem,
            this.fuzzyNameMatchesOnlyToolStripMenuItem});
			this.getDuplicateFilesToolStripMenuItem.Name = "getDuplicateFilesToolStripMenuItem";
			this.getDuplicateFilesToolStripMenuItem.Size = new System.Drawing.Size(247, 22);
			this.getDuplicateFilesToolStripMenuItem.Text = "Get Duplicate Files";
			// 
			// exactNameMatchesOnlyToolStripMenuItem
			// 
			this.exactNameMatchesOnlyToolStripMenuItem.Name = "exactNameMatchesOnlyToolStripMenuItem";
			this.exactNameMatchesOnlyToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
			this.exactNameMatchesOnlyToolStripMenuItem.Text = "Exact Name Matches Only";
			this.exactNameMatchesOnlyToolStripMenuItem.Click += new System.EventHandler(this.exactNameMatchesOnlyToolStripMenuItem_Click);
			// 
			// fuzzyNameMatchesOnlyToolStripMenuItem
			// 
			this.fuzzyNameMatchesOnlyToolStripMenuItem.Name = "fuzzyNameMatchesOnlyToolStripMenuItem";
			this.fuzzyNameMatchesOnlyToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
			this.fuzzyNameMatchesOnlyToolStripMenuItem.Text = "Fuzzy Name Matches Only";
			this.fuzzyNameMatchesOnlyToolStripMenuItem.Click += new System.EventHandler(this.fuzzyNameMatchesOnlyToolStripMenuItem_Click);
			// 
			// getRatingsToolStripMenuItem
			// 
			this.getRatingsToolStripMenuItem.Name = "getRatingsToolStripMenuItem";
			this.getRatingsToolStripMenuItem.Size = new System.Drawing.Size(247, 22);
			this.getRatingsToolStripMenuItem.Text = "Get Ratings";
			this.getRatingsToolStripMenuItem.Click += new System.EventHandler(this.getRatingsToolStripMenuItem_Click);
			// 
			// livesearch
			// 
			this.livesearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.livesearch.Location = new System.Drawing.Point(380, 114);
			this.livesearch.Name = "livesearch";
			this.livesearch.Size = new System.Drawing.Size(206, 20);
			this.livesearch.TabIndex = 22;
			this.livesearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.livesearch_KeyPress);
			// 
			// viewfilebutton
			// 
			this.viewfilebutton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.viewfilebutton.Location = new System.Drawing.Point(8, 77);
			this.viewfilebutton.Name = "viewfilebutton";
			this.viewfilebutton.Size = new System.Drawing.Size(656, 23);
			this.viewfilebutton.TabIndex = 7;
			this.viewfilebutton.Text = "View Folder Structure in File";
			this.viewfilebutton.UseVisualStyleBackColor = true;
			this.viewfilebutton.Click += new System.EventHandler(this.viewfilebutton_Click);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(5, 12);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(166, 13);
			this.label2.TabIndex = 5;
			this.label2.Text = "Select folder structure file to view:";
			// 
			// collapsebutton
			// 
			this.collapsebutton.Location = new System.Drawing.Point(102, 112);
			this.collapsebutton.Name = "collapsebutton";
			this.collapsebutton.Size = new System.Drawing.Size(97, 23);
			this.collapsebutton.TabIndex = 20;
			this.collapsebutton.Text = "Collapse Tree";
			this.collapsebutton.UseVisualStyleBackColor = true;
			this.collapsebutton.Click += new System.EventHandler(this.collapsebutton_Click);
			// 
			// viewpath
			// 
			this.viewpath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.viewpath.Location = new System.Drawing.Point(8, 28);
			this.viewpath.MaxLength = 200;
			this.viewpath.Name = "viewpath";
			this.viewpath.Size = new System.Drawing.Size(553, 20);
			this.viewpath.TabIndex = 4;
			// 
			// viewfolder
			// 
			this.viewfolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.viewfolder.Location = new System.Drawing.Point(567, 26);
			this.viewfolder.Name = "viewfolder";
			this.viewfolder.Size = new System.Drawing.Size(97, 23);
			this.viewfolder.TabIndex = 3;
			this.viewfolder.Text = "Browse";
			this.viewfolder.UseVisualStyleBackColor = true;
			this.viewfolder.Click += new System.EventHandler(this.viewfolder_Click);
			// 
			// expandbutton
			// 
			this.expandbutton.Location = new System.Drawing.Point(8, 112);
			this.expandbutton.Name = "expandbutton";
			this.expandbutton.Size = new System.Drawing.Size(88, 23);
			this.expandbutton.TabIndex = 19;
			this.expandbutton.Text = "Expand Tree";
			this.expandbutton.UseVisualStyleBackColor = true;
			this.expandbutton.Click += new System.EventHandler(this.expandbutton_Click);
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.selectnone);
			this.tabPage1.Controls.Add(this.selectall);
			this.tabPage1.Controls.Add(this.label4);
			this.tabPage1.Controls.Add(this.baselevelsremove);
			this.tabPage1.Controls.Add(this.filelist);
			this.tabPage1.Controls.Add(this.randomname);
			this.tabPage1.Controls.Add(this.mergebutton);
			this.tabPage1.Controls.Add(this.outputfilename);
			this.tabPage1.Controls.Add(this.label6);
			this.tabPage1.Controls.Add(this.label5);
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(670, 570);
			this.tabPage1.TabIndex = 2;
			this.tabPage1.Text = "Merge";
			this.tabPage1.UseVisualStyleBackColor = true;
			this.tabPage1.Enter += new System.EventHandler(this.tabPage1_Enter);
			// 
			// selectnone
			// 
			this.selectnone.Location = new System.Drawing.Point(90, 31);
			this.selectnone.Name = "selectnone";
			this.selectnone.Size = new System.Drawing.Size(75, 23);
			this.selectnone.TabIndex = 19;
			this.selectnone.Text = "Select None";
			this.selectnone.UseVisualStyleBackColor = true;
			this.selectnone.Click += new System.EventHandler(this.selectnone_Click);
			// 
			// selectall
			// 
			this.selectall.Location = new System.Drawing.Point(9, 31);
			this.selectall.Name = "selectall";
			this.selectall.Size = new System.Drawing.Size(75, 23);
			this.selectall.TabIndex = 18;
			this.selectall.Text = "Select All";
			this.selectall.UseVisualStyleBackColor = true;
			this.selectall.Click += new System.EventHandler(this.selectall_Click);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(313, 143);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(149, 13);
			this.label4.TabIndex = 17;
			this.label4.Text = "Remove base directory levels:";
			// 
			// baselevelsremove
			// 
			this.baselevelsremove.FormattingEnabled = true;
			this.baselevelsremove.Items.AddRange(new object[] {
            "0",
            "1",
            "2"});
			this.baselevelsremove.Location = new System.Drawing.Point(302, 159);
			this.baselevelsremove.Name = "baselevelsremove";
			this.baselevelsremove.Size = new System.Drawing.Size(121, 21);
			this.baselevelsremove.TabIndex = 16;
			this.baselevelsremove.TextChanged += new System.EventHandler(this.baselevelsremove_TextChanged);
			this.baselevelsremove.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.baselevelsremove_KeyPress);
			// 
			// filelist
			// 
			this.filelist.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)));
			this.filelist.CheckOnClick = true;
			this.filelist.FormattingEnabled = true;
			this.filelist.Location = new System.Drawing.Point(9, 61);
			this.filelist.Name = "filelist";
			this.filelist.Size = new System.Drawing.Size(287, 499);
			this.filelist.TabIndex = 14;
			// 
			// randomname
			// 
			this.randomname.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.randomname.Location = new System.Drawing.Point(560, 59);
			this.randomname.Name = "randomname";
			this.randomname.Size = new System.Drawing.Size(102, 23);
			this.randomname.TabIndex = 13;
			this.randomname.Text = "Get Current Time";
			this.randomname.UseVisualStyleBackColor = true;
			this.randomname.Click += new System.EventHandler(this.randomname_Click);
			// 
			// mergebutton
			// 
			this.mergebutton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.mergebutton.Location = new System.Drawing.Point(302, 186);
			this.mergebutton.Name = "mergebutton";
			this.mergebutton.Size = new System.Drawing.Size(360, 23);
			this.mergebutton.TabIndex = 12;
			this.mergebutton.Text = "Merge";
			this.mergebutton.UseVisualStyleBackColor = true;
			this.mergebutton.Click += new System.EventHandler(this.mergebutton_Click);
			// 
			// outputfilename
			// 
			this.outputfilename.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.outputfilename.Location = new System.Drawing.Point(302, 61);
			this.outputfilename.MaxLength = 200;
			this.outputfilename.Multiline = true;
			this.outputfilename.Name = "outputfilename";
			this.outputfilename.Size = new System.Drawing.Size(255, 68);
			this.outputfilename.TabIndex = 11;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(313, 45);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(110, 13);
			this.label6.TabIndex = 10;
			this.label6.Text = "Enter output filename:";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(6, 15);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(123, 13);
			this.label5.TabIndex = 7;
			this.label5.Text = "Select the files to merge:";
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "File Path";
			this.columnHeader1.Width = 512;
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "Size";
			// 
			// outputtree
			// 
			this.outputtree.AllowDrop = true;
			this.outputtree.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.outputtree.BackColor = System.Drawing.SystemColors.Window;
			this.outputtree.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6});
			treeListViewItemCollectionComparer1.Column = 0;
			treeListViewItemCollectionComparer1.SortOrder = System.Windows.Forms.SortOrder.Ascending;
			this.outputtree.Comparer = treeListViewItemCollectionComparer1;
			this.outputtree.ContextMenuStrip = this.viewContextStrip;
			this.outputtree.ExpandMethod = System.Windows.Forms.TreeListViewExpandMethod.IconDbleClick;
			this.outputtree.GridLines = true;
			this.outputtree.Location = new System.Drawing.Point(8, 141);
			this.outputtree.Name = "outputtree";
			this.outputtree.Size = new System.Drawing.Size(659, 401);
			this.outputtree.SmallImageList = this.imageList1;
			this.outputtree.TabIndex = 24;
			this.outputtree.UseCompatibleStateImageBehavior = false;
			this.outputtree.AfterExpand += new System.Windows.Forms.TreeListViewEventHandler(this.outputtree_AfterExpand);
			this.outputtree.AfterCollapse += new System.Windows.Forms.TreeListViewEventHandler(this.outputtree_AfterCollapse);
			this.outputtree.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.outputtree_ItemSelectionChanged);
			this.outputtree.DragDrop += new System.Windows.Forms.DragEventHandler(this.outputtree_DragDrop);
			this.outputtree.DragEnter += new System.Windows.Forms.DragEventHandler(this.outputtree_DragEnter);
			this.outputtree.DoubleClick += new System.EventHandler(this.outputtree_DoubleClick);
			this.outputtree.KeyUp += new System.Windows.Forms.KeyEventHandler(this.outputtree_KeyUp);
			// 
			// columnHeader3
			// 
			this.columnHeader3.Text = "Relative Path";
			this.columnHeader3.Width = 375;
			// 
			// columnHeader4
			// 
			this.columnHeader4.Text = "Size";
			this.columnHeader4.Width = 91;
			// 
			// columnHeader5
			// 
			this.columnHeader5.Text = "Full Path";
			// 
			// columnHeader6
			// 
			this.columnHeader6.Text = "Rating";
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(678, 620);
			this.Controls.Add(this.TC);
			this.Controls.Add(this.menuStrip1);
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "Form1";
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "REPLACE";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
			this.Load += new System.EventHandler(this.Form1_Load);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.TC.ResumeLayout(false);
			this.savetabpage.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.viewtabpage.ResumeLayout(false);
			this.viewtabpage.PerformLayout();
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			this.viewContextStrip.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
		private System.Windows.Forms.TabControl TC;
		private System.Windows.Forms.TabPage savetabpage;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ComboBox maxdepth;
		public System.Windows.Forms.CheckBox savefilesize;
		private System.Windows.Forms.Button savebutton;
		private System.Windows.Forms.TextBox foldertext;
		private System.Windows.Forms.Button selectfolder;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TabPage viewtabpage;
		private System.Windows.Forms.Button viewfilebutton;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button collapsebutton;
		private System.Windows.Forms.TextBox viewpath;
		private System.Windows.Forms.Button viewfolder;
		private System.Windows.Forms.Button expandbutton;
		private System.Windows.Forms.TextBox livesearch;
		private System.Windows.Forms.TreeListView outputtree;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Button mergebutton;
		private System.Windows.Forms.TextBox outputfilename;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Button randomname;
		private System.Windows.Forms.CheckedListBox filelist;
		private System.Windows.Forms.Button searchbutton;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		private System.Windows.Forms.ColumnHeader columnHeader4;
		private System.Windows.Forms.ColumnHeader columnHeader5;
		private System.Windows.Forms.ContextMenuStrip viewContextStrip;
		private System.Windows.Forms.ToolStripMenuItem openBaseFolderInExplorerToolStripMenuItem;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.ComboBox baselevelsremove;
		private System.Windows.Forms.ToolStripMenuItem removeItemFromListToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
		public System.Windows.Forms.ToolStripMenuItem autosave;
		private System.Windows.Forms.ToolStripMenuItem recalculateFileSizesToolStripMenuItem;
		public System.Windows.Forms.CheckBox showicon;
		private System.Windows.Forms.ToolStripMenuItem addFileToTreeToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem addFolderToTreeToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem recalculateAllSubitemsAsWellToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem recalculateSelectedOnlyToolStripMenuItem;
		private System.Windows.Forms.Button selectnone;
		private System.Windows.Forms.Button selectall;
		private System.Windows.Forms.Button autoresize;
		private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem replaceAllSpacesWithDotsInTheRelativePathToolStripMenuItem;
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
		private System.Windows.Forms.ToolStripStatusLabel Status1;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
		public System.Windows.Forms.ToolStripStatusLabel Status2;
		private System.Windows.Forms.ToolStripMenuItem revertRelativePathsToProperNameToolStripMenuItem;
		public System.Windows.Forms.ToolStripMenuItem dontsave;
		private System.Windows.Forms.ToolStripMenuItem copySelectedFilesToClipboardToolStripMenuItem;
		public System.Windows.Forms.ToolStripMenuItem existcopyonly;
		public System.Windows.Forms.ToolStripMenuItem warnondelete;
		private System.Windows.Forms.ToolStripMenuItem deleteSourceFileAsWellToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem justRemoveItemFromListToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripMenuItem getDuplicateFilesToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem exactNameMatchesOnlyToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem fuzzyNameMatchesOnlyToolStripMenuItem;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.TreeView multiselecttree;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button refreshtreebutton;
		private System.Windows.Forms.Button unselectallbutton;
		private System.Windows.Forms.ToolStripMenuItem replaceAllDotsWithSpacesInRelativePathsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem replaceAllCharactersWithLowerCaseInRelativePathsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem useCamelCaseWithAllRelativePathCharactersToolStripMenuItem;
		private System.Windows.Forms.ColumnHeader columnHeader6;
		private System.Windows.Forms.ToolStripMenuItem getRatingsToolStripMenuItem;

    }
}

