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
    /// Логика взаимодействия для TeachersPages.xaml
    /// </summary>
    public partial class TeachersPages : Page
    {
        public TeachersPages()
        {
            InitializeComponent();
            TeachersLV.ItemsSource = Connect.Contex.Teachers.ToList();
        }
        private void editBtn_Click(object sender, RoutedEventArgs e)
        {
            if (LoginPage.Admin == true)
            {
                Nav.Mframe.Navigate(new AddTeachers((sender as Button).DataContext as Teachers));
            }
            else
                MessageBox.Show("Гости не имеют доступа к этим настройкам.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            TeachersLV.ItemsSource = Connect.Contex.Teachers.ToList();

        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            if (LoginPage.Admin == true)
            {
                Nav.Mframe.Navigate(new AddTeachers(null));
            }
            else
                MessageBox.Show("Гости не имеют доступа к этим настройкам.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);

        }

        private void Del_Click(object sender, RoutedEventArgs e)
        {
            if (LoginPage.Admin == true)
            {
                var delrezult = TeachersLV.SelectedItems.Cast<Teachers>().ToList();

                if (MessageBox.Show($"Вы точно хотите удалить запись", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    Connect.Contex.Teachers.RemoveRange(delrezult);
                try
                {
                    Connect.Contex.SaveChanges();
                    TeachersLV.ItemsSource = Connect.Contex.Teachers.ToList();
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
