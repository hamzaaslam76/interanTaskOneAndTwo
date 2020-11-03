namespace StudentWindowsFormApplication
{
    partial class UpdateStudent
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
            this.courseAdd = new System.Windows.Forms.ListBox();
            this.label7 = new System.Windows.Forms.Label();
            this.dateofbirth = new System.Windows.Forms.DateTimePicker();
            this.button1 = new System.Windows.Forms.Button();
            this.confiramPass = new System.Windows.Forms.TextBox();
            this.password = new System.Windows.Forms.TextBox();
            this.phone = new System.Windows.Forms.TextBox();
            this.email = new System.Windows.Forms.TextBox();
            this.name = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // courseAdd
            // 
            this.courseAdd.FormattingEnabled = true;
            this.courseAdd.Location = new System.Drawing.Point(386, 125);
            this.courseAdd.Name = "courseAdd";
            this.courseAdd.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.courseAdd.Size = new System.Drawing.Size(172, 121);
            this.courseAdd.TabIndex = 31;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(281, 138);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(40, 13);
            this.label7.TabIndex = 30;
            this.label7.Text = "Course";
            // 
            // dateofbirth
            // 
            this.dateofbirth.Location = new System.Drawing.Point(86, 137);
            this.dateofbirth.Name = "dateofbirth";
            this.dateofbirth.Size = new System.Drawing.Size(182, 20);
            this.dateofbirth.TabIndex = 29;
            this.dateofbirth.Value = new System.DateTime(2020, 10, 27, 0, 0, 0, 0);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.button1.Location = new System.Drawing.Point(423, 362);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 28;
            this.button1.Text = "Update";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // confiramPass
            // 
            this.confiramPass.Location = new System.Drawing.Point(385, 307);
            this.confiramPass.Name = "confiramPass";
            this.confiramPass.Size = new System.Drawing.Size(173, 20);
            this.confiramPass.TabIndex = 27;
            this.confiramPass.TextChanged += new System.EventHandler(this.confiramPass_TextChanged);
            // 
            // password
            // 
            this.password.Location = new System.Drawing.Point(95, 312);
            this.password.Name = "password";
            this.password.Size = new System.Drawing.Size(173, 20);
            this.password.TabIndex = 26;
            // 
            // phone
            // 
            this.phone.Location = new System.Drawing.Point(91, 225);
            this.phone.Name = "phone";
            this.phone.Size = new System.Drawing.Size(177, 20);
            this.phone.TabIndex = 25;
            // 
            // email
            // 
            this.email.Location = new System.Drawing.Point(380, 66);
            this.email.Name = "email";
            this.email.Size = new System.Drawing.Size(178, 20);
            this.email.TabIndex = 24;
            // 
            // name
            // 
            this.name.Location = new System.Drawing.Point(86, 70);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(182, 20);
            this.name.TabIndex = 23;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(281, 314);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(97, 13);
            this.label6.TabIndex = 22;
            this.label6.Text = "Confiram Password";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 312);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 13);
            this.label5.TabIndex = 21;
            this.label5.Text = "Password";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 225);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 13);
            this.label4.TabIndex = 20;
            this.label4.Text = "Phone Number";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(2, 144);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 19;
            this.label3.Text = "DataOfBirth";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(275, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "Email";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(2, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "Name";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(580, 66);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(218, 180);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 32;
            this.pictureBox2.TabStop = false;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(653, 302);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(109, 23);
            this.button2.TabIndex = 33;
            this.button2.Text = "Change Image";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // UpdateStudent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.courseAdd);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.dateofbirth);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.confiramPass);
            this.Controls.Add(this.password);
            this.Controls.Add(this.phone);
            this.Controls.Add(this.email);
            this.Controls.Add(this.name);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "UpdateStudent";
            this.Text = "UpdateStudent";
            this.Load += new System.EventHandler(this.UpdateStudent_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox courseAdd;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dateofbirth;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox confiramPass;
        private System.Windows.Forms.TextBox password;
        private System.Windows.Forms.TextBox phone;
        private System.Windows.Forms.TextBox email;
        private System.Windows.Forms.TextBox name;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button button2;
    }
}