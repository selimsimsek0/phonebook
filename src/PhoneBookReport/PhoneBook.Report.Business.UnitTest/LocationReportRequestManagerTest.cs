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
    public class LocationReportRequestManagerTest
    {
        [Test]
        public void Delete_WithNullGetReport_ReturnFalse()
        {
            #region Arrange

            Mock<IPhoneBookReportUOW> moqUOW = new Mock<IPhoneBookReportUOW>();
            Mock<ILocationReportRequestDal> moqLocationReportRequestDal = new Mock<ILocationReportRequestDal>();
            moqLocationReportRequestDal.Setup(p => p.Get(It.IsAny<Guid>())).Returns<LocationReportRequest>(null);
            moqUOW.Setup(p => p.LocationReportRequestDal).Returns(moqLocationReportRequestDal.Object);

            LocationReportRequestManager locationReportManager = new LocationReportRequestManager(moqUOW.Object);

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
