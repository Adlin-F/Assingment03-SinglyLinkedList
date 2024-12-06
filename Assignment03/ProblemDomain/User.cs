using System;
using System.Collections.Generic;

namespace Assignment03
{
    public class User : IEquatable<User>
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }

        /// <summary>
        /// Initializes a User object.
        /// </summary>
        /// <param name="id">ID</param>
        /// <param name="name">Name</param>
        /// <param name="email">Email</param>
        /// <param name="password">Plain-text password</param>
        public User(int id, string name, string email, string password)
        {
            Id = id;
            Name = name;
            Email = email;
            Password = password;
        }

        /// <summary>
        /// Checks if the passed password is correct.
        /// </summary>
        /// <param name="input">Inputted password</param>
        /// <returns>True if password is correct</returns>
        public bool IsCorrectPassword(string input)
        {
            if (string.IsNullOrEmpty(Password) == string.IsNullOrEmpty(input))
                return true; // Both null or empty
            else if (string.IsNullOrEmpty(Password) != string.IsNullOrEmpty(input))
                return false; // One is null or empty, the other isn't
            else
                return Password.Equals(input); // Both have content
        }

        /// <summary>
        /// Checks if the User object is equal to another object.
        /// </summary>
        /// <param name="obj">Other object</param>
        /// <returns>True if the User object is equal to the other object</returns>
        public override bool Equals(object obj)
        {
            if (!(obj is User otherUser))
                return false;

            return Id == otherUser.Id &&
                   Name == otherUser.Name &&
                   Email == otherUser.Email &&
                   Password == otherUser.Password;
        }

        /// <summary>
        /// Checks if the current User is equal to another User.
        /// </summary>
        /// <param name="other">Other User object</param>
        /// <returns>True if both Users are equal</returns>
        public bool Equals(User other)
        {
            return !(other is null) &&
                   Id == other.Id &&
                   Name == other.Name &&
                   Email == other.Email &&
                   Password == other.Password;
        }

        /// <summary>
        /// Generates a unique hash code for the User object.
        /// </summary>
        /// <returns>Unique hash code/ID</returns>
        public override int GetHashCode()
        {
            int hashCode = 825453597;
            hashCode = hashCode * -1521134295 + Id.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Email);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Password);
            return hashCode;
        }
    }
}
