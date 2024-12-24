using FNVCB.VIEWMODEL;
using FNVCB.VIEWMODEL.Interfaces;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FNVCB.VIEW.Shell
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Shell_View : Window
    {
        public Shell_View(IViewModelFactory vmf)
        {
            InitializeComponent();
            this.DataContext = vmf.GenerateShellVM();
        }

        // Allows the user to drag the window when the mouse is clicked
        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            // Enable window dragging when the mouse is pressed
            if (e.ButtonState == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }

        private void Power_Off(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}