namespace ChatApp
{
    partial class ChatForm
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
            this.chatBox = new System.Windows.Forms.RichTextBox();
            this.msgTextBox = new System.Windows.Forms.TextBox();
            this.sendMsgBtn = new System.Windows.Forms.Button();
            this.messageWaiter = new System.ComponentModel.BackgroundWorker();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.hostTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.portNumBox = new System.Windows.Forms.ToolStripTextBox();
            this.connectBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.authMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loginTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.passTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // chatBox
            // 
            this.chatBox.Location = new System.Drawing.Point(12, 27);
            this.chatBox.Name = "chatBox";
            this.chatBox.ReadOnly = true;
            this.chatBox.Size = new System.Drawing.Size(516, 306);
            this.chatBox.TabIndex = 6;
            this.chatBox.Text = "";
            // 
            // msgTextBox
            // 
            this.msgTextBox.Location = new System.Drawing.Point(12, 339);
            this.msgTextBox.Multiline = true;
            this.msgTextBox.Name = "msgTextBox";
            this.msgTextBox.Size = new System.Drawing.Size(418, 46);
            this.msgTextBox.TabIndex = 7;
            // 
            // sendMsgBtn
            // 
            this.sendMsgBtn.Location = new System.Drawing.Point(436, 339);
            this.sendMsgBtn.Name = "sendMsgBtn";
            this.sendMsgBtn.Size = new System.Drawing.Size(92, 46);
            this.sendMsgBtn.TabIndex = 8;
            this.sendMsgBtn.Text = "Отправить";
            this.sendMsgBtn.UseVisualStyleBackColor = true;
            this.sendMsgBtn.Click += new System.EventHandler(this.sendMsgBtn_Click);
            // 
            // messageWaiter
            // 
            this.messageWaiter.WorkerReportsProgress = true;
            this.messageWaiter.WorkerSupportsCancellation = true;
            this.messageWaiter.DoWork += new System.ComponentModel.DoWorkEventHandler(this.messageWaiter_DoWork);
            this.messageWaiter.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.messageWaiter_ProgressChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.authMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(815, 24);
            this.menuStrip1.TabIndex = 9;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hostTextBox,
            this.portNumBox,
            this.connectBtn});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(97, 20);
            this.toolStripMenuItem1.Text = "Подключение";
            // 
            // hostTextBox
            // 
            this.hostTextBox.Name = "hostTextBox";
            this.hostTextBox.Size = new System.Drawing.Size(100, 23);
            this.hostTextBox.Text = "127.0.0.1";
            this.hostTextBox.ToolTipText = "Server Host Address";
            // 
            // portNumBox
            // 
            this.portNumBox.Name = "portNumBox";
            this.portNumBox.Size = new System.Drawing.Size(100, 23);
            this.portNumBox.Text = "8005";
            this.portNumBox.ToolTipText = "Port Number for Host";
            // 
            // connectBtn
            // 
            this.connectBtn.Name = "connectBtn";
            this.connectBtn.Size = new System.Drawing.Size(180, 22);
            this.connectBtn.Text = "Connect";
            this.connectBtn.Click += new System.EventHandler(this.connectBtn_Click);
            // 
            // authMenuItem
            // 
            this.authMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loginTextBox,
            this.passTextBox,
            this.toolStripMenuItem3});
            this.authMenuItem.Name = "authMenuItem";
            this.authMenuItem.Size = new System.Drawing.Size(90, 20);
            this.authMenuItem.Text = "Авторизация";
            // 
            // loginTextBox
            // 
            this.loginTextBox.Name = "loginTextBox";
            this.loginTextBox.Size = new System.Drawing.Size(100, 23);
            this.loginTextBox.ToolTipText = "Login";
            // 
            // passTextBox
            // 
            this.passTextBox.Name = "passTextBox";
            this.passTextBox.Size = new System.Drawing.Size(100, 23);
            this.passTextBox.ToolTipText = "Password";
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(231, 22);
            this.toolStripMenuItem3.Text = "Войти/Зарегистрировантьая";
            this.toolStripMenuItem3.Click += new System.EventHandler(this.toolStripMenuItem3_Click);
            // 
            // ChatForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(815, 397);
            this.Controls.Add(this.sendMsgBtn);
            this.Controls.Add(this.msgTextBox);
            this.Controls.Add(this.chatBox);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "ChatForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.ChatForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox msgTextBox;
        private System.Windows.Forms.Button sendMsgBtn;
        public System.Windows.Forms.RichTextBox chatBox;
        private System.ComponentModel.BackgroundWorker messageWaiter;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripTextBox hostTextBox;
        private System.Windows.Forms.ToolStripTextBox portNumBox;
        private System.Windows.Forms.ToolStripMenuItem connectBtn;
        private System.Windows.Forms.ToolStripMenuItem authMenuItem;
        private System.Windows.Forms.ToolStripTextBox loginTextBox;
        private System.Windows.Forms.ToolStripTextBox passTextBox;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
    }
}

