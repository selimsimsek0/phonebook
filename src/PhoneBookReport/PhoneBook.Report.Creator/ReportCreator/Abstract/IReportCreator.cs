using PhoneBook.Report.Entity;
using System.Threading.Tasks;

namespace PhoneBook.Report.Creator.ReportCreator.Abstract
{
    public interface IReportCreator<T>
        where T:IEntity
    {
        Task<bool> CreateReportAsync(T entity);
    }
}
