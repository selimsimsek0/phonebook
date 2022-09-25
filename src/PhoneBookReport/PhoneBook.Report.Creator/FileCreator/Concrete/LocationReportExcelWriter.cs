using Microsoft.Office.Interop.Excel;
using PhoneBook.Report.Business.Enums;
using PhoneBook.Report.Creator.Common;
using PhoneBook.Report.Creator.FileCreator.Abstract;
using PhoneBook.Report.Entity.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace PhoneBook.Report.Creator.FileCreator.Concrete
{
    public class LocationReportExcelWriter : IExcelWriter<LocationReport>
    {
        public bool CreateFile(LocationReport entity, out string filePath, out string fileName)
        {
            entity.ReportRequest.DocumentType = (int)Enums.DocumentType.Excel;

            filePath = FileWritePath.GetFullPath(FileWritePath.Path, FileWritePath.MainFolder, FileWritePath.LocationReportFolder);
            CreateFolders(filePath);
            string dateNow = DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss");
            dateNow = dateNow.Replace("-", "");
            fileName = $"LocationReport{dateNow}.xlsx";
            string fullPath = Path.Combine(filePath, fileName);


            Application excelApp = new Application();
            excelApp.Visible = false;

            object missing = Type.Missing;

            Workbook excelBook = excelApp.Workbooks.Add(missing);
            Worksheet worksheet = (Worksheet)excelBook.ActiveSheet;

            #region Headers
            worksheet.Cells[1, 1] = "Location";
            worksheet.Cells[1, 2] = "PersonCount";
            worksheet.Cells[1, 3] = "PhoneNumberCount";
            #endregion

            int row = 2;
            int column = 1;
            List<LocationReportDetail> reportDetails = entity.ReportDetails.ToList();
            for (int i = 0; i < reportDetails.Count; i++)
            {
                LocationReportDetail detail = reportDetails[i];
                worksheet.Cells[row, column] = detail.Location;
                ++column;
                worksheet.Cells[row, column] = detail.PersonCount;
                ++column;
                worksheet.Cells[row, column] = detail.PhoneNumberCount;

                ++row;
                column = 1;
            }

            object False = false;
            XlFileFormat format = XlFileFormat.xlWorkbookDefault;
            worksheet.SaveAs(fullPath, format, missing, missing, missing, False, XlSaveAsAccessMode.xlNoChange, missing, False, missing);

            return true;
        }

        private void CreateFolders(string fullPath)
        {
            if (Directory.Exists(fullPath) == false)
                Directory.CreateDirectory(fullPath);
        }
    }
}
