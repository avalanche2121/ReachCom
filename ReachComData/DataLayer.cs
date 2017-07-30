using System;
using System.Collections.Generic;
using System.IO;
using ExcelUtility;

namespace ReachComData
{
    public class DataLayer
    {
        private static ExcelData GetSheet(Stream filePath, string sheetname)
        {
            return (new ReadExcelData().ReadExcelSpecificWorkSheet(filePath, sheetname));
        }
        public List<SealApp> GetSealApplications(Stream filePath, string sheetname = "Application_List")
        {
            if (filePath == null || string.IsNullOrEmpty(sheetname))
            {
                return null;
            }

            ExcelData readExcelSpecificWorkSheet = GetSheet(filePath, sheetname); ;

            List<SealApp> sealApplications = new List<SealApp>();

            foreach (List<string> row in readExcelSpecificWorkSheet.DataRows)
            {
                SealApp sealApp = new SealApp
                {
                    SealId = Convert.ToInt32(row[0]),
                    Title = row[1],
                    DescriptionApp = row[2]
                };


                sealApplications.Add(sealApp);

            }

            return sealApplications;
        }

        public List<ErrorLookup> GetErrorLookups(Stream filePath, string sheetname = "Error_Lookup")
        {
            ExcelData readExcelSpecificWorkSheet = GetSheet(filePath, sheetname);

            List<ErrorLookup> errorLookups = new List<ErrorLookup>();

            foreach (List<string> row in readExcelSpecificWorkSheet.DataRows)
            {
                ErrorLookup errorLookup = new ErrorLookup
                {
                    SealId = Convert.ToInt32(row[0]),
                    Title = row[1],
                    DescriptionError = row[2]
                };

                errorLookups.Add(errorLookup);
            }


            return errorLookups;

        }


        public List<CurrentAction> GetCurrentActions(Stream filePath, string sheetname = "Current_Action")
        {
            ExcelData readExcelSpecificWorkSheet = GetSheet(filePath, sheetname);
            List<CurrentAction> currentActions = new List<CurrentAction>();

            foreach (List<string> row in readExcelSpecificWorkSheet.DataRows)
            {
                CurrentAction currentAction = new CurrentAction
                {
                    SealId = Convert.ToInt32(row[0]),
                    Action = row[1],
                    DescriptionAction = row[2]

                };

                currentActions.Add(currentAction);
            }

            return currentActions;

        }


    }
}
