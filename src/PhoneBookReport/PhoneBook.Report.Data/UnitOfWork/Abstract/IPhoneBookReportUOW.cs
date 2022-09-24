using PhoneBook.Report.Data.Repository.Abstract;

namespace PhoneBook.Report.Data.UnitOfWork.Abstract
{
    public interface IPhoneBookReportUOW : IUnitOfWork
    {
        ILocationReportDal LocationReportDal { get; }
        ILocationReportRequestDal LocationReportRequestDal { get; }
    }
}
