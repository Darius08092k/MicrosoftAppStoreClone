using MiscUtil;
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
    /// Interaction logic for AReview.xaml
    /// </summary>
    public partial class AReview : UserControl
    {
        List<string> Names;
        List<string> Devices;
        public AReview()
        {
            InitializeComponent();
            Names = new List<string>()
            {
                "John Doe",
                "Jane Smith",
                "Alice Johnson",
                "Bob Brown",
                "Charlie Davis",    
                "Diana Evans",
                "Frank Green",
                "Grace Harris",
                "Henry Irving",
                "Ivy Jackson"
            };

            string reviewerName = Names[StaticRandom.Next(Names.Count)];
            RevierNameLabel.Content = reviewerName;
            AvatarLabel.Content = reviewerName[0];

            Devices = new List<string>()
            {
                "Windows 10 PC",
                "Windows 11 Laptop",
                "Surface Pro",
                "Xbox Series X",
                "Windows Tablet",
                "Gaming PC",
                "Workstation",
                "Convertible Laptop",
                "All-in-One PC",
                "Desktop PC"
            };

            DeviceLabel.Content = Devices[StaticRandom.Next(Devices.Count)];

            NumOfStarsLabel.Content = GetRandomNumberOfStars();

            ReviewTitle.Content = GetReviewTitlesBasedOnStars(NumOfStarsLabel.Content.ToString());
        }

        private string GetRandomNumberOfStars()
        {
            string content = "";
            for (int i = 0; i < StaticRandom.Next(1, 6); i++)
            {
                content += "★";
            }
            return content;
        }

        private string GetReviewTitlesBasedOnStars(string inStars)
        {
            string retStr = string.Empty;
            if(inStars.Length >= 4)
            {
                retStr="This app is really awesome!";
            }
            else if(inStars.Length == 3)
            {
                retStr = "This app is alright";
            }
            else
            {
                retStr = "This app is poor";
            }
            return retStr;
        }
    }
}
