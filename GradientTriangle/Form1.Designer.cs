namespace GradientTriangle
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.Confirm = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.chooseFirstColor = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.chooseSecondColor = new System.Windows.Forms.Button();
            this.chooseThirdColor = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // Confirm
            // 
            this.Confirm.Location = new System.Drawing.Point(733, 491);
            this.Confirm.Name = "Confirm";
            this.Confirm.Size = new System.Drawing.Size(168, 50);
            this.Confirm.TabIndex = 0;
            this.Confirm.Text = "Confirm";
            this.Confirm.UseVisualStyleBackColor = true;
            this.Confirm.Click += new System.EventHandler(this.Confirm_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(310, 491);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(124, 22);
            this.textBox1.TabIndex = 3;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(961, 452);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // chooseFirstColor
            // 
            this.chooseFirstColor.Location = new System.Drawing.Point(310, 520);
            this.chooseFirstColor.Name = "chooseFirstColor";
            this.chooseFirstColor.Size = new System.Drawing.Size(124, 23);
            this.chooseFirstColor.TabIndex = 5;
            this.chooseFirstColor.Text = "chooseFirstColor";
            this.chooseFirstColor.UseVisualStyleBackColor = true;
            this.chooseFirstColor.Click += new System.EventHandler(this.chooseFirstColor_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(440, 491);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(149, 22);
            this.textBox2.TabIndex = 7;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(595, 491);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(132, 22);
            this.textBox3.TabIndex = 8;
            // 
            // chooseSecondColor
            // 
            this.chooseSecondColor.Location = new System.Drawing.Point(440, 519);
            this.chooseSecondColor.Name = "chooseSecondColor";
            this.chooseSecondColor.Size = new System.Drawing.Size(149, 23);
            this.chooseSecondColor.TabIndex = 9;
            this.chooseSecondColor.Text = "chooseSecondColor";
            this.chooseSecondColor.UseVisualStyleBackColor = true;
            this.chooseSecondColor.Click += new System.EventHandler(this.chooseSecondColor_Click);
            // 
            // chooseThirdColor
            // 
            this.chooseThirdColor.Location = new System.Drawing.Point(595, 519);
            this.chooseThirdColor.Name = "chooseThirdColor";
            this.chooseThirdColor.Size = new System.Drawing.Size(132, 23);
            this.chooseThirdColor.TabIndex = 10;
            this.chooseThirdColor.Text = "chooseThirdColor";
            this.chooseThirdColor.UseVisualStyleBackColor = true;
            this.chooseThirdColor.Click += new System.EventHandler(this.chooseThirdColor_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(323, 471);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 17);
            this.label1.TabIndex = 11;
            this.label1.Text = "FirstCoordinates";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(440, 471);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(132, 17);
            this.label2.TabIndex = 12;
            this.label2.Text = "SecondCoordinates";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(605, 471);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(117, 17);
            this.label3.TabIndex = 13;
            this.label3.Text = "ThirdCoordinates";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(985, 562);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chooseThirdColor);
            this.Controls.Add(this.chooseSecondColor);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.chooseFirstColor);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.Confirm);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Confirm;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button chooseFirstColor;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Button chooseSecondColor;
        private System.Windows.Forms.Button chooseThirdColor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}

