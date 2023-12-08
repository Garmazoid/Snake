using System.Diagnostics;

namespace WinFormsApp1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.MAIN_SNAKE = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.oakIMG = new System.Windows.Forms.PictureBox();
            this.BirchIMG = new System.Windows.Forms.PictureBox();
            this.APPLE2 = new System.Windows.Forms.PictureBox();
            this.APPLE1 = new System.Windows.Forms.PictureBox();
            this.APPLE3 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.oakIMG)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BirchIMG)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.APPLE2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.APPLE1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.APPLE3)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 200;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // MAIN_SNAKE
            // 
            this.MAIN_SNAKE.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.MAIN_SNAKE.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MAIN_SNAKE.Font = new System.Drawing.Font("Segoe UI Black", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.MAIN_SNAKE.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.MAIN_SNAKE.Location = new System.Drawing.Point(504, 283);
            this.MAIN_SNAKE.Name = "MAIN_SNAKE";
            this.MAIN_SNAKE.Size = new System.Drawing.Size(50, 50);
            this.MAIN_SNAKE.TabIndex = 0;
            this.MAIN_SNAKE.UseVisualStyleBackColor = false;
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Magenta;
            this.imageList1.Images.SetKeyName(0, "oak.jpg");
            // 
            // oakIMG
            // 
            this.oakIMG.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("oakIMG.BackgroundImage")));
            this.oakIMG.Location = new System.Drawing.Point(-100, 0);
            this.oakIMG.Name = "oakIMG";
            this.oakIMG.Size = new System.Drawing.Size(50, 50);
            this.oakIMG.TabIndex = 8;
            this.oakIMG.TabStop = false;
            // 
            // BirchIMG
            // 
            this.BirchIMG.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BirchIMG.BackgroundImage")));
            this.BirchIMG.Location = new System.Drawing.Point(-50, 0);
            this.BirchIMG.Name = "BirchIMG";
            this.BirchIMG.Size = new System.Drawing.Size(50, 50);
            this.BirchIMG.TabIndex = 9;
            this.BirchIMG.TabStop = false;
            // 
            // APPLE2
            // 
            this.APPLE2.BackColor = System.Drawing.Color.Transparent;
            this.APPLE2.Image = ((System.Drawing.Image)(resources.GetObject("APPLE2.Image")));
            this.APPLE2.Location = new System.Drawing.Point(596, 292);
            this.APPLE2.Name = "APPLE2";
            this.APPLE2.Size = new System.Drawing.Size(30, 32);
            this.APPLE2.TabIndex = 11;
            this.APPLE2.TabStop = false;
            // 
            // APPLE1
            // 
            this.APPLE1.BackColor = System.Drawing.Color.Transparent;
            this.APPLE1.Image = ((System.Drawing.Image)(resources.GetObject("APPLE1.Image")));
            this.APPLE1.Location = new System.Drawing.Point(560, 292);
            this.APPLE1.Name = "APPLE1";
            this.APPLE1.Size = new System.Drawing.Size(30, 32);
            this.APPLE1.TabIndex = 10;
            this.APPLE1.TabStop = false;
            // 
            // APPLE3
            // 
            this.APPLE3.BackColor = System.Drawing.Color.Transparent;
            this.APPLE3.Image = ((System.Drawing.Image)(resources.GetObject("APPLE3.Image")));
            this.APPLE3.Location = new System.Drawing.Point(632, 292);
            this.APPLE3.Name = "APPLE3";
            this.APPLE3.Size = new System.Drawing.Size(30, 32);
            this.APPLE3.TabIndex = 12;
            this.APPLE3.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.HotTrack;
            this.ClientSize = new System.Drawing.Size(1127, 691);
            this.Controls.Add(this.APPLE3);
            this.Controls.Add(this.APPLE2);
            this.Controls.Add(this.APPLE1);
            this.Controls.Add(this.MAIN_SNAKE);
            this.Controls.Add(this.BirchIMG);
            this.Controls.Add(this.oakIMG);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Змейка";
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.oakIMG)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BirchIMG)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.APPLE2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.APPLE1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.APPLE3)).EndInit();
            this.ResumeLayout(false);

        }


        #endregion

        private System.Windows.Forms.Timer timer1;
        private Button MAIN_SNAKE;
        private ImageList imageList1;
        private PictureBox oakIMG;
        private PictureBox BirchIMG;
        private PictureBox APPLE2;
        private PictureBox APPLE1;
        private PictureBox APPLE3;
    }
}