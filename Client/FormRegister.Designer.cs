
namespace Client
{
    partial class FormRegister
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
            this.Create = new System.Windows.Forms.Button();
            this.username = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.PeudoBox = new System.Windows.Forms.TextBox();
            this.MailBox = new System.Windows.Forms.TextBox();
            this.PassBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // Create
            // 
            this.Create.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Create.Location = new System.Drawing.Point(117, 329);
            this.Create.Name = "Create";
            this.Create.Size = new System.Drawing.Size(75, 23);
            this.Create.TabIndex = 4;
            this.Create.Text = "Create";
            this.Create.UseVisualStyleBackColor = true;
            // 
            // username
            // 
            this.username.AutoSize = true;
            this.username.Location = new System.Drawing.Point(33, 104);
            this.username.Name = "username";
            this.username.Size = new System.Drawing.Size(49, 13);
            this.username.TabIndex = 5;
            this.username.Text = "Pseudo :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 154);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Adresse email :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 202);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Mot de passe :";
            // 
            // PeudoBox
            // 
            this.PeudoBox.Location = new System.Drawing.Point(125, 97);
            this.PeudoBox.Name = "PeudoBox";
            this.PeudoBox.Size = new System.Drawing.Size(158, 20);
            this.PeudoBox.TabIndex = 8;
            this.PeudoBox.TextChanged += new System.EventHandler(this.PeudoBox_TextChanged);
            // 
            // MailBox
            // 
            this.MailBox.Location = new System.Drawing.Point(126, 147);
            this.MailBox.Name = "MailBox";
            this.MailBox.Size = new System.Drawing.Size(157, 20);
            this.MailBox.TabIndex = 9;
            this.MailBox.TextChanged += new System.EventHandler(this.MailBox_TextChanged);
            // 
            // PassBox
            // 
            this.PassBox.Location = new System.Drawing.Point(125, 199);
            this.PassBox.Name = "PassBox";
            this.PassBox.Size = new System.Drawing.Size(158, 20);
            this.PassBox.TabIndex = 10;
            this.PassBox.TextChanged += new System.EventHandler(this.PassBox_TextChanged);
            // 
            // FormRegister
            // 
            this.AcceptButton = this.Create;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(314, 435);
            this.Controls.Add(this.PassBox);
            this.Controls.Add(this.MailBox);
            this.Controls.Add(this.PeudoBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.username);
            this.Controls.Add(this.Create);
            this.Location = new System.Drawing.Point(112, 85);
            this.Name = "FormRegister";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FormRegister";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button Create;
        private System.Windows.Forms.Label username;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox PeudoBox;
        private System.Windows.Forms.TextBox MailBox;
        private System.Windows.Forms.TextBox PassBox;
    }
}