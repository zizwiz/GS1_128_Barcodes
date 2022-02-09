using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using BarcodeGenerator.Code128GS1;
using GS1_128_Barcodes.Properties;




// check the number is in legal set to use

namespace GS1_128_Barcodes
{
    public partial class Form1 : Form
    {
        //create and instance of PrivateFontCollection
        PrivateFontCollection pfc = new PrivateFontCollection();

        public Form1()
        {
            InitializeComponent();
        }

        private void btn_make_image_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "Png files (*.png)|*.png|All files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 1;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                var path = saveFileDialog1.FileName;

                var bitmap = new Bitmap(picbx_output.Size.Width, picbx_output.Size.Height);
                picbx_output.DrawToBitmap(bitmap, new Rectangle(0, 0, bitmap.Width, bitmap.Height));
                bitmap.Save(path, ImageFormat.Png);
            }
        }

        private void btn_print_Click(object sender, EventArgs e)
        {
            printDocument.Print();
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            if (Regex.IsMatch(txtbx_bar_width.Text, @"^\d+$")) //is it a number
            {
                GenerateBarCode(int.Parse(txtbx_bar_width.Text));
            }
            else
            {
                MessageBox.Show("You must enter a Bar Width number", "No Data", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void GenerateBarCode(int BarWidth)
        {
            if (txtbx_data_input.Text != "")
            {
                BarCodeEncoder c128 = new BarCodeEncoder();
                BarcodeImage barcodeImage = new BarcodeImage();


                //Draw Barcode
                Bitmap barcode = (Bitmap) barcodeImage.CreateImage(
                    c128.Encode(txtbx_data_input.Text),
                    BarWidth,
                    chkbx_add_qz.Checked);

                if (chckbx_hrFlag.Checked)
                {
                    //Draw Human Readable
                    //Work out the width of the text 
                    Font f = new Font(pfc.Families[0], 7 * float.Parse(txtbx_bar_width.Text), FontStyle.Regular);
                    SizeF sizeOfString = Graphics.FromImage(new Bitmap(barcode.Width, barcode.Height))
                        .MeasureString(txtbx_data_input.Text, f);

                    // make a bitmap of the text
                    Bitmap bitmap = new Bitmap(barcode.Width, 10 * int.Parse(txtbx_bar_width.Text));
                    Graphics g = Graphics.FromImage(bitmap);

                    g.SmoothingMode = SmoothingMode.AntiAlias;
                    g.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
                    g.Clear(Color.Transparent);

                    TextRenderer.DrawText(g, txtbx_data_input.Text,
                        new Font(pfc.Families[0], 7 * float.Parse(txtbx_bar_width.Text)),
                        new Point(0, 0), Color.Black, Color.White);

                    g.Dispose();

                    //Combine HR with Barocde.
                    picbx_output.Image = MergedBitmaps(barcode, bitmap, sizeOfString);
                }
                else
                {
                    //Just show the barcode
                    picbx_output.Image = barcode;
                }
            }
            else
            {
                MessageBox.Show("You must enter some data", "No Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btn_makeBigger_Click(object sender, EventArgs e)
        {
            int BarSize = int.Parse(txtbx_bar_width.Text) + 1;
            txtbx_bar_width.Text = BarSize.ToString();
            GenerateBarCode(BarSize);
        }

        private void btn_makeSmaller_Click(object sender, EventArgs e)
        {
            int BarSize = int.Parse(txtbx_bar_width.Text) - 1;
            if (BarSize < 1)
            {
                BarSize = 1;
                MessageBox.Show("Bar Width cannot be less than 1", "Bar Size too Small", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }

            txtbx_bar_width.Text = BarSize.ToString();
            GenerateBarCode(BarSize);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //We add the font file to resources so we know it will be on the computer
            //we we load the form we need ot get hold of the font file and this is how I do it.
            // there are other ways to do it using unsafe code but I do it this way.

            //Write the byte array to a file in same directory as the exe we are running
            File.WriteAllBytes("OCRB_Regular.ttf", Resources.OCRB_Regular.ToArray());

            //add the font file to our instance of PrivateFontCollection
            pfc.AddFontFile(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\OCRB_Regular.ttf");

            fill_ai_test_data();
            cmbobx_ai_test_data.SelectedIndex = 0;
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private Bitmap MergedBitmaps(Bitmap bmp1, Bitmap bmp2, SizeF sizeOfString)
        {

            //Work out where the Human readable will start so it is centered on BarCode
            int _startPoint = (bmp1.Width - (int) Math.Round(sizeOfString.Width)) / 2;


            //make it the width of the largest and the height of both combined
            Bitmap result = new Bitmap(Math.Max(bmp1.Width, bmp2.Width), bmp1.Height + bmp2.Height);

            Graphics g = Graphics.FromImage(result);
            g.Clear(Color.White);

            using (g)
            {
                g.DrawImage(bmp2, _startPoint, bmp1.Height);
                g.DrawImage(bmp1, 0, 0);
            }

            return result;
        }


        private void printDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            using (var g = e.Graphics)
            {
                using (var fnt = new Font("\\OCRB_Regular.ttf", 14))
                {
                    var caption = $"Code128 barcode";
                    g.DrawString(caption, fnt, Brushes.Black, 50, 50);
                    caption = $"Bar Weight = {txtbx_bar_width.Text}";
                    g.DrawString(caption, fnt, Brushes.Black, 50, 75);
                    caption = $"Data = '{txtbx_data_input.Text}'";
                    g.DrawString(caption, fnt, Brushes.Black, 50, 100);
                    g.DrawImage(picbx_output.Image, 50, 135);
                }
            }
        }



        private void btn_decipher_Click(object sender, EventArgs e)
        {
            rchtxtbx_output.Clear();

            string _barCodeData = txtbx_data_input.Text;
            int _ai = 0;


            if (CheckData.IsCharLegal(_barCodeData))
            {

                int[] data = new int[_barCodeData.Length];
                int count = 0;


                //find all instances of char (
                for (int i = _barCodeData.IndexOf('('); i > -1; i = _barCodeData.IndexOf('(', i + 1))
                {
                    data[count] = i;
                    count += 2;
                }

                count = 1;

                //find all instances of char (
                for (int i = _barCodeData.IndexOf(')'); i > -1; i = _barCodeData.IndexOf(')', i + 1))
                {
                    data[count] = i;
                    count += 2;
                }

                data[count - 1] = _barCodeData.Length; //need value of end of string for calculations
                Array.Resize(ref data, count);

                //Go through the string and pull out AI and following information
                for (int i = 0; i < data.Length - 1; i += 2)
                {
                    int a = data[i] + 1; // AI Start
                    int b = data[i + 1] - a; // AI Length

                    int c = data[i + 1] + 1; // Data Start
                    int d = data[i + 2] - c; // Data end

                    string ai = _barCodeData.Substring(a, b);
                    string _data = _barCodeData.Substring(c, d);
                    if (ai.Length>3) {_ai = int.Parse(ai.Substring(0, 3));} // for ai that are longer than 3 

                    //Some ai use various sub-numbers and we include them all in the same class
                    //here we send over all the data as some of it dictates the decimal point etc
                    if ((_ai >= 310) && (_ai <= 316))
                    {
                        _data = ai + _data;
                        ai = "31nn";
                    }
                    else if ((_ai >= 320) && (_ai <= 329))
                    {
                        _data = ai + _data;
                        ai = "32nn";
                    }
                    else if ((_ai >= 330) && (_ai <= 336))
                    {
                        _data = ai + _data;
                        ai = "33nn";
                    }
                    else if ((_ai >= 340) && (_ai <= 349))
                    {
                        _data = ai + _data;
                        ai = "34nn";
                    }
                    else if ((_ai >= 350) && (_ai <= 357))
                    {
                        _data = ai + _data;
                        ai = "35nn";
                    }
                    else if ((_ai >= 360) && (_ai <= 369))
                    {
                        _data = ai + _data;
                        ai = "36nn";
                    }

                    DecipherData(ai,_data);
                }
            }
            else
            {
                MessageBox.Show("Found a non-legal character\rCheck the barcode data is correct");
            }
        }

       
    }
}
