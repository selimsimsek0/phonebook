using PhoneBook.Report.Entity;

namespace PhoneBook.Report.Creator.FileCreator.Abstract
{
    public interface IFileWriter<T>
        where T:IEntity
    {
        bool CreateFile(T entity,out string filePath, out string fileName);
    }
}
