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
    /// Логика взаимодействия для ReportMainPage.xaml
    /// </summary>
    public partial class ReportMainPage : Page
    {
        public ReportMainPage(Заявка order)
        {
            InitializeComponent();
            _order = order;
            _order.ДатаОтчета = DateTime.Now;
            DataContext= _order;
            if (_order.Статус != (int)status.Ожидает_отчёта)
            {
                Panel.IsEnabled= false;
            }
        }
        private Заявка _order;

        private void SaveClick(object sender, RoutedEventArgs e)
        {
            _order.Статус = (int)status.завершен;
            DrillMasterEntities.GetContext().SaveChanges();
            Nav.Back();
            Word();
        }

        private readonly string TemplateFileName = System.IO.Path.GetFullPath(@"Word/Отчет.docx");
        void ReplaceWordStub(String stubToReplace, string text, Word.Document wordDocument)
        {
            var range = wordDocument.Content;
            range.Find.ClearFormatting();
            range.Find.Execute(FindText: stubToReplace, ReplaceWith: text);
        }
        private void Word()
        {
            var wordApp = new Word.Application();

            wordApp.Visible = false;
            Word.Document wordDocument;
            
                wordDocument = wordApp.Documents.Open(TemplateFileName);
           
           
            ReplaceWordStub("(код)", $"{_order.Код}", wordDocument);
            ReplaceWordStub("(оборудование)", $"{_order.Оборудование.name}", wordDocument);
            ReplaceWordStub("(датаРемонта)", $"{_order.ДатаРемонта}", wordDocument);
            ReplaceWordStub("(датаОтчета)", $"{_order.ДатаОтчета}", wordDocument);
            ReplaceWordStub("(отчет)", $"{_order.Отчет}", wordDocument);

            
                wordDocument.SaveAs2(System.IO.Path.GetFullPath($@"Word/Отчет №{_order.Код}.docx"));
           

            wordApp.Visible = true;
        }
    }
}
