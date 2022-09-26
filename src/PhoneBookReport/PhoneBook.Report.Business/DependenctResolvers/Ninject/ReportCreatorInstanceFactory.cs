using Ninject;
using PhoneBook.Report.Creator.CreatorManager.Abstract;
using PhoneBook.Report.Creator.CreatorManager.Concrete;
using PhoneBook.Report.Creator.FileCreator.Concrete;
using PhoneBook.Report.Creator.ReportCreator.Concrete;
using PhoneBook.Report.Data.UnitOfWork.Abstract;

namespace PhoneBook.Report.Business.DependenctResolvers.Ninject
{
    public class ReportCreatorInstanceFactory
    {
        private static IKernel _kernel;
        public static T GetInstance<T>()
        {
            if (_kernel == null) BindKernel();

            return _kernel.Get<T>();
        }

        private static void BindKernel()
        {
            _kernel = new StandardKernel();

            _kernel.Bind<ILocationReportCreatorManager>().ToConstructor(p => new LocationReportCreatorManager
            (
                NinjectInstanceFactory.GetInstance<IPhoneBookReportUOW>(),
                new LocationReportExcelWriter(),
                new LocationReportCreater()
            ));

        }
    }
}
