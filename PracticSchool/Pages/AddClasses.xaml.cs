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
    /// Логика взаимодействия для AddClasses.xaml
    /// </summary>
    public partial class AddClasses : Page
    {
        Classes clas;
        bool CheckNew;
        public AddClasses(Classes p)
        {
            InitializeComponent();
            TeachersLV.ItemsSource = Connect.Contex.Teachers.ToList();
            if (p == null)
            {
                p = new Classes();
                CheckNew = true;
            }
            else
                CheckNew = false;
            DataContext = clas = p;
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            if (CheckNew)
            {
                Connect.Contex.Classes.Add(clas);
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
