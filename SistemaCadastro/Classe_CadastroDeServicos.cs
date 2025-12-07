using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaCadastro
{
    public class Dono
    {
        private string cPF;
        private string nome;
        private string telefone;

        public string CPF { get => cPF; set => cPF = value; }
        public string Nome { get => nome; set => nome = value; }
        public string Telefone { get => telefone; set => telefone = value; }
    }
    public class Carro
    {
        private string placa;
        private string marca;
        private string modelo;
        private string categoria;
        private string servicos;
        private string cPF_Dono;

        public string Placa { get => placa; set => placa = value; }
        public string Marca { get => marca; set => marca = value; }
        public string Modelo { get => modelo; set => modelo = value; }
        public string Categoria { get => categoria; set => categoria = value; }
        public string Servicos { get => servicos; set => servicos = value; }
        public string CPF_Dono { get => cPF_Dono; set => cPF_Dono = value; }
    }


}

