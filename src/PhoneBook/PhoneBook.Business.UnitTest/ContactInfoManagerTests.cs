using FluentAssertions;
using Moq;
using NUnit.Framework;
using PhoneBook.Business.Concrete;
using PhoneBook.Data.Abstract;
using PhoneBook.Data.UnitOfWork.Abstract;
using PhoneBook.Entity.Entity;
using System;

namespace PhoneBook.Business.UnitTest
{
    public class ContactInfoManagerTests
    {
        [Test]
        public void DeleteContactInfo_WithNullGetReport_ReturnFalse()
        {
            #region Arrange

            Mock<IPhoneBookUOW> moqUOW = new Mock<IPhoneBookUOW>();
            Mock<IContactInfoDal> moqContactInfoDal = new Mock<IContactInfoDal>();
            moqContactInfoDal.Setup(p => p.Get(It.IsAny<Guid>())).Returns<ContactInfo>(null);
            moqUOW.Setup(p => p.ContactInfoDal).Returns(moqContactInfoDal.Object);

            ContactInfoManager contactInfoManager = new ContactInfoManager(moqUOW.Object);

            #endregion

            #region Action

            bool deleteAction = contactInfoManager.DeleteContactInfo(Guid.NewGuid());

            #endregion

            #region Assert

            deleteAction.Should().BeFalse();

            #endregion
        }
    }
}
