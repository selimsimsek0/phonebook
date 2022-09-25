using Microsoft.EntityFrameworkCore;
using Ninject;
using PhoneBook.Report.Data.Context;
using PhoneBook.Report.Data.Repository.Abstract;
using PhoneBook.Report.Data.Repository.Concrete.EfCore;
using PhoneBook.Report.Data.UnitOfWork.Abstract;
using PhoneBook.Report.Data.UnitOfWork.Concrete;

namespace PhoneBook.Report.Business.DependenctResolvers.Ninject
{
    public class NinjectInstanceFactory
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

            _kernel.Bind<DbContext>().To<PhoneBookReportDbContext>();

            _kernel.Bind<ILocationReportDal>().To<EfLocationReportDal>();
            _kernel.Bind<ILocationReportRequestDal>().To<EfLocationReportRequestDal>();
            _kernel.Bind<ILocationReportDetailDal>().To<EfLocationReportDetailDal>();

            _kernel.Bind<IPhoneBookReportUOW>().To<EfPhoneBookReportUOW>();

        }
    }
}
