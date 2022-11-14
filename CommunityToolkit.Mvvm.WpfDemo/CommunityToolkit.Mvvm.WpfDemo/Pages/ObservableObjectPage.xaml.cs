using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CommunityToolkit.Mvvm.WpfDemo.Pages
{
    /// <summary>
    /// ObservableObjectPage.xaml 的交互逻辑
    /// </summary>
    public partial class ObservableObjectPage : Page
    {
        public ObservableObjectPage()
        {
            InitializeComponent();
            this.DataContext = new ViewModels.ObservableObjectPageViewModel();
        }
    }
}
