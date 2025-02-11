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

namespace PracticSchool.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddAttendance.xaml
    /// </summary>
    public partial class AddAttendance : Page
    {
        Attendance attendance;
        bool CheckNew;
        public AddAttendance(Attendance p)
        {
            InitializeComponent();

            StudentsLV.ItemsSource = Connect.Contex.Students.ToList();
            StudentsLV1.ItemsSource = Connect.Contex.Students.ToList();
            ClassesLV.ItemsSource = Connect.Contex.Classes.ToList();
            if (p == null)
            {
                p = new Attendance();
                CheckNew = true;
            }
            else
                CheckNew = false;
            DataContext = attendance = p;
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            if (CheckNew)
            {
                Connect.Contex.Attendance.Add(attendance);
            }
            try
            {
                Connect.Contex.SaveChanges();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            Nav.MainFrame.GoBack();
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            Nav.MainFrame.GoBack();
        }
    }
}
