namespace PhoneBook.Report.Data.UnitOfWork.Abstract
{
    public interface IUnitOfWork
    {
        void NewTranaction();
        void Commit();
        void RollBack();
    }
}
