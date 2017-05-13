namespace Client_TIP
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
            this.ServerIPTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.acceptServIPBtn = new System.Windows.Forms.Button();
            this.loginPanel = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.registerLabel = new System.Windows.Forms.LinkLabel();
            this.cancelButton1 = new System.Windows.Forms.Button();
            this.loginBtn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.userNameTextBox = new System.Windows.Forms.TextBox();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.deviceComboBox = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelValidation = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cancelFriendBtn = new System.Windows.Forms.Button();
            this.searchFriendBtn = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.friendNameTextBox = new System.Windows.Forms.TextBox();
            this.findFriendBtn = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.friendsList = new System.Windows.Forms.ListView();
            this.finishBtn = new System.Windows.Forms.Button();
            this.callBtn = new System.Windows.Forms.Button();
            this.waitforconnection = new System.ComponentModel.BackgroundWorker();
            this.waitformessage = new System.ComponentModel.BackgroundWorker();
            this.waitForMessage2 = new System.ComponentModel.BackgroundWorker();
            this.deleteFriendBtn = new System.Windows.Forms.Button();
            this.loginPanel.SuspendLayout();
            this.mainPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ServerIPTextBox
            // 
            this.ServerIPTextBox.Location = new System.Drawing.Point(92, 137);
            this.ServerIPTextBox.Name = "ServerIPTextBox";
            this.ServerIPTextBox.Size = new System.Drawing.Size(227, 20);
            this.ServerIPTextBox.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(89, 121);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Podaj IP serwera:";
            // 
            // acceptServIPBtn
            // 
            this.acceptServIPBtn.Location = new System.Drawing.Point(163, 176);
            this.acceptServIPBtn.Name = "acceptServIPBtn";
            this.acceptServIPBtn.Size = new System.Drawing.Size(75, 23);
            this.acceptServIPBtn.TabIndex = 2;
            this.acceptServIPBtn.Text = "Akceptuj";
            this.acceptServIPBtn.UseVisualStyleBackColor = true;
            this.acceptServIPBtn.Click += new System.EventHandler(this.acceptServIPBtn_Click);
            // 
            // loginPanel
            // 
            this.loginPanel.Controls.Add(this.label4);
            this.loginPanel.Controls.Add(this.registerLabel);
            this.loginPanel.Controls.Add(this.cancelButton1);
            this.loginPanel.Controls.Add(this.loginBtn);
            this.loginPanel.Controls.Add(this.label3);
            this.loginPanel.Controls.Add(this.label2);
            this.loginPanel.Controls.Add(this.passwordTextBox);
            this.loginPanel.Controls.Add(this.userNameTextBox);
            this.loginPanel.Location = new System.Drawing.Point(-4, -4);
            this.loginPanel.Name = "loginPanel";
            this.loginPanel.Size = new System.Drawing.Size(406, 384);
            this.loginPanel.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(79, 307);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "label4";
            // 
            // registerLabel
            // 
            this.registerLabel.AutoSize = true;
            this.registerLabel.Location = new System.Drawing.Point(83, 263);
            this.registerLabel.Name = "registerLabel";
            this.registerLabel.Size = new System.Drawing.Size(65, 13);
            this.registerLabel.TabIndex = 8;
            this.registerLabel.TabStop = true;
            this.registerLabel.Text = "Zarejestruj...";
            this.registerLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.registerLabel_LinkClicked);
            // 
            // cancelButton1
            // 
            this.cancelButton1.Location = new System.Drawing.Point(234, 200);
            this.cancelButton1.Name = "cancelButton1";
            this.cancelButton1.Size = new System.Drawing.Size(75, 23);
            this.cancelButton1.TabIndex = 7;
            this.cancelButton1.Text = "Anuluj";
            this.cancelButton1.UseVisualStyleBackColor = true;
            // 
            // loginBtn
            // 
            this.loginBtn.Location = new System.Drawing.Point(82, 200);
            this.loginBtn.Name = "loginBtn";
            this.loginBtn.Size = new System.Drawing.Size(75, 23);
            this.loginBtn.TabIndex = 6;
            this.loginBtn.Text = "Zaloguj";
            this.loginBtn.UseVisualStyleBackColor = true;
            this.loginBtn.Click += new System.EventHandler(this.loginBtn_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(79, 129);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Hasło:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(79, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Login:";
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.Location = new System.Drawing.Point(82, 145);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.PasswordChar = '*';
            this.passwordTextBox.Size = new System.Drawing.Size(227, 20);
            this.passwordTextBox.TabIndex = 1;
            // 
            // userNameTextBox
            // 
            this.userNameTextBox.Location = new System.Drawing.Point(82, 103);
            this.userNameTextBox.Name = "userNameTextBox";
            this.userNameTextBox.Size = new System.Drawing.Size(227, 20);
            this.userNameTextBox.TabIndex = 0;
            // 
            // mainPanel
            // 
            this.mainPanel.BackgroundImage = global::Client_TIP.Properties.Resources.abstract_background_design;
            this.mainPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.mainPanel.Controls.Add(this.label8);
            this.mainPanel.Controls.Add(this.deviceComboBox);
            this.mainPanel.Controls.Add(this.panel1);
            this.mainPanel.Controls.Add(this.findFriendBtn);
            this.mainPanel.Controls.Add(this.label5);
            this.mainPanel.Controls.Add(this.friendsList);
            this.mainPanel.Controls.Add(this.finishBtn);
            this.mainPanel.Controls.Add(this.callBtn);
            this.mainPanel.Location = new System.Drawing.Point(-1, -1);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(403, 381);
            this.mainPanel.TabIndex = 4;
            this.mainPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.mainPanel_Paint);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label8.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label8.Location = new System.Drawing.Point(9, 260);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(156, 17);
            this.label8.TabIndex = 12;
            this.label8.Text = "Wybierz urządzenie:";
            // 
            // deviceComboBox
            // 
            this.deviceComboBox.FormattingEnabled = true;
            this.deviceComboBox.Location = new System.Drawing.Point(12, 280);
            this.deviceComboBox.Name = "deviceComboBox";
            this.deviceComboBox.Size = new System.Drawing.Size(375, 21);
            this.deviceComboBox.TabIndex = 11;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.PaleTurquoise;
            this.panel1.Controls.Add(this.deleteFriendBtn);
            this.panel1.Controls.Add(this.labelValidation);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.cancelFriendBtn);
            this.panel1.Controls.Add(this.searchFriendBtn);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.friendNameTextBox);
            this.panel1.Location = new System.Drawing.Point(15, 157);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(375, 86);
            this.panel1.TabIndex = 10;
            // 
            // labelValidation
            // 
            this.labelValidation.AutoSize = true;
            this.labelValidation.ForeColor = System.Drawing.Color.Red;
            this.labelValidation.Location = new System.Drawing.Point(260, 10);
            this.labelValidation.Name = "labelValidation";
            this.labelValidation.Size = new System.Drawing.Size(112, 13);
            this.labelValidation.TabIndex = 5;
            this.labelValidation.Text = "Nieprawidłowa nazwa";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 5);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(102, 13);
            this.label7.TabIndex = 4;
            this.label7.Text = "Znajdź znajomego...";
            // 
            // cancelFriendBtn
            // 
            this.cancelFriendBtn.Location = new System.Drawing.Point(297, 58);
            this.cancelFriendBtn.Name = "cancelFriendBtn";
            this.cancelFriendBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelFriendBtn.TabIndex = 3;
            this.cancelFriendBtn.Text = "Anuluj";
            this.cancelFriendBtn.UseVisualStyleBackColor = true;
            this.cancelFriendBtn.Click += new System.EventHandler(this.cancelFriendBtn_Click);
            // 
            // searchFriendBtn
            // 
            this.searchFriendBtn.Location = new System.Drawing.Point(216, 58);
            this.searchFriendBtn.Name = "searchFriendBtn";
            this.searchFriendBtn.Size = new System.Drawing.Size(75, 23);
            this.searchFriendBtn.TabIndex = 2;
            this.searchFriendBtn.Text = "Szukaj...";
            this.searchFriendBtn.UseVisualStyleBackColor = true;
            this.searchFriendBtn.Click += new System.EventHandler(this.searchFriendBtn_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 32);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "Nazwa:";
            // 
            // friendNameTextBox
            // 
            this.friendNameTextBox.Location = new System.Drawing.Point(54, 29);
            this.friendNameTextBox.Name = "friendNameTextBox";
            this.friendNameTextBox.Size = new System.Drawing.Size(318, 20);
            this.friendNameTextBox.TabIndex = 0;
            this.friendNameTextBox.TextChanged += new System.EventHandler(this.friendNameTextBox_TextChanged);
            // 
            // findFriendBtn
            // 
            this.findFriendBtn.Location = new System.Drawing.Point(315, 7);
            this.findFriendBtn.Name = "findFriendBtn";
            this.findFriendBtn.Size = new System.Drawing.Size(75, 23);
            this.findFriendBtn.TabIndex = 9;
            this.findFriendBtn.Text = "Znajdź...";
            this.findFriendBtn.UseVisualStyleBackColor = true;
            this.findFriendBtn.Click += new System.EventHandler(this.findFriendBtn_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(12, 17);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(85, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Lista znajomych:";
            // 
            // friendsList
            // 
            this.friendsList.FullRowSelect = true;
            this.friendsList.Location = new System.Drawing.Point(12, 33);
            this.friendsList.Name = "friendsList";
            this.friendsList.Size = new System.Drawing.Size(378, 118);
            this.friendsList.TabIndex = 0;
            this.friendsList.UseCompatibleStateImageBehavior = false;
            this.friendsList.View = System.Windows.Forms.View.List;
            // 
            // finishBtn
            // 
            this.finishBtn.BackColor = System.Drawing.Color.Crimson;
            this.finishBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.finishBtn.ForeColor = System.Drawing.SystemColors.Window;
            this.finishBtn.Location = new System.Drawing.Point(220, 324);
            this.finishBtn.Name = "finishBtn";
            this.finishBtn.Size = new System.Drawing.Size(170, 42);
            this.finishBtn.TabIndex = 6;
            this.finishBtn.Text = "Zakończ";
            this.finishBtn.UseVisualStyleBackColor = false;
            this.finishBtn.Click += new System.EventHandler(this.finishBtn_Click);
            // 
            // callBtn
            // 
            this.callBtn.BackColor = System.Drawing.Color.LimeGreen;
            this.callBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.callBtn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.callBtn.Location = new System.Drawing.Point(12, 324);
            this.callBtn.Name = "callBtn";
            this.callBtn.Size = new System.Drawing.Size(175, 42);
            this.callBtn.TabIndex = 5;
            this.callBtn.Text = "Dzwoń";
            this.callBtn.UseVisualStyleBackColor = false;
            this.callBtn.Click += new System.EventHandler(this.callBtn_Click);
            // 
            // waitforconnection
            // 
            this.waitforconnection.DoWork += new System.ComponentModel.DoWorkEventHandler(this.waitforconnection_DoWork);
            // 
            // waitformessage
            // 
            this.waitformessage.DoWork += new System.ComponentModel.DoWorkEventHandler(this.waitformessage_DoWork);
            // 
            // waitForMessage2
            // 
            this.waitForMessage2.DoWork += new System.ComponentModel.DoWorkEventHandler(this.waitForMessage2_DoWork);
            // 
            // deleteFriendBtn
            // 
            this.deleteFriendBtn.Location = new System.Drawing.Point(135, 58);
            this.deleteFriendBtn.Name = "deleteFriendBtn";
            this.deleteFriendBtn.Size = new System.Drawing.Size(75, 23);
            this.deleteFriendBtn.TabIndex = 5;
            this.deleteFriendBtn.Text = "Usuń";
            this.deleteFriendBtn.UseVisualStyleBackColor = true;
            this.deleteFriendBtn.Click += new System.EventHandler(this.deleteFriendBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Client_TIP.Properties.Resources.comp;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(402, 378);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.loginPanel);
            this.Controls.Add(this.acceptServIPBtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ServerIPTextBox);
            this.DoubleBuffered = true;
            this.Name = "Form1";
            this.Text = "VOiP Phone";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.loginPanel.ResumeLayout(false);
            this.loginPanel.PerformLayout();
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox ServerIPTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button acceptServIPBtn;
        private System.Windows.Forms.Panel loginPanel;
        private System.Windows.Forms.LinkLabel registerLabel;
        private System.Windows.Forms.Button cancelButton1;
        private System.Windows.Forms.Button loginBtn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox passwordTextBox;
        private System.Windows.Forms.TextBox userNameTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel mainPanel;
        private System.ComponentModel.BackgroundWorker waitforconnection;
        private System.ComponentModel.BackgroundWorker waitformessage;
        private System.ComponentModel.BackgroundWorker waitForMessage2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button cancelFriendBtn;
        private System.Windows.Forms.Button searchFriendBtn;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox friendNameTextBox;
        private System.Windows.Forms.Button findFriendBtn;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListView friendsList;
        private System.Windows.Forms.Button finishBtn;
        private System.Windows.Forms.Button callBtn;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label labelValidation;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox deviceComboBox;
        private System.Windows.Forms.Button deleteFriendBtn;
    }
}

