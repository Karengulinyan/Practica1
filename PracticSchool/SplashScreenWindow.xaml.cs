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
using System.Windows.Shapes;

namespace PracticSchool
{
    /// <summary>
    /// Логика взаимодействия для SplashScreenWindow.xaml
    /// </summary>
    public partial class SplashScreenWindow : Window
    {
        public SplashScreenWindow()
        {
            InitializeComponent();
        }
        public void SetStatus(string status)
        {
            StatusTextBlock.Text = status;
        }

        public void SetProgress(int progress)
        {
            ProgressBar.Value = progress;
        }

    }
}
