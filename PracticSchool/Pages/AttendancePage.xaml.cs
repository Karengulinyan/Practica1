using PracticSchool.AppData;
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
using Excel = Microsoft.Office.Interop.Excel;

namespace PracticSchool.Pages
{
    /// <summary>
    /// Логика взаимодействия для AttendancePage.xaml
    /// </summary>
    public partial class AttendancePage : Page
    {
        public AttendancePage()
        {
            InitializeComponent();
            AttendanceLV.ItemsSource = Connect.Contex.Attendance.ToList();
        }
        private void editBtn_Click(object sender, RoutedEventArgs e)
        {
            if (LoginPage.Admin == true)
            {
                Nav.Mframe.Navigate(new AddAttendance((sender as Button).DataContext as Attendance));
            }
            else
                MessageBox.Show("Гости не имеют доступа к этим настройкам.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            AttendanceLV.ItemsSource = Connect.Contex.Attendance.ToList();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            if (LoginPage.Admin == true)
            {
                Nav.Mframe.Navigate(new AddAttendance(null));
            }
            else
                MessageBox.Show("Гости не имеют доступа к этим настройкам.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            
        }

        private void Del_Click(object sender, RoutedEventArgs e)
        {
            if (LoginPage.Admin == true)
            {
                var delrezult = AttendanceLV.SelectedItems.Cast<Attendance>().ToList();

                if (MessageBox.Show($"Вы точно хотите удалить запись", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    Connect.Contex.Attendance.RemoveRange(delrezult);
                try
                {
                    Connect.Contex.SaveChanges();
                    AttendanceLV.ItemsSource = Connect.Contex.Attendance.ToList();
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
                Excel.Worksheet sheet = (Excel.Worksheet)app.Worksheets.get_Item(1); sheet.Name = "Журнал посещаемости учеников";
                sheet.Cells[1, 1] = "ID Посещаемость";
                sheet.Cells[1, 2] = "Имя ученика";
                sheet.Cells[1, 3] = "Фамилия ученика";
                sheet.Cells[1, 4] = "Кабинет";
                sheet.Cells[1, 5] = "Посещаемость на уроках";
                var currentRow = 2;
                var prod = Connect.Contex.Attendance.ToList();
                foreach (var item in prod)
                {
                    sheet.Cells[currentRow, 1] = item.AttendanceID;
                    sheet.Cells[currentRow, 2] = item.Students.Name;
                    sheet.Cells[currentRow, 3] = item.Students.Surname;
                    sheet.Cells[currentRow, 4] = item.Classes.ClassName;
                    sheet.Cells[currentRow, 5] = item.Visiting;
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
