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

namespace MicrosoftAppStoreClone.UserControls
{
    /// <summary>
    /// Interaction logic for HeaderRightButtons.xaml
    /// </summary>
    public partial class HeaderRightButtons : UserControl
    {

        public delegate void OnDownloadButtonClick(object sender, RoutedEventArgs e);
        public event OnDownloadButtonClick HeaderRightButtonsDownloadButtonClicked;

        public HeaderRightButtons()
        {
            InitializeComponent();
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            (sender as Button).Visibility = Visibility.Collapsed;
            SearchTextBox.Visibility = Visibility.Visible;
        }

        private void MouseDown_OutsideOfHeaderRightButtons()
        {
            if(!SearchTextBox.IsMouseOver)
            {
                SearchButton.Visibility = Visibility.Visible;
                SearchTextBox.Visibility = Visibility.Collapsed;
            }
        }

        private void DownloadButton_Click(object sender, RoutedEventArgs e)
        {
            HeaderRightButtonsDownloadButtonClicked(sender, e); 
        }

        private void DownloadsAndUpdated_Click(object sender, RoutedEventArgs e)
        {
            HeaderRightButtonsDownloadButtonClicked(sender, e);
        }
    }
}
