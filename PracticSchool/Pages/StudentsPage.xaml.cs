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

namespace PracticSchool.Pages
{
    /// <summary>
    /// Логика взаимодействия для StudentsPage.xaml
    /// </summary>
    public partial class StudentsPage : Page
    {
        //d:ItemsSource="{d:SampleData ItemCount=5}"
        public StudentsPage()
        {
            InitializeComponent();
            StudentsLV.ItemsSource = Connect.Contex.Students.ToList();
        }
        private void editBtn_Click(object sender, RoutedEventArgs e)
        {
            if (LoginPage.Admin == true)
            {
                Nav.Mframe.Navigate(new AddStudents((sender as Button).DataContext as Students));
            }
            else
                MessageBox.Show("Гости не имеют доступа к этим настройкам.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            StudentsLV.ItemsSource = Connect.Contex.Students.ToList();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            if (LoginPage.Admin == true)
            {
                Nav.Mframe.Navigate(new AddStudents(null));
            }
            else
                MessageBox.Show("Гости не имеют доступа к этим настройкам.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            
        }

        private void Del_Click(object sender, RoutedEventArgs e)
        {
            if (LoginPage.Admin == true)
            {
                var delrezult = StudentsLV.SelectedItems.Cast<Students>().ToList();

                if (MessageBox.Show($"Вы точно хотите удалить запись", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    Connect.Contex.Students.RemoveRange(delrezult);
                try
                {
                    Connect.Contex.SaveChanges();
                    StudentsLV.ItemsSource = Connect.Contex.Students.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString(), "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
                MessageBox.Show("Гости не имеют доступа к этим настройкам.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);

            
        }
    }
}
