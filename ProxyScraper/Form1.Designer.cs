﻿namespace ProxyScraper
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
            this.btnSetDefaultProxySettings = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button1.Location = new System.Drawing.Point(12, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(167, 68);
            this.button1.TabIndex = 1;
            this.button1.Text = "Proxy Değiş";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnSetDefaultProxySettings
            // 
            this.btnSetDefaultProxySettings.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSetDefaultProxySettings.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnSetDefaultProxySettings.Location = new System.Drawing.Point(185, 12);
            this.btnSetDefaultProxySettings.Name = "btnSetDefaultProxySettings";
            this.btnSetDefaultProxySettings.Size = new System.Drawing.Size(167, 68);
            this.btnSetDefaultProxySettings.TabIndex = 2;
            this.btnSetDefaultProxySettings.Text = "Proxy Sıfırla";
            this.btnSetDefaultProxySettings.UseVisualStyleBackColor = true;
            this.btnSetDefaultProxySettings.Click += new System.EventHandler(this.btnSetDefaultProxySettings_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(359, 95);
            this.Controls.Add(this.btnSetDefaultProxySettings);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Proxy Changer";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnSetDefaultProxySettings;
    }
}

