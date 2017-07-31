using System.Windows;
using System.Windows.Controls;

namespace ReachComApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }



        private void TabControlMain_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ButoonSealAppConfirm_Click(object sender, RoutedEventArgs e)
        {
            if (TabControlMain.SelectedIndex == TabControlMain.Items.Count - 1)
                TabControlMain.SelectedIndex = 0;
            else
            {
                TabControlMain.SelectedIndex++;
            }
        }

        private void ButoonErrorConfirm_Click(object sender, RoutedEventArgs e)
        {
            if (TabControlMain.SelectedIndex == TabControlMain.Items.Count - 1)
                TabControlMain.SelectedIndex = 0;
            else
            {
                TabControlMain.SelectedIndex++;
            }

        }

        private void ButoonCurrentActionConfirm_Click(object sender, RoutedEventArgs e)
        {
            if (TabControlMain.SelectedIndex == TabControlMain.Items.Count - 1)
                TabControlMain.SelectedIndex = 0;
            else
            {
                TabControlMain.SelectedIndex++;
            }

        }

        private void ButoonCurrentImpactsConfirm_Click(object sender, RoutedEventArgs e)
        {
            if (TabControlMain.SelectedIndex == TabControlMain.Items.Count - 1)
                TabControlMain.SelectedIndex = 0;
            else
            {
                TabControlMain.SelectedIndex++;
            }
        }

        private void ButtonIntro_Click(object sender, RoutedEventArgs e)
        {
            if (TabControlMain.SelectedIndex == TabControlMain.Items.Count - 1)
                TabControlMain.SelectedIndex = 0;
            else
            {
                TabControlMain.SelectedIndex++;
            }
        }
    }
}
