using System;
using ReachComData;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;

namespace ReachComApp
{
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ComReach _comReach;

        public MainWindow()
        {
            InitializeComponent();

            _comReach = new ComReach();
        }

        private void ButonReset_Click(object sender, RoutedEventArgs e)
        {
            //Clear Contents
            Resetinputs();

            TabControlMain.SelectedIndex = 1;
        }

        private void ButoonCurrentActionConfirm_Click(object sender, RoutedEventArgs e)
        {
            CurrentActionSelected();

            PopulateReportData();

            //Handle move to the next Tab
            MoveToNextTab();
        }

        private void CurrentActionSelected()
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
        }

        private void ButoonCurrentImpactsConfirm_Click(object sender, RoutedEventArgs e)
        {
            PopulateReportData();

            //Build Reach Output
            RechComReport();

            //Move to the Next Tab
            MoveToNextTab();
        }

        private void ButoonErrorConfirm_Click(object sender, RoutedEventArgs e)
        {
            ErrorLookupSelected();

            MoveToNextTab(); ;
        }

        private void ErrorLookupSelected()
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
        }

        private void ButoonSealAppConfirm_Click(object sender, RoutedEventArgs e)
        {
            SealAppSelected();

            MoveToNextTab();
        }

        private void MoveToNextTab()
        {
            if (TabControlMain.SelectedIndex == TabControlMain.Items.Count - 1)
                TabControlMain.SelectedIndex = 0;
            else
                TabControlMain.SelectedIndex++;
        }

        private void SealAppSelected()
        {
            foreach (var rowSelectedItem in sealAppDataGrid.SelectedItems)
            {
                SealApp sealApp = rowSelectedItem as SealApp;

                if (sealApp != null)
                {
                    _comReach.SealId = sealApp.SealId;
                    _comReach.AppTitle = sealApp.Title;
                    _comReach.AppDescription = sealApp.DescriptionApp;
                }
            }
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

            if (CheckBoxReputational.IsChecked != null && !(bool)CheckBoxReputational.IsChecked)
            {
                LabelReputational.Visibility = Visibility.Hidden;
                TextBoxReputational.Visibility = Visibility.Hidden;
            }
            else
            {
                LabelReputational.Visibility = Visibility.Visible;
                TextBoxReputational.Visibility = Visibility.Visible;
            }

            if (CheckBoxOtherIssue.IsChecked != null && !(bool) CheckBoxOtherIssue.IsChecked)
            {
                LabelOtherIssue.Visibility = Visibility.Hidden;
                TextBoxOtherIssue.Visibility = Visibility.Hidden;
            }
            else
            {
                LabelOtherIssue.Visibility = Visibility.Visible;
                TextBoxOtherIssue.Visibility = Visibility.Visible;
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

            if (CheckBoxOtherIssue.IsChecked != null && (bool) CheckBoxOtherIssue.IsChecked)
                _comReach.OtherIssue = TextBoxOtherIssue.Text;
            else
                _comReach.OtherIssue = string.Empty; 
        

            if (CheckBoxReputational.IsChecked != null && (bool) CheckBoxReputational.IsChecked)
            {
                _comReach.ReputationalImpact = TextBoxReputational.Text;
            }
            else
            {
                _comReach.ReputationalImpact = string.Empty;
            }


            try
            {
                _comReach.StartTime = TextBoxStartTime.Text;
            }
            catch (Exception e)
            {
                //Console.WriteLine(e);
                //throw;
            }
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


            //What is the Reputation Impacts in Dollars?
            if (CheckBoxReputational.IsChecked != null && (bool)CheckBoxReputational.IsChecked)
            {
                textIssueParagraph.Inlines.Add(new Run("Reputation Impacts - "));
                textIssueParagraph.Inlines.Add(new Run(_comReach.ReputationalImpact));
                textIssueParagraph.Inlines.Add(new Run("\r"));

            }


            //Have SLA's Been Impacted?
            if (CheckBoxSla.IsChecked != null && (bool)CheckBoxSla.IsChecked)
            {
                textIssueParagraph.Inlines.Add(new Run(("SLA Impacts - ")));
                textIssueParagraph.Inlines.Add(new Run((_comReach.SlaInfo)));
                textIssueParagraph.Inlines.Add(new Run("\r"));

            }

            if (CheckBoxOtherIssue.IsChecked != null && (bool) CheckBoxOtherIssue.IsChecked)
            {
                if (textIssueParagraph.Inlines.Count > 0)
                {
                    textIssueParagraph.Inlines.Add(new Run(("Other Impacts - ")));
                }
                else
                {
                    textIssueParagraph.Inlines.Add(new Run(("Impacts - ")));
                }

                textIssueParagraph.Inlines.Add(new Run((_comReach.OtherIssue)));
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

        private void Resetinputs()
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
            TabItem tabItem = TabControlMain.SelectedItem as TabItem;

            //If the Report Output tab is active then make sure the data is current
            if (tabItem != null && tabItem.Name == "TabItemReachPosting")
            {
                PopulateReportData();
                RechComReport();
            }
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

        private void CheckBoxReputational_Checked(object sender, RoutedEventArgs e)
        {
            Hideimpactquestions();
        }

        private void CheckBoxReputational_Unchecked(object sender, RoutedEventArgs e)
        {
            Hideimpactquestions();
        }

        private void sealAppDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ButtonReachComLaunch_Click(object sender, RoutedEventArgs e)
        {
            OpenUri(Properties.Settings.Default.REACHCOM.ToString());
        }


        public static bool IsValidUri(string uri)
        {
            if (!Uri.IsWellFormedUriString(uri, UriKind.Absolute))
                return false;
            Uri tmp;
            if (!Uri.TryCreate(uri, UriKind.Absolute, out tmp))
                return false;
            return tmp.Scheme == Uri.UriSchemeHttp || tmp.Scheme == Uri.UriSchemeHttps;
        }

        public static bool OpenUri(string uri)
        {
            if (!IsValidUri(uri))
                return false;
            System.Diagnostics.Process.Start(uri);
            return true;
        }

        private void CheckBoxOtherIssue_Checked(object sender, RoutedEventArgs e)
        {
            Hideimpactquestions();
        }

        private void CheckBoxOtherIssue_Unchecked(object sender, RoutedEventArgs e)
        {
            Hideimpactquestions();
        }

        private void ButtonCopyToClipBoard_Click(object sender, RoutedEventArgs e)
        {
            RichTextBoxReachPosting.SelectAll();
            RichTextBoxReachPosting.Copy();

        }
    }
}