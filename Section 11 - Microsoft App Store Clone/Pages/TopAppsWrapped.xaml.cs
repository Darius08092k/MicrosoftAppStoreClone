using MicrosoftAppStoreClone.UserControls;
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

namespace MicrosoftAppStoreClone.Pages
{
    /// <summary>
    /// Interaction logic for TopAppsWrapped.xaml
    /// </summary>
    public partial class TopAppsWrapped : Page
    {
        public delegate void OnAppClicked(AnApp sender, RoutedEventArgs e);
        public event OnAppClicked AnAppClicked;

        public delegate void OnBackButtonClicked(object sender, RoutedEventArgs e);
        public event OnBackButtonClicked BackButtonclicked;
        public TopAppsWrapped()
        {
            InitializeComponent();

            for (int i = 0; i < 20; i++)
            {
                AnApp currApp = new AnApp();
                currApp.AppClicked += CurrApp_AppClicked;
                TopAppsWrappedPageMainWrapPanel.Children.Add(currApp);
            }
        }

        private void CurrApp_AppClicked(AnApp sender, RoutedEventArgs e)
        {
            AnAppClicked(sender, e);
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            BackButtonclicked(sender, e);
        }

        private void TopAppsWrappedPageMainSV_ScrollChanged(object sender, ScrollChangedEventArgs e)
        {
            if (e.VerticalChange > 0)
            {
                int adjustment = 400;
                if(e.VerticalOffset + e.ViewportHeight+adjustment >= e.ExtentHeight)
                {
                    for (int i = 0; i < 6; i++)
                    {
                        AnApp currApp = new AnApp();
                        currApp.AppClicked += CurrApp_AppClicked;
                        TopAppsWrappedPageMainWrapPanel.Children.Add(currApp);
                    }
                }
            }
        }
    }
}
