namespace Alfred
{
    partial class UI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UI));
            this.alfredTag = new System.Windows.Forms.Label();
            this.intelliBar = new System.Windows.Forms.TextBox();
            this.alfredSays = new System.Windows.Forms.Label();
            this.sysTray = new System.Windows.Forms.NotifyIcon(this.components);
            this.sysTrayMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.maximizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.expandContract = new System.Windows.Forms.PictureBox();
            this.listView = new System.Windows.Forms.ListView();
            this.serialNo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.taskDescription = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.start = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.end = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tag = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.sysTrayMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.expandContract)).BeginInit();
            this.SuspendLayout();
            // 
            // alfredTag
            // 
            this.alfredTag.AutoSize = true;
            this.alfredTag.BackColor = System.Drawing.Color.Transparent;
            this.alfredTag.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.alfredTag.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.alfredTag.Location = new System.Drawing.Point(60, 62);
            this.alfredTag.Name = "alfredTag";
            this.alfredTag.Size = new System.Drawing.Size(51, 18);
            this.alfredTag.TabIndex = 3;
            this.alfredTag.Text = "Alfred:";
            // 
            // intelliBar
            // 
            this.intelliBar.AutoCompleteCustomSource.AddRange(new string[] {
            "add",
            "edit",
            "delete",
            "undo",
            "redo",
            "search",
            "exit",
            "help",
            "complete",
            "all",
            "archive",
            "clear",
            "uncomplete"});
            this.intelliBar.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.intelliBar.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.intelliBar.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.intelliBar.Location = new System.Drawing.Point(63, 40);
            this.intelliBar.Name = "intelliBar";
            this.intelliBar.Size = new System.Drawing.Size(550, 22);
            this.intelliBar.TabIndex = 4;
            this.intelliBar.TextChanged += new System.EventHandler(this.intelliBar_TextChanged);
            this.intelliBar.KeyDown += new System.Windows.Forms.KeyEventHandler(this.intelliBar_KeyDown);
            // 
            // alfredSays
            // 
            this.alfredSays.AutoSize = true;
            this.alfredSays.BackColor = System.Drawing.Color.Transparent;
            this.alfredSays.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.alfredSays.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.alfredSays.Location = new System.Drawing.Point(117, 64);
            this.alfredSays.Name = "alfredSays";
            this.alfredSays.Size = new System.Drawing.Size(0, 15);
            this.alfredSays.TabIndex = 7;
            // 
            // sysTray
            // 
            this.sysTray.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.sysTray.BalloonTipText = "Alfred is Minimized to Systrem Tray";
            this.sysTray.ContextMenuStrip = this.sysTrayMenu;
            this.sysTray.Icon = ((System.Drawing.Icon)(resources.GetObject("sysTray.Icon")));
            this.sysTray.Text = "Alfred";
            this.sysTray.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.sysTray_MouseDoubleClick);
            // 
            // sysTrayMenu
            // 
            this.sysTrayMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helpToolStripMenuItem,
            this.maximizeToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.sysTrayMenu.Name = "sysTrayMenu";
            this.sysTrayMenu.Size = new System.Drawing.Size(125, 70);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.helpToolStripMenuItem.Text = "Help";
            this.helpToolStripMenuItem.Click += new System.EventHandler(this.helpToolStripMenuItem_Click);
            // 
            // maximizeToolStripMenuItem
            // 
            this.maximizeToolStripMenuItem.Name = "maximizeToolStripMenuItem";
            this.maximizeToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.maximizeToolStripMenuItem.Text = "Maximize";
            this.maximizeToolStripMenuItem.Click += new System.EventHandler(this.maximizeToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // expandContract
            // 
            this.expandContract.BackColor = System.Drawing.Color.Transparent;
            this.expandContract.Image = global::Alfred.Properties.Resources.expand;
            this.expandContract.Location = new System.Drawing.Point(650, 81);
            this.expandContract.Name = "expandContract";
            this.expandContract.Size = new System.Drawing.Size(32, 23);
            this.expandContract.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.expandContract.TabIndex = 5;
            this.expandContract.TabStop = false;
            this.expandContract.Click += new System.EventHandler(this.expand_contract_Click);
            this.expandContract.MouseEnter += new System.EventHandler(this.expand_contract_MouseEnter);
            this.expandContract.MouseLeave += new System.EventHandler(this.expand_contract_MouseLeave);
            // 
            // listView
            // 
            this.listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.serialNo,
            this.taskDescription,
            this.start,
            this.end,
            this.tag});
            this.listView.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listView.FullRowSelect = true;
            this.listView.Location = new System.Drawing.Point(35, 127);
            this.listView.Name = "listView";
            this.listView.Size = new System.Drawing.Size(628, 310);
            this.listView.TabIndex = 8;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.View = System.Windows.Forms.View.Details;
            // 
            // serialNo
            // 
            this.serialNo.Text = "No.";
            this.serialNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.serialNo.Width = 32;
            // 
            // taskDescription
            // 
            this.taskDescription.Text = "                Task Description";
            this.taskDescription.Width = 228;
            // 
            // start
            // 
            this.start.Text = "Start";
            this.start.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.start.Width = 143;
            // 
            // end
            // 
            this.end.Text = "End";
            this.end.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.end.Width = 142;
            // 
            // tag
            // 
            this.tag.Text = "Tag";
            this.tag.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tag.Width = 76;
            // 
            // UI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImage = global::Alfred.Properties.Resources.Bg_2;
            this.ClientSize = new System.Drawing.Size(694, 113);
            this.Controls.Add(this.listView);
            this.Controls.Add(this.alfredSays);
            this.Controls.Add(this.intelliBar);
            this.Controls.Add(this.alfredTag);
            this.Controls.Add(this.expandContract);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "UI";
            this.Text = "Alfred";
            this.Resize += new System.EventHandler(this.UI_Resize);
            this.sysTrayMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.expandContract)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label alfredTag;
        private System.Windows.Forms.TextBox intelliBar;
        private System.Windows.Forms.Label alfredSays;
        private System.Windows.Forms.NotifyIcon sysTray;
        private System.Windows.Forms.ContextMenuStrip sysTrayMenu;
        private System.Windows.Forms.ToolStripMenuItem maximizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.PictureBox expandContract;
        private System.Windows.Forms.ListView listView;
        private System.Windows.Forms.ColumnHeader serialNo;
        private System.Windows.Forms.ColumnHeader taskDescription;
        private System.Windows.Forms.ColumnHeader start;
        private System.Windows.Forms.ColumnHeader end;
        private System.Windows.Forms.ColumnHeader tag;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
    }
}

