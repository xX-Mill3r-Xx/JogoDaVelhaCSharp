using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JogoDaVelha_CSharp
{
    public partial class Form1 : Form
    {
        int palyerX = 0;
        int palyerO = 0;
        int empatePoint = 0;
        int rodadas = 0;
        bool FinalGame = false;
        bool turn = true;

        string[] texto = new string[9];

        public Form1()
        {
            InitializeComponent();
        }

        private void btn_1_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if(btn.Text == "" && FinalGame == false)
            {
                if (turn)
                {
                    btn.Text = "X";
                    rodadas++;
                    turn = !turn;
                }
                else
                {
                    btn.Text = "O";
                    rodadas++;
                    turn = !turn;
                }
            }
            
        }
    }
}
