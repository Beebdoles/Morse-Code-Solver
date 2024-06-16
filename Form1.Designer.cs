namespace Morse_Code_Solver
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            pictureBox1 = new PictureBox();
            timer2 = new System.Windows.Forms.Timer(components);
            button1 = new Button();
            label2 = new Label();
            pictureBox2 = new PictureBox();
            label4 = new Label();
            label5 = new Label();
            serialTextbox = new TextBox();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            countdown = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.BorderStyle = BorderStyle.FixedSingle;
            pictureBox1.Location = new Point(247, 203);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(60, 60);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // timer2
            // 
            timer2.Interval = 300;
            timer2.Tick += timer2_Tick;
            // 
            // button1
            // 
            button1.Location = new Point(58, 259);
            button1.Name = "button1";
            button1.Size = new Size(98, 23);
            button1.TabIndex = 2;
            button1.Text = "Start timer";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(307, 148);
            label2.Name = "label2";
            label2.Size = new Size(0, 15);
            label2.TabIndex = 0;
            // 
            // pictureBox2
            // 
            pictureBox2.BackgroundImage = (Image)resources.GetObject("pictureBox2.BackgroundImage");
            pictureBox2.InitialImage = (Image)resources.GetObject("pictureBox2.InitialImage");
            pictureBox2.Location = new Point(119, 12);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(137, 138);
            pictureBox2.TabIndex = 3;
            pictureBox2.TabStop = false;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = SystemColors.ControlLight;
            label4.BorderStyle = BorderStyle.FixedSingle;
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(224, 301);
            label4.Name = "label4";
            label4.Size = new Size(41, 17);
            label4.TabIndex = 5;
            label4.Text = "Word:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(119, 153);
            label5.Name = "label5";
            label5.Size = new Size(133, 30);
            label5.TabIndex = 6;
            label5.Text = "Morse Code";
            // 
            // serialTextbox
            // 
            serialTextbox.Location = new Point(49, 221);
            serialTextbox.Name = "serialTextbox";
            serialTextbox.PlaceholderText = "Enter serial number:";
            serialTextbox.Size = new Size(116, 23);
            serialTextbox.TabIndex = 7;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(224, 266);
            label6.Name = "label6";
            label6.Size = new Size(105, 15);
            label6.TabIndex = 8;
            label6.Text = "Mouse cursor POV";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = SystemColors.ControlLight;
            label7.BorderStyle = BorderStyle.FixedSingle;
            label7.Location = new Point(224, 318);
            label7.Name = "label7";
            label7.Size = new Size(38, 17);
            label7.TabIndex = 9;
            label7.Text = "Click:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 7F, FontStyle.Regular, GraphicsUnit.Point);
            label8.ForeColor = SystemColors.ControlDarkDark;
            label8.Location = new Point(22, 291);
            label8.Name = "label8";
            label8.Size = new Size(167, 36);
            label8.TabIndex = 10;
            label8.Text = "Enter serial number, then start timer. \r\nStopping the timer will automatically \r\ndecode the word.\r\n";
            label8.TextAlign = ContentAlignment.TopCenter;
            // 
            // countdown
            // 
            countdown.AutoSize = true;
            countdown.Location = new Point(162, 263);
            countdown.Name = "countdown";
            countdown.Size = new Size(0, 15);
            countdown.TabIndex = 11;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(384, 361);
            Controls.Add(countdown);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(serialTextbox);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(pictureBox2);
            Controls.Add(label2);
            Controls.Add(button1);
            Controls.Add(pictureBox1);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private System.Windows.Forms.Timer timer2;
        private Button button1;
        private Label label2;
        private PictureBox pictureBox2;
        private Label label4;
        private Label label5;
        private TextBox serialTextbox;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label countdown;
    }
}