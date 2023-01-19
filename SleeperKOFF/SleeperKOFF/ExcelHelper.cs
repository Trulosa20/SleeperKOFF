using PlayerSheet.SleeperModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;

namespace PlayerSheet
{
    public class ExcelHelper
    {
        //point of this class is to take the extracted json data from sleeper and manipulate it/write it to excel fle
        private static System.Data.DataTable? _dataTable;
        private Application _excelApplication = new();
        private Workbook _workbook = new();
        private Worksheet _worksheet = new();

       public void ImportPlayerData(UserInfo team)
        {
            //setting up excel workbook/sheet info
            _excelApplication.Visible = false;
            _excelApplication.DisplayAlerts = false;
            
            string filepath = @"\\sfbappdev\appdev\Trulock,Seth\Personal Stuff\Kyle_FantasyFootball\The League Contract Info.xlsx";
            if (File.Exists(filepath))
            {
                _workbook = _excelApplication.Workbooks.Open(filepath);
                _worksheet = (Worksheet)_workbook.Worksheets.Item[42];
            }
        }
    }
}
