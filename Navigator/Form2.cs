using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Diagnostics;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace Navigator
{

    public partial class Form2 : Form
    {

        public Form2()
        {
            InitializeComponent();

        }


        static Image FixedSize(string imagePath, int width, int height)
        {
            if (string.IsNullOrEmpty(imagePath))
                throw new ArgumentException("Invalid image path.", nameof(imagePath));

            using (FileStream stream = new FileStream(imagePath, FileMode.Open, FileAccess.Read))
            using (Image imgPhoto = Image.FromStream(stream, false, false))
            {
                int sourceWidth = imgPhoto.Width;
                int sourceHeight = imgPhoto.Height;

                float scale = Math.Min((float)width / sourceWidth, (float)height / sourceHeight);

                int destWidth = (int)(sourceWidth * scale);
                int destHeight = (int)(sourceHeight * scale);

                int destX = (width - destWidth) / 2;
                int destY = (height - destHeight) / 2;

                Bitmap bmPhoto = new Bitmap(width, height, imgPhoto.PixelFormat);
                bmPhoto.SetResolution(imgPhoto.HorizontalResolution, imgPhoto.VerticalResolution);

                using (Graphics grPhoto = Graphics.FromImage(bmPhoto))
                {
                    grPhoto.Clear(Color.Black);
                    grPhoto.InterpolationMode = InterpolationMode.NearestNeighbor;
                    grPhoto.DrawImage(imgPhoto, new Rectangle(destX, destY, destWidth, destHeight), new Rectangle(0, 0, sourceWidth, sourceHeight), GraphicsUnit.Pixel);
                }

                return bmPhoto;
            }
        }

        private void loadImage(PictureBox pic, string path)
        {
            pic.Image = FixedSize(path, 400, 400); // get image call, idk
            }

        private void Form2_Load(object sender, EventArgs e)
                {

                    string[] filePaths = System.IO.Directory.GetFiles(@"E:\camerastuff\temp\");
                    Console.WriteLine($"{filePaths}");

                    double count = 0.0;

                    for (int i = 0; i < filePaths.Length; i++)
                    {
                        int y = (int)(410.0 + (400.0 * Math.Floor((count - 5.0) / 5.0)));
                        int x = (int)(410.0 + (400.0 * (count % 5.0)) - 400.0);

                        string path = filePaths[i];

                        if (path.Contains(".JPG") || path.Contains(".jpg")|| path.Contains(".png") || path.Contains(".PNG"))
                        {
                            var picture = new PictureBox();
                            picture.Name = "pictureBox";
                            picture.Size = new Size(400, 400);
                            picture.Location = new Point(x, y);
                            picture.Image = FixedSize(path, 400, 400);
                            Thread thread = new Thread(() => loadImage(picture, path));
                            thread.Start();

                            Console.WriteLine($"Image: {count}");

                            picture.Click += (sender1, args) =>
                            {
                                Process.Start(path);
                            };

                            this.Controls.Add(picture);
                            count += 1.0;
                        }

                    }

                }
    }
}

