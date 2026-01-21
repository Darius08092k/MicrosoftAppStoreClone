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

namespace MicrosoftAppStoreClone.UserControls.AppDetailsTabContent
{
    /// <summary>
    /// Interaction logic for Related.xaml
    /// </summary>
    public partial class Related : UserControl
    {
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
        public Related()
        {
            InitializeComponent();
            AppsViewerInsideRelatedTab_PeopleAlsoLike.AppClicked += AppsViewerInsideReleatedTab_AppClicked_PeopleAlsoLike;
            AppsViewerInsideRelatedTab_TopFreeGames.AppClicked += AppsViewerInsideReleatedTab_AppClicked_TopFreeGames;
            AppsViewerInsideRelatedTab_TopPaidGames.AppClicked += AppsViewerInsideReleatedTab_AppClicked_TopPaidGames;
            AppsViewerInsideRelatedTab_BestRatedGames.AppClicked += AppsViewerInsideReleatedTab_AppClicked_BestRatedGames;
            AppsViewerInsideRelatedTab_BestSellingGames.AppClicked += AppsViewerInsideReleatedTab_AppClicked_BestSellingGames;


        }

        private void AppsViewerInsideReleatedTab_AppClicked_BestSellingGames(AnApp sender, RoutedEventArgs e)
        {
            AppClicked_BestSellingGames(sender, e);

        }

        private void AppsViewerInsideReleatedTab_AppClicked_BestRatedGames(AnApp sender, RoutedEventArgs e)
        {
            AppClicked_BestRatedGames(sender, e);
        }

        private void AppsViewerInsideReleatedTab_AppClicked_TopPaidGames(AnApp sender, RoutedEventArgs e)
        {
            AppClicked_TopPaidGames(sender, e);

        }

        private void AppsViewerInsideReleatedTab_AppClicked_TopFreeGames(AnApp sender, RoutedEventArgs e)
        {
            AppClicked_TopFreeGames(sender, e);
        }

        private void AppsViewerInsideReleatedTab_AppClicked_PeopleAlsoLike(AnApp sender, RoutedEventArgs e)
        {
            AppClicked_PeopleAlsoLike(sender,e);
        }
    }
}
