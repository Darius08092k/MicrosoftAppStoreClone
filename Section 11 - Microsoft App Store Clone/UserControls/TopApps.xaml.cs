using System;
using System.Collections.Generic;
using System.Globalization;
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

namespace MicrosoftAppStoreClone.UserControls
{
    /// <summary>
    /// Interaction logic for TopApps.xaml
    /// </summary>
    public partial class TopApps : UserControl
    {
        public delegate void OnAppClicked(AnApp sender, RoutedEventArgs e);
        public event OnAppClicked AppClicked;

        public delegate void OnTopAppClicked(object sender, RoutedEventArgs e);
        public event OnTopAppClicked TopAppButtonClicked;
        public TopApps()
        {
            InitializeComponent();
        }

        private void Image_MouseUp(object sender, MouseButtonEventArgs e)
        {
            string appName = (new CultureInfo("en-US", false).TextInfo).ToTitleCase
            (
                (sender as Image).Source.ToString().Split('/')
                .Last().Split('.').First().Split('-').Last().Split('.').First()
            );
            AppClicked(new AnApp(appName, (sender as Image).Source), e);
        }

        private void TopAppsButton_Click(object sender, RoutedEventArgs e)
        {
            TopAppButtonClicked(sender,e);
        }

        private void TopGamesButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CollectionsButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Featured_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
