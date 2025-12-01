using Microsoft.AspNet.Identity;
using Moq;
using PAWB.Domain.Exceptions;
using PAWB.Domain.Model;
using PAWB.Domain.Models;
using PAWB.Domain.Services;
using PAWB.Domain.Services.AuthenticationServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Tests done for methods in AuthenticationServices
namespace PAWB.Domain.Tests.Services.AuthenticationServices
{
    [TestFixture]
    public class AuthenticationServiceTests
    {
        private Mock<IPasswordHasher> _mockPasswordHasher;
        private Mock<IAccountService> _mockAccountService;
        private AuthenticationService _authenticationService;

        [SetUp]
        public void Setup()
        {
            _mockAccountService = new Mock<IAccountService>();
            _mockPasswordHasher = new Mock<IPasswordHasher>();
            _authenticationService = new AuthenticationService(_mockAccountService.Object, _mockPasswordHasher.Object);

        }

        //Tests successful login
        [Test]
        public async Task Login_WithTheCorrectPasswordForExistingUsername_ReturnsAccountForCorrectUsername()
        {
            //Arrange
            string expectedUsername = "testuser";
            string password = "testpassword";
            _mockAccountService.Setup(s => s.GetByUsername(expectedUsername)).ReturnsAsync(new Account() { AccountHolder = new User() { Username = expectedUsername } });
            _mockPasswordHasher.Setup(s => s.VerifyHashedPassword(It.IsAny<string>() , password)).Returns(PasswordVerificationResult.Success);

            //Act
            Account account = await _authenticationService.Login(expectedUsername, password);

            //Assert
            string actualUsername = account.AccountHolder.Username;
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(expectedUsername, actualUsername);
        }

        //Tests login with incorrect password for an existing username
        [Test]
        public void Login_WithIncorrectPasswordForExistingUsername_ThrowsInvalidPasswordExceptionForUsername()
        {
            //Arrange
            string expectedUsername = "testuser";
            string password = "testpassword";
            _mockAccountService.Setup(s => s.GetByUsername(expectedUsername)).ReturnsAsync(new Account() { AccountHolder = new User() { Username = expectedUsername } });
            _mockPasswordHasher.Setup(s => s.VerifyHashedPassword(It.IsAny<string>(), password)).Returns(PasswordVerificationResult.Failed);

            //Act
            InvalidPasswordException exception = NUnit.Framework.Assert.ThrowsAsync<InvalidPasswordException>(() => _authenticationService.Login(expectedUsername, password));

            //Assert
            string actualUsername = exception.Username;
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(expectedUsername, actualUsername);
        }

        //Test login for a non-existing username
        [Test]
        public void Login_WithNonExistingUsername_ThrowsInvalidPasswordExceptionForUsername()
        {
            //Arrange
            string expectedUsername = "testuser";
            string password = "testpassword";
            _mockPasswordHasher.Setup(s => s.VerifyHashedPassword(It.IsAny<string>(), password)).Returns(PasswordVerificationResult.Failed);

            //Act
            UserNotFoundException exception = NUnit.Framework.Assert.ThrowsAsync<UserNotFoundException>(() => _authenticationService.Login(expectedUsername, password));

            //Assert
            string actualUsername = exception.Username;
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(expectedUsername, actualUsername);
        }

        //Tests registration with non-matching passwords
        [Test]
        public async Task Register_WithPasswordsNotMatching_ReturnsPasswordsDoNotMatch()
        {
            //Arrange
            string password = "testpassword";
            string confirmPassword = "confirmtestpassword";

            RegistrationResult expected = RegistrationResult.PasswordsDoNotMatch;

            //Act
            RegistrationResult actual = await _authenticationService.Resister(It.IsAny<string>(), It.IsAny<string>(), password, confirmPassword);

            //Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(expected, actual);

        }

        //Tests registration with an already existing email
        [Test]
        public async Task Register_WithAlreadyExistingEmail_ReturnsEmailAlreadyExists()
        {
            //Arrange
            string email = "test@gmail.com";
            _mockAccountService.Setup(s => s.GetByEmail(email)).ReturnsAsync(new Account());
            RegistrationResult expected = RegistrationResult.EmailAlreadyExists;

            //Act
            RegistrationResult actual = await _authenticationService.Resister(email, It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>());

            //Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(expected, actual);

        }

        //Tests registration with an already existing username
        [Test]
        public async Task Register_WithAlreadyExistingUsername_ReturnsUsernameAlreadyExists()
        {
            //Arrange
            string username = "testuser";
            _mockAccountService.Setup(s => s.GetByUsername(username)).ReturnsAsync(new Account());
            RegistrationResult expected = RegistrationResult.UsernameAlreadyExists;

            //Act
            RegistrationResult actual = await _authenticationService.Resister(It.IsAny<string>(), username, It.IsAny<string>(), It.IsAny<string>());

            //Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(expected, actual);

        }

        //Tests successful registration
        [Test]
        public async Task Register_WithNonExistingUserAndMatchingPasswords_ReturnsSuccess()
        {
            //Arrange
            RegistrationResult expected = RegistrationResult.Success;
            //Act
            RegistrationResult actual = await _authenticationService.Resister(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>());

            //Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(expected, actual);

        }
    }
}
