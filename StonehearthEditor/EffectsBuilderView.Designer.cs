﻿namespace StonehearthEditor
{
   partial class EffectsBuilderView
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
         this.effectsBuilderPanel = new System.Windows.Forms.FlowLayoutPanel();
         this.SuspendLayout();
         // 
         // effectsBuilderPanel
         // 
         this.effectsBuilderPanel.Dock = System.Windows.Forms.DockStyle.Fill;
         this.effectsBuilderPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
         this.effectsBuilderPanel.Location = new System.Drawing.Point(0, 0);
         this.effectsBuilderPanel.Name = "effectsBuilderPanel";
         this.effectsBuilderPanel.Size = new System.Drawing.Size(431, 576);
         this.effectsBuilderPanel.TabIndex = 0;
         // 
         // EffectsBuilderView
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.Controls.Add(this.effectsBuilderPanel);
         this.Name = "EffectsBuilderView";
         this.Size = new System.Drawing.Size(431, 576);
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.FlowLayoutPanel effectsBuilderPanel;
   }
}
