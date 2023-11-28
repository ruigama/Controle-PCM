using Microsoft.Win32;
using System;
using System.Windows;
using System.Windows.Controls;
using Controle_PCM.Models;
using System.Collections.Generic;
using System.IO;
using Controle_PCM.Controllers;
using System.Linq;
using System.Windows.Input;
using Xceed.Wpf.Toolkit;

namespace Controle_PCM.Views
{
    /// <summary>
    /// Lógica interna para Formulario.xaml
    /// </summary>
    public partial class Formulario : Window
    {
        public Formulario()
        {
            InitializeComponent();
            //WindowState = WindowState.Maximized;
        }

        private void AnexarImagens_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = true;
            openFileDialog.Filter = "Imagens|*.jpg;*.jpeg;*.png;*.gif;*.bmp";

            if (openFileDialog.ShowDialog() == true)
            {
                foreach (string fileName in openFileDialog.FileNames)
                {
                    // Adicione o caminho do arquivo à lista ou faça o que for necessário
                    listaImagens.Items.Add(fileName);
                }

            }
        }

        private void salvar_Click(object sender, RoutedEventArgs e)
        {
            bool salvar = false;
            FormularioController formularioController = new FormularioController();
            Informacoes formulario = new Informacoes();
            formulario.modelo = modelo.Text;
            formulario.codigo = codigo.Text;

            if (_1.IsChecked == true)
            {
                formulario.aspecto_tecnico = "Aspecto Nova";
            }
            else if (_2.IsChecked == true)
            {
                formulario.aspecto_tecnico = "Pequenas Avarias";
            }
            else if (_3.IsChecked == true)
            {
                formulario.aspecto_tecnico = "Grandes Avarias";
            }

            formulario.preco_nova = preco_nova.Text;
            formulario.custo = custo.Text;
            formulario.preco_atual = preco_estado_atual.Text;
            formulario.avaliacao_tecnica = avaliacao.Text;

            List<string> imagensCaminhos = new List<string>();            

            foreach (string imagePath in listaImagens.Items)
            {
                string imageName = Path.GetFileName(imagePath);
                string imageFullPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, imagePath);
                imagensCaminhos.Add(imageName + " - " + imageFullPath);
            }

            salvar = formularioController.Salvar(formulario, imagensCaminhos);

            if(salvar)
            {
                Inicio paginaPrincipal = new Inicio();
                paginaPrincipal.Show();
                Close();
            }
            else
            {
                System.Windows.MessageBox.Show("Revise as informações do formulário.");
            }
        }
    }
}
