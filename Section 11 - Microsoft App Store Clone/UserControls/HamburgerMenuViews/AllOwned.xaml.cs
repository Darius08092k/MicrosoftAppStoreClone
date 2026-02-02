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

namespace MicrosoftAppStoreClone.UserControls.HamburgerMenuViews
{
    /// <summary>
    /// Interaction logic for AllOwned.xaml
    /// </summary>
    public partial class AllOwned : UserControl
    {

        public AllOwned()
        {
            InitializeComponent();
            HamHeader.FilterMenuItemClicked += HamHeader_FilterMenuItemClicked;
            HamHeader.SortByMenuItemClicked += HamHeader_SortByItemClicked;
        }

        private void HamHeader_FilterMenuItemClicked(object sender, RoutedEventArgs e)
        {
            if((sender as MenuItem).Header.ToString().ToLower().Equals("all types"))
            {
                HamAppsList.AddAll();
            }
            else
            {
                HamAppsList.FilterByType((sender as MenuItem).Header.ToString());
            }
        }

        private void HamHeader_SortByItemClicked(object sender, RoutedEventArgs e)
        {
            if ((sender as MenuItem).Header.ToString().ToLower().Equals("sort by name"))
            {
                HamAppsList.SortByName();
            }
            else
            {
                HamAppsList.SortByDate();
            }
        }
    }
}
