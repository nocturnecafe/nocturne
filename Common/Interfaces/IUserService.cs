using System;
using Nocturne.Common.Models;

namespace Nocturne.Common.Interfaces
{
    /// <summary>
    /// Interface to work with users
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// Get user by id
        /// </summary>
        /// <param name="id">User id</param>
        /// <returns>User, or null</returns>
        User GetUser(int id);

        /// <summary>
        /// Get user by username and password
        /// </summary>
        /// <param name="userName">Username</param>
        /// <param name="password">Password</param>
        /// <returns>User, or null</returns>
        User GetUser(string userName, string password);

        /// <summary>
        /// Get user by reg. code
        /// </summary>
        /// <param name="regCode">User reg. code</param>
        /// <returns>User, or null</returns>
        User GetUserByRegCode(string regCode);

        /// <summary>
        /// Filters users based on a predicate.
        /// </summary>
        /// <param name="predicate">A function to test each element for a condition.</param>
        /// <returns>An user collection that satisfy the condition.</returns>
        User[] Find(Func<User, bool> predicate);

        /// <summary>
        /// Save user
        /// </summary>
        /// <param name="user"></param>
        /// <returns>Save messages and user id(if save success)</returns>
        ValidationResult<int> SaveUser(User user);

        /// <summary>
        /// Get all avaliable user roles
        /// </summary>
        /// <returns>User role names</returns>
        Role[] GetAvaliableRoles();
    }
}
