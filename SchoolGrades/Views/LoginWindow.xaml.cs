
namespace SchoolGrades.Views
{
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        // Application ShutDown
        private void Close( object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        // Movable Window
        private void Move_Window(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if(e.LeftButton == System.Windows.Input.MouseButtonState.Pressed )
            {
                this.DragMove();
            }
        }
    }
}
