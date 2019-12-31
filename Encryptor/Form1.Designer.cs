namespace Encryptor
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
            this.buttonEncrypt = new System.Windows.Forms.Button();
            this.textBoxPath = new System.Windows.Forms.TextBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.buttonDecrypt = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonBrowse = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.radioButtonRemove = new System.Windows.Forms.RadioButton();
            this.radioButtonKeep = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // buttonEncrypt
            // 
            this.buttonEncrypt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonEncrypt.Location = new System.Drawing.Point(41, 203);
            this.buttonEncrypt.Name = "buttonEncrypt";
            this.buttonEncrypt.Size = new System.Drawing.Size(135, 40);
            this.buttonEncrypt.TabIndex = 0;
            this.buttonEncrypt.Text = "ENCRYPT";
            this.buttonEncrypt.UseVisualStyleBackColor = true;
            this.buttonEncrypt.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBoxPath
            // 
            this.textBoxPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxPath.Location = new System.Drawing.Point(41, 27);
            this.textBoxPath.Name = "textBoxPath";
            this.textBoxPath.Size = new System.Drawing.Size(332, 26);
            this.textBoxPath.TabIndex = 1;
            this.textBoxPath.Click += new System.EventHandler(this.textBoxPath_Click);
            // 
            // buttonDecrypt
            // 
            this.buttonDecrypt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDecrypt.Location = new System.Drawing.Point(238, 203);
            this.buttonDecrypt.Name = "buttonDecrypt";
            this.buttonDecrypt.Size = new System.Drawing.Size(135, 40);
            this.buttonDecrypt.TabIndex = 2;
            this.buttonDecrypt.Text = "DECRYPT";
            this.buttonDecrypt.UseVisualStyleBackColor = true;
            this.buttonDecrypt.Click += new System.EventHandler(this.buttonDecrypt_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(37, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "PATH";
            // 
            // buttonBrowse
            // 
            this.buttonBrowse.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonBrowse.Location = new System.Drawing.Point(289, 59);
            this.buttonBrowse.Name = "buttonBrowse";
            this.buttonBrowse.Size = new System.Drawing.Size(84, 26);
            this.buttonBrowse.TabIndex = 4;
            this.buttonBrowse.Text = "BROWSE";
            this.buttonBrowse.UseVisualStyleBackColor = true;
            this.buttonBrowse.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(37, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "PASSWORD";
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxPassword.Location = new System.Drawing.Point(41, 91);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.Size = new System.Drawing.Size(332, 26);
            this.textBoxPassword.TabIndex = 5;
            // 
            // radioButtonRemove
            // 
            this.radioButtonRemove.AutoSize = true;
            this.radioButtonRemove.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonRemove.Location = new System.Drawing.Point(41, 132);
            this.radioButtonRemove.Name = "radioButtonRemove";
            this.radioButtonRemove.Size = new System.Drawing.Size(224, 24);
            this.radioButtonRemove.TabIndex = 11;
            this.radioButtonRemove.TabStop = true;
            this.radioButtonRemove.Text = "Permanentely erase files";
            this.radioButtonRemove.UseVisualStyleBackColor = true;
            // 
            // radioButtonKeep
            // 
            this.radioButtonKeep.AutoSize = true;
            this.radioButtonKeep.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonKeep.Location = new System.Drawing.Point(41, 162);
            this.radioButtonKeep.Name = "radioButtonKeep";
            this.radioButtonKeep.Size = new System.Drawing.Size(106, 24);
            this.radioButtonKeep.TabIndex = 13;
            this.radioButtonKeep.TabStop = true;
            this.radioButtonKeep.Text = "Keep files";
            this.radioButtonKeep.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.ClientSize = new System.Drawing.Size(422, 270);
            this.Controls.Add(this.radioButtonKeep);
            this.Controls.Add(this.radioButtonRemove);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxPassword);
            this.Controls.Add(this.buttonBrowse);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonDecrypt);
            this.Controls.Add(this.textBoxPath);
            this.Controls.Add(this.buttonEncrypt);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CRYPTER";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonEncrypt;
        private System.Windows.Forms.TextBox textBoxPath;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button buttonDecrypt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonBrowse;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.RadioButton radioButtonRemove;
        private System.Windows.Forms.RadioButton radioButtonKeep;
    }
}

