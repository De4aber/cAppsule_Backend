using System.Collections.Generic;
using System.IO;
using System.Linq;
using cAppsule;
using de4aber.cAppsule.DataAccess.Entities;
using de4aber.cAppsule.Domain.IRepositories;

namespace de4aber.cAppsule.DataAccess.Repositories
{
    public class FriendshipRepository : IFriendshipRepository
    {
        private readonly MainDbContext _ctx;
        private readonly IUserRepository _userRepository;
        
        public FriendshipRepository(MainDbContext ctx, IUserRepository userRepository)
        {
            _ctx = ctx ?? throw new InvalidDataException("FriendshipRepository need a DBcontext");
            _userRepository = userRepository ?? throw new InvalidDataException("FriendshipRepository need a UserRepository");
        }

        public List<Friendship> FindAll()
        {
            return _ctx.Friendships.Select(f => f.ToFriendship()).ToList();
        }

        public List<Friendship> FindByUserId(int userId)
        {
            return _ctx.Friendships
                .Where(f => f.Accepted == true
                            && (f.UserIdRequested == userId || f.UserIdRequesting == userId))
                .Select(f => f.ToFriendship())
                .ToList();
        }

        
        
    }
}