using System.Drawing;
using System.Drawing.Configuration;
using System.Reflection.Emit;
using System.Threading;

namespace Morse_Code_Solver
{
    public partial class Form1 : Form
    {
        private Boolean buttonState = true;
        private Color[] listOfColours;
        private List<string> morseLights = new List<string>();
        private List<string> morse = new List<string>();
        private int numOfUnits = 0;
        private Bitmap bitmap = new Bitmap(1, 1);

        public Form1()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //takeColour();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void takeColour(int n)
        {
            Rectangle bounds = new Rectangle(MousePosition.X, MousePosition.Y, 1, 1);
            using (Graphics graphics = Graphics.FromImage(bitmap))
                graphics.CopyFromScreen(bounds.Location, Point.Empty, bounds.Size);
            Color colour = bitmap.GetPixel(0, 0);

            //label1.Text = colour.ToString();
            pictureBox1.BackColor = colour;

            listOfColours[n] = colour;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            takeColour(numOfUnits);
            ++numOfUnits;
            //pictureBox2.BackColor
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (buttonState)
            {
                Thread.Sleep(3000);
                buttonState = false;
                label2.Text = "";
                label3.Text = "";
                label4.Text = "";
                numOfUnits = 0;
                listOfColours = new Color[5000];
                morseLights.Clear();
                morse.Clear();
                timer2.Enabled = true;
            }
            else
            {
                timer2.Enabled = false;
                buttonState = true;
                colourToPseudoMorse();
                pseudoMorseToMorse();
                string rep = "";
                for (int i = 0; i < morse.Count; ++i)
                {
                    rep += morse[i];
                }
                label2.Text = rep;
            }
        }

        private void colourToPseudoMorse()
        {
            for (int i = 0; i < listOfColours.Length; ++i)
            {
                if (listOfColours[i] != Color.Empty)
                {
                    Color tempColour = listOfColours[i];
                    //set default as RGB(0, 6, 16) for black, RGB(255, 237, 59)

                    double distance1 = Math.Sqrt(Math.Pow(tempColour.R, 2) + Math.Pow(tempColour.G - 6, 2) + Math.Pow(tempColour.B - 16, 2));
                    double distance2 = Math.Sqrt(Math.Pow(tempColour.R - 255, 2) + Math.Pow(tempColour.G - 237, 2) + Math.Pow(tempColour.B - 59, 2));

                    if (distance1 > distance2) //this is wacky, but apparently farther away => closer colour???
                    {
                        morseLights.Add("1");
                        label3.Text += "1";
                    }
                    else
                    {
                        morseLights.Add("0");
                        label3.Text += "0";
                    }
                    label4.Text += distance1 + " " + distance2 + " ";
                }
                else
                {
                    i = 10001;
                }
                //label2.Text += String.Join("", morseLights);
            }
        }

        private void pseudoMorseToMorse()
        {
            for (int i = 0; i < morseLights.Count; ++i)
            {
                string symbol = morseLights[i];
                int length = 0;
                Boolean condition = true;
                while (condition)
                {
                    if (i < morseLights.Count && morseLights[i].Equals(symbol))
                    {
                        ++length;
                        ++i;
                    }
                    else
                    {
                        condition = false;
                        --i;
                    }
                }
                if (symbol.Equals("1"))
                {
                    if (length == 1)
                    {
                        morse.Add(".");
                    }
                    else if(length == 2 || length == 3 || length == 4) //error range
                    {
                        morse.Add("-");
                    }
                }
                else
                {
                    if (length == 3 || length == 4 || length == 2) //error range
                    {
                        morse.Add("/");
                    }
                    else if(length != 1)
                    {
                        morse.Add("|");
                    }
                }
            }
        }
    }

    //add a lookup table for morse code values :)
    //(0 6 16) (4 7 13) (7 9 18)              (255 237 59) (255 221 61) (255 226 58)
    //5.1, 7.87                                //16.1, 11
}