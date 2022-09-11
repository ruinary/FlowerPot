using FlowerPot.Views.Pages;
using System;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace FlowerPot.Views.UC
{
    public partial class ImagesProduct : UserControl
    {
        public ImagesProduct()
        {
            InitializeComponent();
           
            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri(Catalog.infoFlower.ImageAdress, UriKind.Relative);
            bitmap.CacheOption = BitmapCacheOption.OnLoad;
            bitmap.EndInit();
            ImagesProd.Source = bitmap;

        }
    }
}
