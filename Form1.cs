using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pokemon
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }

        private void btnApanhar_Click(object sender, EventArgs e)
        {
            /*
             * Esta funcao ira exibir o numero de pokemons apanhados considerando       
             * o movimento informado em txtMovimento, também irá exibir os pokemons 
             * apanhados.
             */

            // declaracao de treinador e atribuicao de nome
            Treinador treinador1 = new Treinador();
            treinador1.Nome = "Ash";
            
            /* 
             * Declarando o relógio que usaremos para contar os ticks de CPU
             */
            Stopwatch stopWatch = new Stopwatch();
            // iniciando a contagem dos ticks
            stopWatch.Start();

            //variavel para armazenar retorno do metodo ApanhaPokemon
            int apanhados = treinador1.ApanhaPokemon(txtMovimento.Text);

            // parando o relógio para ver o tempo gasto
            stopWatch.Stop();
            // Ajustando exibição do tempo gasto.
            TimeSpan ts = stopWatch.Elapsed;
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
            ts.Hours, ts.Minutes, ts.Seconds,
            ts.Milliseconds / 10);

            // exibindo o tempo gasto no text box
            txtTempo.Text = elapsedTime;

            // colocando o numero do pokemons apanhados na caixa de texto de saida
            txtApanhados.Text = apanhados.ToString();

            /* medindo memória ram consumida (depois de adicionar todos os itens do 
             * dicionario
             */
            var tamanhoEmMegaBytes = System.Diagnostics.Process.GetCurrentProcess().PrivateMemorySize64 / 1024 / 1024;
            txtMemoria.Text = tamanhoEmMegaBytes.ToString();

            //Exibindo pokemons apanhados
            if (apanhados == 1) {
                pictureBox2.Visible = true;
                pictureBox3.Visible = false;
                pictureBox4.Visible = false;
                pictureBox5.Visible = false;
            } else if (apanhados == 2) {
                pictureBox2.Visible = true;
                pictureBox3.Visible = true;
                pictureBox4.Visible = false;
                pictureBox5.Visible = false;
            } else if (apanhados == 3) {
                pictureBox2.Visible = true;
                pictureBox3.Visible = true;
                pictureBox4.Visible = true;
                pictureBox5.Visible = false;
            } else if (apanhados >= 4) {
                pictureBox2.Visible = true;
                pictureBox3.Visible = true;
                pictureBox4.Visible = true;
                pictureBox5.Visible = true;

            }
            else { 
                    pictureBox2.Visible = false;
                    pictureBox3.Visible = false;
                    pictureBox4.Visible = false;
                    pictureBox5.Visible = false;
                   
            }
            // liberando variavel
            treinador1 = null;
        }

        private void txtMovimento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnApanhar_Click(sender,e);
            }

        }
    }
}
