using System.Windows;
//using System.Windows.Media.Media3D;
using Inventario.Controller;
using Inventario.Model;

namespace Inventario.Views
{
    /// <summary>
    /// Lógica de interacción para ProductosView.xaml
    /// </summary>
    public partial class ProductosView : Window
    {
        public ProductoController controller = new ProductoController();
        public ProductosView()
        {
            InitializeComponent();
        }
        
    }
}
