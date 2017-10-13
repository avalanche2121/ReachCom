using System;
using ReachComData;
using System.IO;
using System.Windows;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace NaturalLanguage
{

    public class ParagraphClass
    {
        private ComReach _comReach;


        public string NatLang()
        {

            InitializeComponent();

            _comReach = new ComReach();
            Paragraph NaturalLanguageParagraph = new Paragraph();

            NaturalLanguageParagraph.Inlines.Add(new Run("At "));
            NaturalLanguageParagraph.Inlines.Add(new Run(_comReach.StartTime));
            NaturalLanguageParagraph.Inlines.Add(new Run(", "));
            NaturalLanguageParagraph.Inlines.Add(new Run(_comReach.AppTitle));
            NaturalLanguageParagraph.Inlines.Add(new Run(_comReach.SealId.ToString()));
            NaturalLanguageParagraph.Inlines.Add(new Run(" ran into an issue with its production environment."));
            NaturalLanguageParagraph.Inlines.Add(new Run(_comReach.ErrorDescription));
            NaturalLanguageParagraph.Inlines.Add(new Run(_comReach.ActionDescription));
            NaturalLanguageParagraph.Inlines.Add(new Run(_comReach.AppDescription));


            //string startTime = "[Start Time]";
            //string sealID = "[SEAL id]";
            //string issue = "[Issue]";
            //string currentAction = "[Current Action]";
            //string currentImpacts = "";

            //if (2 > 3)
            //{
            //    currentImpacts = "There are currently no impacts!";
            //}
            //else
            //{
            //    currentImpacts = "The impacts are listed below";
            //};
            //System.Console.WriteLine("At ");
            //System.Console.WriteLine(startTime);
            //System.Console.WriteLine(", ");
            //System.Console.WriteLine(sealID);
            //System.Console.WriteLine("experienced an issue within the production environment");
            //System.Console.WriteLine(issue);
            //System.Console.WriteLine(currentAction);
            //System.Console.WriteLine(currentImpacts);
            //Console.ReadKey();
        }
    }
}
