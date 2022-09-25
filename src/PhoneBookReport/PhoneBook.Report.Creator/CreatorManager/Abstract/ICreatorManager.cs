using PhoneBook.Report.Entity;
using System.Threading.Tasks;

namespace PhoneBook.Report.Creator.CreatorManager.Abstract
{
    public interface ICreatorManager<T>
        where T:IEntity
    {
        Task<bool> CreateReportAsync(T entity);
    }
}
