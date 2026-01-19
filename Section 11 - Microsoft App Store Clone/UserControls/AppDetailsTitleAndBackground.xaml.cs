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
    /// Interaction logic for AppDetailsTitleAndBackground.xaml
    /// </summary>
    public partial class AppDetailsTitleAndBackground : UserControl
    {
        public delegate void OnBackButtonClicked(object sender, RoutedEventArgs e);
        public event OnBackButtonClicked BackButtonclicked;
        public AppDetailsTitleAndBackground()
        {
            InitializeComponent();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            BackButtonclicked(this, e);
        }

        private void MiddleStackPanel_GiveFeedback(object sender, GiveFeedbackEventArgs e)
        {

        }
    }
}
