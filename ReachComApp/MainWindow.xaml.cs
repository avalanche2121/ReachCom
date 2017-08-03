using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using ReachComData;

namespace ReachComApp
{
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly ComReach _comReach;

        public MainWindow()
        {
            InitializeComponent();

            _comReach = new ComReach();
        }

        private void ButonReset_Click(object sender, RoutedEventArgs e)
        {
            TabControlMain.SelectedIndex = 1;
        }

        private void ButoonCurrentActionConfirm_Click(object sender, RoutedEventArgs e)
        {
            foreach (var rowSelectedItem in currentActionDataGrid.SelectedItems)
            {
                var actionCurrent = rowSelectedItem as CurrentAction;

                if (actionCurrent != null)
                {
                    _comReach.ErrorTitle = actionCurrent.Action;
                    _comReach.ErrorDescription = actionCurrent.DescriptionAction;
                }
            }

            //Handle move to the next Tab
            if (TabControlMain.SelectedIndex == TabControlMain.Items.Count - 1)
                TabControlMain.SelectedIndex = 0;
            else
                TabControlMain.SelectedIndex++;
        }


        private void RechComReport()
        {
            //Clear Contents
            RichTextBoxReachPosting.Document.Blocks.Clear();


            //Build Time Entry
            Paragraph textStartTime = new Paragraph();
            textStartTime.Inlines.Add(new Run("Issue Start Time is "));
            textStartTime.Inlines.Add(new Run(_comReach.StartTime));
            textStartTime.FontSize = 14;
            FontWeight fontWeight;
            fontWeight = FontWeights.Bold;
            textStartTime.FontWeight = fontWeight;

            //Application Information
            Paragraph application = new Paragraph();
            application.Inlines.Add(new Run("Application: "));
            application.Inlines.Add(new Run(_comReach.AppTitle));
            application.Inlines.Add(new Run("  "));
            application.Inlines.Add(new Run("Seal Id: "));
            application.Inlines.Add(new Run(_comReach.SealId.ToString()));

            //Current Issue
            var textIssues = new Paragraph();
            textIssues.Inlines.Add(new Bold(new Run("Current Issues")));


            RichTextBoxReachPosting.Focus();
            RichTextBoxReachPosting.ScrollToEnd();
        }

        private void ButoonCurrentImpactsConfirm_Click(object sender, RoutedEventArgs e)
        {
            PopulateReportData();


            //Build Reach Output
            RechComReport();


            if (TabControlMain.SelectedIndex == TabControlMain.Items.Count - 1)
                TabControlMain.SelectedIndex = 0;
            else
                TabControlMain.SelectedIndex++;
        }

        private void PopulateReportData()
        {
            if (CheckBoxCustomerCalls.IsChecked != null && (bool) CheckBoxCustomerCalls.IsChecked)
                _comReach.CustomerCall = TextBoxCustomerCall.Text;
            else
                _comReach.CustomerCall = "";

            if (CheckBoxTransactions.IsChecked != null && (bool) CheckBoxTransactions.IsChecked)
                _comReach.TransactionCount = TextBoxTransactions.Text;
            else
                _comReach.TransactionCount = "";

            if (CheckBoxReports.IsChecked != null && (bool) CheckBoxReports.IsChecked)
                _comReach.ReportCount = TextBoxReports.Text;
            else
                _comReach.ReportCount = TextBoxReports.Text;

            if (CheckBoxFinancial.IsChecked != null && (bool) CheckBoxFinancial.IsChecked)
                _comReach.FinancialAmount = TextBoxFinancials.Text;
            else
                _comReach.FinancialAmount = "";

            if (CheckBoxSla.IsChecked != null && (bool) CheckBoxSla.IsChecked)
                _comReach.SlaInfo = TextBoxSla.Text;
            else
                _comReach.SlaInfo = "";

            _comReach.StartTime = TextBoxStartTime.Text;
        }

        private void ButoonErrorConfirm_Click(object sender, RoutedEventArgs e)
        {
            foreach (var rowSelectedItem in errorLookupDataGrid.SelectedItems)
            {
                var errorLookup = rowSelectedItem as ErrorLookup;
                if (errorLookup != null)
                {
                    _comReach.ErrorTitle = errorLookup.Title;
                    _comReach.ErrorDescription = errorLookup.DescriptionError;
                }
            }

            if (TabControlMain.SelectedIndex == TabControlMain.Items.Count - 1)
                TabControlMain.SelectedIndex = 0;
            else
                TabControlMain.SelectedIndex++;
        }

        private void ButoonSealAppConfirm_Click(object sender, RoutedEventArgs e)
        {
            foreach (var rowSelectedItem in sealAppDataGrid.SelectedItems)
            {
                var sealApp = rowSelectedItem as SealApp;

                _comReach.SealId = sealApp.SealId;
                _comReach.AppTitle = sealApp.Title;
                _comReach.AppDescription = sealApp.DescriptionApp;
            }

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

        private void CheckBoxCustomerCalls_Checked(object sender, RoutedEventArgs e)
        {
            Hideimpactquestions();
        }

        private void CheckBoxCustomerCalls_Unchecked(object sender, RoutedEventArgs e)
        {
            Hideimpactquestions();
        }

        private void CheckBoxFinancial_Checked(object sender, RoutedEventArgs e)
        {
            Hideimpactquestions();
        }

        private void CheckBoxFinancial_Unchecked(object sender, RoutedEventArgs e)
        {
            Hideimpactquestions();
        }

        private void CheckBoxReports_Checked(object sender, RoutedEventArgs e)
        {
            Hideimpactquestions();
        }

        private void CheckBoxReports_Unchecked(object sender, RoutedEventArgs e)
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

        private void CheckBoxTransactions_Checked(object sender, RoutedEventArgs e)
        {
            Hideimpactquestions();
        }

        private void CheckBoxTransactions_Unchecked(object sender, RoutedEventArgs e)
        {
            Hideimpactquestions();
        }

        private void errorLookupDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }

        private void GenerateReachComs()
        {
        }

        private void Hideimpactquestions()
        {
            if (CheckBoxCustomerCalls.IsChecked != null && !(bool) CheckBoxCustomerCalls.IsChecked)
            {
                LabelCustomerCall.Visibility = Visibility.Hidden;
                TextBoxCustomerCall.Visibility = Visibility.Hidden;
            }
            else
            {
                LabelCustomerCall.Visibility = Visibility.Visible;
                TextBoxCustomerCall.Visibility = Visibility.Visible;
            }


            if (CheckBoxReports.IsChecked != null && !(bool) CheckBoxReports.IsChecked)
            {
                LabelReports.Visibility = Visibility.Hidden;
                TextBoxReports.Visibility = Visibility.Hidden;
            }
            else
            {
                LabelReports.Visibility = Visibility.Visible;
                TextBoxReports.Visibility = Visibility.Visible;
            }

            if (CheckBoxTransactions.IsChecked != null && !(bool) CheckBoxTransactions.IsChecked)
            {
                LabelTransactions.Visibility = Visibility.Hidden;
                TextBoxTransactions.Visibility = Visibility.Hidden;
            }
            else
            {
                LabelTransactions.Visibility = Visibility.Visible;
                TextBoxTransactions.Visibility = Visibility.Visible;
            }


            if (CheckBoxSla.IsChecked != null && !(bool) CheckBoxSla.IsChecked)
            {
                LabelSla.Visibility = Visibility.Hidden;
                TextBoxSla.Visibility = Visibility.Hidden;
            }
            else
            {
                LabelSla.Visibility = Visibility.Visible;
                TextBoxSla.Visibility = Visibility.Visible;
            }

            if (CheckBoxFinancial.IsChecked != null && !(bool) CheckBoxFinancial.IsChecked)
            {
                LabelFinancials.Visibility = Visibility.Hidden;
                TextBoxFinancials.Visibility = Visibility.Hidden;
            }
            else
            {
                LabelFinancials.Visibility = Visibility.Visible;
                TextBoxFinancials.Visibility = Visibility.Visible;
            }
        }

        private void TabControlMain_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }

        private void TextBoxCustomerCall_TextChanged(object sender, TextChangedEventArgs e)
        {
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Stream stream = File.Open(".\\ExcelData\\REACH.xlsx", FileMode.Open);

            var data = new DataLayer();

            var sealAppViewSource = (CollectionViewSource) FindResource("sealAppViewSource");
            // Load data by setting the CollectionViewSource.Source property:
            sealAppViewSource.Source = data.GetSealApplications(stream);
            var errorLookupViewSource = (CollectionViewSource) FindResource("errorLookupViewSource");
            // Load data by setting the CollectionViewSource.Source property:
            errorLookupViewSource.Source = data.GetErrorLookups(stream);

            var currentActionViewSource = (CollectionViewSource) FindResource("currentActionViewSource");
            // Load data by setting the CollectionViewSource.Source property:
            currentActionViewSource.Source = data.GetCurrentActions(stream);

            Hideimpactquestions();
        }

        private void CheckBoxSla_Unchecked_1(object sender, RoutedEventArgs e)
        {
            Hideimpactquestions();
        }
    }
}