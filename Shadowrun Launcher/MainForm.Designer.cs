using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;
using System.Drawing.Imaging;
using System.Drawing;
using System.Windows.Forms;
using System;
using System.Linq;

namespace Shadowrun_Launcher
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.VersionText = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.pictureBox1 = new Shadowrun_Launcher.TransparentPictureBox();
            this.pictureBox2 = new Shadowrun_Launcher.TransparentPictureBox();
            this.pictureBox3 = new Shadowrun_Launcher.TransparentPictureBox();
            this.pictureBox4 = new Shadowrun_Launcher.TransparentPictureBox();
            this.pictureBox5 = new Shadowrun_Launcher.TransparentPictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.Location = new System.Drawing.Point(23, 166);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(190, 42);
            this.button1.TabIndex = 1;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.PlayButton_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Transparent;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Image = ((System.Drawing.Image)(resources.GetObject("button2.Image")));
            this.button2.Location = new System.Drawing.Point(23, 212);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(190, 42);
            this.button2.TabIndex = 2;
            this.button2.Text = "Website";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // VersionText
            // 
            this.VersionText.AutoSize = true;
            this.VersionText.BackColor = System.Drawing.Color.Transparent;
            this.VersionText.ForeColor = System.Drawing.Color.White;
            this.VersionText.Location = new System.Drawing.Point(13, 525);
            this.VersionText.Name = "VersionText";
            this.VersionText.Size = new System.Drawing.Size(42, 13);
            this.VersionText.TabIndex = 4;
            this.VersionText.Text = "Version";
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.Transparent;
            this.button4.FlatAppearance.BorderSize = 0;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.ForeColor = System.Drawing.Color.White;
            this.button4.Image = ((System.Drawing.Image)(resources.GetObject("button4.Image")));
            this.button4.Location = new System.Drawing.Point(23, 258);
            this.button4.Margin = new System.Windows.Forms.Padding(2);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(190, 42);
            this.button4.TabIndex = 5;
            this.button4.Text = "Generate Key";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.Transparent;
            this.button5.FlatAppearance.BorderSize = 0;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.ForeColor = System.Drawing.Color.White;
            this.button5.Image = ((System.Drawing.Image)(resources.GetObject("button5.Image")));
            this.button5.Location = new System.Drawing.Point(23, 304);
            this.button5.Margin = new System.Windows.Forms.Padding(2);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(190, 42);
            this.button5.TabIndex = 6;
            this.button5.Text = "DXVK Fix";
            this.button5.UseVisualStyleBackColor = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(355, 111);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Opacity = 255;
            this.pictureBox1.Size = new System.Drawing.Size(301, 301);
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(355, 111);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Opacity = 255;
            this.pictureBox2.Size = new System.Drawing.Size(301, 301);
            this.pictureBox2.TabIndex = 8;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(355, 111);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Opacity = 255;
            this.pictureBox3.Size = new System.Drawing.Size(301, 301);
            this.pictureBox3.TabIndex = 9;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
            this.pictureBox4.Location = new System.Drawing.Point(355, 111);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Opacity = 255;
            this.pictureBox4.Size = new System.Drawing.Size(301, 301);
            this.pictureBox4.TabIndex = 10;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox5
            // 
            this.pictureBox5.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox5.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox5.Image")));
            this.pictureBox5.Location = new System.Drawing.Point(355, 111);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Opacity = 255;
            this.pictureBox5.Size = new System.Drawing.Size(301, 301);
            this.pictureBox5.TabIndex = 11;
            this.pictureBox5.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Highlight;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(730, 550);
            this.Controls.Add(this.pictureBox5);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.VersionText);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GWFL Online Fixer";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label VersionText;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private TransparentPictureBox pictureBox1;
        private TransparentPictureBox pictureBox2;
        private TransparentPictureBox pictureBox3;
        private TransparentPictureBox pictureBox4;
        private TransparentPictureBox pictureBox5;
    }

    internal class TransparentPictureBox : PictureBox
    {
        private int opacity = 255; // Initial opacity (fully opaque)

        // Property to get or set the opacity value (from 0 to 255)
        public int Opacity
        {
            get { return opacity; }
            set
            {
                opacity = Math.Max(0, Math.Min(255, value)); // Ensure opacity value is within range
                Invalidate(); // Invalidate the control to trigger a redraw
            }
        }

        public TransparentPictureBox()
        {
            this.BackColor = Color.Transparent;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (Parent != null && this.BackColor == Color.Transparent)
            {
                using (var bmp = new Bitmap(Parent.Width, Parent.Height))
                {
                    using (var tempGraphics = Graphics.FromImage(bmp))
                    {
                        tempGraphics.Clear(Color.Transparent);

                        // Draw overlapped controls onto the temporary bitmap
                        Parent.Controls.Cast<Control>()
                              .Where(c => Parent.Controls.GetChildIndex(c) > Parent.Controls.GetChildIndex(this))
                              .Where(c => c.Bounds.IntersectsWith(this.Bounds))
                              .OrderByDescending(c => Parent.Controls.GetChildIndex(c))
                              .ToList()
                              .ForEach(c => c.DrawToBitmap(bmp, c.Bounds));
                    }

                    // Apply opacity to the entire bitmap
                    using (var adjustedImage = AdjustImageOpacity(bmp, opacity))
                    {
                        e.Graphics.DrawImage(adjustedImage, -Left, -Top);
                    }
                }
            }
            base.OnPaint(e);
        }

        // Method to adjust the opacity of an image
        private Bitmap AdjustImageOpacity(Bitmap image, int opacity)
        {
            Bitmap adjustedImage = new Bitmap(image.Width, image.Height);
            using (Graphics g = Graphics.FromImage(adjustedImage))
            {
                ColorMatrix colorMatrix = new ColorMatrix();
                colorMatrix.Matrix33 = opacity / 255f; // Set the alpha value

                ImageAttributes attributes = new ImageAttributes();
                attributes.SetColorMatrix(colorMatrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);

                g.DrawImage(image, new Rectangle(0, 0, image.Width, image.Height), 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, attributes);
            }
            return adjustedImage;
        }
    }
}
