
namespace Client
{
    partial class FormPrivate
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
            this.history = new System.Windows.Forms.TextBox();
            this.Send = new System.Windows.Forms.Button();
            this.input = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.indicator = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // history
            // 
            this.history.Location = new System.Drawing.Point(12, 46);
            this.history.Multiline = true;
            this.history.Name = "history";
            this.history.Size = new System.Drawing.Size(278, 232);
            this.history.TabIndex = 10;
            // 
            // Send
            // 
            this.Send.Location = new System.Drawing.Point(206, 295);
            this.Send.Name = "Send";
            this.Send.Size = new System.Drawing.Size(84, 23);
            this.Send.TabIndex = 9;
            this.Send.Text = "Send";
            this.Send.UseVisualStyleBackColor = true;
            this.Send.Click += new System.EventHandler(this.Send_Click);
            // 
            // input
            // 
            this.input.Location = new System.Drawing.Point(12, 297);
            this.input.Name = "input";
            this.input.Size = new System.Drawing.Size(181, 20);
            this.input.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Topic";
            // 
            // indicator
            // 
            this.indicator.Location = new System.Drawing.Point(265, 16);
            this.indicator.Name = "indicator";
            this.indicator.Size = new System.Drawing.Size(25, 24);
            this.indicator.TabIndex = 12;
            // 
            // FormPrivate
            // 
            this.AcceptButton = this.Send;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(311, 336);
            this.Controls.Add(this.indicator);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.history);
            this.Controls.Add(this.Send);
            this.Controls.Add(this.input);
            this.Name = "FormPrivate";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FormPrivate";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox history;
        private System.Windows.Forms.Button Send;
        private System.Windows.Forms.TextBox input;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel indicator;
    }
}