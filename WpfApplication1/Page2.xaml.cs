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

namespace WpfApplication1
{
    /// <summary>
    /// Page2.xaml 的交互逻辑
    /// </summary>
    public partial class Page2 : Page
    {
        public Page2()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("Page1.xaml", UriKind.Relative));
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("Page3.xaml", UriKind.Relative));
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("Page4.xaml", UriKind.Relative));
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("Page5.xaml", UriKind.Relative));
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("Page6.xaml", UriKind.Relative));
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("Page7.xaml", UriKind.Relative));
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("Page8.xaml", UriKind.Relative));
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("Page9.xaml", UriKind.Relative));
        }

        private void Button_Click_8(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("Page10.xaml", UriKind.Relative));
        }

        private void Button_Click_9(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("Page11.xaml", UriKind.Relative));
        }

        private void Button_Click_10(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("Page12.xaml", UriKind.Relative));
        }

        private void Button_Click_11(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("Page13.xaml", UriKind.Relative));
        }

        private void Button_Click_12(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("Page14.xaml", UriKind.Relative));
        }

        private void Button_Click_13(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("Page15.xaml", UriKind.Relative));
        }

        private void Button_Click_14(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("Page16.xaml", UriKind.Relative));
        }

        private void Button_Click_15(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("Page17.xaml", UriKind.Relative));
        }
    }
}
