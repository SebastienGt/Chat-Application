
namespace Client
{
    partial class FormTopic
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormTopic));
            this.label1 = new System.Windows.Forms.Label();
            this.history = new System.Windows.Forms.TextBox();
            this.Send = new System.Windows.Forms.Button();
            this.input = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Topic";
            // 
            // history
            // 
            this.history.Location = new System.Drawing.Point(12, 40);
            this.history.Multiline = true;
            this.history.Name = "history";
            this.history.ReadOnly = true;
            this.history.Size = new System.Drawing.Size(483, 223);
            this.history.TabIndex = 14;
            this.history.TextChanged += new System.EventHandler(this.history_TextChanged);
            // 
            // Send
            // 
            this.Send.Location = new System.Drawing.Point(411, 288);
            this.Send.Name = "Send";
            this.Send.Size = new System.Drawing.Size(84, 23);
            this.Send.TabIndex = 13;
            this.Send.Text = "Send";
            this.Send.UseVisualStyleBackColor = true;
            this.Send.Click += new System.EventHandler(this.Send_Click_1);
            // 
            // input
            // 
            this.input.Location = new System.Drawing.Point(12, 291);
            this.input.Name = "input";
            this.input.Size = new System.Drawing.Size(381, 20);
            this.input.TabIndex = 12;
            // 
            // FormTopic
            // 
            this.AcceptButton = this.Send;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(523, 343);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.history);
            this.Controls.Add(this.Send);
            this.Controls.Add(this.input);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormTopic";
            this.Text = "FormTopic";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox history;
        private System.Windows.Forms.Button Send;
        private System.Windows.Forms.TextBox input;
    }
}