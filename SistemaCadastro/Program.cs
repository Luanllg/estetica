using System;
using System.Windows.Forms;

namespace SistemaCadastro
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Cria e exibe o login
            using (FormLogin login = new FormLogin())
            {
                // Se o login for bem-sucedido 
                // (por exemplo, o usuário clicou em "OK" no formulário de login)
                if (login.ShowDialog() == DialogResult.OK)
                {
                    // Abre o sistema principal
                    Application.Run(new Sistema());
                }
                else
                {
                    // Fecha o programa se o login não for concluído corretamente
                    Application.Exit();
                }
            }
        }
    }
}//Alterei por que estava dando erro de compilação no meu visual studio
//fiz assim para corrigir o erro e rodar o programa normalmente
//primeiro cria o form de login
//depois cria o form do sistema
