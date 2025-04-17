using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HilosRelojes
{
    public partial class Form1 : Form
    {

        private Thread hiloTlaxiaco, hiloNY, hiloMadrid, hiloTokio;
        private bool relojesActivos = false;
        private readonly object lockObj = new object();

        public Form1()
        {
            InitializeComponent();

        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {

        }

        private void btnPausa_Click(object sender, EventArgs e)
        {

        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
        
        }
    }
}