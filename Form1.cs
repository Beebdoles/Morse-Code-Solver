using System.Drawing;
using System.Drawing.Configuration;
using System.Reflection.Emit;
using System.Text;
using System.Threading;

namespace Morse_Code_Solver
{
    public partial class Form1 : Form
    {
        private Boolean buttonState = true;
        private Color[] listOfColours;
        private int numOfUnits = 0;
        private Bitmap bitmap = new Bitmap(1, 1);

        private int lightLengthCount = 0;
        private Boolean isStart = false;

        private string[] listOfMorseCodeReps =
            {
                ".-", "-...", "-.-.", "-..", ".", "..-.", "--.", "....", "..", ".---", "-.-", ".-..", "--",
                "-.", "---", ".--.", "--.-", ".-.", "...", "-", "..-", "...-", ".--", "-..-", "-.--", "--.."
            };

        public Form1()
        {
            InitializeComponent();
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
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (buttonState)
            {
                Thread.Sleep(3000);
                buttonState = false;
                label2.Text = "";
                numOfUnits = 0;
                listOfColours = new Color[5000];
                timer2.Enabled = true;
            }
            else
            {
                timer2.Enabled = false;
                buttonState = true;
                string rep = decoder(pseudoMorseToMorse(colourToPseudoMorse()));
                label2.Text = rep;
            }
        }

        private List<string> colourToPseudoMorse()
        {
            List<string> morseLights = new List<string>();
            for (int i = 0; i < listOfColours.Length; ++i)
            {
                if (listOfColours[i] != Color.Empty)
                {
                    Color tempColour = listOfColours[i];
                    //set default as RGB(0, 6, 16) for black, RGB(255, 237, 59) for yellow

                    double distance1 = Math.Sqrt(Math.Pow(tempColour.R, 2) + Math.Pow(tempColour.G - 6, 2) + Math.Pow(tempColour.B - 16, 2));
                    double distance2 = Math.Sqrt(Math.Pow(tempColour.R - 255, 2) + Math.Pow(tempColour.G - 237, 2) + Math.Pow(tempColour.B - 59, 2));

                    if (distance1 > distance2)      //run some sample calculations to check whether math is being correct or not
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
                    i = 10001;                                                  //pure band aid fix
                }
            }
            return morseLights;
        }

        private List<string> pseudoMorseToMorse(List<string> morseLights)
        {
            List<string> morse = new List<string>();
            StringBuilder s = new StringBuilder();
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
                        s.Append(".");                    //appends to code
                    }
                    else if (length == 2 || length == 3) //error range
                    {
                        s.Append("-");                    //appends to code
                    }
                }
                else
                {
                    if (length == 3 || length == 4)     //error range
                    {
                        morse.Add(s.ToString());                //pushes to list as single string
                        s.Clear();
                    }
                    else if (length != 1)
                    {
                        morse.Add(s.ToString());
                        s.Clear();
                        morse.Add("|");                         //detects end of message
                    }
                }
            }
            return morse;
        }

        private string decoder(List<string> codes)                         //decodes each morse string into the corresponding letter
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < codes.Count; ++i)
            {
                for (int j = 0; j < listOfMorseCodeReps.Length; ++j)
                {
                    if (codes[i].Equals(listOfMorseCodeReps[j]))            //the lookup table cancer, terribly inneficient ik :(
                    {
                        sb.Append((char)(j + 97));
                    }
                    label1.Text += codes[i];
                }
                if (codes[i].Equals("|"))
                {
                    sb.Append("|");
                }
                label1.Text += codes[i];
            }
            return sb.ToString();
        }
    }
}
//(0 6 16) (4 7 13) (7 9 18)              (255 237 59) (255 221 61) (255 226 58)
//5.1, 7.87                                //16.1, 11
//just a comment check to see if my account settings actually work now, cause all my previous commits dont get recognized as me?