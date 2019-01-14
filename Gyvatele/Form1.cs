using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gyvatele
{
    public partial class Form1 : Form
    {
        private List<GyvatesDalis> gyvatele = new List<GyvatesDalis>();
        private GyvatesDalis maistas = new GyvatesDalis();

        public Form1()
        {
            InitializeComponent();

            //Nustatyti pirminius nustatymus
            new Nustatymai();

            //Nustatyti zaidimo greiti ir aktyvuoti timeri
            gameTimer.Interval = 4000 / Nustatymai.Greitis;
            gameTimer.Tick += AtnaujintiEkrana;
            gameTimer.Start();

            //Pradeti nauja zaidima
            PradetiZaidima();
        }

        private void PradetiZaidima()
        {
            lblZaidimoPabaiga.Visible = false;

            //Atstatyi pirminius nustatymus
            new Nustatymai();

            //Sukurti nauja zaideja
            gyvatele.Clear();
            GyvatesDalis galva = new GyvatesDalis();
            galva.X = 10;
            galva.Y = 5;
            gyvatele.Add(galva);

            lblRezultatas.Text = Nustatymai.Rezultatas.ToString();
            SukurtiMaista();
        }

        //Sukurti gyvatei maista atsitiktineje vietoje zaidimo lauke
        private void SukurtiMaista()
        {
            int maxXPos = pbZaidimoLaukas.Size.Width / Nustatymai.Plotis;
            int maxYPos = pbZaidimoLaukas.Size.Height / Nustatymai.Aukstis;

            Random random = new Random();
            maistas = new GyvatesDalis();
            maistas.X = random.Next(0, maxXPos);
            maistas.Y = random.Next(0, maxYPos);
        }

        private void AtnaujintiEkrana(object sender, EventArgs e)
        {
            //Patikrinti zaidimasBaigtas reiksme
            if (Nustatymai.ZaidimasBaigtas)
            {
                //Patikrinti ar nuspaustas enter, jei taip pradeti zaidima is naujo
                if (Ivedimas.KeyPressed(Keys.Enter))
                {
                    PradetiZaidima();
                }
            }
            else
            {
                if (Ivedimas.KeyPressed(Keys.Right) && Nustatymai.Kryptis != Kryptis.Kaire)
                {
                    Nustatymai.Kryptis = Kryptis.Desine;
                }
                else if (Ivedimas.KeyPressed(Keys.Left) && Nustatymai.Kryptis != Kryptis.Desine)
                {
                    Nustatymai.Kryptis = Kryptis.Kaire;
                }
                else if (Ivedimas.KeyPressed(Keys.Up) && Nustatymai.Kryptis != Kryptis.Zemyn)
                {
                    Nustatymai.Kryptis = Kryptis.Aukstyn;
                }
                else if (Ivedimas.KeyPressed(Keys.Down) && Nustatymai.Kryptis != Kryptis.Aukstyn)
                {
                    Nustatymai.Kryptis = Kryptis.Zemyn;
                }

                ZaidejoJudejimas();
            }
            pbZaidimoLaukas.Invalidate();
        }

        private void pbZaidimoLaukas_Paint(object sender, PaintEventArgs e)
        {
            Graphics ZaidimoLaukas = e.Graphics;

            if (!Nustatymai.ZaidimasBaigtas)
            {
                //Prideti gyvatelei spalva
                Brush gyvatelesSpalva;

                for (int i = 0; i < gyvatele.Count; i++)
                {
                    if (i == 0)
                    {
                        gyvatelesSpalva = Brushes.Black; //Prideti gyvateles galvai spalva
                    }
                    else
                    {
                        gyvatelesSpalva = Brushes.Green; //Prideti gyvateles kunui spalva
                    }

                    //Nuspalvinti gyvatele
                    ZaidimoLaukas.FillEllipse(gyvatelesSpalva, new Rectangle(gyvatele[i].X * Nustatymai.Plotis,
                                                                  gyvatele[i].Y * Nustatymai.Aukstis,
                                                                  Nustatymai.Plotis, Nustatymai.Aukstis));

                    //Nuspalvinti gyvateles maista
                    ZaidimoLaukas.FillEllipse(Brushes.Red,
                                       new Rectangle(maistas.X * Nustatymai.Plotis, maistas.Y * Nustatymai.Aukstis,
                                       Nustatymai.Plotis, Nustatymai.Aukstis));
                }
            }
            else
            {
                string baigtasZaidimas = "Zaidimas baiges \nJusu taskai: " + Nustatymai.Rezultatas + "\nPaspauskite Enter zaisti is naujo";
                lblZaidimoPabaiga.Text = baigtasZaidimas;
                lblZaidimoPabaiga.Visible = true;
            }
        }

        private void ZaidejoJudejimas()
        {
            for (int i = gyvatele.Count - 1; i >= 0; i--)
            {
                //Judinti galva
                if (i == 0 )
                {
                    switch (Nustatymai.Kryptis)
                    {
                        case Kryptis.Desine:
                            gyvatele[i].X++;
                            break;
                        case Kryptis.Kaire:
                            gyvatele[i].X--;
                            break;
                        case Kryptis.Aukstyn:
                            gyvatele[i].Y--;
                            break;
                        case Kryptis.Zemyn:
                            gyvatele[i].Y++;
                            break;
                    }

                    //Get maximum X and Y pos
                    int maxXPos = pbZaidimoLaukas.Size.Width / Nustatymai.Plotis;
                    int maxYPos = pbZaidimoLaukas.Size.Height / Nustatymai.Aukstis;

                    //Patikrinti ar neatsitrenke i zaidimo lango remus
                    if (gyvatele[i].X < 0 || gyvatele[i].Y < 0 || gyvatele[i].X >= maxXPos || gyvatele[i].Y >=maxYPos)
                    {
                        Mirti();
                    }

                    //Patikrinti ar neatsitrenke i savo kuna
                    for (int j = 1; j < gyvatele.Count; j++)
                    {
                        if (gyvatele[i].X == gyvatele[j].X && gyvatele[i].Y == gyvatele[j].Y)
                        {
                            Mirti();
                        }
                    }

                    //Patikrinti ar pasieke maista
                    if (gyvatele[0].X == maistas.X && gyvatele[0].Y == maistas.Y)
                    {
                        Suvalgyti();
                    }
                }
                else
                {
                    //Judinti kuna
                    gyvatele[i].X = gyvatele[i - 1].X;
                    gyvatele[i].Y = gyvatele[i - 1].Y;

                }
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            Ivedimas.ChangeState(e.KeyCode, true);
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            Ivedimas.ChangeState(e.KeyCode, false);
        }

        private void Mirti()
        {
            Nustatymai.ZaidimasBaigtas = true;
        }

        private void Suvalgyti()
        {
            GyvatesDalis maistas = new GyvatesDalis();
            maistas.X = gyvatele[gyvatele.Count - 1].X;
            maistas.Y = gyvatele[gyvatele.Count - 1].Y;

            gyvatele.Add(maistas);

            //Atnaujinti rezultata
            Nustatymai.Rezultatas += Nustatymai.Taskai;
            lblRezultatas.Text = Nustatymai.Rezultatas.ToString();

            SukurtiMaista();
        }
    }
}
