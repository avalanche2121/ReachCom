using ReachComData;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;

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
            //Clear Contents
            resetinputs();

            TabControlMain.SelectedIndex = 1;
        }

        private void ButoonCurrentActionConfirm_Click(object sender, RoutedEventArgs e)
        {
            foreach (var rowSelectedItem in currentActionDataGrid.SelectedItems)
            {
                CurrentAction actionCurrent = rowSelectedItem as CurrentAction;

                if (actionCurrent != null)
                {
                    _comReach.ActionTitle = actionCurrent.Action;
                    _comReach.ActionDescription = actionCurrent.DescriptionAction;
                }
            }

            //Handle move to the next Tab
            if (TabControlMain.SelectedIndex == TabControlMain.Items.Count - 1)
                TabControlMain.SelectedIndex = 0;
            else
                TabControlMain.SelectedIndex++;
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

        private void CheckBoxSla_Unchecked_1(object sender, RoutedEventArgs e)
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
            if (CheckBoxCustomerCalls.IsChecked != null && !(bool)CheckBoxCustomerCalls.IsChecked)
            {
                LabelCustomerCall.Visibility = Visibility.Hidden;
                TextBoxCustomerCall.Visibility = Visibility.Hidden;
            }
            else
            {
                LabelCustomerCall.Visibility = Visibility.Visible;
                TextBoxCustomerCall.Visibility = Visibility.Visible;
            }


            if (CheckBoxReports.IsChecked != null && !(bool)CheckBoxReports.IsChecked)
            {
                LabelReports.Visibility = Visibility.Hidden;
                TextBoxReports.Visibility = Visibility.Hidden;
            }
            else
            {
                LabelReports.Visibility = Visibility.Visible;
                TextBoxReports.Visibility = Visibility.Visible;
            }

            if (CheckBoxTransactions.IsChecked != null && !(bool)CheckBoxTransactions.IsChecked)
            {
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
            }
            else
            {
                LabelSla.Visibility = Visibility.Visible;
                TextBoxSla.Visibility = Visibility.Visible;
            }

            if (CheckBoxFinancial.IsChecked != null && !(bool)CheckBoxFinancial.IsChecked)
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

        private void PopulateReportData()
        {
            if (CheckBoxCustomerCalls.IsChecked != null && (bool)CheckBoxCustomerCalls.IsChecked)
                _comReach.CustomerCall = TextBoxCustomerCall.Text;
            else
                _comReach.CustomerCall = string.Empty;

            if (CheckBoxTransactions.IsChecked != null && (bool)CheckBoxTransactions.IsChecked)
                _comReach.TransactionCount = TextBoxTransactions.Text;
            else
                _comReach.TransactionCount = string.Empty;

            if (CheckBoxReports.IsChecked != null && (bool)CheckBoxReports.IsChecked)
                _comReach.ReportCount = TextBoxReports.Text;
            else
                _comReach.ReportCount = string.Empty;

            if (CheckBoxFinancial.IsChecked != null && (bool)CheckBoxFinancial.IsChecked)
                _comReach.FinancialAmount = TextBoxFinancials.Text;
            else
                _comReach.FinancialAmount = string.Empty;

            if (CheckBoxSla.IsChecked != null && (bool)CheckBoxSla.IsChecked)
                _comReach.SlaInfo = TextBoxSla.Text;
            else
                _comReach.SlaInfo = string.Empty;

            _comReach.StartTime = TextBoxStartTime.Text;
        }


        private void RechComReport()
        {
            //Clear Contents
            RichTextBoxReachPosting.Document.Blocks.Clear();


            //Build Time Entry
            Paragraph textStartTime = new Paragraph();
            textStartTime.Inlines.Add(new Run("Issue Start Time is "));
            textStartTime.Inlines.Add(new Run(_comReach.StartTime));


            //Application Information
            Paragraph textAppParagraph = new Paragraph();
            textAppParagraph.Inlines.Add(new Run("Application: "));
            textAppParagraph.Inlines.Add(new Run(_comReach.AppTitle));
            textAppParagraph.Inlines.Add(new Run("  "));
            textAppParagraph.Inlines.Add(new Run("Seal Id: "));
            textAppParagraph.Inlines.Add(new Run(_comReach.SealId.ToString()));

            //Current Issue
            Paragraph textIssuesTitleParagraph = new Paragraph();
            textIssuesTitleParagraph.Inlines.Add(new Bold(new Run("Current Issues")));

            //Error Condition
            Paragraph textErrorParagraph = new Paragraph();
            textErrorParagraph.Inlines.Add(new Run("Error - "));
            textErrorParagraph.Inlines.Add(new Run(_comReach.ErrorDescription));


            //Issue Details
            Paragraph textIssueParagraph = new Paragraph();

            //How many Calls?
            if (CheckBoxCustomerCalls.IsChecked != null && (bool)CheckBoxCustomerCalls.IsChecked)
            {
                textIssueParagraph.Inlines.Add(new Run("Calls Received - "));
                textIssueParagraph.Inlines.Add(new Run(_comReach.CustomerCall));
                textIssueParagraph.Inlines.Add(new Run("\r"));
            }


            //How many Transactions impacted?
            if (CheckBoxTransactions.IsChecked != null && (bool)CheckBoxTransactions.IsChecked)
            {
                textIssueParagraph.Inlines.Add(new Run("Transactions Affected - "));
                textIssueParagraph.Inlines.Add(new Run(_comReach.TransactionCount));
                textIssueParagraph.Inlines.Add(new Run("\r"));

            }

            //How many Reports impacted?
            if (CheckBoxReports.IsChecked != null && (bool)CheckBoxReports.IsChecked)
            {
                textIssueParagraph.Inlines.Add(new Run(("Transactions Affected - ")));
                textIssueParagraph.Inlines.Add(new Run((_comReach.ReportCount)));
                textIssueParagraph.Inlines.Add(new Run("\r"));

            }

            //What is the Financial Impacts in Dollars?
            if (CheckBoxFinancial.IsChecked != null && (bool)CheckBoxFinancial.IsChecked)
            {
                textIssueParagraph.Inlines.Add(new Run("Financial Impacts - "));
                textIssueParagraph.Inlines.Add(new Run(_comReach.FinancialAmount));
                textIssueParagraph.Inlines.Add(new Run("\r"));

            }

            //Have SLA's Been Impacted?
            if (TextBoxSla.Text.Length > 0)
            {
                textIssueParagraph.Inlines.Add(new Run(("SLA Impacts - ")));
                textIssueParagraph.Inlines.Add(new Run((_comReach.SlaInfo)));
                textIssueParagraph.Inlines.Add(new Run("\r"));

            }

            //Remediation
            Paragraph textRemediationParagraph = new Paragraph();
            textRemediationParagraph.Inlines.Add(new Run("Current Remediation - "));
            textRemediationParagraph.Inlines.Add(new Run(_comReach.ActionDescription));

            //Application Details
            Paragraph textApplicationParagraph = new Paragraph();
            textApplicationParagraph.Inlines.Add(new Bold(new Run("Application \r")));
            textApplicationParagraph.Inlines.Add(new Run(_comReach.AppDescription));

            //Putting All together
            RichTextBoxReachPosting.Document.Blocks.Add(textStartTime);
            RichTextBoxReachPosting.Document.Blocks.Add(textAppParagraph);
            RichTextBoxReachPosting.Document.Blocks.Add(textIssuesTitleParagraph);
            RichTextBoxReachPosting.Document.Blocks.Add(textErrorParagraph);
            RichTextBoxReachPosting.Document.Blocks.Add(textIssueParagraph);
            RichTextBoxReachPosting.Document.Blocks.Add(textRemediationParagraph);
            RichTextBoxReachPosting.Document.Blocks.Add(textApplicationParagraph);

            RichTextBoxReachPosting.Focus();
            RichTextBoxReachPosting.ScrollToHome();
        }

        private void resetinputs()
        {
            //Reset Checkboxes to unchecked
            CheckBoxTransactions.IsChecked = false;
            CheckBoxCustomerCalls.IsChecked = false;
            CheckBoxFinancial.IsChecked = false;
            CheckBoxReports.IsChecked = false;
            CheckBoxSla.IsChecked = false;

            //Reset Textbox inputs
            TextBoxTransactions.Text = "0";
            TextBoxCustomerCall.Text = "0";
            TextBoxFinancials.Text = "$0.00";
            TextBoxReports.Text = "0";
            TextBoxSla.Text = "0";

            TextBoxStartTime.Text = "00:00 AM/PM ET";

            sealAppDataGrid.SelectedIndex = 0;
            errorLookupDataGrid.SelectedIndex = 0;
            currentActionDataGrid.SelectedIndex = 0;

            RichTextBoxReachPosting.Document.Blocks.Clear();

        }

        private void RichTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

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

            var sealAppViewSource = (CollectionViewSource)FindResource("sealAppViewSource");
            // Load data by setting the CollectionViewSource.Source property:
            sealAppViewSource.Source = data.GetSealApplications(stream);
            var errorLookupViewSource = (CollectionViewSource)FindResource("errorLookupViewSource");
            // Load data by setting the CollectionViewSource.Source property:
            errorLookupViewSource.Source = data.GetErrorLookups(stream);

            var currentActionViewSource = (CollectionViewSource)FindResource("currentActionViewSource");
            // Load data by setting the CollectionViewSource.Source property:
            currentActionViewSource.Source = data.GetCurrentActions(stream);

            Hideimpactquestions();
        }
    }
}