
using System;

namespace Advanced_Programming_Assignment
{
    partial class Form1
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
        private void InitializeComponent()
        {
            this.txtBoxScript = new System.Windows.Forms.TextBox();
            this.txtCmdLine = new System.Windows.Forms.TextBox();
            this.btnRunScript = new System.Windows.Forms.Button();
            this.btnGo = new System.Windows.Forms.Button();
            this.lstBoxRanCommands = new System.Windows.Forms.ListBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtBoxScript
            // 
            this.txtBoxScript.Location = new System.Drawing.Point(13, 41);
            this.txtBoxScript.Multiline = true;
            this.txtBoxScript.Name = "txtBoxScript";
            this.txtBoxScript.Size = new System.Drawing.Size(447, 645);
            this.txtBoxScript.TabIndex = 0;
            // 
            // txtCmdLine
            // 
            this.txtCmdLine.Location = new System.Drawing.Point(13, 727);
            this.txtCmdLine.Name = "txtCmdLine";
            this.txtCmdLine.Size = new System.Drawing.Size(392, 27);
            this.txtCmdLine.TabIndex = 1;
            // 
            // btnRunScript
            // 
            this.btnRunScript.Location = new System.Drawing.Point(13, 692);
            this.btnRunScript.Name = "btnRunScript";
            this.btnRunScript.Size = new System.Drawing.Size(94, 29);
            this.btnRunScript.TabIndex = 2;
            this.btnRunScript.Text = "Run Script";
            this.btnRunScript.UseVisualStyleBackColor = true;
            this.btnRunScript.Click += new System.EventHandler(this.btnRunScript_Click);
            // 
            // btnGo
            // 
            this.btnGo.Location = new System.Drawing.Point(411, 726);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(49, 29);
            this.btnGo.TabIndex = 3;
            this.btnGo.Text = " Go";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btnGo_MouseClick);
            // 
            // lstBoxRanCommands
            // 
            this.lstBoxRanCommands.FormattingEnabled = true;
            this.lstBoxRanCommands.HorizontalScrollbar = true;
            this.lstBoxRanCommands.ItemHeight = 20;
            this.lstBoxRanCommands.Location = new System.Drawing.Point(13, 761);
            this.lstBoxRanCommands.Name = "lstBoxRanCommands";
            this.lstBoxRanCommands.Size = new System.Drawing.Size(447, 104);
            this.lstBoxRanCommands.TabIndex = 4;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Gray;
            this.pictureBox1.Location = new System.Drawing.Point(466, 41);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1228, 824);
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            // 
            // menuToolStripMenuItem
            // 
            this.menuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            this.menuToolStripMenuItem.Size = new System.Drawing.Size(60, 24);
            this.menuToolStripMenuItem.Text = "Menu";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(128, 26);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(128, 26);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(128, 26);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1706, 28);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1706, 876);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lstBoxRanCommands);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.btnRunScript);
            this.Controls.Add(this.txtCmdLine);
            this.Controls.Add(this.txtBoxScript);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Advanced Software Assignment";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtBoxScript;
        private System.Windows.Forms.TextBox txtCmdLine;
        private System.Windows.Forms.Button btnRunScript;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.ListBox lstBoxRanCommands;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
    }
}

