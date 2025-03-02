using System;

namespace Collections
{
    public class User : IUser
    {
        public User(string fullName, string username, uint? age)
        {

            Username = username ?? throw new ArgumentNullException("Username cannot be null");
            Age = age;
            FullName = fullName;
        }
        
        public uint? Age { get; }
        
        public string FullName { get; }
        
        public string Username { get; }

        public bool IsAgeDefined => Age != null;
        
    }
}
