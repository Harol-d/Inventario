using System.Windows;
using Inventario.Controller;
//using Inventario.Model;
using Inventario.Views;

namespace Inventario
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ProductoController controller = new ProductoController();
        public MainWindow()
        {
            InitializeComponent();
            this.Loaded += MainWindow_Loaded;
            
        }
        private void MainWindow_Loaded(object sender, RoutedEventArgs e) {
            dgProductos.ItemsSource = controller.GetProductos();
            //cantidadProductos.Content = $"Total de productos: {controller.GetProductos().Count}"; 
        }

        private void AgregarProducto(object sender, RoutedEventArgs e)
        {
            ProductosView view = new ProductosView();
            view.ShowDialog();
        }

        private void TextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {

        }

        private void dgProductos_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ProductosView view = new ProductosView();
            view.ShowDialog();
        }
    }
}