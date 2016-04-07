﻿namespace StonehearthEditor
{
   partial class EffectsEditorView
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

      #region Component Designer generated code

      /// <summary> 
      /// Required method for Designer support - do not modify 
      /// the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent()
      {
         this.components = new System.ComponentModel.Container();
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EffectsEditorView));
         this.effectsSplitContainer = new System.Windows.Forms.SplitContainer();
         this.treeViewTabControl = new System.Windows.Forms.TabControl();
         this.cubemittersTreeViewTab = new System.Windows.Forms.TabPage();
         this.cubemittersTreeView = new System.Windows.Forms.TreeView();
         this.effectsTreeViewTab = new System.Windows.Forms.TabPage();
         this.effectsEditorTreeView = new System.Windows.Forms.TreeView();
         this.effectsSplitContainer2 = new System.Windows.Forms.SplitContainer();
         this.filePreviewTabs = new System.Windows.Forms.TabControl();
         this.effectsToolStrip = new System.Windows.Forms.ToolStrip();
         this.newFileButton = new System.Windows.Forms.ToolStripButton();
         this.effectsOpenFileButton = new System.Windows.Forms.ToolStripButton();
         this.openEffectsFileDialog = new System.Windows.Forms.OpenFileDialog();
         this.cloneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.effectsEditorContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
         this.saveEffectsFileDialog = new System.Windows.Forms.SaveFileDialog();
         this.helpButton = new System.Windows.Forms.Button();
         this.effectsBuilderView = new StonehearthEditor.EffectsBuilderView();
         ((System.ComponentModel.ISupportInitialize)(this.effectsSplitContainer)).BeginInit();
         this.effectsSplitContainer.Panel1.SuspendLayout();
         this.effectsSplitContainer.Panel2.SuspendLayout();
         this.effectsSplitContainer.SuspendLayout();
         this.treeViewTabControl.SuspendLayout();
         this.cubemittersTreeViewTab.SuspendLayout();
         this.effectsTreeViewTab.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.effectsSplitContainer2)).BeginInit();
         this.effectsSplitContainer2.Panel1.SuspendLayout();
         this.effectsSplitContainer2.Panel2.SuspendLayout();
         this.effectsSplitContainer2.SuspendLayout();
         this.effectsToolStrip.SuspendLayout();
         this.effectsEditorContextMenuStrip.SuspendLayout();
         this.SuspendLayout();
         // 
         // effectsSplitContainer
         // 
         this.effectsSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
         this.effectsSplitContainer.Location = new System.Drawing.Point(0, 25);
         this.effectsSplitContainer.Name = "effectsSplitContainer";
         // 
         // effectsSplitContainer.Panel1
         // 
         this.effectsSplitContainer.Panel1.Controls.Add(this.treeViewTabControl);
         // 
         // effectsSplitContainer.Panel2
         // 
         this.effectsSplitContainer.Panel2.Controls.Add(this.effectsSplitContainer2);
         this.effectsSplitContainer.Size = new System.Drawing.Size(840, 551);
         this.effectsSplitContainer.SplitterDistance = 242;
         this.effectsSplitContainer.TabIndex = 1;
         // 
         // treeViewTabControl
         // 
         this.treeViewTabControl.Controls.Add(this.cubemittersTreeViewTab);
         this.treeViewTabControl.Controls.Add(this.effectsTreeViewTab);
         this.treeViewTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
         this.treeViewTabControl.Location = new System.Drawing.Point(0, 0);
         this.treeViewTabControl.Name = "treeViewTabControl";
         this.treeViewTabControl.SelectedIndex = 0;
         this.treeViewTabControl.Size = new System.Drawing.Size(242, 551);
         this.treeViewTabControl.TabIndex = 0;
         // 
         // cubemittersTreeViewTab
         // 
         this.cubemittersTreeViewTab.Controls.Add(this.cubemittersTreeView);
         this.cubemittersTreeViewTab.Location = new System.Drawing.Point(4, 22);
         this.cubemittersTreeViewTab.Name = "cubemittersTreeViewTab";
         this.cubemittersTreeViewTab.Padding = new System.Windows.Forms.Padding(3);
         this.cubemittersTreeViewTab.Size = new System.Drawing.Size(234, 525);
         this.cubemittersTreeViewTab.TabIndex = 1;
         this.cubemittersTreeViewTab.Text = "Cubemitters";
         this.cubemittersTreeViewTab.UseVisualStyleBackColor = true;
         // 
         // cubemittersTreeView
         // 
         this.cubemittersTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
         this.cubemittersTreeView.FullRowSelect = true;
         this.cubemittersTreeView.Location = new System.Drawing.Point(3, 3);
         this.cubemittersTreeView.Name = "cubemittersTreeView";
         this.cubemittersTreeView.PathSeparator = "/";
         this.cubemittersTreeView.Size = new System.Drawing.Size(228, 519);
         this.cubemittersTreeView.TabIndex = 1;
         this.cubemittersTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.cubemittersTreeView_AfterSelect);
         this.cubemittersTreeView.MouseClick += new System.Windows.Forms.MouseEventHandler(this.cubemittersTreeView_MouseClick);
         // 
         // effectsTreeViewTab
         // 
         this.effectsTreeViewTab.Controls.Add(this.effectsEditorTreeView);
         this.effectsTreeViewTab.Location = new System.Drawing.Point(4, 22);
         this.effectsTreeViewTab.Name = "effectsTreeViewTab";
         this.effectsTreeViewTab.Padding = new System.Windows.Forms.Padding(3);
         this.effectsTreeViewTab.Size = new System.Drawing.Size(234, 525);
         this.effectsTreeViewTab.TabIndex = 0;
         this.effectsTreeViewTab.Text = "Effects";
         this.effectsTreeViewTab.UseVisualStyleBackColor = true;
         // 
         // effectsEditorTreeView
         // 
         this.effectsEditorTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
         this.effectsEditorTreeView.FullRowSelect = true;
         this.effectsEditorTreeView.HideSelection = false;
         this.effectsEditorTreeView.Location = new System.Drawing.Point(3, 3);
         this.effectsEditorTreeView.Name = "effectsEditorTreeView";
         this.effectsEditorTreeView.PathSeparator = "/";
         this.effectsEditorTreeView.Size = new System.Drawing.Size(228, 519);
         this.effectsEditorTreeView.TabIndex = 0;
         this.effectsEditorTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.effectsEditorTreeView_AfterSelect);
         this.effectsEditorTreeView.MouseClick += new System.Windows.Forms.MouseEventHandler(this.effectsEditorTreeView_MouseClick);
         // 
         // effectsSplitContainer2
         // 
         this.effectsSplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
         this.effectsSplitContainer2.Location = new System.Drawing.Point(0, 0);
         this.effectsSplitContainer2.Name = "effectsSplitContainer2";
         // 
         // effectsSplitContainer2.Panel1
         // 
         this.effectsSplitContainer2.Panel1.Controls.Add(this.filePreviewTabs);
         // 
         // effectsSplitContainer2.Panel2
         // 
         this.effectsSplitContainer2.Panel2.Controls.Add(this.effectsBuilderView);
         this.effectsSplitContainer2.Size = new System.Drawing.Size(594, 551);
         this.effectsSplitContainer2.SplitterDistance = 339;
         this.effectsSplitContainer2.TabIndex = 0;
         // 
         // filePreviewTabs
         // 
         this.filePreviewTabs.Dock = System.Windows.Forms.DockStyle.Fill;
         this.filePreviewTabs.Location = new System.Drawing.Point(0, 0);
         this.filePreviewTabs.Name = "filePreviewTabs";
         this.filePreviewTabs.SelectedIndex = 0;
         this.filePreviewTabs.Size = new System.Drawing.Size(339, 551);
         this.filePreviewTabs.TabIndex = 3;
         // 
         // effectsToolStrip
         // 
         this.effectsToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newFileButton,
            this.effectsOpenFileButton});
         this.effectsToolStrip.Location = new System.Drawing.Point(0, 0);
         this.effectsToolStrip.Name = "effectsToolStrip";
         this.effectsToolStrip.Size = new System.Drawing.Size(840, 25);
         this.effectsToolStrip.TabIndex = 2;
         this.effectsToolStrip.Text = "Effects Tool Strip";
         // 
         // newFileButton
         // 
         this.newFileButton.BackColor = System.Drawing.SystemColors.ButtonShadow;
         this.newFileButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
         this.newFileButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
         this.newFileButton.ImageTransparentColor = System.Drawing.Color.Magenta;
         this.newFileButton.Name = "newFileButton";
         this.newFileButton.Size = new System.Drawing.Size(105, 22);
         this.newFileButton.Text = "+ New Effects File";
         this.newFileButton.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
         this.newFileButton.ToolTipText = "Not yet implemented!";
         this.newFileButton.Click += new System.EventHandler(this.newFileButton_Click);
         // 
         // effectsOpenFileButton
         // 
         this.effectsOpenFileButton.BackColor = System.Drawing.SystemColors.ButtonShadow;
         this.effectsOpenFileButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
         this.effectsOpenFileButton.Image = ((System.Drawing.Image)(resources.GetObject("effectsOpenFileButton.Image")));
         this.effectsOpenFileButton.ImageTransparentColor = System.Drawing.Color.Magenta;
         this.effectsOpenFileButton.Margin = new System.Windows.Forms.Padding(3, 1, 0, 2);
         this.effectsOpenFileButton.Name = "effectsOpenFileButton";
         this.effectsOpenFileButton.Size = new System.Drawing.Size(61, 22);
         this.effectsOpenFileButton.Text = "Open File";
         this.effectsOpenFileButton.Click += new System.EventHandler(this.effectsOpenFileButton_Click);
         // 
         // openEffectsFileDialog
         // 
         this.openEffectsFileDialog.FileName = "openEffectsFileDialog";
         this.openEffectsFileDialog.Filter = "JSON Files|*.json|Lua Files|*.lua";
         this.openEffectsFileDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.openEffectsFileDialog_FileOk);
         // 
         // cloneToolStripMenuItem
         // 
         this.cloneToolStripMenuItem.Name = "cloneToolStripMenuItem";
         this.cloneToolStripMenuItem.Size = new System.Drawing.Size(105, 22);
         this.cloneToolStripMenuItem.Text = "Clone";
         this.cloneToolStripMenuItem.Click += new System.EventHandler(this.cloneToolStripMenuItem_Click);
         // 
         // effectsEditorContextMenuStrip
         // 
         this.effectsEditorContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cloneToolStripMenuItem});
         this.effectsEditorContextMenuStrip.Name = "effectsEditorContextMenuStrip";
         this.effectsEditorContextMenuStrip.Size = new System.Drawing.Size(106, 26);
         // 
         // saveEffectsFileDialog
         // 
         this.saveEffectsFileDialog.Filter = "JSON Files|*.json|Lua Files|*.lua";
         this.saveEffectsFileDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.saveEffectsFileDialog_FileOk);
         // 
         // helpButton
         // 
         this.helpButton.BackColor = System.Drawing.SystemColors.AppWorkspace;
         this.helpButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.helpButton.Location = new System.Drawing.Point(791, 0);
         this.helpButton.Name = "helpButton";
         this.helpButton.Size = new System.Drawing.Size(46, 25);
         this.helpButton.TabIndex = 3;
         this.helpButton.Text = "Help";
         this.helpButton.UseVisualStyleBackColor = false;
         this.helpButton.Click += new System.EventHandler(this.helpButton_Click);
         // 
         // effectsBuilderView
         // 
         this.effectsBuilderView.Dock = System.Windows.Forms.DockStyle.Fill;
         this.effectsBuilderView.Location = new System.Drawing.Point(0, 0);
         this.effectsBuilderView.Name = "effectsBuilderView";
         this.effectsBuilderView.Size = new System.Drawing.Size(251, 551);
         this.effectsBuilderView.TabIndex = 1;
         this.effectsBuilderView.SaveRequested += effectsBuilderView_SaveRequested;
         this.effectsBuilderView.PreviewRequested += effectsBuilderView_PreviewRequested;
         // 
         // EffectsEditorView
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.Controls.Add(this.helpButton);
         this.Controls.Add(this.effectsSplitContainer);
         this.Controls.Add(this.effectsToolStrip);
         this.Name = "EffectsEditorView";
         this.Size = new System.Drawing.Size(840, 576);
         this.effectsSplitContainer.Panel1.ResumeLayout(false);
         this.effectsSplitContainer.Panel2.ResumeLayout(false);
         ((System.ComponentModel.ISupportInitialize)(this.effectsSplitContainer)).EndInit();
         this.effectsSplitContainer.ResumeLayout(false);
         this.treeViewTabControl.ResumeLayout(false);
         this.cubemittersTreeViewTab.ResumeLayout(false);
         this.effectsTreeViewTab.ResumeLayout(false);
         this.effectsSplitContainer2.Panel1.ResumeLayout(false);
         this.effectsSplitContainer2.Panel2.ResumeLayout(false);
         ((System.ComponentModel.ISupportInitialize)(this.effectsSplitContainer2)).EndInit();
         this.effectsSplitContainer2.ResumeLayout(false);
         this.effectsToolStrip.ResumeLayout(false);
         this.effectsToolStrip.PerformLayout();
         this.effectsEditorContextMenuStrip.ResumeLayout(false);
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.SplitContainer effectsSplitContainer;
      private System.Windows.Forms.SplitContainer effectsSplitContainer2;
      private System.Windows.Forms.TabControl filePreviewTabs;
      private System.Windows.Forms.ToolStrip effectsToolStrip;
      private System.Windows.Forms.ToolStripButton newFileButton;
      private System.Windows.Forms.ToolStripButton effectsOpenFileButton;
      private System.Windows.Forms.OpenFileDialog openEffectsFileDialog;
      private System.Windows.Forms.TreeView effectsEditorTreeView;
      private System.Windows.Forms.TabControl treeViewTabControl;
      private System.Windows.Forms.TabPage cubemittersTreeViewTab;
      private System.Windows.Forms.TreeView cubemittersTreeView;
      private System.Windows.Forms.TabPage effectsTreeViewTab;
      private System.Windows.Forms.ToolStripMenuItem cloneToolStripMenuItem;
      private System.Windows.Forms.ContextMenuStrip effectsEditorContextMenuStrip;
      private System.Windows.Forms.SaveFileDialog saveEffectsFileDialog;
      private System.Windows.Forms.Button helpButton;
      private EffectsBuilderView effectsBuilderView;
   }
}
