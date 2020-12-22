using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RenomearArquivos
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
            
        }

        private void btnRenomear_Click(object sender, EventArgs e)
        {
            try
            {
                string dir = txtDiretorio.Text;
                string d = dir + "/";
                DirectoryInfo dirInfo = new DirectoryInfo(dir);
                FileInfo[] arquivos = dirInfo.GetFiles().OrderBy(p=>p.CreationTime).ToArray();
                string area = txtArea.Text;
                string data = txtData.Text;

                for (int i = 0; i < arquivos.Length; i++)
                {
                    string numeracao = (i + 1).ToString();
                    string nomeAntigo;
                    string novoNome;
                    string extensao;
                    int value = i + 1;

                    if (numeracao.Length == 1)
                    {                      
                        nomeAntigo = d + arquivos[i].Name;
                        extensao = arquivos[i].Extension;
                        novoNome = d + "0" + value.ToString() + "-" + area + "-"+ data +".png";
                    }
                    else
                    {
                        nomeAntigo = d + arquivos[i].Name;
                        extensao = arquivos[i].Extension;
                        novoNome = d + value.ToString() + "-" + area + "-" + data + ".png";
                    }
                    File.Move(nomeAntigo, novoNome);                   
                }
                MessageBox.Show( "Arquivos Renomeados com sucesso!", "Renomear", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimparCampos();
            }catch(Exception E)
            {
                MessageBox.Show(E.Message);
            }
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            var d1 = monthCalendar1.SelectionStart.ToString("dd-MM-yyyy");
            txtData.Text = d1;
        }

        public void LimparCampos()
        {
            txtArea.Text = "";
            txtData.Text = "";
            txtDiretorio.Text = "";
        }
    }
}
