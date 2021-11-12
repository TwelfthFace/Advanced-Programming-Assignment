
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
            this.SuspendLayout();
            // 
            // txtBoxScript
            // 
            this.txtBoxScript.Location = new System.Drawing.Point(13, 13);
            this.txtBoxScript.Multiline = true;
            this.txtBoxScript.Name = "txtBoxScript";
            this.txtBoxScript.Size = new System.Drawing.Size(447, 673);
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
            this.lstBoxRanCommands.ItemHeight = 20;
            this.lstBoxRanCommands.Location = new System.Drawing.Point(13, 761);
            this.lstBoxRanCommands.Name = "lstBoxRanCommands";
            this.lstBoxRanCommands.Size = new System.Drawing.Size(447, 104);
            this.lstBoxRanCommands.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1706, 876);
            this.Controls.Add(this.lstBoxRanCommands);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.btnRunScript);
            this.Controls.Add(this.txtCmdLine);
            this.Controls.Add(this.txtBoxScript);
            this.Name = "Form1";
            this.Text = "Advanced Software Assignment";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtBoxScript;
        private System.Windows.Forms.TextBox txtCmdLine;
        private System.Windows.Forms.Button btnRunScript;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.ListBox lstBoxRanCommands;
    }
}

