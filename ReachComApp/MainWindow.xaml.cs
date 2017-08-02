using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media.Imaging;
using ReachComData;
using System;

namespace ReachComApp
{
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
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
                TabControlMain.SelectedIndex++;
        }

        private void ButoonErrorConfirm_Click(object sender, RoutedEventArgs e)
        {
            if (TabControlMain.SelectedIndex == TabControlMain.Items.Count - 1)
                TabControlMain.SelectedIndex = 0;
            else
                TabControlMain.SelectedIndex++;
        }

        private void ButoonCurrentActionConfirm_Click(object sender, RoutedEventArgs e)
        {
            if (TabControlMain.SelectedIndex == TabControlMain.Items.Count - 1)
                TabControlMain.SelectedIndex = 0;
            else
                TabControlMain.SelectedIndex++;
        }

        private void ButoonCurrentImpactsConfirm_Click(object sender, RoutedEventArgs e)
        {
            if (TabControlMain.SelectedIndex == TabControlMain.Items.Count - 1)
                TabControlMain.SelectedIndex = 0;
            else
                TabControlMain.SelectedIndex++;
        }

        private void ButtonIntro_Click(object sender, RoutedEventArgs e)
        {
            if (TabControlMain.SelectedIndex == TabControlMain.Items.Count - 1)
                TabControlMain.SelectedIndex = 0;
            else
                TabControlMain.SelectedIndex++;
        }

        private void ButonReset_Click(object sender, RoutedEventArgs e)
        {
            TabControlMain.SelectedIndex = 1;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Stream stream = File.Open(".\\ExcelData\\REACH.xlsx", FileMode.Open);

            var data = new DataLayer();

            var sealAppViewSource = (CollectionViewSource)FindResource("sealAppViewSource");
            // Load data by setting the CollectionViewSource.Source property:
            sealAppViewSource.Source = data.GetSealApplications(stream);
            System.Windows.Data.CollectionViewSource errorLookupViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("errorLookupViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            errorLookupViewSource.Source = data.GetErrorLookups(stream);

            System.Windows.Data.CollectionViewSource currentActionViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("currentActionViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            currentActionViewSource.Source = data.GetCurrentActions(stream);

            Hideimpactquestions();
        }

        private void errorLookupDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Hideimpactquestions()
        {
            if (CheckBoxCustomerCalls.IsChecked != null && !(bool)CheckBoxCustomerCalls.IsChecked) {
            LabelCustomerCall.Visibility = Visibility.Hidden;
            TextBoxCustomerCall.Visibility = Visibility.Hidden;
            }
            else
            {
                LabelCustomerCall.Visibility = Visibility.Visible;
                TextBoxCustomerCall.Visibility = Visibility.Visible;
            }


            if (CheckBoxReports.IsChecked != null && !(bool)CheckBoxReports.IsChecked) { 
            LabelReports.Visibility = Visibility.Hidden;
            TextBoxReports.Visibility = Visibility.Hidden;
            }
            else
            {
                LabelReports.Visibility = Visibility.Visible;
                TextBoxReports.Visibility = Visibility.Visible;
            }

            if(CheckBoxTransactions.IsChecked != null && !(bool)CheckBoxTransactions.IsChecked) { 
            LabelTransactions.Visibility = Visibility.Hidden;
            TextBoxTransactions.Visibility = Visibility.Hidden;
            }
            else
            {
                LabelTransactions.Visibility = Visibility.Visible;
                TextBoxTransactions.Visibility = Visibility.Visible;
            }


            if (CheckBoxSla.IsChecked != null && !(bool)CheckBoxSla.IsChecked)
            {
                LabelSla.Visibility = Visibility.Hidden;
                TextBoxSla.Visibility = Visibility.Hidden;
            }else
            {
                LabelSla.Visibility = Visibility.Visible;
                TextBoxSla.Visibility = Visibility.Visible;
            }

            if (CheckBoxFinancial.IsChecked != null && !(bool)CheckBoxFinancial.IsChecked)
            {
                LabelFinancials.Visibility = Visibility.Hidden;
                TextBoxFinancials.Visibility = Visibility.Hidden;
            }else
            {
                LabelFinancials.Visibility = Visibility.Visible;
                TextBoxFinancials.Visibility = Visibility.Visible;
            }



        }

        private void TextBoxCustomerCall_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void CheckBoxCustomerCalls_Checked(object sender, RoutedEventArgs e)
        {
            Hideimpactquestions();


        }

        private void CheckBoxCustomerCalls_Unchecked(object sender, RoutedEventArgs e)
        {
            Hideimpactquestions();
        }

        private void CheckBoxReports_Unchecked(object sender, RoutedEventArgs e)
        {
            Hideimpactquestions();
        }

        private void CheckBoxReports_Checked(object sender, RoutedEventArgs e)
        {
            Hideimpactquestions();
        }

        private void CheckBoxTransactions_Checked(object sender, RoutedEventArgs e)
        {
            Hideimpactquestions();
        }

        private void CheckBoxTransactions_Unchecked(object sender, RoutedEventArgs e)
        {
            Hideimpactquestions();
        }

        private void CheckBoxFinancial_Unchecked(object sender, RoutedEventArgs e)
        {
            Hideimpactquestions();
        }

        private void CheckBoxFinancial_Checked(object sender, RoutedEventArgs e)
        {
            Hideimpactquestions();
        }

        private void CheckBoxSla_Checked(object sender, RoutedEventArgs e)
        {
            Hideimpactquestions();
        }

        private void CheckBoxSla_Unchecked(object sender, RoutedEventArgs e)
        {
            Hideimpactquestions();
        }
    }
}