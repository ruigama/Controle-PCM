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

namespace Controle_PCM.Views
{
    /// <summary>
    /// Interação lógica para Principal.xam
    /// </summary>
    public partial class Principal : Page
    {
        public Principal()
        {
            InitializeComponent();
            Window window = Window.GetWindow(this);
            if (window == null)
            {
                return;
            }
            window.WindowState = System.Windows.WindowState.Maximized;
        }

        private void MenuItem_Sair_Click(object sender, RoutedEventArgs e)
        {
            Window janela = Window.GetWindow(this);
            janela?.Close();
        }
    }
}
