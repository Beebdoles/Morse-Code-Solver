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
                buttonState = false;
                button1.Enabled = false;
                label7.Text = "Click: ";
                for (int i = 3; i > -1; --i)
                {
                    countdown.Text = Convert.ToString(i) + ".";
                    Task.Delay(333).Wait();
                    countdown.Text = Convert.ToString(i) + "..";
                    Task.Delay(333).Wait();
                    countdown.Text = Convert.ToString(i) + "...";
                    Task.Delay(333).Wait();
                }
                button1.Enabled = true;
                label4.Text = "Word: ";
                numOfUnits = 0;
                listOfColours = new Color[5000];
                timer2.Enabled = true;
                button1.Text = "Stop timer";
            }
            else
            {
                timer2.Enabled = false;
                buttonState = true;
                label4.Text = "Word: " + decoder(pseudoMorseToMorse(colourToPseudoMorse()));
                countdown.Text = String.Empty;
                label7.Text = "Click: " + processSerialNum();
                button1.Text = "Start timer";
            }
        }

        private String processSerialNum()
        {
            if(serialTextbox.Text.Contains("A"))
            {
                return "Yellow";
            }
            else if(serialTextbox.Text.Contains("6"))
            {
                return "Blue";
            }
            else if(serialTextbox.Text.Contains("D"))
            {
                return "Blue";
            }
            else if(serialTextbox.Text.Contains("8"))
            {
                return "Blue";
            }
            else if(serialTextbox.Text.Contains("I"))
            {
                return "Yellow";
            }
            else if(serialTextbox.Text.Contains("1"))
            {
                return "Yellow";
            }
            else
            {
                return "Blue";
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

                    if (distance1 > distance2)
                    {
                        morseLights.Add("1");
                    }
                    else
                    {
                        morseLights.Add("0");
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
                }
                if (codes[i].Equals("|"))
                {
                    sb.Append("|");
                }
            }
            return sb.ToString();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
//(0 6 16) (4 7 13) (7 9 18)              (255 237 59) (255 221 61) (255 226 58)
//5.1, 7.87                                //16.1, 11
//just a comment check to see if my account settings actually work now, cause all my previous commits dont get recognized as me?