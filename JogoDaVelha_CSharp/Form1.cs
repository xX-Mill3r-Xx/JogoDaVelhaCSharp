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
        int PlayerX = 0;
        int PlayerO = 0;
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
            int ButtonIndex = btn.TabIndex;
            if (btn.Text == "" && FinalGame == false)
            {
                if (turn)
                {
                    btn.Text = "X";
                    texto[ButtonIndex] = btn.Text;
                    rodadas++;
                    turn = !turn;
                    Check(1);
                }
                else
                {
                    btn.Text = "O";
                    texto[ButtonIndex] = btn.Text;
                    rodadas++;
                    turn = !turn;
                    Check(2);
                }
            }
            
        }

        void Winner(int PlayerWinner)
        {
            FinalGame = true;
            if(PlayerWinner == 1)
            {
                PlayerX++;
                lbl_PontoX.Text = Convert.ToString(PlayerX);
                MessageBox.Show("Player X foi o vencedor da partida!");
                turn = true;
            }
            else
            {
                PlayerO++;
                lbl_PontoO.Text = Convert.ToString(PlayerO);
                MessageBox.Show("Player O foi o vencedor da partida!");
                turn = false;
            }
        }

        void Check(int checkPlayer)
        {
            #region Suporte
            string suport = "";
            //
            if(checkPlayer == 1)
            {
                suport = "X";
            }
            else
            {
                suport = "O";
            }
            //
            #endregion

            #region Loop Horizontal
            for (int h = 0; h < 8; h+=3)
            {
                #region Check Horizontal
                if (suport == texto[h])
                {
                    if (texto[h] == texto[h+1] && texto[h] == texto[h+2])
                    {
                        Winner(checkPlayer);
                        return;
                    }
                }
                #endregion
            }
            #endregion

            #region Loop Vertical
            for (int v = 0; v < 3; v++)
            {
                #region Check Horizontal
                if (suport == texto[v])
                {
                    if (texto[v] == texto[v + 3] && texto[v] == texto[v + 6])
                    {
                        Winner(checkPlayer);
                        return;
                    }
                }
                #endregion
            }
            #endregion

            #region Diagonais
            if (texto[0] == suport)
            {
                if (texto[0] == texto[4] && texto[0] == texto[8])
                {
                    Winner(checkPlayer);
                    return;
                }
            }

            if (texto[2] == suport)
            {
                if (texto[2] == texto[4] && texto[2] == texto[6])
                {
                    Winner(checkPlayer);
                    return;
                }
            }
            #endregion

            if(rodadas == 9 && FinalGame == false)
            {
                empatePoint++;
                lbl_Empate.Text = Convert.ToString(empatePoint);
                MessageBox.Show("Empatou");
                FinalGame = true;
                return;
            }
        }

        private void btn_Reset_Click(object sender, EventArgs e)
        {
            btn_1.Text = "";
            btn_2.Text = "";
            btn_3.Text = "";
            btn_4.Text = "";
            btn_5.Text = "";
            btn_6.Text = "";
            btn_7.Text = "";
            btn_8.Text = "";
            btn_9.Text = "";
            rodadas = 0;
            FinalGame = false;
            for(int i = 0; i < 9; i++)
            {
                texto[i] = "";
            }
        }
    }
}
