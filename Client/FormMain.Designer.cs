
namespace Client
{
    partial class FormMain
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup("Connected", System.Windows.Forms.HorizontalAlignment.Center);
            this.listClients = new System.Windows.Forms.ListView();
            this.input = new System.Windows.Forms.TextBox();
            this.Send = new System.Windows.Forms.Button();
            this.history = new System.Windows.Forms.TextBox();
            this.indicator = new System.Windows.Forms.Panel();
            this.ListTopics = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.buttonAddTopic = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listClients
            // 
            this.listClients.Cursor = System.Windows.Forms.Cursors.Default;
            listViewGroup1.Header = "Connected";
            listViewGroup1.HeaderAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            listViewGroup1.Name = "Connected";
            this.listClients.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup1});
            this.listClients.HideSelection = false;
            this.listClients.Location = new System.Drawing.Point(493, 53);
            this.listClients.Name = "listClients";
            this.listClients.Size = new System.Drawing.Size(121, 253);
            this.listClients.TabIndex = 0;
            this.listClients.UseCompatibleStateImageBehavior = false;
            this.listClients.View = System.Windows.Forms.View.SmallIcon;
            this.listClients.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listClients_MouseDoubleClick);
            // 
            // input
            // 
            this.input.Location = new System.Drawing.Point(23, 288);
            this.input.Name = "input";
            this.input.Size = new System.Drawing.Size(278, 20);
            this.input.TabIndex = 1;
            // 
            // Send
            // 
            this.Send.Location = new System.Drawing.Point(307, 286);
            this.Send.Name = "Send";
            this.Send.Size = new System.Drawing.Size(84, 23);
            this.Send.TabIndex = 2;
            this.Send.Text = "Send";
            this.Send.UseVisualStyleBackColor = true;
            this.Send.Click += new System.EventHandler(this.Send_Click);
            // 
            // history
            // 
            this.history.Location = new System.Drawing.Point(23, 26);
            this.history.Multiline = true;
            this.history.Name = "history";
            this.history.Size = new System.Drawing.Size(278, 232);
            this.history.TabIndex = 4;
            // 
            // indicator
            // 
            this.indicator.Location = new System.Drawing.Point(319, 26);
            this.indicator.Name = "indicator";
            this.indicator.Size = new System.Drawing.Size(25, 24);
            this.indicator.TabIndex = 5;
            // 
            // ListTopics
            // 
            this.ListTopics.FormattingEnabled = true;
            this.ListTopics.Location = new System.Drawing.Point(319, 98);
            this.ListTopics.Name = "ListTopics";
            this.ListTopics.Size = new System.Drawing.Size(120, 160);
            this.ListTopics.TabIndex = 6;
            this.ListTopics.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.ListTopics_MouseDoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(319, 79);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Topics";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(500, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Connected";
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.BalloonTipText = "salut";
            this.notifyIcon1.BalloonTipTitle = "ahah";
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            // 
            // buttonAddTopic
            // 
            this.buttonAddTopic.Location = new System.Drawing.Point(410, 232);
            this.buttonAddTopic.Name = "buttonAddTopic";
            this.buttonAddTopic.Size = new System.Drawing.Size(29, 26);
            this.buttonAddTopic.TabIndex = 9;
            this.buttonAddTopic.Text = "+";
            this.buttonAddTopic.UseVisualStyleBackColor = true;
            this.buttonAddTopic.Click += new System.EventHandler(this.button1_Click);
            // 
            // FormMain
            // 
            this.AcceptButton = this.Send;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(643, 331);
            this.Controls.Add(this.buttonAddTopic);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ListTopics);
            this.Controls.Add(this.indicator);
            this.Controls.Add(this.history);
            this.Controls.Add(this.Send);
            this.Controls.Add(this.input);
            this.Controls.Add(this.listClients);
            this.Name = "FormMain";
            this.Text = "EFREI PARIS - Forum";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.formMain_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listClients;
        private System.Windows.Forms.TextBox input;
        private System.Windows.Forms.Button Send;
        private System.Windows.Forms.TextBox history;
        private System.Windows.Forms.Panel indicator;
        private System.Windows.Forms.ListBox ListTopics;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.Button buttonAddTopic;
    }
}