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
using System.Windows.Shapes;

namespace Controle_PCM.Views
{
    /// <summary>
    /// Lógica interna para Inicio.xaml
    /// </summary>
    public partial class Inicio : Window
    {
        public Inicio()
        {
            InitializeComponent();
            //WindowState = WindowState.Maximized;
        }

        private void MenuItem_Sair_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Deseja realmente sair?", "Confirmação", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                // Fechar a aplicação
                Application.Current.Shutdown();
            }
        }

        private void MenuItem_Novo_Click(object sender, RoutedEventArgs e)
        {
            AbrirFormulario();
        }

        private void Button_AbrirFormulario_Click(object sender, RoutedEventArgs e)
        {
            AbrirFormulario();
        }

        private void AbrirFormulario()
        {
            Formulario formulario = new Formulario();
            formulario.Show();
        }
    }
}
