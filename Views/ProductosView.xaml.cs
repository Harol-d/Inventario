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
        public CategoriaController categoria = new CategoriaController();
        public ProductosView()
        {
            InitializeComponent();
            cbCategorias.ItemsSource = categoria.GetCategorias();
        }

        private void AgregarProducto(object sender, RoutedEventArgs e)
        {
            Boolean result = controller.AgregarProducto(txtNombre.Text, int.Parse(txtCantidad.Text), float.Parse(txtPrecio.Text), (int)cbCategorias.SelectedValue);
            if (result)
            {
                MessageBox.Show("Producto agregado exitosamente");
                this.Close();
            }
            else
            {
                MessageBox.Show("Error al agregar producto");
            }
        }
    }
}
