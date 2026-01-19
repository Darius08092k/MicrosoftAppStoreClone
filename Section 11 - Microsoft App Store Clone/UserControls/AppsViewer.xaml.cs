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

namespace MicrosoftAppStoreClone.UserControls
{
    /// <summary>
    /// Interaction logic for AppsViewer.xaml
    /// </summary>
    public partial class AppsViewer : UserControl
    {
        List<AnApp> presentedApps;

        public delegate void OnAppClicked(AnApp sender, RoutedEventArgs e);
        public event OnAppClicked AppClicked;

        public AppsViewer()
        {
            InitializeComponent();
            presentedApps = new List<AnApp>();
            AppsList.ItemsSource = presentedApps;
            for (int i = 0; i < 9; i++)
            {
                AnApp newApp = new AnApp();
                newApp.AppClicked += Curr_AppClicked;
                presentedApps.Add(newApp);
            }
        }

        private void ScrollLeftButton_Click(object sender, RoutedEventArgs e)
        {
            int widthOfAnApp = (int)presentedApps.First().ActualWidth + 2 * (int)presentedApps.First().Margin.Left;

            AppsScrollView.ScrollToHorizontalOffset(AppsScrollView.HorizontalOffset - 1 * widthOfAnApp);
        }

        private void ScrollRightButton_Click(object sender, RoutedEventArgs e)
        {
            int widthOfAnApp = (int)presentedApps.First().ActualWidth + 2 * (int)presentedApps.First().Margin.Left;

            AppsScrollView.ScrollToHorizontalOffset(AppsScrollView.HorizontalOffset + 1 * widthOfAnApp);
        }

        private void AppsScrollView_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            e.Handled = true;
            var args = new MouseWheelEventArgs(e.MouseDevice, e.Timestamp, e.Delta);
            args.RoutedEvent = UIElement.MouseWheelEvent;
            args.Source = sender;
            var parent = ((Control)sender).Parent as UIElement;
            parent.RaiseEvent(args);
        }

        private void Curr_AppClicked(AnApp sender, RoutedEventArgs e)
        {
            AppClicked(sender, e);
        }
    }
}
