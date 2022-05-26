using System;
using System.Collections.Generic;
using cAppsule;
using de4aber.cAppsule.Core.DTOs;
using de4aber.cAppsule.Core.Models;
using de4aber.cAppsule.Domain.IRepositories;
using de4aber.cAppsule.Domain.Service;
using Moq;
using Xunit;

namespace de4aber.cAppsule.Domain_Test.Services
{
    public class CapsuleServiceTest
    {
        private readonly Mock<ICapsuleRepository> _mock;
        private readonly Mock<IUserRepository> _userMock;
        private readonly CapsuleService _service;
        private readonly List<Capsule> _testData;

        public CapsuleServiceTest()
        {
            _mock = new Mock<ICapsuleRepository>();
            _userMock = new Mock<IUserRepository>();
            _service = new CapsuleService(_mock.Object, _userMock.Object);
            _testData = new List<Capsule>
            {
                new Capsule
                {
                    Id = 1, SenderId = 4, ReceiverId = 5, Message = "Goddag Gerda", Time = DateTime.Now,
                    Latitude = 55.468505670134455, Longitude = 8.458455774539244, Photo = ""
                },
                new Capsule
                {
                    Id = 2, SenderId = 2, ReceiverId = 5, Message = "Hej Gerda, Hvordan går det?", Time = DateTime.Now,
                    Latitude = 55.468386425389454, Longitude = 8.449243752725645, Photo = ""
                },
                new Capsule
                {
                    Id = 2, SenderId = 2, ReceiverId = 4, Message = "Hvordan er det nu man snakker baglæns?", Time = DateTime.Now,
                    Latitude = 55.468386425389454, Longitude = 8.449243752725645, Photo = ""
                }
            };
        }

        [Fact]
        public void GetCapsules_NoFilter_ReturnsListOfAllCapsules()
        {
            _mock.Setup(r => r.FindAll()).Returns(_testData);
            Assert.Equal(_testData,_service.GetAll());
        }

        /*[Fact]
        public void GetCapsules_ByReceiverId()
        {
            var expectedList = new List<Capsule>
            {
                new Capsule
                {
                    Id = 1, SenderId = 4, ReceiverId = 5, Message = "Goddag Gerda", Time = DateTime.Now,
                    Latitude = 55.468505670134455, Longitude = 8.458455774539244, Photo = ""
                },
                new Capsule
                {
                    Id = 2, SenderId = 2, ReceiverId = 5, Message = "Hej Gerda, Hvordan går det?", Time = DateTime.Now,
                    Latitude = 55.468386425389454, Longitude = 8.449243752725645, Photo = ""
                },
            };
            
            var expectedList2 = new List<ReceiveCapsuleDTO>
            {
                new ReceiveCapsuleDTO(1,"4")
                {
                    Message = "Goddag Gerda", Time = DateTime.Now.ToString(),
                    Latitude = 55.468505670134455, Longitude = 8.458455774539244, Photo = ""
                },
                new ReceiveCapsuleDTO(2,"2")
                {
                    Message = "Hej Gerda, Hvordan går det?", Time = DateTime.Now.ToString(),
                    Latitude = 55.468386425389454, Longitude = 8.449243752725645, Photo = ""
                },
            };

            var user = new User {Id = 1, Username = "5", BirthDate = DateTime.Today, CapScore = 2};

            _mock.Setup(r => r.FindByReceiverId(5)).Returns(expectedList);
            _userMock.Setup(r => r.ReadById(5)).Returns(user);
            Assert.Equal(expectedList2, _service.GetByReceiverId(5));
        }*/

        [Fact]
        public void SendCapsule()
        {
            
        }
    }
}