using System.Drawing;
using System.Windows.Forms;
namespace Sieci_Projekt
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
            this.button1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.IMG = new System.Windows.Forms.PictureBox();
            this.button2 = new System.Windows.Forms.Button();
            this.litera = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.IMG)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(204, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(139, 49);
            this.button1.TabIndex = 0;
            this.button1.Text = "Ucz";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.IMG);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(100, 140);
            this.panel1.TabIndex = 1;
            // 
            // IMG
            // 
            this.IMG.Location = new System.Drawing.Point(0, 0);
            this.IMG.Name = "IMG";
            this.IMG.Size = new System.Drawing.Size(100, 140);
            this.IMG.TabIndex = 0;
            this.IMG.TabStop = false;
            this.IMG.MouseDown += new System.Windows.Forms.MouseEventHandler(this.IMG_MouseDown);
            this.IMG.MouseMove += new System.Windows.Forms.MouseEventHandler(this.IMG_MouseMove);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(204, 67);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(139, 51);
            this.button2.TabIndex = 2;
            this.button2.Text = "Sprawdz";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // litera
            // 
            this.litera.Location = new System.Drawing.Point(13, 166);
            this.litera.Name = "litera";
            this.litera.Size = new System.Drawing.Size(100, 20);
            this.litera.TabIndex = 3;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(204, 129);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(139, 57);
            this.button3.TabIndex = 4;
            this.button3.Text = "Wyczysc";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(358, 198);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.litera);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "PSI";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.IMG)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private Panel panel1;
        private PictureBox IMG;
        private Button button2;
        private TextBox litera;
        private Button button3;
        
    }
}

