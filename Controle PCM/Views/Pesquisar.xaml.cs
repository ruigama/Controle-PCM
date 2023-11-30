using Controle_PCM.Controllers;
using Controle_PCM.Models;
using PdfSharp.Pdf.Filters;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Runtime.Remoting.Messaging;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Markup;
using Aspose.Pdf;
using Aspose.Pdf.Text;
using Page = Aspose.Pdf.Page;
using PdfSharp.Drawing;
using PdfSharp.Pdf;

namespace Controle_PCM.Views
{
    /// <summary>
    /// Lógica interna para Pesquisar.xaml
    /// </summary>
    public partial class Pesquisar : Window
    {
        public Pesquisar()
        {
            InitializeComponent();
        }

        private void pesquisar_Click(object sender, RoutedEventArgs e)
        {
            string codigo = parametro.Text;
            PesquisaController pesquisa = new PesquisaController();
            List<Informacoes> resultados = pesquisa.PesquisarEquipamentos(codigo);

            // Preencha o DataGrid com os resultados
            resultadoGrid.ItemsSource = (System.Collections.IEnumerable)resultados;
        }

        private void Imprimir_Click(object sender, RoutedEventArgs e)
        {
            // Obter o item da linha selecionada
            Informacoes informacao = (Informacoes)resultadoGrid.SelectedItem;

            // Verificar se há um item selecionado
            if (informacao != null)
            {
                // Criar um documento PDF
                PdfDocument pdfDocument = new PdfDocument();

                // Adicionar uma página ao documento
                PdfPage pdfPage = pdfDocument.AddPage();

                // Configurar uma instância de XGraphics para desenhar na página
                XGraphics gfx = XGraphics.FromPdfPage(pdfPage);

                // Adicionar cabeçalho
                AdicionarCabecalho(gfx);

                // Adicionar informações ao PDF
                AdicionarTextoInformacao(gfx, informacao);

                // Adicionar rodapé
                AdicionarRodape(gfx, pdfPage);

                // Salvar o documento PDF
                pdfDocument.Save("output.pdf");

                // Lógica adicional para abrir ou exibir o PDF, se necessário
                System.Diagnostics.Process.Start("output.pdf");
            }
        }

        private void AdicionarCabecalho(XGraphics gfx)
        {
            // Adicione seu conteúdo de cabeçalho aqui, como título, logotipo, etc.
            XFont fonteCabecalho = new XFont("Arial", 16);

            // A posição e a largura da caixa de layout dependem do conteúdo real que você deseja adicionar
            XRect layoutRect = new XRect(30, 30, 500, 30);

            gfx.DrawString("Cabeçalho Personalizado", fonteCabecalho, XBrushes.Black, layoutRect, XStringFormats.TopLeft);
        }

        private void AdicionarRodape(XGraphics gfx, PdfPage pdfPage)
        {
            // Adicione seu conteúdo de rodapé aqui, como números de página, informações de data, etc.
            XFont fonteRodape = new XFont("Arial", 12);

            // A posição e a largura da caixa de layout dependem do conteúdo real que você deseja adicionar
            XRect layoutRect = new XRect(30, pdfPage.Height - 30, 500, 30);

            gfx.DrawString("Rodapé Personalizado - Página 1", fonteRodape, XBrushes.Black, layoutRect, XStringFormats.TopLeft);
        }

        private void AdicionarTextoInformacao(XGraphics gfx, Informacoes informacao)
        {
            // Adicionar informações ao PDF usando XGraphics
            XFont fonteInformacao = new XFont("Arial", 12);

            // A posição e a largura da caixa de layout dependem do conteúdo real que você deseja adicionar
            XRect layoutRectCodigo = new XRect(30, 70, 500, 30);
            gfx.DrawString($"Código: {informacao.codigo}", fonteInformacao, XBrushes.Black, layoutRectCodigo, XStringFormats.TopLeft);

            XRect layoutRectModelo = new XRect(30, 100, 500, 30);
            gfx.DrawString($"Modelo: {informacao.modelo}", fonteInformacao, XBrushes.Black, layoutRectModelo, XStringFormats.TopLeft);

            // Adicione mais informações conforme necessário
        }
    }
}
