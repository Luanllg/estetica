using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaCadastro
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        
        {
            if (txtusuario.Text == "admin" && txtSenhaUsuario.Text == "123")
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Usuário ou senha incorretos!");
            }//o problema de login abrindo ".cspj" que esta no program.cs para abrir o sistema principal esta dando erro acredito que pela forma de abrir e pela versão




            //criar o sistema de comapração para login e senha que atras de um if else em string fixas apenas compare e retorne  se for verdadeiro, se for clico no botão de login e ja entra para a pagina do site aonde o usuário ira cadastrar
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtSenhaUsuario_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
