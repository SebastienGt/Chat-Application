
namespace ForumAppProject
{
    partial class Server
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.Connection = new System.Windows.Forms.Button();
            this.Listbox_Clients = new System.Windows.Forms.ListBox();
            this.Listbox_Topics = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(224, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Server";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Chat log";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 90);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(295, 264);
            this.textBox1.TabIndex = 2;
            // 
            // Connection
            // 
            this.Connection.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.Connection.Location = new System.Drawing.Point(425, 23);
            this.Connection.Name = "Connection";
            this.Connection.Size = new System.Drawing.Size(75, 23);
            this.Connection.TabIndex = 5;
            this.Connection.Text = "Start";
            this.Connection.UseVisualStyleBackColor = false;
            this.Connection.Click += new System.EventHandler(this.Start_Click);
            // 
            // Listbox_Clients
            // 
            this.Listbox_Clients.FormattingEnabled = true;
            this.Listbox_Clients.Location = new System.Drawing.Point(439, 90);
            this.Listbox_Clients.Name = "Listbox_Clients";
            this.Listbox_Clients.Size = new System.Drawing.Size(102, 264);
            this.Listbox_Clients.TabIndex = 7;
            this.Listbox_Clients.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.Listbox_Clients_MouseDoubleClick);
            // 
            // Listbox_Topics
            // 
            this.Listbox_Topics.FormattingEnabled = true;
            this.Listbox_Topics.Location = new System.Drawing.Point(329, 90);
            this.Listbox_Topics.Name = "Listbox_Topics";
            this.Listbox_Topics.Size = new System.Drawing.Size(95, 264);
            this.Listbox_Topics.TabIndex = 8;
            this.Listbox_Topics.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.Listbox_Topics_MouseDoubleClick);
            // 
            // Server
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(553, 376);
            this.Controls.Add(this.Listbox_Topics);
            this.Controls.Add(this.Listbox_Clients);
            this.Controls.Add(this.Connection);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Server";
            this.Text = "EFREI PARIS - Server";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button Connection;
        private System.Windows.Forms.ListBox Listbox_Clients;
        private System.Windows.Forms.ListBox Listbox_Topics;
    }
}

