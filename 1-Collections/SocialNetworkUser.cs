using System;
using System.Collections.Generic;

namespace Collections
{
    public class SocialNetworkUser<TUser> : User, ISocialNetworkUser<TUser>
        where TUser : IUser
    {
        Dictionary<string, ISet<TUser>> socialNetwork;

        public SocialNetworkUser(string fullName, string username, uint? age) : base(fullName, username, age)
        {
            socialNetwork = new Dictionary<string, ISet<TUser>>();
        }

        public bool AddFollowedUser(string group, TUser user)
        {
            if (!socialNetwork.ContainsKey(group))
            {
                socialNetwork.Add(group, new HashSet<TUser>());
            }

            return socialNetwork[group].Add(user);
        }

        public IList<TUser> FollowedUsers
        {
            get
            {
                ISet<TUser> followedUsers = new HashSet<TUser>();

                foreach (String group in socialNetwork.Keys)
                {
                    foreach (TUser user in socialNetwork[group])
                    {
                        followedUsers.Add(user);
                    }
                }


                return new List<TUser>(followedUsers);
            }
        }

        public ICollection<TUser> GetFollowedUsersInGroup(string group)
        {
            return socialNetwork.ContainsKey(group) ? new HashSet<TUser>(socialNetwork[group]) : new HashSet<TUser>();
        }
    }
}
