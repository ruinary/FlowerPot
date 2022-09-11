using FlowerPot.Views.Pages;
using HelixToolkit.Wpf;
using System.Windows.Controls;
using System.Windows.Media.Media3D;


namespace FlowerPot.Views.UC
{
    public partial class ThreeDimensional : UserControl
    {
        public ThreeDimensional()
        {
            InitializeComponent();

            var model = Catalog.infoFlower.ModelAdress;

            ObjReader CurrentHelixObjReader = new ObjReader();
            Model3DGroup MyModel = CurrentHelixObjReader.Read(model);
            foo.Content = MyModel;
        }
    }
}
