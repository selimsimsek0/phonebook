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
    public class PersonManagerTests
    {
        [Test]
        public void DeletePerson_WithNullGetReport_ReturnFalse()
        {
            #region Arrange

            Mock<IPhoneBookUOW> moqUOW = new Mock<IPhoneBookUOW>();
            Mock<IPersonDal> moqPersonDal = new Mock<IPersonDal>();
            moqPersonDal.Setup(p => p.Get(It.IsAny<Guid>())).Returns<Person>(null);
            moqUOW.Setup(p => p.PersonDal).Returns(moqPersonDal.Object);

            PersonManager contactInfoManager = new PersonManager(moqUOW.Object);

            #endregion

            #region Action

            bool deleteAction = contactInfoManager.DeletePerson(Guid.NewGuid());

            #endregion

            #region Assert

            deleteAction.Should().BeFalse();

            #endregion
        }

        [Test]
        public void GenerateFakePerson_WithNotAddPerson_ThrowException()
        {
            #region Arrange

            Mock<IPhoneBookUOW> moqUOW = new Mock<IPhoneBookUOW>();
            Mock<IPersonDal> moqPersonDal = new Mock<IPersonDal>();
            moqPersonDal.Setup(p => p.Add(It.IsAny<Person>())).Returns(false);

            moqUOW.Setup(p => p.PersonDal).Returns(moqPersonDal.Object);

            PersonManager contactInfoManager = new PersonManager(moqUOW.Object);

            #endregion

            #region Action

            Action generatePersonAction = () => contactInfoManager.GenerateFakePerson(1);

            #endregion

            #region Assert

            generatePersonAction.Should().Throw<Exception>();

            #endregion
        }

        [Test]
        public void GenerateFakePerson_WithNotAddContatInfo_ThrowException()
        {
            #region Arrange

            Mock<IPhoneBookUOW> moqUOW = new Mock<IPhoneBookUOW>();

            Mock<IContactInfoDal> moqContactInfoDal = new Mock<IContactInfoDal>();
            moqContactInfoDal.Setup(p => p.Add(It.IsAny<ContactInfo>())).Returns(false);

            Mock<IPersonDal> moqPersonDal = new Mock<IPersonDal>();
            moqPersonDal.Setup(p => p.Add(It.IsAny<Person>())).Returns(true);

            moqUOW.Setup(p => p.PersonDal).Returns(moqPersonDal.Object);
            moqUOW.Setup(p => p.ContactInfoDal).Returns(moqContactInfoDal.Object);

            PersonManager contactInfoManager = new PersonManager(moqUOW.Object);

            #endregion

            #region Action

            Action generatePersonAction = () => contactInfoManager.GenerateFakePerson(1);

            #endregion

            #region Assert

            generatePersonAction.Should().Throw<Exception>();

            #endregion
        }
    }
}
