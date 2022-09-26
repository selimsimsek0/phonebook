using FluentAssertions;
using Moq;
using NUnit.Framework;
using PhoneBook.Report.Business.Concrete;
using PhoneBook.Report.Data.Repository.Abstract;
using PhoneBook.Report.Data.UnitOfWork.Abstract;
using PhoneBook.Report.Entity.Entity;
using System;

namespace PhoneBook.Report.Business.UnitTest
{
   public class LocationReportDetailManagerTests
    {

        [Test]
        public void Delete_WithNullGetReport_ReturnFalse()
        {
            #region Arrange

            Mock<IPhoneBookReportUOW> moqUOW = new Mock<IPhoneBookReportUOW>();
            Mock<ILocationReportDetailDal> moqLocationReportDetailDal = new Mock<ILocationReportDetailDal>();
            moqLocationReportDetailDal.Setup(p => p.Get(It.IsAny<Guid>())).Returns<LocationReportDetail>(null);
            moqUOW.Setup(p => p.LocationReportDetailDal).Returns(moqLocationReportDetailDal.Object);

            LocationReportDetailManager locationReportManager = new LocationReportDetailManager(moqUOW.Object);

            #endregion

            #region Action

            bool deleteAction = locationReportManager.Delete(Guid.NewGuid());

            #endregion

            #region Assert

            deleteAction.Should().BeFalse();

            #endregion
        }
    }
}
