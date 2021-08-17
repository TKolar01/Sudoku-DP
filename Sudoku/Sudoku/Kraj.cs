using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sudoku
{
    public partial class Kraj : Form
    {
        DateTime dt;
        public Kraj(DateTime date)
        {
            InitializeComponent();
            this.dt = date; 
        }

        private void Kraj_Load(object sender, EventArgs e)
        {
            labelVrijemeProlaza.Text = dt.ToString("mm:ss");
        }

        private void btnPovratak_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Kraj_FormClosing(object sender, FormClosingEventArgs e)
        {
          
        }
    }
}
