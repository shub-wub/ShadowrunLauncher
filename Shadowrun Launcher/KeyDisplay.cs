using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

namespace Shadowrun_Launcher
{
    public partial class KeyDisplay : Form
    {
        private static string currentkey = " ";
        bool isgen;
        static Random random = new Random();
        public KeyDisplay(string key = "CMCY6-TPV4Y-4HYWP-Q2TFJ-R8BW3", bool IsGen = false)
        {
            InitializeComponent();
            if (IsGen)
            {
                isgen = IsGen;
                rc1.Text = "Generate Key";
                SetKey(GenerateKey());
            }
            else
            {
                if(key.Length > 0)
                {
                  SetKey(key);
                }

            }

        }

        private void SetKey(string key)
        {
            currentkey = key;
            string[] Keysector = key.Split('-');
            r1.Text = Keysector[0];
            r2.Text = Keysector[1];
            r3.Text = Keysector[2];
            r4.Text = Keysector[3];
            r5.Text = Keysector[4];
        }

        private void rc1_Click(object sender, EventArgs e)
        {
            if(isgen)
            {
                SetKey(GenerateKey());
                Clipboard.SetText(currentkey);
            }
            else
            {
                Clipboard.SetText(currentkey);
            }

        }
        public static string GenerateKey()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            char[] key = new char[29];

            for (int i = 0; i < key.Length; i++)
            {
                if ((i + 1) % 6 == 0)
                    key[i] = '-';
                else
                    key[i] = chars[random.Next(chars.Length)];
            }
            currentkey = new string(key);
            return new string(key);
        }
        private void exit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
