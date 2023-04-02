using DrillApp.Model;
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
using Word = Microsoft.Office.Interop.Word;

namespace DrillApp.View.Pages.Order
{
    /// <summary>
    /// Логика взаимодействия для DiagnosticsPage.xaml
    /// </summary>
    public partial class DiagnosticsPage : Page
    {
        public DiagnosticsPage(Заявка order)
        {
            InitializeComponent();
            _order = order;
            _order.ДатаРемонта = DateTime.Now;
            DataContext = _order;
            if (_order.Статус != (int)status.Ремонтируется)
            {
                Panel.IsEnabled= false;
            }
        }
        private Заявка _order;
        private readonly string TemplateFileName = System.IO.Path.GetFullPath(@"Word/отчет о проделанной работе.docx");
        private readonly string TemplateFileName1 = System.IO.Path.GetFullPath(@"Word/Акт списания.docx");
        void ReplaceWordStub(String stubToReplace, string text, Word.Document wordDocument)
        {
            var range = wordDocument.Content;
            range.Find.ClearFormatting();
            range.Find.Execute(FindText: stubToReplace, ReplaceWith: text);
        }
        private void Word(bool repair)
        {
            var wordApp = new Word.Application();

            wordApp.Visible = false;
            Word.Document wordDocument;
            if (repair)
            {
                wordDocument = wordApp.Documents.Open(TemplateFileName);
            }
            else
            {
                 wordDocument = wordApp.Documents.Open(TemplateFileName1);
            }
            ReplaceWordStub("(код)",$"{_order.Код}" , wordDocument);
            ReplaceWordStub("(оборудование)", $"{_order.Оборудование.name}", wordDocument);
            ReplaceWordStub("(датаРемонта)", $"{_order.ДатаРемонта}", wordDocument);
            ReplaceWordStub("(описание)", $"{_order.ОписаниеРемонта}", wordDocument);

            if (repair)
            {
                wordDocument.SaveAs2(System.IO.Path.GetFullPath($@"Word/отчет о проделанной работе№{_order.Код}.docx"));
            }
            else
            {
                wordDocument.SaveAs2(System.IO.Path.GetFullPath($@"Word/Акт списаемя№{_order.Код}.docx"));
            }
            
            wordApp.Visible = true;
        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void SaveClick(object sender, RoutedEventArgs e)
        {
            if (rBtnBroken.IsChecked.Value)
            {
                _order.Оборудование.Списан = true;
                _order.Статус = (int)status.завершен;
            }
            else
            {
                _order.Статус = (int)status.Ожидает_отчёта;
                
            }
            Word(!rBtnBroken.IsChecked.Value);
            _order.Оборудование.Ремонтируется = false;
            DrillMasterEntities.GetContext().SaveChanges();
            Nav.Back();
        }
    }
}
