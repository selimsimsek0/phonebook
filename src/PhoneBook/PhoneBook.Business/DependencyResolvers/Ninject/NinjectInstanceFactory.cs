using Microsoft.EntityFrameworkCore;
using Ninject;
using PhoneBook.Data.Abstract;
using PhoneBook.Data.Concrete.EfCore;
using PhoneBook.Data.Context;
using PhoneBook.Data.UnitOfWork.Abstract;
using PhoneBook.Data.UnitOfWork.Concrete;

namespace PhoneBook.Business.DependencyResolvers.Ninject
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

            _kernel.Bind<DbContext>().To<PhoneBookDbContext>();

            _kernel.Bind<IPersonDal>().To<EfPersonDal>();
            _kernel.Bind<IContactInfoDal>().To<EfContactInfoDal>();

            _kernel.Bind<IPhoneBookUOW>().To<EfPhoneBookUOW>();

        }
    }
}
