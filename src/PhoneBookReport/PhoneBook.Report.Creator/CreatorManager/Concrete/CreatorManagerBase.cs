using PhoneBook.Report.Creator.CreatorManager.Abstract;
using PhoneBook.Report.Creator.FileCreator.Abstract;
using PhoneBook.Report.Creator.ReportCreator.Abstract;
using PhoneBook.Report.Data.UnitOfWork.Abstract;
using PhoneBook.Report.Entity;
using System.Threading.Tasks;

namespace PhoneBook.Report.Creator.CreatorManager.Concrete
{
    public abstract class CreatorManagerBase<T> : ICreatorManager<T>
         where T : IEntity
    {
        protected IPhoneBookReportUOW _phoneBookReportUOW;
        protected IFileWriter<T> _fileWriter;
        protected IReportCreator<T> _reportCreator;

        public CreatorManagerBase(IPhoneBookReportUOW phoneBookReportUOW, IFileWriter<T> fileWriter, IReportCreator<T> reportCreator)
        {
            _phoneBookReportUOW = phoneBookReportUOW;
            _fileWriter = fileWriter;
            _reportCreator = reportCreator;
        }

        public abstract Task<bool> CreateReportAsync(T entity);
    }
}
