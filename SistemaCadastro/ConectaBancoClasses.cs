using MySql.Data.MySqlClient;

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Mail;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZstdSharp.Unsafe;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

//O tema escolhido deve ser relacionado a um problema real. - Sistema de cadastro para estética automotiva
//classes que vão buscar as stotred procedures no banco de dados
//fazer a coneção com o bnaco e criar as astividades do forms 
namespace SistemaCadastro
{
    internal class ConectaBancoClasses
    {
        MySqlConnection conexao = new MySqlConnection("server=localhost;user id=root;password=1234;database=esteticaautomotiva");
        public string mensagem;
        private object txtPlacaAlternar;
        private object txtMarcaAlterar;
        private object txtModeloAlterar;
        private object txtCpfAlterar;
        private object txtCategoriaAlterar;

        public bool inseredono(Dono novoDono)
        {
            try
            {
                conexao.Open();
                MySqlCommand cmd =
                    new MySqlCommand("sp_insereDono", conexao);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("p_cpf", novoDono.CPF);
                cmd.Parameters.AddWithValue("p_nome", novoDono.Nome);
                cmd.Parameters.AddWithValue("p_telefone", novoDono.Telefone);
                cmd.ExecuteNonQuery();//executar no banco
                return true;
            }
            catch (MySqlException erro)
            {
                mensagem = erro.Message;
                return false;
            }
            finally

            {
                conexao.Close();
            }

        }



        public bool inserecarro(Carro novocarro)
        {
            try
            {
                conexao.Open();
                MySqlCommand cmd =
                    new MySqlCommand("sp_insereCarro", conexao);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("p_placa", novocarro.Placa);
                cmd.Parameters.AddWithValue("p_marca", novocarro.Marca);
                cmd.Parameters.AddWithValue("p_modelo", novocarro.Modelo);
                cmd.Parameters.AddWithValue("p_categoria", novocarro.Categoria);
                cmd.Parameters.AddWithValue("p_servicos", novocarro.Servicos);
                cmd.Parameters.AddWithValue("p_cpf_dono", novocarro.CPF_Dono);
                cmd.ExecuteNonQuery();//executar no banco
                return true;
               

            }
            catch (MySqlException erro)
            {
                mensagem = erro.Message;
                return false;
            }
            finally
            {
                conexao.Close();
            }




        }// aqui esta meu cadastro de bancos de dados aonde adcionei minha tabela donos e depois carros, pois para carros é preciso que haja um cpf de um dono que pode ter vários carros.


        //Deve ser permitido realizar uma busca nos dados de acordo com algum critério especificado. Como mexo, acredito que a busca deve ser pelo dono (neste caso = cpf), buscando o carro que deva atualizar algo.
        //É normal as pessoas quererem adcionar serviços de acordo com os que ja estão sendo feito,para ficar mais completo, então fiz o sistema que atualiza a tabela carros aonde esta alocado os serviços.
        public DataTable BuscarCarroPorCpfParcial(string cpf)
        {
            DataTable tabela = new DataTable();
            try
            {
                conexao.Open();
                MySqlCommand cmd = new MySqlCommand("sp_BuscarCarroPorCpfParcial", conexao);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("p_cpf", cpf);

                MySqlDataAdapter ada = new MySqlDataAdapter(cmd);
                ada.Fill(tabela);
            }
            catch (MySqlException erro)
            {
                mensagem = erro.Message;
                return null;
            }
            finally
            {
                conexao.Close();
            }
            return tabela;
        }//agora busca pelo cpf do dono retona a tebela que tem o cpf do dono na tabela carros
       
        
        
        public DataTable BuscarDonoPorCpfParcial(string cpf)
        {
            DataTable tabela = new DataTable();
            try
            {
                conexao.Open();
                MySqlCommand cmd = new MySqlCommand("sp_BuscarDonoPorCpfParcial", conexao);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("p_cpf", cpf);

                MySqlDataAdapter don = new MySqlDataAdapter(cmd);
                don.Fill(tabela);
            }
            catch (MySqlException erro)
            {
                mensagem = erro.Message;
                return null;
            }
            finally
            {
                conexao.Close();
            }
            return tabela;
        }//agora busca pelo cpf do dono retona a tebela  do dono 



        public bool alteraCarro(Carro carro)
        {
            try
            {
                conexao.Open();
                MySqlCommand cmd = new MySqlCommand("sp_alteraCarro", conexao);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("p_placa", carro.Placa);
                cmd.Parameters.AddWithValue("p_marca", carro.Marca);
                cmd.Parameters.AddWithValue("p_modelo", carro.Modelo);
                cmd.Parameters.AddWithValue("p_categoria", carro.Categoria);
                cmd.Parameters.AddWithValue("p_servicos", carro.Servicos);

                int linhas = cmd.ExecuteNonQuery();
                if (linhas > 0)
                {

                    return true;
                }
                else
                {
                    mensagem = "Nenhum carro encontrado com a placa informada.";
                    return false;
                }
            }
            catch (Exception erro)
            {
                mensagem = erro.Message;
                return false;
            }
            finally
            {
                conexao.Close();

            }
        }//adcionando um função para aterar os carros cadastrados,
        public bool alteraDono(Dono dono)
        {
            try
            {
                conexao.Open();
                MySqlCommand cmd = new MySqlCommand("sp_alteraDono", conexao);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("p_cpf", dono.CPF);
                cmd.Parameters.AddWithValue("p_nome", dono.Nome);
                cmd.Parameters.AddWithValue("p_telefone", dono.Telefone);
               

                int linhas = cmd.ExecuteNonQuery();
                if (linhas > 0)
                {

                    return true;
                }
                else
                {
                    mensagem = "Nenhum carro encontrado com a placa informada.";
                    return false;
                }
            }
            catch (Exception erro)
            {
                mensagem = erro.Message;
                return false;
            }
            finally
            {
                conexao.Close();

            }


        }//adcionando um função para aterar os carros cadastrados, 



        public bool RemoveCarro(string cpf)
        {
            try
            {
                conexao.Open();
                MySqlCommand cmd = new MySqlCommand("sp_RemoveCarro", conexao);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("p_cpf", cpf);
                int linhas = cmd.ExecuteNonQuery();
                if (linhas > 0)
                {
                    return true;
                }
                else
                {
                    mensagem = "Nenhum carro encontrado para o CPF informado.";
                    return false;
                }
            }
            catch (MySqlException erro)
            {
                mensagem = erro.Message;
                return false;
            }
            finally
            {
                conexao.Close();
            }
        }//fazendo um função para remover os carros registrados em algum cpf 

        //controle de login fixo, por que o sistema vai ser usado para o prestador do serviço
        public bool RemoveDono(string cpf)
        {
            try
            {
                conexao.Open();
                MySqlCommand cmd = new MySqlCommand("sp_RemoveDono", conexao);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("p_cpf", cpf);
                int linhas = cmd.ExecuteNonQuery();
                if (linhas > 0)
                {
                    return true;
                }
                else
                {
                    mensagem = "Nenhum dono encontrado para o CPF informado.";
                    return false;
                }
            }
            catch (MySqlException erro)
            {
                mensagem = erro.Message;
                return false;
            }
            finally
            {
                conexao.Close();
            }
        }
    }
}
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    