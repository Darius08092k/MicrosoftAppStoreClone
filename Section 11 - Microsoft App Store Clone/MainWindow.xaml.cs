using MicrosoftAppStoreClone.Pages;
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

namespace MicrosoftAppStoreClone
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Main MainWindowContentPage;
        public MainWindow()
        {
            InitializeComponent();
            MainWindowContentPage = new Main();
            MainWindowContentPage.AppClicked += MainWindowContentPage_AppClicked;
        }

        private void MainWindowContentPage_AppClicked(AnApp sender, RoutedEventArgs e)
        {
            AppDetails myAppDetails = new AppDetails(sender);
            myAppDetails.BackButtonclicked += MyAppDetails_BackButtonclicked;
            myAppDetails.AppClicked += MainWindowContentPage_AppClicked;

            // Related Tab
            myAppDetails.AppClicked_PeopleAlsoLike += MainWindowContentPage_AppClicked;
            myAppDetails.AppClicked_TopFreeGames += MainWindowContentPage_AppClicked;
            myAppDetails.AppClicked_TopPaidGames += MainWindowContentPage_AppClicked;
            myAppDetails.AppClicked_BestRatedGames += MainWindowContentPage_AppClicked;
            myAppDetails.AppClicked_BestSellingGames += MainWindowContentPage_AppClicked;


            MainFrame.Content = myAppDetails;
        }

        private void MyAppDetails_BackButtonclicked(object sender, RoutedEventArgs e)
        {
            if (MainFrame.NavigationService.CanGoBack)
            {
                MainFrame.NavigationService.GoBack();
            }
        }

        private void MainFrame_Loaded(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = MainWindowContentPage;
        }
    }
}
