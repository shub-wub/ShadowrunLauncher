using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shadowrun_Launcher.Logic
{
    internal class ImageRotator
    {
        private PictureBox pictureBox;
        private Bitmap originalImage;
        private Bitmap rotatedImage;
        private Timer rotationTimer;
        private int rotationAngle; // Variable to hold rotation angle
        private int rotationSpeed; // Variable to hold rotation speed

        public ImageRotator(PictureBox pictureBox, int speed)
        {
            this.pictureBox = pictureBox;
            originalImage = (Bitmap)pictureBox.Image.Clone(); // Clone the image from PictureBox
            rotationAngle = 0;
            rotationSpeed = speed;

            // Initialize and configure the timer
            rotationTimer = new Timer();
            rotationTimer.Interval = 10; // Adjust as needed
            rotationTimer.Tick += RotationTimer_Tick;

            // Start the rotation timer
            rotationTimer.Start();
        }

        private void RotationTimer_Tick(object sender, EventArgs e)
        {
            // Increment rotation angle
            rotationAngle += rotationSpeed;

            // Rotate the image continuously with the set speed
            RotateImage(rotationAngle);
        }

        private void RotateImage(int angle)
        {
            // Create a new bitmap for the rotated image
            rotatedImage = new Bitmap(originalImage.Width, originalImage.Height);

            // Create a graphics object from the rotated image
            using (Graphics g = Graphics.FromImage(rotatedImage))
            {
                // Clear the graphics surface
                g.Clear(Color.Transparent);

                // Set the rotation point to the center of the image
                g.TranslateTransform(originalImage.Width / 2, originalImage.Height / 2);

                // Rotate the image
                g.RotateTransform(angle);

                // Draw the original image onto the rotated image
                g.DrawImage(originalImage, new Rectangle(-originalImage.Width / 2, -originalImage.Height / 2, originalImage.Width, originalImage.Height));
            }

            // Display the rotated image
            pictureBox.Image = rotatedImage;
        }
    }
}
