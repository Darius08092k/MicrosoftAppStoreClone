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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MicrosoftAppStoreClone.Pages
{
    /// <summary>
    /// Interaction logic for Main.xaml
    /// </summary>
    public partial class Main : Page
    {
        public delegate void OnAppClicked(AnApp sender, RoutedEventArgs e);
        public event OnAppClicked AppClicked;

        public delegate void OnTopAppClicked(object sender, RoutedEventArgs e);
        public event OnTopAppClicked TopAppButtonClicked;

        public delegate void OnDownloadsAndUpdatesClicked(object sender, RoutedEventArgs e);
        public event OnDownloadsAndUpdatesClicked DownloadsAndUpdatesButtonClicked;

        public Main()
        {
            InitializeComponent();

            DealsApp1.AppClicked += AnAppClicked;

            ProductivityApp1.AppClicked += AnAppClicked;

            EntertainmentApp1.AppClicked += AnAppClicked;

            GamingApp1.AppClicked += AnAppClicked;

            FeaturedAppsViewer.AppClicked += AnAppClicked;
            MostPopularViewer.AppClicked += AnAppClicked;
            TopFreeAppsViewer.AppClicked += AnAppClicked;
            TopFreeGamesViewer.AppClicked += AnAppClicked;

            TopAppsControl.AppClicked += AnAppClicked;
            TopAppsControl.TopAppButtonClicked += TopApps_TopAppButtonClicked;

            ProductivityTopAppsControl.AppClicked += AnAppClicked;

            RightHeaderButtons.HeaderRightButtonsDownloadButtonClicked += RightHeaderButtons_DownloadClicked;

            // Subscribe to app list changes to dynamically adjust MaxHeight
            AllOwnedView.HamAppsList.AppListChanged += HamAppsList_AppListChanged;
        }

        private void RightHeaderButtons_DownloadClicked(object sender, RoutedEventArgs e)
        {
            DownloadsAndUpdatesButtonClicked?.Invoke(sender, e);
        }

        private void HamburgerOverlay_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.Source == HamburgerOverlay)
            {
                HamburgerOverlay.Visibility = Visibility.Collapsed;
            }
        }

        private void HamAppsList_AppListChanged(object sender, EventArgs e)
        {
            // Get the hamburger border element
            Border hamburgerBorder = (Border)HamburgerOverlay.FindName("Border");
            if (hamburgerBorder != null)
            {
                int appCount = AllOwnedView.HamAppsList.MainStackPanel.Children.Count;
                double calculatedHeight = (appCount * 64) + 50; // 50 for header padding

                // Cap at 500 pixels max
                hamburgerBorder.MaxHeight = Math.Min(calculatedHeight, 500);
            }
        }

        private void TopApps_TopAppButtonClicked(object sender, RoutedEventArgs e)
        {
            TopAppButtonClicked(sender, e);
        }

        private void MainScrollViewer_Loaded(object sender, RoutedEventArgs e)
        {
            UIElement element = sender as UIElement;
            element.Opacity = 0;
            DoubleAnimation animation = new DoubleAnimation()
            {
                From = 0,
                To = 1,
                Duration = new Duration(TimeSpan.FromSeconds(1))
            };

            element.BeginAnimation(UIElement.OpacityProperty, animation);
        }

        private void AnAppClicked(AnApp sender, RoutedEventArgs e)
        {
            AppClicked(sender, e);
        }
    }
}
