using PhoneBook.Report.Common;
using PhoneBook.Report.Common.CustomExceptions;
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
                UpdateRequestStatusToCreating(selectedReport);
                await GenerateReportAsync(selectedReport);
                AddDbReportDetails(selectedReport);
                CreateDocumentFile(selectedReport);

                _phoneBookReportUOW.Commit();
                return true;
            }
            catch
            {
                _phoneBookReportUOW.RollBack();

                selectedReport.ReportRequest.Status = (int)Enums.CreatedStatus.Fail;
                UpdateReportRequest(selectedReport);

                throw;
            }

        }

        public void CreateDocumentFile(LocationReport selectedReport)
        {
            if (_fileWriter.CreateFile(selectedReport, out string filePath, out string fileName))
            {
                selectedReport.ReportRequest.CompletedDate = DateTime.Now;
                selectedReport.ReportRequest.DocumentPath = filePath;
                selectedReport.ReportRequest.DocumentName = fileName;
                selectedReport.ReportRequest.Status = (int)Enums.CreatedStatus.Created;
                UpdateReportRequest(selectedReport);

            }
            else throw new FailDocumentGenerateException("Failed to generate document.");
        }

        public void AddDbReportDetails(LocationReport selectedReport)
        {
            foreach (LocationReportDetail reportDetail in selectedReport.ReportDetails)
            {
                bool addReportDetailResult = AddReportDetail(reportDetail);
                if (addReportDetailResult == false) throw new FailDataInsertException("Report detail could not be added.");
            }
        }

        public async Task GenerateReportAsync(LocationReport selectedReport)
        {
            bool reportCreateResult = await _reportCreator.CreateReportAsync(selectedReport);
            if (reportCreateResult == false) throw new FailReportGenerateException("Report could not be generated.");
        }

        public void UpdateRequestStatusToCreating(LocationReport selectedReport)
        {
            selectedReport.ReportRequest.Status = (int)Enums.CreatedStatus.Creating;
            bool updateRequestResult = UpdateReportRequest(selectedReport);
            if (updateRequestResult == false) throw new FailDataUpdateException("Request could not be updated.");
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
