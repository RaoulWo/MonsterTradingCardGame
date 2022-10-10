using BusinessObjects.Entities;
using BusinessObjects.Interfaces.Services;
using BusinessObjects.Models;
using Moq;
using Presentation.Controllers;

namespace Presentation.Test.Controllers
{
    [TestFixture]
    public class UserControllerTest
    {
        [Test]
        public void GetAll_InputIsHttpRequest_CallGetAllExactlyOnce()
        {
            // Arrange
            Mock<IUserService> mockUserService = new Mock<IUserService>();
            UserController userController = new UserController(mockUserService.Object);
            HttpRequest httpRequest = new HttpRequest(null, null, null, 
                0, null, null, null);

            // Act
            Task<string> result = userController.GetAll(httpRequest);

            // Assert
            mockUserService.Verify(mock => mock.GetAll(), Times.Exactly(1));
        }

        [Test]
        public void GetById_InputIsHttpRequest_CallGetByIdExactlyOnce()
        {
            // Arrange
            Mock<IUserService> mockUserService = new Mock<IUserService>();
            UserController userController = new UserController(mockUserService.Object);
            HttpRequest httpRequest = new HttpRequest(null, "/users/1", null,
                0, null, null, null);

            // Act
            Task<string> result = userController.GetById(httpRequest);

            // Assert
            mockUserService.Verify(mock => mock.GetById(1), Times.Exactly(1));
        }

        [Test]
        public void GetByName_InputIsHttpRequest_CallGetByNameExactlyOnce()
        {
            // Arrange
            Mock<IUserService> mockUserService = new Mock<IUserService>();
            UserController userController = new UserController(mockUserService.Object);
            HttpRequest httpRequest = new HttpRequest(null, "/users/Admin", null,
                0, null, null, null);

            // Act
            Task<string> result = userController.GetByName(httpRequest);

            // Assert
            mockUserService.Verify(mock => mock.GetByName("Admin"), Times.Exactly(1));
        }

        [Test]
        public void Insert_InputIsHttpRequest_CallInsertExactlyOnce()
        {
            // Arrange
            Mock<IUserService> mockUserService = new Mock<IUserService>();
            UserController userController = new UserController(mockUserService.Object);
            HttpRequest httpRequest = new HttpRequest(null, null, null,
                0, null, null, "{\"Username\": \"Admin\", \"Password\": \"Admin\"}");

            // Act
            Task<string> result = userController.Insert(httpRequest);

            // Assert
            UserEntity user = new UserEntity(0, "Admin", "Admin", 0);
            mockUserService.Verify(mock => mock.Insert(user), Times.Exactly(1));
        }

        [Test]
        public void Update_InputIsHttpRequest_CallUpdateExactlyOnce()
        {
            // Arrange
            Mock<IUserService> mockUserService = new Mock<IUserService>();
            UserController userController = new UserController(mockUserService.Object);
            HttpRequest httpRequest = new HttpRequest(null, null, null,
                0, null, null, "{\"Id\": 1, \"Username\": \"User\", \"Password\": \"User\", \"Coins\": 1}");

            // Act
            Task<string> result = userController.Update(httpRequest);

            // Assert
            UserEntity user = new UserEntity(1, "User", "User", 1);
            mockUserService.Verify(mock => mock.Update(user), Times.Exactly(1));
        }

        [Test]
        public void DeleteById_InputIsHttpRequest_CallDeleteByIdExactlyOnce()
        {
            // Arrange
            Mock<IUserService> mockUserService = new Mock<IUserService>();
            UserController userController = new UserController(mockUserService.Object);
            HttpRequest httpRequest = new HttpRequest(null, "/users/1", null,
                0, null, null, null);

            // Act
            Task<string> result = userController.DeleteById(httpRequest);

            // Assert
            mockUserService.Verify(mock => mock.DeleteById(1), Times.Exactly(1));
        }

        [Test]
        public void DeleteByName_InputIsHttpRequest_CallDeleteByNameExactlyOnce()
        {
            // Arrange
            Mock<IUserService> mockUserService = new Mock<IUserService>();
            UserController userController = new UserController(mockUserService.Object);
            HttpRequest httpRequest = new HttpRequest(null, "/users/Admin", null,
                0, null, null, null);

            // Act
            Task<string> result = userController.DeleteByName(httpRequest);

            // Assert
            mockUserService.Verify(mock => mock.DeleteByName("Admin"), Times.Exactly(1));
        }
    }
}
