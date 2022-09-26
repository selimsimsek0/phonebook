using PhoneBook.Report.Common;
using PhoneBook.Report.Creator.CreatorManager.Abstract;
using PhoneBook.Report.Creator.FileCreator.Abstract;
using PhoneBook.Report.Creator.ReportCreator.Abstract;
using PhoneBook.Report.Data.UnitOfWork.Abstract;
using PhoneBook.Report.Entity.Entity;
using System;
using System.Threading.Tasks;

namespace PhoneBook.Report.Creator.CreatorManager.Concrete
{
    public class LocationReportCreatorManager : CreatorManagerBase<LocationReport>, ILocationReportCreatorManager
    {
        public LocationReportCreatorManager(IPhoneBookReportUOW phoneBookReportUOW, IFileWriter<LocationReport> fileWriter, IReportCreator<LocationReport> reportCreator)
            : base(phoneBookReportUOW, fileWriter, reportCreator)
        {

        }
        public override async Task<bool> CreateReportAsync(LocationReport selectedReport)
        {
            _phoneBookReportUOW.NewTranaction();
            try
            {
                selectedReport.ReportRequest.Status = (int)Enums.CreatedStatus.Creating;
                UpdateReportRequest(selectedReport);
                await _reportCreator.CreateReportAsync(selectedReport);

                foreach (LocationReportDetail reportDetail in selectedReport.ReportDetails)
                {
                    AddReportDetail(reportDetail);
                }

                if (_fileWriter.CreateFile(selectedReport, out string filePath, out string fileName))
                {
                    selectedReport.ReportRequest.DocumentPath = filePath;
                    selectedReport.ReportRequest.DocumentName = fileName;
                    selectedReport.ReportRequest.Status = (int)Enums.CreatedStatus.Created;
                    UpdateReportRequest(selectedReport);

                }
                else throw new Exception();

                _phoneBookReportUOW.Commit();
                return true;
            }
            catch
            {
                _phoneBookReportUOW.RollBack();

                selectedReport.ReportRequest.Status = (int)Enums.CreatedStatus.Fail;
                UpdateReportRequest(selectedReport);

                return false;
            }

        }

        private bool UpdateReportRequest(LocationReport selectedReport)
        {
            return _phoneBookReportUOW.LocationReportRequestDal.Update(selectedReport.ReportRequest);
        }
        private bool AddReportDetail(LocationReportDetail reportDetail)
        {
            return _phoneBookReportUOW.LocationReportDetailDal.Add(reportDetail);
        }
    }
}
