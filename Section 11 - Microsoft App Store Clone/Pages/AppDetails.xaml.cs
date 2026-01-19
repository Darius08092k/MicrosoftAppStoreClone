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

        public AppDetails(AnApp anApp)
        {
            InitializeComponent();

            AppDetailsAndBackgroundUC.AppTitleLabel.Content = anApp.AppName;
            AppDetailsAndBackgroundUC.AppImage.Source = anApp.AppImageSource;
            AppDetailsAndBackgroundUC.BackButtonclicked += AppDetailsTitleAndBackgroundControl_BackButtonclicked;
        }

        private void AppDetailsTitleAndBackgroundControl_BackButtonclicked(object sender, RoutedEventArgs e)
        {
            BackButtonclicked(this, e);
        }

    }
}
