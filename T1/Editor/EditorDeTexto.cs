using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Editor
{
    public partial class EditorDeTexto : Form
    {
        public EditorDeTexto()
        {
            InitializeComponent();
        }

        private void EditorDeTexto_Load(object sender, EventArgs e)
        {
            using (Stream entrada = File.Open("texto.txt", FileMode.Open))
            using (StreamReader leitor = new StreamReader(entrada))
            {
                texto.Text = leitor.ReadToEnd();
            }
                //if (File.Exists("texto.txt"))

                //Stream entrada = File.Open("texto.txt", FileMode.Open);

                //byte b = entrada.ReadByte();

                //StreamReader leitor = new StreamReader(entrada);

                //String linha = leitor.ReadLine();

                //while (linha != null)
                //{
                //    texto.Text += linha;
                //    linha = leitor.ReadLine();
                //}

                //leitor.Close();
                //entrada.Close();
        }

        private void botaoGravar_Click(object sender, EventArgs e)
        {
            using (Stream saida = File.Open("texto.txt", FileMode.Create))
            using (StreamWriter escritor = new StreamWriter(saida))
            {
                escritor.Write(texto.Text);
            }
            //escritor.Close();
            //saida.Close();
        }
    }
}
