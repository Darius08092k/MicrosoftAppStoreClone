using MiscUtil;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
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
    /// Interaction logic for HamburgerMenuApp.xaml
    /// </summary>
    public partial class HamburgerMenuApp : UserControl
    {

        public List<string> AppNames { get; set; }
        public List<string> AppTypes { get; set; }
        public string AppName { get; set; }
        public DateTime Purchased { get; set; }
        public string Type { get; set; }



        public HamburgerMenuApp()
        {
            InitializeComponent();

            AppTypes = new List<string>()
            {
                "Apps",
                "Games",
                "Movies",
                "Avatars"
            };

            if (System.ComponentModel.DesignerProperties.GetIsInDesignMode(this))
            {
                return;
            }

            string imagesPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\Images\MiniIcons");
            imagesPath = System.IO.Path.GetFullPath(imagesPath);

            if (!Directory.Exists(imagesPath))
            {
                // Fallback to looking in the project root Images folder
                imagesPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\Images\MiniIcons");
                imagesPath = System.IO.Path.GetFullPath(imagesPath);
            }

            if (!Directory.Exists(imagesPath))
            {
                // If still not found, don't crash
                return;
            }

            List<string> filepaths = Directory.GetFiles(imagesPath, "*.png").ToList<string>();
            if (filepaths.Count == 0)
            {
                return;
            }

            FileInfo randomFile = new FileInfo(filepaths[StaticRandom.Next(filepaths.Count)]);
            AppImage.Source = new BitmapImage(new Uri(randomFile.FullName, UriKind.RelativeOrAbsolute));
            AppNameLabel.Content = (new CultureInfo("en-US", false).TextInfo)
                .ToTitleCase(randomFile.FullName.Split('\\').Last()
                .Split('-').Last().Split('.').First());
            AppName = AppNameLabel.Content.ToString();  
            Type = AppTypes[StaticRandom.Next(AppTypes.Count)];
            Purchased = new DateTime(2021, 1, StaticRandom.Next(1, DateTime.Now.Day + 1));
            PurchasedLabel.Content = "Purchased " + Purchased.ToString("d");
              

        }
    }
}
