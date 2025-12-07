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

namespace SistemaCadastro
{
    public partial class Sistema : Form
    {
        int idAlterar;//definido fora do escopo para ser usado em vários métodos

        public Sistema()
        {
            InitializeComponent();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnCadastra_Click(object sender, EventArgs e)
        {
            marcador.Height = btnCadastra.Height;
            marcador.Top = btnCadastra.Top;
            tabControl1.SelectedTab = tabControl1.TabPages[0];
        }


        private void btnBusca_Click(object sender, EventArgs e)
        {
            marcador.Height = btnBusca.Height;
            marcador.Top = btnBusca.Top;
            tabControl1.SelectedTab = tabControl1.TabPages[1];
        }

        private void button1_Click(object sender, EventArgs e)
        {

            marcador.Height = btnAlterarNav.Height;
            marcador.Top = btnAlterarNav.Top;
            tabControl1.SelectedTab = tabControl1.TabPages[2];
        }
        private void Sistema_Load(object sender, EventArgs e)
        {

        }
        private void txtBusca_TextChanged(object sender, EventArgs e)
        {
            string cpfDigitado = txtBuscaVeiculo.Text.Trim();
            
            ConectaBancoClasses conexao = new ConectaBancoClasses();
            DataTable tabelaCarros = conexao.BuscarCarroPorCpfParcial(cpfDigitado);
            dgCarros.DataSource = tabelaCarros;
        }
        private void btnRemoveBanda_Click(object sender, EventArgs e)
        {
            string cpf = txtBuscaVeiculo.Text;
           
            ConectaBancoClasses conexao = new ConectaBancoClasses();
            bool sucesso = conexao.RemoveCarro(cpf);
            if (sucesso)
            {
                MessageBox.Show("Carros removidos com sucesso.");
            }
            else
            {
                MessageBox.Show("Erro ao remover carros: " + conexao.mensagem);
            }
        }//removendo os carros registardos em algum cpf


        private void btnAlterar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgCarros.CurrentRow == null)
                {
                    MessageBox.Show("Selecione um carro.");
                    return;
                }

                int linha = dgCarros.CurrentRow.Index;

                txtPlacaAlternar.Text = dgCarros.Rows[linha].Cells["Placa"].Value.ToString();
                txtMarcaAlternar.Text = dgCarros.Rows[linha].Cells["Marca"].Value.ToString();
                txtModeloAlterar.Text = dgCarros.Rows[linha].Cells["Modelo"].Value.ToString();
                txtCategoriaAlternar.Text = dgCarros.Rows[linha].Cells["Categoria"].Value.ToString();
                
                txtalterarServicos.Text = dgCarros.Rows[linha].Cells["Servicos"].Value.ToString();

                tabControl1.SelectedTab = tabAlterarCarro;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao selecionar carro: " + ex.Message);
            }
        }
        //Aqui quando o  botão alterar é acionado ele pega os valores e preenche no campo de alterar, para que o usuario tenha melhor visão doque se deve mudar


        private void btnConfirmaAlteracao_Click(object sender, EventArgs e)
        {
            ConectaBancoClasses con = new ConectaBancoClasses();

            Carro carro = new Carro();
            carro.Placa = txtPlacaAlternar.Text;
            carro.Marca = txtMarcaAlternar.Text;
            carro.Modelo = txtModeloAlterar.Text;
            carro.Categoria = txtCategoriaAlternar.Text;
            carro.Servicos = txtalterarServicos.Text;


            if (con.alteraCarro(carro))
            {
                MessageBox.Show("Carro alterado com sucesso!");
                dgCarros.DataSource = con.BuscarCarroPorCpfParcial(txtBuscaVeiculo.Text.Trim());
            }
            else
            {
                MessageBox.Show("Erro ao alterar: " + con.mensagem);
            }
        }// a plca não sofre alteração por que ´chave primaria e por enquanto quero manter assim, mas aqui esta o campo de que altera os valores




        private void bntAddGenero_Click(object sender, EventArgs e)
        {

        }

        
        
        private void BtnConfirmaCadastro_Click(object sender, EventArgs e)
        {
            ConectaBancoClasses conecta = new ConectaBancoClasses();
            Dono novoDono = new Dono(); 
            novoDono.CPF = txtCPFdoDono.Text;
            novoDono.Nome = txtNome.Text;
            novoDono.Telefone = txtTelefone.Text;
            bool sucessoDono = conecta.inseredono(novoDono);
            if (sucessoDono)
            {
                MessageBox.Show("Dono cadastrado com sucesso!");
            }
            else
            {
                MessageBox.Show("Erro ao cadastrar dono: " + conecta.mensagem);
            }//analisando o retorno da função

            Carro novocarro = new Carro();  
            novocarro.Placa = txtPlaca.Text;
            novocarro.Marca = txtMarca.Text;
            novocarro.Modelo= txtModelo.Text;
            novocarro.Categoria = txtCategoria.Text;
            novocarro.Servicos = txtServico.Text;
            novocarro.CPF_Dono = txtCPFdoDono.Text;
            bool sucessoCarro = conecta.inserecarro(novocarro);
            if (sucessoCarro)
            {
                MessageBox.Show("Carro cadastrado com sucesso!");
            }
            else
            {
                MessageBox.Show("Erro ao cadastrar carro: " + conecta.mensagem);
            }//analisando o retorno da função

        }
        //fazendo o cadastros dos itens que adcionei nos bancos para qu o botão adcione no banco de dados


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void cbGenero_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtnome_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtranking_TextChanged(object sender, EventArgs e)
        {

        }

        private void tabCadastrar_Click(object sender, EventArgs e)
        {

        }

        private void txtCarro_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtPlaca_TextChanged(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_2(object sender, EventArgs e)
        {

        }

        private void txtBuscar_Click(object sender, EventArgs e)
        {
            txtBuscaVeiculo.Clear();
            dgCarros.DataSource = null;
        }  
         
        

        private void dgBandas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void tabAlterar_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void txtBuscarVeiculo_TextChanged(object sender, EventArgs e)
        {
            string cpfDigitado = txtBuscaVeiculo.Text.Trim();

            ConectaBancoClasses conexao = new ConectaBancoClasses();
            DataTable tabelaCarros = conexao.BuscarCarroPorCpfParcial(cpfDigitado);
            dgCarros.DataSource = tabelaCarros;
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
          
        }

        private void btnLimparBuscaDono_Click(object sender, EventArgs e)
        {
            txtBuscarDono.Clear();
            dgDonos.DataSource = null;
        }

        private void btnRemoveDono_Click(object sender, EventArgs e)
        {
            string cpf = txtBuscarDono.Text;

            ConectaBancoClasses conexao = new ConectaBancoClasses();
            bool sucesso = conexao.RemoveDono(cpf);
            if (sucesso)
            {
                MessageBox.Show("Dono removidos com sucesso.");
            }
            else
            {
                MessageBox.Show("Erro ao remover dono: " + conexao.mensagem);
            }
        }

        private void btnAlteraDono_Click(object sender, EventArgs e)
        {
            
            if (dgDonos.CurrentRow == null)
            {
                MessageBox.Show("Selecione um dono.");
                return;
            }

            int linha = dgDonos.CurrentRow.Index;

            txtAlteraDono.Text = dgDonos.Rows[linha].Cells["CPF"].Value.ToString();
            txtAlteraNome.Text = dgDonos.Rows[linha].Cells["Nome"].Value.ToString();
            txtAlterarTelefone.Text = dgDonos.Rows[linha].Cells["Telefone"].Value.ToString();
            


            tabControl1.SelectedTab = tabAlterarDono;
        }

        private void btnConfirmarAlterar_Click(object sender, EventArgs e)
        {
            ConectaBancoClasses con = new ConectaBancoClasses();

            Dono dono = new Dono();
            dono.CPF = txtAlteraDono.Text;
            dono.Nome = txtAlteraNome.Text;
            dono.Telefone = txtAlterarTelefone.Text;
            

            if (con.alteraDono(dono))
            {
            
                MessageBox.Show("Dono alterado com sucesso!");
                dgCarros.DataSource = con.BuscarDonoPorCpfParcial(txtBuscarDono.Text.Trim());
            }
            else
            {
                MessageBox.Show("Erro ao alterar dono: " + con.mensagem);
            }
        }

        private void btmBuacaCarro_Click(object sender, EventArgs e)
        {
            marcador.Height = btnBuscaDono.Height;
            marcador.Top = btnBuscaDono.Top;
            tabControl1.SelectedTab = tabControl1.TabPages[3];

        }

        private void btnalterarDono_Click(object sender, EventArgs e)
        {
            marcador.Height = btnAlteraDono.Height;
            marcador.Top = btnAlteraDono.Top;
            tabControl1.SelectedTab = tabControl1.TabPages[4];
        }

        private void tabAlterarDono_Click(object sender, EventArgs e)
        {

        }

        private void txtCategoriaAlternar_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtBuscarDono_TextChanged(object sender, EventArgs e)
        {
            string cpfDigitado = txtBuscarDono.Text.Trim();

            ConectaBancoClasses conexao = new ConectaBancoClasses();
            DataTable tabelaDonos = conexao.BuscarDonoPorCpfParcial(cpfDigitado);
            dgDonos.DataSource = tabelaDonos;

        } //caixa de texte que carrega os donos no datagrid

        private void tabBuscar_Click(object sender, EventArgs e)
        {

        }
    }
}


