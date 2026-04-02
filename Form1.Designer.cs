namespace LocPackBinReader
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.top_menu = new MenuStrip();
            this.file_menu = new ToolStripMenuItem();
            this.open_item = new ToolStripMenuItem();
            this.toolStripSeparator2 = new ToolStripSeparator();
            this.save_item = new ToolStripMenuItem();
            this.saveas_item = new ToolStripMenuItem();
            this.toolStripSeparator1 = new ToolStripSeparator();
            this.exit_item = new ToolStripMenuItem();
            this.tree = new TreeView();
            this.log = new ListBox();
            this.progress = new ProgressBar();
            this.edit_group = new GroupBox();
            this.save_button = new Button();
            this.label3 = new Label();
            this.id_label = new Label();
            this.text_label = new Label();
            this.pos_viewer = new NumericUpDown();
            this.id_viewer = new TextBox();
            this.text_editor = new TextBox();
            this.top_menu.SuspendLayout();
            this.edit_group.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)this.pos_viewer).BeginInit();
            this.SuspendLayout();
            // 
            // top_menu
            // 
            this.top_menu.Items.AddRange(new ToolStripItem[] { this.file_menu });
            this.top_menu.Location = new Point(0, 0);
            this.top_menu.Name = "top_menu";
            this.top_menu.Size = new Size(800, 24);
            this.top_menu.TabIndex = 2;
            this.top_menu.Text = "menuStrip1";
            // 
            // file_menu
            // 
            this.file_menu.DropDownItems.AddRange(new ToolStripItem[] { this.open_item, this.toolStripSeparator2, this.save_item, this.saveas_item, this.toolStripSeparator1, this.exit_item });
            this.file_menu.Name = "file_menu";
            this.file_menu.Size = new Size(37, 20);
            this.file_menu.Text = "File";
            // 
            // open_item
            // 
            this.open_item.Name = "open_item";
            this.open_item.Size = new Size(180, 22);
            this.open_item.Text = "Open";
            this.open_item.Click += this.open_item_Click;
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new Size(177, 6);
            // 
            // save_item
            // 
            this.save_item.Name = "save_item";
            this.save_item.Size = new Size(180, 22);
            this.save_item.Text = "Save";
            this.save_item.Click += this.save_item_Click;
            // 
            // saveas_item
            // 
            this.saveas_item.Name = "saveas_item";
            this.saveas_item.Size = new Size(180, 22);
            this.saveas_item.Text = "Save As...";
            this.saveas_item.Click += this.saveas_item_Click;
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new Size(177, 6);
            // 
            // exit_item
            // 
            this.exit_item.Name = "exit_item";
            this.exit_item.Size = new Size(180, 22);
            this.exit_item.Text = "Exit";
            this.exit_item.Click += this.exit_item_Click;
            // 
            // tree
            // 
            this.tree.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            this.tree.Location = new Point(12, 27);
            this.tree.Name = "tree";
            this.tree.Size = new Size(417, 411);
            this.tree.TabIndex = 3;
            this.tree.AfterSelect += this.tree_click;
            // 
            // log
            // 
            this.log.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            this.log.FormattingEnabled = true;
            this.log.HorizontalScrollbar = true;
            this.log.ItemHeight = 15;
            this.log.Location = new Point(435, 27);
            this.log.Name = "log";
            this.log.Size = new Size(353, 199);
            this.log.TabIndex = 4;
            // 
            // progress
            // 
            this.progress.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            this.progress.Location = new Point(435, 404);
            this.progress.Name = "progress";
            this.progress.Size = new Size(353, 34);
            this.progress.Step = 0;
            this.progress.TabIndex = 5;
            // 
            // edit_group
            // 
            this.edit_group.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            this.edit_group.Controls.Add(this.save_button);
            this.edit_group.Controls.Add(this.label3);
            this.edit_group.Controls.Add(this.id_label);
            this.edit_group.Controls.Add(this.text_label);
            this.edit_group.Controls.Add(this.pos_viewer);
            this.edit_group.Controls.Add(this.id_viewer);
            this.edit_group.Controls.Add(this.text_editor);
            this.edit_group.Location = new Point(435, 230);
            this.edit_group.Name = "edit_group";
            this.edit_group.Size = new Size(353, 168);
            this.edit_group.TabIndex = 6;
            this.edit_group.TabStop = false;
            this.edit_group.Text = "Edit";
            // 
            // save_button
            // 
            this.save_button.Location = new Point(284, 37);
            this.save_button.Name = "save_button";
            this.save_button.Size = new Size(63, 23);
            this.save_button.TabIndex = 6;
            this.save_button.Text = "Save";
            this.save_button.UseVisualStyleBackColor = true;
            this.save_button.Click += this.save_button_Click;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new Point(199, 19);
            this.label3.Name = "label3";
            this.label3.Size = new Size(53, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "Position:";
            // 
            // id_label
            // 
            this.id_label.AutoSize = true;
            this.id_label.Location = new Point(6, 19);
            this.id_label.Name = "id_label";
            this.id_label.Size = new Size(37, 15);
            this.id_label.TabIndex = 4;
            this.id_label.Text = "GUID:";
            // 
            // text_label
            // 
            this.text_label.AutoSize = true;
            this.text_label.Location = new Point(6, 63);
            this.text_label.Name = "text_label";
            this.text_label.Size = new Size(31, 15);
            this.text_label.TabIndex = 3;
            this.text_label.Text = "Text:";
            // 
            // pos_viewer
            // 
            this.pos_viewer.Enabled = false;
            this.pos_viewer.InterceptArrowKeys = false;
            this.pos_viewer.Location = new Point(199, 37);
            this.pos_viewer.Name = "pos_viewer";
            this.pos_viewer.ReadOnly = true;
            this.pos_viewer.Size = new Size(79, 23);
            this.pos_viewer.TabIndex = 2;
            this.pos_viewer.ThousandsSeparator = true;
            // 
            // id_viewer
            // 
            this.id_viewer.Location = new Point(6, 37);
            this.id_viewer.Name = "id_viewer";
            this.id_viewer.ReadOnly = true;
            this.id_viewer.Size = new Size(187, 23);
            this.id_viewer.TabIndex = 1;
            // 
            // text_editor
            // 
            this.text_editor.Location = new Point(6, 81);
            this.text_editor.Multiline = true;
            this.text_editor.Name = "text_editor";
            this.text_editor.Size = new Size(341, 81);
            this.text_editor.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(800, 450);
            this.Controls.Add(this.edit_group);
            this.Controls.Add(this.progress);
            this.Controls.Add(this.tree);
            this.Controls.Add(this.log);
            this.Controls.Add(this.top_menu);
            this.MainMenuStrip = this.top_menu;
            this.Name = "MainForm";
            this.Text = "LocPackBin Reader";
            this.top_menu.ResumeLayout(false);
            this.top_menu.PerformLayout();
            this.edit_group.ResumeLayout(false);
            this.edit_group.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)this.pos_viewer).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
        private MenuStrip top_menu;
        private ToolStripMenuItem file_menu;
        private ToolStripMenuItem open_item;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripMenuItem save_item;
        private ToolStripMenuItem saveas_item;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem exit_item;
        private TreeView tree;
        private ListBox log;
        private ProgressBar progress;
        private GroupBox edit_group;
        private NumericUpDown pos_viewer;
        private TextBox id_viewer;
        private TextBox text_editor;
        private Label label3;
        private Label id_label;
        private Label text_label;
        private Button save_button;
    }
}
