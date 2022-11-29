using CommunityToolkit.Mvvm.WpfDemo.ViewModels;
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
    /// RelayCommandPage.xaml 的交互逻辑
    /// </summary>
    public partial class RelayCommandPage : Page
    {
        public RelayCommandPage()
        {
            InitializeComponent();
            this.DataContext = new RelayCommandPageViewModel();
        }
    }
}
