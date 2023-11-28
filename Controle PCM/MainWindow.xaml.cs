using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Controle_PCM.Controllers;
using Controle_PCM.Views;

namespace Controle_PCM
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void entrar_Click(object sender, RoutedEventArgs e)
        {
            string nomeUsuario = user.Text;
            string senha = password.Password;

            LoginController loginController = new LoginController();

            bool usuario = loginController.VerificaUsuario(nomeUsuario, senha);

            if (usuario)
            {
                Inicio paginaPrincipal = new Inicio();
                paginaPrincipal.Show();
                Close();
            }
            else
            {
                MessageBox.Show("Nome de usuário ou senha incorretos. Por favor, tente novamente.");
            }

        }
    }
}
