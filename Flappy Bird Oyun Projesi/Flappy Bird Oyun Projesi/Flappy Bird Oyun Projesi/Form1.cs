using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Flappy_Bird_Oyun_Projesi
{
    public partial class Form1 : Form
    {
        int boruHızı = 8;
        int gravity = 10;
        int skor = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void GameTimerEvent(object sender, EventArgs e)
        {
            Bird.Top += gravity;
            BoruAlt.Left -= boruHızı;
            BoruUst.Left -= boruHızı;
            Skorlbl.Text = "Skor: " + skor;
            if (BoruAlt.Left<-150)
            {
                BoruAlt.Left = 800;
                skor++;
            }
            if (BoruUst.Left<-180)  
            {
                BoruUst.Left = 950;
                skor++;
            }

            if (Bird.Bounds.IntersectsWith(BoruAlt.Bounds)|| Bird.Bounds.IntersectsWith(BoruUst.Bounds) || Bird.Bounds.IntersectsWith(Zemin.Bounds))
            {
                endGame();
            }
            
        }

        private void GameKeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Space)
            {
                gravity = -10;
            }
        }

        private void GameKeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                gravity = +10;
            }

        }
        private void endGame()
        {
            GameTimer.Stop();
            Skorlbl.Text = " Game Over !!! ";
        }
    }
}
