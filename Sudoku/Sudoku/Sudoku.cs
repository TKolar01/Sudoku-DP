using SbsSW.SwiPlCs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sudoku
{
    public partial class Sudoku : Form
    {
        String ispisRjesenja;
        Stopwatch timer;


        public Sudoku()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {

          
            for (int i = 1; i < 82; i++)
            {
                (Controls["textBox" + i] as TextBox).TextAlign = HorizontalAlignment.Center;
                (Controls["textBox" + i] as TextBox).Enabled = false;
                
            }
            btnNovaIgra.Enabled = false;
            comboBox1.Items.Add("Lagana");
            comboBox1.Items.Add("Srednja");
            comboBox1.Items.Add("Teška");
          

            checkBox1.Enabled = false;


        }

        private void btnZapocni_Click(object sender, EventArgs e)
        {
            this.ActiveControl = label1;
            Random rnd = new Random();
            int random = rnd.Next(1, 4);
            Inicijalizacija();
            timer = new Stopwatch();
            timer.Start();
            
            string odabir = comboBox1.Text.ToLower();

            if (odabir != "težina")
            {
                if (odabir == "teška")
                    odabir = "teska";
                


                PlQuery matrica = new PlQuery($"problem({odabir},{random},X)");
                matrica.NextSolution();
                PlQuery zavrseno = new PlQuery($"sudoku({odabir},{random},X)");
                zavrseno.NextSolution();

                string ispis = matricaZadatka(matrica);
                string rjesenje = zavrseno.Variables["X"].ToString();
                ispisRjesenja = new String(rjesenje.Where(Char.IsDigit).ToArray());
                PlEngine.PlCleanup();
                int brojac = 0;

                for (int i = 1; i <= 81; i++)
                {

                    for (int j = brojac; j < ispis.Length; j++)
                    {
                        if (ispis[j] > '0' && ispis[j] <= '9')
                        {
                            (Controls["textBox" + i] as TextBox).Text = ispis[j].ToString();


                            brojac = j + 1;
                            break;

                        }
                        else if (ispis[j] == ' ')
                        {
                            (Controls["textBox" + i] as TextBox).Text = ispis[j].ToString();
                            brojac = j + 1;
                            break;
                        }

                    }
                    (Controls["textBox" + i] as TextBox).Enabled = true;
                    var blokiranje = (Controls["textBox" + i] as TextBox).Text;
                    if (blokiranje == "1" || blokiranje == "2" || blokiranje == "3" || blokiranje == "4" || blokiranje == "5"
                        || blokiranje == "6" || blokiranje == "7" || blokiranje == "8" || blokiranje == "9")
                    {
                        (Controls["textBox" + i] as TextBox).ReadOnly = true;


                    }
                    btnZapocni.Enabled = false;
                    btnNovaIgra.Enabled = true;
                    checkBox1.Enabled = true;

                }
            }

            else
            {
                MessageBox.Show("Odaberite težinu","Upozorenje!");
              
            }
                

        }
        

        private void btnUpute_Click(object sender, EventArgs e)
        {
            Inicijalizacija();

            PlQuery upute = new PlQuery("upute(X)");
            upute.NextSolution();
            MessageBox.Show(upute.Variables["X"].ToString(), "Upute");
            PlEngine.PlCleanup();
            
        }

        private void Inicijalizacija()
        {
            if (!PlEngine.IsInitialized)
            {
                Environment.SetEnvironmentVariable("Path", @"C:\Users\Trol\Desktop\Sudoku\Sudoku\bin\Debug\prolog\bin");
                string[] p = { "-q", "-f", @"prolog.pl" };
                PlEngine.Initialize(p);
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
                TocnosUnosa(); 
        }


     
        private void textBox55_KeyUp(object sender, KeyEventArgs e)
        {
          
            TocnosUnosa();
            TextBox odabir = sender as TextBox;
            string imeTextBoxa = odabir.Name;
            (Controls[imeTextBoxa] as TextBox).MaxLength = 1;
           
            

            if (KrajIgre())
            {
                PlEngine.PlCleanup();
                timer.Stop();
                TimeSpan timeTaken = timer.Elapsed;
                DateTime dt = new DateTime() + timeTaken;
                Kraj kraj = new Kraj(dt);
                kraj.ShowDialog(this);

            }



        }
       

        private void textBox55_KeyPress(object sender, KeyPressEventArgs e)
        {
            DefinicajBoxa(sender, e);
        }
       

        private void btnNovaIgra_Click(object sender, EventArgs e)
        {
            timer.Stop();
            TimeSpan timeTaken = timer.Elapsed;
            DateTime dt = new DateTime() + timeTaken;
           
            PlEngine.PlCleanup();
           
          
            for(int i =1; i < 82; i++)
            {
                (Controls["textBox" + i] as TextBox).Clear();
                (Controls["textBox" + i] as TextBox).Enabled = false;
                (Controls["textBox" + i] as TextBox).BackColor = Color.White;
                (Controls["textBox" + i] as TextBox).ReadOnly = false;

            }
            comboBox1.Text = "Težina" ;
            btnZapocni.Enabled = true;
            checkBox1.Enabled = false;
            btnNovaIgra.Enabled = false;

          



        }
        private void TocnosUnosa()
        {
            if (checkBox1.Checked)
            {
                for (int i = 1; i < 82; i++)
                {
                    var vrijednost = ((Controls["textBox" + i] as TextBox).Text).Trim();
                    if ((Controls["textBox" + i] as TextBox).ReadOnly == false && vrijednost != "")
                    {
                        if (ispisRjesenja[i - 1].ToString() == vrijednost)
                        {
                            (Controls["textBox" + i] as TextBox).BackColor = Color.LightGreen;
                        }
                        else (Controls["textBox" + i] as TextBox).BackColor = Color.OrangeRed;
                    }
                }
            }
            else
            {
                for (int i = 1; i < 82; i++)
                {
                    if ((Controls["textBox" + i] as TextBox).ReadOnly == false)
                        (Controls["textBox" + i] as TextBox).BackColor = Color.White;
                }
            }

        }
        private bool KrajIgre()
        {
            bool kraj = false;
            for (int i = 1; i < 82; i++)
            {
                string broj = (Controls["textBox" + i] as TextBox).Text.Trim();
                if (broj != null && broj != "")
                {
                    if (ispisRjesenja[i - 1].ToString() == ((Controls["textBox" + i] as TextBox).Text).Trim())
                    {
                        kraj = true;
                    }
                    else
                    {
                        kraj = false;
                        break;
                    }
                }
                else
                {
                    kraj = false;
                    break;
                }
            }
            return kraj;
        }

        private void DefinicajBoxa(object sender, KeyPressEventArgs e)
        {
            
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

        }

        private string matricaZadatka(PlQuery matrica)
        {
            string zadatak = matrica.Variables["X"].ToString();
            string pattern = @"(?<!\w)_\w+";
            string replace = " ";
            string result = Regex.Replace(zadatak, pattern, replace);


            return result;
        }


        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            PlEngine.PlCleanup();
            System.Environment.Exit(1);
        }

        private void textBox55_KeyDown(object sender, KeyEventArgs e)
        {
           
        }
    }
}



 
