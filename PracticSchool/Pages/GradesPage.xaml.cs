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
using PracticSchool.AppData;
using Excel = Microsoft.Office.Interop.Excel;


namespace PracticSchool.Pages
{
    /// <summary>
    /// Логика взаимодействия для GradesPage.xaml
    /// </summary>
    public partial class GradesPage : Page
    {
        public GradesPage()
        {
            InitializeComponent();
            GradeLV.ItemsSource = Connect.Contex.Grades.ToList();
        }
        private void editBtn_Click(object sender, RoutedEventArgs e)
        {
            if (LoginPage.Admin == true)
            {
                Nav.Mframe.Navigate(new AddGrades((sender as Button).DataContext as Grades));
            }
            else
                MessageBox.Show("Гости не имеют доступа к этим настройкам.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            GradeLV.ItemsSource = Connect.Contex.Grades.ToList();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            if (LoginPage.Admin == true)
            {
                Nav.Mframe.Navigate(new AddGrades(null));
            }
            else
                MessageBox.Show("Гости не имеют доступа к этим настройкам.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);

        }

        private void Del_Click(object sender, RoutedEventArgs e)
        {
            if (LoginPage.Admin == true)
            {
                var delrezult = GradeLV.SelectedItems.Cast<Grades>().ToList();

                if (MessageBox.Show($"Вы точно хотите удалить запись", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    Connect.Contex.Grades.RemoveRange(delrezult);
                try
                {
                    Connect.Contex.SaveChanges();
                    GradeLV.ItemsSource = Connect.Contex.Grades.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString(), "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
                MessageBox.Show("Гости не имеют доступа к этим настройкам.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);

        }

        private void Excel_Click(object sender, RoutedEventArgs e)
        {
            if (LoginPage.Admin == true)
            {
                Excel.Application app = new Excel.Application()
                {
                    Visible = true,
                    SheetsInNewWorkbook = 1
                };
                Excel.Workbook workbook = app.Workbooks.Add(Type.Missing); app.DisplayAlerts = false;
                Excel.Worksheet sheet = (Excel.Worksheet)app.Worksheets.get_Item(1); sheet.Name = "Журнал оценок учеников";
                sheet.Cells[1, 1] = "ID Оценок";
                sheet.Cells[1, 2] = "Имя ученика";
                sheet.Cells[1, 3] = "Фамилия ученика";
                sheet.Cells[1, 4] = "Предмет";
                sheet.Cells[1, 5] = "Оценка";
                sheet.Cells[1, 6] = "Дата оценки";
                var currentRow = 2;
                var prod = Connect.Contex.Grades.ToList();
                foreach (var item in prod)
                {
                    sheet.Cells[currentRow, 1] = item.GradeID;
                    sheet.Cells[currentRow, 2] = item.Students.Name;
                    sheet.Cells[currentRow, 3] = item.Students.Surname;
                    sheet.Cells[currentRow, 4] = item.Subjects.SubjectName;
                    sheet.Cells[currentRow, 5] = item.Grade;
                    sheet.Cells[currentRow, 6] = item.GradeDate;
                    currentRow++;
                }

                Excel.Range range2 = sheet.get_Range("A1", "F20"); range2.Cells.Font.Name = "Times New Roman";
                range2.Cells.Font.Size = 12; range2.ColumnWidth = 20;
            }
            else
                MessageBox.Show("Гости не имеют доступа к этим настройкам.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);

            
        }
    }
}
