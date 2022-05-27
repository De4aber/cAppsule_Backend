using System.Collections.Generic;
using cAppsule;
using de4aber.cAppsule.Domain.IRepositories;
using de4aber.cAppsule.Domain.Service;
using Moq;
using Xunit;

namespace de4aber.cAppsule.Domain_Test.Services
{
    public class FriendshipServiceTest
    {
        private Mock<IFriendshipRepository> _mock;
        private FriendshipService _service;
        private List<Friendship> _expected;
        private readonly Mock<IUserRepository> _userMock;

        public FriendshipServiceTest()
        {
            _mock = new Mock<IFriendshipRepository>();
            _userMock = new Mock<IUserRepository>();
            _service = new FriendshipService(_mock.Object, _userMock.Object);

            _expected = new List<Friendship>
            {
                new Friendship{ Id = 1, UserIdRequested = 3, UserIdRequesting = 5, Accepted = true},
                new Friendship{ Id = 2, UserIdRequested = 5, UserIdRequesting = 5, Accepted = true},
                new Friendship{ Id = 3, UserIdRequested = 7, UserIdRequesting = 3, Accepted = false},
            };
        }
        
        [Fact]
        public void GetFriends_NoFilter()
        {
            _mock.Setup(r => r.FindAll()).Returns(_expected);
            Assert.Equal(_expected,_service.FindAll());
        }
    }
}