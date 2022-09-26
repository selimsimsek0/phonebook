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
    public class LocationReportManagerTests
    {

        [Test]
        public void CreateExcelReport_WithNotAddedLocationReport_ThrowException()
        {
            #region Arrange

            Mock<IPhoneBookReportUOW> moqUOW = new Mock<IPhoneBookReportUOW>();
            Mock<ILocationReportDal> moqLocationReportDal = new Mock<ILocationReportDal>();
            moqLocationReportDal.SetReturnsDefault(false);
            moqUOW.Setup(p => p.LocationReportDal).Returns(moqLocationReportDal.Object);

            LocationReportManager locationReportManager = new LocationReportManager(moqUOW.Object);

            #endregion

            #region Action

            Action locationReportAddAction = () => locationReportManager.CreateExcelReport();

            #endregion

            #region Assert

            locationReportAddAction.Should().Throw<Exception>();

            #endregion
        }

        [Test]
        public void CreateExcelReport_WithNotAddedLocationReportRequest_ThrowException()
        {
            #region Arrange

            Mock<IPhoneBookReportUOW> moqUOW = new Mock<IPhoneBookReportUOW>();
            Mock<ILocationReportRequestDal> moqLocationReportRequestDal = new Mock<ILocationReportRequestDal>();
            moqLocationReportRequestDal.SetReturnsDefault(false);
            moqUOW.Setup(p => p.LocationReportRequestDal).Returns(moqLocationReportRequestDal.Object);

            LocationReportManager locationReportManager = new LocationReportManager(moqUOW.Object);

            #endregion

            #region Action

            Action locationReportRequestAddAction = () => locationReportManager.CreateExcelReport();

            #endregion

            #region Assert

            locationReportRequestAddAction.Should().Throw<Exception>();

            #endregion
        }

        [Test]
        public void Delete_WithNullGetReport_ReturnFalse()
        {
            #region Arrange

            Mock<IPhoneBookReportUOW> moqUOW = new Mock<IPhoneBookReportUOW>();
            Mock<ILocationReportDal> moqLocationReportDal = new Mock<ILocationReportDal>();
            moqLocationReportDal.Setup(p => p.Get(It.IsAny<Guid>())).Returns<LocationReport>(null);
            moqUOW.Setup(p => p.LocationReportDal).Returns(moqLocationReportDal.Object);

            LocationReportManager locationReportManager = new LocationReportManager(moqUOW.Object);

            LocationReport locationReport = new LocationReport
            {
                CreationDate = DateTime.Now,
                Id = Guid.NewGuid()
            };

            #endregion

            #region Action

           bool deleteAction= locationReportManager.Delete(locationReport);

            #endregion

            #region Assert

            deleteAction.Should().BeFalse();

            #endregion
        }
    }
}
