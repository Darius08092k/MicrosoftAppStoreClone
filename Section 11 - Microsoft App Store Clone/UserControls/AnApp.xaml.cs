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

namespace MicrosoftAppStoreClone.UserControls
{
    /// <summary>
    /// Interaction logic for AnApp.xaml
    /// </summary>
    public partial class AnApp : UserControl
    {
        public string AppName;
        public ImageSource AppImageSource;

        public delegate void OnAppClicked(AnApp sender, RoutedEventArgs e);
        public event OnAppClicked AppClicked;

        public AnApp()
        {
            InitializeComponent();
            
            if (System.ComponentModel.DesignerProperties.GetIsInDesignMode(this))
            {
                return;
            }
            
            string imagesPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\Images");
            imagesPath = System.IO.Path.GetFullPath(imagesPath);
            
            if (!Directory.Exists(imagesPath))
            {
                // Fallback to looking in the project root Images folder
                imagesPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\Images");
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

            ProductImage.Source = new BitmapImage(new Uri(randomFile.FullName, UriKind.RelativeOrAbsolute));

            AppNameText.Text = (new CultureInfo("en-US", false).TextInfo)
                .ToTitleCase(randomFile.FullName.Split('\\').Last()
                .Split('-').Last().Split('.').First());

            AppName = AppNameText.Text;
            AppImageSource = ProductImage.Source;

        }

        public AnApp(string inAppName, ImageSource inImageSource)
        {
            InitializeComponent();
            ProductImage.Source = inImageSource;
            AppNameText.Text = inAppName;
            AppName = inAppName;
            AppImageSource = inImageSource;
        }

        private void ProductImage_MouseUp(object sender, MouseButtonEventArgs e)
        {
            AppClicked(this, e);
        }

        private void BottomGrid_GiveFeedback(object sender, GiveFeedbackEventArgs e)
        {

        }

        private void BottomGrid_MouseUp(object sender, MouseButtonEventArgs e)
        {

        }

        private void AppNameText_GotFocus(object sender, RoutedEventArgs e)
        {

        }
    }
}
