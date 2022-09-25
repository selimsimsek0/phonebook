using PhoneBook.Report.Entity;

namespace PhoneBook.Report.Creator.FileCreator.Abstract
{
    public interface IExcelWriter<T>:IFileWriter<T>
        where T : IEntity
    {
    }
}
