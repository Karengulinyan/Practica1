using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
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
using Microsoft.Win32;
using PracticSchool.AppData;

namespace PracticSchool.Pages
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
            Nav.Mframe = MFrame;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MFrame.Navigate(new StudentsPage());
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MFrame.Navigate(new ClassesPage());
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            MFrame.Navigate(new TeachersPages());
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            MFrame.Navigate(new SubjectsPage());
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            MFrame.Navigate(new GradesPage());

        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            MFrame.Navigate(new AttendancePage());
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            Nav.MainFrame.Navigate(new LoginPage());
        }

        //private void Button_Click_6(object sender, RoutedEventArgs e)
        //{
        //    var dialog = new SaveFileDialog();
        //    dialog.Filter = "Резервная копия(*.bak)|*.bak|Все файлы(*.*)|*.*";
        //    bool? result = dialog.ShowDialog();
        //    if (result == true)
        //        Connect.Contex.Database.ExecuteSqlCommand(TransactionalBehavior.DoNotEnsureTransaction,
        //            $@"BACKUP DATABASE [{Directory.GetCurrentDirectory()}\School.mdf] TO  " +
        //        $@"DISK = N'{dialog.FileName}' WITH NOFORMAT, NOINIT,  " +
        //        $@"NAME = N'{dialog.FileName}', SKIP, NOREWIND, NOUNLOAD,  STATS = 10");
        //}

    }
}
