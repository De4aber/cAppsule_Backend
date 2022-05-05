using System;
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

        public Friendship FindById(int friendshipId)
        {
            var friendshipEntity = _ctx.Friendships.Find(friendshipId);
            return friendshipEntity?.ToFriendship() ?? throw new InvalidOperationException();
        }

        public List<Friendship> FindByUserId(int userId)
        {
            return _ctx.Friendships
                .Where(f => f.Accepted == true
                            && (f.UserIdRequested == userId || f.UserIdRequesting == userId))
                .Select(f => f.ToFriendship())
                .ToList();
        }

        public bool DeleteById(int id)
        {
            
                var toDelete = _ctx.Friendships.Find(id);
                if (toDelete == null) return false;
                _ctx.Friendships.Remove(toDelete);
                _ctx.SaveChanges();
                return true;
                
        }

        public Friendship Create(Friendship friendship)
        {
            FriendshipEntity friendshipEntity = new FriendshipEntity(friendship);
            FriendshipEntity createdFriendshipEntity = _ctx.Friendships.Add(friendshipEntity).Entity;

            _ctx.SaveChanges();

            return createdFriendshipEntity.ToFriendship();
        }

        public Friendship UpdateFriendship(int id, Friendship friendship)
        {
            friendship.Id = id;
            var updatedFriendship = _ctx.Friendships.Update(new FriendshipEntity(friendship)).Entity;
            _ctx.SaveChanges();
            return updatedFriendship.ToFriendship();
        }

        public Friendship AcceptFriendRequest(int friendshipId, int acceptingUserId)
        {
            var friendshipEntity = _ctx.Friendships.Find(friendshipId);
            if (friendshipEntity.UserIdRequested == acceptingUserId)
            {
                friendshipEntity.Accepted = true;
                _ctx.SaveChanges();
            }
            return friendshipEntity.ToFriendship();
        }
    }
}