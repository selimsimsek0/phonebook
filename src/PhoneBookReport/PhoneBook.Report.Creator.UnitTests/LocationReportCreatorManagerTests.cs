using FluentAssertions;
using Moq;
using NUnit.Framework;
using PhoneBook.Report.Common.CustomExceptions;
using PhoneBook.Report.Creator.CreatorManager.Concrete;
using PhoneBook.Report.Creator.FileCreator.Abstract;
using PhoneBook.Report.Creator.ReportCreator.Abstract;
using PhoneBook.Report.Data.Repository.Abstract;
using PhoneBook.Report.Data.UnitOfWork.Abstract;
using PhoneBook.Report.Entity.Entity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PhoneBook.Report.Creator.UnitTests
{
    public class LocationReportCreatorManagerTests
    {
        [Test]
        public void UpdateRequestStatusToCreating_WithNotUpdateRequest_ThrowFailDataUpdateException()
        {
            #region Arrange
            Mock<IPhoneBookReportUOW> moqUOW = new Mock<IPhoneBookReportUOW>();
            Mock<ILocationReportRequestDal> moqLocationReportRequestDal = new Mock<ILocationReportRequestDal>();
            moqLocationReportRequestDal.Setup(p => p.Update(It.IsAny<LocationReportRequest>())).Returns(false);
            moqUOW.Setup(p => p.LocationReportRequestDal).Returns(moqLocationReportRequestDal.Object);

            Mock<IFileWriter<LocationReport>> moqFileWriter = new Mock<IFileWriter<LocationReport>>();
            Mock<IReportCreator<LocationReport>> moqReportCreator = new Mock<IReportCreator<LocationReport>>();

            LocationReportCreatorManager creatorManager = new LocationReportCreatorManager(
                moqUOW.Object, moqFileWriter.Object, moqReportCreator.Object);

            LocationReport report = new LocationReport
            {
                CreationDate = DateTime.Now,
                Id = Guid.NewGuid(),
                ReportRequest = new LocationReportRequest
                {
                    Id = Guid.NewGuid(),
                    CreationDate = DateTime.Now,
                    ReportId = Guid.NewGuid(),
                    CompletedDate = DateTime.Now,
                    DocumentName = "DocumentName",
                    DocumentPath = "Path",
                    DocumentType = 0,
                    Status = 0
                },
                ReportDetails = new List<LocationReportDetail>
                {
                    new LocationReportDetail
                    {
                        Id=Guid.NewGuid(),
                        CreationDate=DateTime.Now,
                        Location="Location",
                        PersonCount=5,
                        PhoneNumberCount=5,
                        ReportId=Guid.NewGuid()
                    },
                    new LocationReportDetail
                    {
                        Id=Guid.NewGuid(),
                        CreationDate=DateTime.Now,
                        Location="Location",
                        PersonCount=5,
                        PhoneNumberCount=5,
                        ReportId=Guid.NewGuid()
                    },
                    new LocationReportDetail
                    {
                        Id=Guid.NewGuid(),
                        CreationDate=DateTime.Now,
                        Location="Location",
                        PersonCount=5,
                        PhoneNumberCount=5,
                        ReportId=Guid.NewGuid()
                    }
                }
            };

            #endregion

            #region Action
            Action updateStatusAction = () => creatorManager.UpdateRequestStatusToCreating(report);
            #endregion

            #region Assert
            updateStatusAction.Should().Throw<FailDataUpdateException>();
            #endregion
        }

        [Test]
        public void GenerateReport_WithFailReportGenerate_ThrowFailReportGenerateException()
        {
            #region Arrange
            Mock<IPhoneBookReportUOW> moqUOW = new Mock<IPhoneBookReportUOW>();
            moqUOW.SetReturnsDefault(true);

            Mock<IFileWriter<LocationReport>> moqFileWriter = new Mock<IFileWriter<LocationReport>>();

            Mock<IReportCreator<LocationReport>> moqReportCreator = new Mock<IReportCreator<LocationReport>>();
            moqReportCreator.Setup(p => p.CreateReportAsync(It.IsAny<LocationReport>())).ReturnsAsync(false);

            LocationReportCreatorManager creatorManager = new LocationReportCreatorManager(
                moqUOW.Object, moqFileWriter.Object, moqReportCreator.Object);

            LocationReport report = new LocationReport
            {
                CreationDate = DateTime.Now,
                Id = Guid.NewGuid(),
                ReportRequest = new LocationReportRequest
                {
                    Id = Guid.NewGuid(),
                    CreationDate = DateTime.Now,
                    ReportId = Guid.NewGuid(),
                    CompletedDate = DateTime.Now,
                    DocumentName = "DocumentName",
                    DocumentPath = "Path",
                    DocumentType = 0,
                    Status = 0
                },
                ReportDetails = new List<LocationReportDetail>
                {
                    new LocationReportDetail
                    {
                        Id=Guid.NewGuid(),
                        CreationDate=DateTime.Now,
                        Location="Location",
                        PersonCount=5,
                        PhoneNumberCount=5,
                        ReportId=Guid.NewGuid()
                    },
                    new LocationReportDetail
                    {
                        Id=Guid.NewGuid(),
                        CreationDate=DateTime.Now,
                        Location="Location",
                        PersonCount=5,
                        PhoneNumberCount=5,
                        ReportId=Guid.NewGuid()
                    },
                    new LocationReportDetail
                    {
                        Id=Guid.NewGuid(),
                        CreationDate=DateTime.Now,
                        Location="Location",
                        PersonCount=5,
                        PhoneNumberCount=5,
                        ReportId=Guid.NewGuid()
                    }
                }
            };

            #endregion

            #region Action
            Func<Task> generateReportAction = async () => { await creatorManager.GenerateReportAsync(report); };
            #endregion

            #region Assert
            var expected = generateReportAction.Should().ThrowAsync<FailReportGenerateException>().Result;


            #endregion
        }

        [Test]
        public void AddDbReportDetails_WithFailAddReportDetail_ThrowFailDataInsertException()
        {
            #region Arrange
            Mock<IPhoneBookReportUOW> moqUOW = new Mock<IPhoneBookReportUOW>();
            Mock<ILocationReportDetailDal> moqLocationReportDetailDal = new Mock<ILocationReportDetailDal>();

            moqLocationReportDetailDal.Setup(p => p.Add(It.IsAny<LocationReportDetail>())).Returns(false);
            moqUOW.Setup(p => p.LocationReportDetailDal).Returns(moqLocationReportDetailDal.Object);

            Mock<IFileWriter<LocationReport>> moqFileWriter = new Mock<IFileWriter<LocationReport>>();
            Mock<IReportCreator<LocationReport>> moqReportCreator = new Mock<IReportCreator<LocationReport>>();

            LocationReportCreatorManager creatorManager = new LocationReportCreatorManager(
                moqUOW.Object, moqFileWriter.Object, moqReportCreator.Object);

            LocationReport report = new LocationReport
            {
                CreationDate = DateTime.Now,
                Id = Guid.NewGuid(),
                ReportRequest = new LocationReportRequest
                {
                    Id = Guid.NewGuid(),
                    CreationDate = DateTime.Now,
                    ReportId = Guid.NewGuid(),
                    CompletedDate = DateTime.Now,
                    DocumentName = "DocumentName",
                    DocumentPath = "Path",
                    DocumentType = 0,
                    Status = 0
                },
                ReportDetails = new List<LocationReportDetail>
                {
                    new LocationReportDetail
                    {
                        Id=Guid.NewGuid(),
                        CreationDate=DateTime.Now,
                        Location="Location",
                        PersonCount=5,
                        PhoneNumberCount=5,
                        ReportId=Guid.NewGuid()
                    },
                    new LocationReportDetail
                    {
                        Id=Guid.NewGuid(),
                        CreationDate=DateTime.Now,
                        Location="Location",
                        PersonCount=5,
                        PhoneNumberCount=5,
                        ReportId=Guid.NewGuid()
                    },
                    new LocationReportDetail
                    {
                        Id=Guid.NewGuid(),
                        CreationDate=DateTime.Now,
                        Location="Location",
                        PersonCount=5,
                        PhoneNumberCount=5,
                        ReportId=Guid.NewGuid()
                    }
                }
            };

            #endregion

            #region Action
            Action addReportDetailAction = () => creatorManager.AddDbReportDetails(report);
            #endregion

            #region Assert

            addReportDetailAction.Should().Throw<FailDataInsertException>();
            #endregion
        }

        [Test]
        public void CreateDocumentFile_WithFailDocumentCreate_ThrowFailDocumentGenerateException()
        {
            #region Arrange
            Mock<IPhoneBookReportUOW> moqUOW = new Mock<IPhoneBookReportUOW>();

            Mock<IFileWriter<LocationReport>> moqFileWriter = new Mock<IFileWriter<LocationReport>>();
            string aa = "";
            string bb = "";
            moqFileWriter.Setup(p => p.CreateFile(It.IsAny<LocationReport>(), out aa, out bb)).Returns(false);

            Mock<IReportCreator<LocationReport>> moqReportCreator = new Mock<IReportCreator<LocationReport>>();

            LocationReportCreatorManager creatorManager = new LocationReportCreatorManager(
                moqUOW.Object, moqFileWriter.Object, moqReportCreator.Object);

            LocationReport report = new LocationReport
            {
                CreationDate = DateTime.Now,
                Id = Guid.NewGuid(),
                ReportRequest = new LocationReportRequest
                {
                    Id = Guid.NewGuid(),
                    CreationDate = DateTime.Now,
                    ReportId = Guid.NewGuid(),
                    CompletedDate = DateTime.Now,
                    DocumentName = "DocumentName",
                    DocumentPath = "Path",
                    DocumentType = 0,
                    Status = 0
                },
                ReportDetails = new List<LocationReportDetail>
                {
                    new LocationReportDetail
                    {
                        Id=Guid.NewGuid(),
                        CreationDate=DateTime.Now,
                        Location="Location",
                        PersonCount=5,
                        PhoneNumberCount=5,
                        ReportId=Guid.NewGuid()
                    },
                    new LocationReportDetail
                    {
                        Id=Guid.NewGuid(),
                        CreationDate=DateTime.Now,
                        Location="Location",
                        PersonCount=5,
                        PhoneNumberCount=5,
                        ReportId=Guid.NewGuid()
                    },
                    new LocationReportDetail
                    {
                        Id=Guid.NewGuid(),
                        CreationDate=DateTime.Now,
                        Location="Location",
                        PersonCount=5,
                        PhoneNumberCount=5,
                        ReportId=Guid.NewGuid()
                    }
                }
            };

            #endregion

            #region Action
            Action createDocumentAction = () => creatorManager.CreateDocumentFile(report);
            #endregion

            #region Assert

            createDocumentAction.Should().Throw<FailDocumentGenerateException>();
            #endregion
        }

    }
}
