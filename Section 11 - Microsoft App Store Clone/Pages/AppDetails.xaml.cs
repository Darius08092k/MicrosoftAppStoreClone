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
    /// Interaction logic for AppDetails.xaml
    /// </summary>
    public partial class AppDetails : Page
    {
        public delegate void OnBackButtonClicked(object sender, RoutedEventArgs e);
        public event OnBackButtonClicked BackButtonclicked;

        public delegate void OnAppDetailsAnotherAppClicked(AnApp sender, RoutedEventArgs e);
        public event OnAppDetailsAnotherAppClicked AppClicked;

        /// Related Tab
        public delegate void OnAppDetailsAppClicked_PeopleAlsoLike(AnApp sender, RoutedEventArgs e);
        public event OnAppDetailsAppClicked_PeopleAlsoLike AppClicked_PeopleAlsoLike;

        public delegate void OnAppDetailsAppClicked_TopFreeGames(AnApp sender, RoutedEventArgs e);
        public event OnAppDetailsAppClicked_TopFreeGames AppClicked_TopFreeGames;

        public delegate void OnAppDetailsAppClicked_TopPaidGames(AnApp sender, RoutedEventArgs e);
        public event OnAppDetailsAppClicked_TopPaidGames AppClicked_TopPaidGames;

        public delegate void OnAppDetailsAppClicked_BestRatedGames(AnApp sender, RoutedEventArgs e);
        public event OnAppDetailsAppClicked_BestRatedGames AppClicked_BestRatedGames;

        public delegate void OnAppDetailsAppClicked_BestSellingGames(AnApp sender, RoutedEventArgs e);
        public event OnAppDetailsAppClicked_BestSellingGames AppClicked_BestSellingGames;

        public AppDetails(AnApp anApp)
        {
            InitializeComponent();

            AppDetailsAndBackgroundUC.AppTitleLabel.Content = anApp.AppName;
            AppDetailsAndBackgroundUC.AppImage.Source = anApp.AppImageSource;
            AppDetailsAndBackgroundUC.BackButtonclicked += AppDetailsTitleAndBackgroundControl_BackButtonclicked;
        
            OverviewTabContentUC.AppClicked += OverviewTabUC_AppDetailsAppClicked;

            RelatedTabContentUC.AppClicked_PeopleAlsoLike += RelatedTabUC_PeopleAlsoLikeClicked;
            RelatedTabContentUC.AppClicked_TopFreeGames += RelatedTabUC_TopFreeGames;
            RelatedTabContentUC.AppClicked_TopPaidGames += RelatedTabUC_TopPaidGames;
            RelatedTabContentUC.AppClicked_BestRatedGames += RelatedTabUC_BestRatedGames;
            RelatedTabContentUC.AppClicked_BestSellingGames += RelatedTabUC_BestSellingGames;

        }

        private void RelatedTabUC_BestSellingGames(AnApp sender, RoutedEventArgs e)
        {
            AppClicked_BestSellingGames(sender, e);
        }

        private void RelatedTabUC_BestRatedGames(AnApp sender, RoutedEventArgs e)
        {
            AppClicked_BestRatedGames(sender, e);
        }

        private void RelatedTabUC_TopPaidGames(AnApp sender, RoutedEventArgs e)
        {
            AppClicked_TopPaidGames(sender, e);
        }

        private void RelatedTabUC_TopFreeGames(AnApp sender, RoutedEventArgs e)
        {
            AppClicked_TopFreeGames(sender, e);
        }

        private void RelatedTabUC_PeopleAlsoLikeClicked(AnApp sender, RoutedEventArgs e)
        {
            AppClicked_PeopleAlsoLike(sender, e);
        }

        private void OverviewTabUC_AppDetailsAppClicked(AnApp sender, RoutedEventArgs e)
        {
            AppClicked(sender, e);
        }

        private void AppDetailsTitleAndBackgroundControl_BackButtonclicked(object sender, RoutedEventArgs e)
        {
            BackButtonclicked(this, e);
        }

    }
}
