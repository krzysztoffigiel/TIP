namespace Client_TIP
{
    partial class Registration
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
            this.registerLoginTextBox = new System.Windows.Forms.TextBox();
            this.registerPasswordTextBox = new System.Windows.Forms.TextBox();
            this.registerIPTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.registerConfirmTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.registerBtn = new System.Windows.Forms.Button();
            this.cancelBtn2 = new System.Windows.Forms.Button();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // registerLoginTextBox
            // 
            this.registerLoginTextBox.Location = new System.Drawing.Point(96, 50);
            this.registerLoginTextBox.Name = "registerLoginTextBox";
            this.registerLoginTextBox.Size = new System.Drawing.Size(193, 20);
            this.registerLoginTextBox.TabIndex = 0;
            // 
            // registerPasswordTextBox
            // 
            this.registerPasswordTextBox.Location = new System.Drawing.Point(96, 93);
            this.registerPasswordTextBox.Name = "registerPasswordTextBox";
            this.registerPasswordTextBox.PasswordChar = '*';
            this.registerPasswordTextBox.Size = new System.Drawing.Size(193, 20);
            this.registerPasswordTextBox.TabIndex = 1;
            // 
            // registerIPTextBox
            // 
            this.registerIPTextBox.Location = new System.Drawing.Point(96, 176);
            this.registerIPTextBox.Name = "registerIPTextBox";
            this.registerIPTextBox.Size = new System.Drawing.Size(193, 20);
            this.registerIPTextBox.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(93, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Login:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(93, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Hasło:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(93, 160);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Twoje IP:";
            // 
            // registerConfirmTextBox
            // 
            this.registerConfirmTextBox.Location = new System.Drawing.Point(96, 135);
            this.registerConfirmTextBox.Name = "registerConfirmTextBox";
            this.registerConfirmTextBox.PasswordChar = '*';
            this.registerConfirmTextBox.Size = new System.Drawing.Size(193, 20);
            this.registerConfirmTextBox.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(94, 119);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Potwierdź hasło:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(306, 160);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "label5";
            // 
            // registerBtn
            // 
            this.registerBtn.Location = new System.Drawing.Point(96, 214);
            this.registerBtn.Name = "registerBtn";
            this.registerBtn.Size = new System.Drawing.Size(75, 23);
            this.registerBtn.TabIndex = 9;
            this.registerBtn.Text = "Zarejestruj";
            this.registerBtn.UseVisualStyleBackColor = true;
            this.registerBtn.Click += new System.EventHandler(this.registerBtn_Click);
            // 
            // cancelBtn2
            // 
            this.cancelBtn2.Location = new System.Drawing.Point(214, 214);
            this.cancelBtn2.Name = "cancelBtn2";
            this.cancelBtn2.Size = new System.Drawing.Size(75, 23);
            this.cancelBtn2.TabIndex = 10;
            this.cancelBtn2.Text = "Anuluj";
            this.cancelBtn2.UseVisualStyleBackColor = true;
            this.cancelBtn2.Click += new System.EventHandler(this.cancelBtn2_Click);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(94, 254);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(138, 13);
            this.linkLabel1.TabIndex = 11;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Jestem już zarejestrowany...";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // Registration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(386, 289);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.cancelBtn2);
            this.Controls.Add(this.registerBtn);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.registerConfirmTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.registerIPTextBox);
            this.Controls.Add(this.registerPasswordTextBox);
            this.Controls.Add(this.registerLoginTextBox);
            this.Name = "Registration";
            this.Text = "Reestracja";
            this.Load += new System.EventHandler(this.Registration_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox registerLoginTextBox;
        private System.Windows.Forms.TextBox registerPasswordTextBox;
        private System.Windows.Forms.TextBox registerIPTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox registerConfirmTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button registerBtn;
        private System.Windows.Forms.Button cancelBtn2;
        private System.Windows.Forms.LinkLabel linkLabel1;
    }
}