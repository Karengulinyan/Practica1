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
    /// Логика взаимодействия для ClassesPage.xaml
    /// </summary>
    public partial class ClassesPage : Page
    {
        //d:ItemsSource="{d:SampleData ItemCount=5}"
        public ClassesPage()
        {
            InitializeComponent();
            ClassesLV.ItemsSource = Connect.Contex.Classes.ToList();
        }
        private void editBtn_Click(object sender, RoutedEventArgs e)
        {
            if (LoginPage.Admin == true)
            {
                Nav.Mframe.Navigate(new AddClasses((sender as Button).DataContext as Classes));
            }
            else
                MessageBox.Show("Гости не имеют доступа к этим настройкам.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            ClassesLV.ItemsSource = Connect.Contex.Classes.ToList();

        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            if (LoginPage.Admin == true)
            {
                Nav.Mframe.Navigate(new AddClasses(null));
            }
            else
                MessageBox.Show("Гости не имеют доступа к этим настройкам.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);

        }

        private void Del_Click(object sender, RoutedEventArgs e)
        {
            if (LoginPage.Admin == true)
            {
                var delrezult = ClassesLV.SelectedItems.Cast<Classes>().ToList();

                if (MessageBox.Show($"Вы точно хотите удалить запись", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    Connect.Contex.Classes.RemoveRange(delrezult);
                try
                {
                    Connect.Contex.SaveChanges();
                    ClassesLV.ItemsSource = Connect.Contex.Classes.ToList();
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
