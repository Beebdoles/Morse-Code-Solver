using System.Drawing;
using System.Drawing.Configuration;
using System.Reflection.Emit;
using System.Threading;

namespace Morse_Code_Solver
{
    public partial class Form1 : Form
    {
        private Boolean buttonState = true;
        private List<string> morseLights = new List<string>();
        private string morse;
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

        private void takeColour()   //attempt is being made to make program self detect the end of a word
        {
            Rectangle bounds = new Rectangle(MousePosition.X, MousePosition.Y, 1, 1);
            using (Graphics graphics = Graphics.FromImage(bitmap))
                graphics.CopyFromScreen(bounds.Location, Point.Empty, bounds.Size);
            Color colour = bitmap.GetPixel(0, 0);

            //label1.Text = colour.ToString();
            pictureBox1.BackColor = colour;

            string morseLight = ColourToPseudoMorse(colour);
            morseLights.Add(morseLight);

            if(morseLight.Equals("0"))
            {
                ++lightLengthCount;
            }
            else
            {
                lightLengthCount = 0;
            }
            if(lightLengthCount >= 5)
            {
                timer2.Enabled = isStart;   //praying this acts like a toggle
                isStart = !isStart;
                lightLengthCount = 0;
            }
        }

        private void output()
        {
            pseudoMorseToMorse();
            string[] morses = morse.Split("|");
            string[] toDecode;
            if (morse[0].Equals("|"))
            {
                toDecode = morses[0].Split("/");
            }
            else
            {
                toDecode = morses[1].Split("/");
            }
            for(int i = 0; i < toDecode.Length; i++) 
            {
                label4.Text += decoder(toDecode[i]);
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            takeColour();
        }

        private void button1_Click(object sender, EventArgs e) //will implement to work with the other takeColour function
        {
            if (buttonState)
            {
                Thread.Sleep(3000);
                buttonState = false;
                label2.Text = "";
                label3.Text = "";   
                label4.Text = "";
                morseLights.Clear();
                morse = "";
                timer2.Enabled = true;
                isStart = true;
            }
        }

        private string ColourToPseudoMorse(Color colour)
        {
            //set default as RGB(0, 6, 16) for black, RGB(255, 237, 59)

            double distance1 = Math.Sqrt(Math.Pow(colour.R, 2) + Math.Pow(colour.G - 6, 2) + Math.Pow(colour.B - 16, 2));
            double distance2 = Math.Sqrt(Math.Pow(colour.R - 255, 2) + Math.Pow(colour.G - 237, 2) + Math.Pow(colour.B - 59, 2));

            if (distance1 > distance2) //this is wacky, but apparently farther away => closer colour???
            {
                label3.Text += "1";
                return "1";
            }
            else
            {
                label3.Text += "0";
                return "0";
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
                        morse += ".";
                    }
                    else if (length == 2 || length == 3 || length == 4) //error range
                    {
                        morse += "-";
                    }
                }
                else
                {
                    if (length == 3 || length == 4 || length == 2) //error range
                    {
                        morse += "/";
                    }
                    else if (length != 1)
                    {
                        morse += "|";
                    }
                }
            }
        }

        private string decoder(string code) //decodes each morse string into the corresponding letter
        {
            for (int i = 0; i < listOfMorseCodeReps.Length; ++i)
            {
                if (code.Equals(listOfMorseCodeReps[i]))
                {
                    return ((char)(i + 97)).ToString();
                }
            }
            return "[oof]"; //smth went wrong if this is returned
        }
    }

    
}

    //(0 6 16) (4 7 13) (7 9 18)              (255 237 59) (255 221 61) (255 226 58)
    //5.1, 7.87                                //16.1, 11

//there is no way this code currently works rn
