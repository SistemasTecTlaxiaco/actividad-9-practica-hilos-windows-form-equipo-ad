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
            this.FormClosing += Form1_FormClosing;
        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            if (!relojesActivos)
            {
                relojesActivos = true;
                btnIniciar.Enabled = false;
                btnPausa.Enabled = true;

                // Crear e iniciar hilos para cada ciudad
                hiloTlaxiaco = new Thread(() => ActualizarReloj(lblHora1, "Central Standard Time"));
                hiloNY = new Thread(() => ActualizarReloj(lblHora2, "Eastern Standard Time"));
                hiloMadrid = new Thread(() => ActualizarReloj(lblHora3, "Central European Standard Time"));
                hiloTokio = new Thread(() => ActualizarReloj(lblHora4, "Tokyo Standard Time"));

                hiloTlaxiaco.Start();
                hiloNY.Start();
                hiloMadrid.Start();
                hiloTokio.Start();
            }

        }

        private void ActualizarReloj(Label label, string timeZoneId)
        {
            while (relojesActivos)
            {
                var horaActual = TimeZoneInfo.ConvertTime(DateTime.Now, TimeZoneInfo.FindSystemTimeZoneById(timeZoneId));

                // Actualizar la interfaz de manera segura
                this.Invoke((MethodInvoker)delegate
                {
                    label.Text = $"{label.Tag} {horaActual:HH:mm:ss}";
                });

                Thread.Sleep(1000); // Actualizar cada segundo
            }
        }


        private void btnPausa_Click(object sender, EventArgs e)
        {
            relojesActivos = false;
            btnIniciar.Enabled = true;
            btnPausa.Enabled = false;

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