using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecommendationEngine
{
    /// <summary>
    /// Manages user information, preferences, and social interactions.
    /// </summary>
    public class UserAccount
    {
        public string Username { get ; set; }
        public string Email { get; set; }
        public List<Video> Favorites { get; set; }
        public List<UserAccount> Friends { get; set; }
        public string Bio { get; set; }
        public List<string> Preferences { get; set; }
        public List<VideoHistoryItem> History { get; set; }

        /// <summary>
        /// Validates the user's credentials against Youtube’s OAuth service.
        /// dont need to worry about this till later
        /// </summary>
        /// <param name="oauthToken">OAuth token for authentication.</param>
        public void Authenticate(string oauthToken) 
        {
            // 1. Send a request to YouTube OAuth service with the oauthToken.
            // 2. Handle the authentication response.
            // 3. Set the user's authenticated state.
        }

        /// <summary>
        /// Allows users to update their account information.
        /// </summary>
        /// <param name="name">User's name.</param>
        /// <param name="picUrl">URL of the user's profile picture.</param>
        /// <param name="bio">User's biography.</param>
        public void UpdateProfile(string name, string picUrl, string bio) 
        {
            // 1. Update the user's profile information (name, pic, bio).
            // 2. Optionally, sync updates with a backend server/database.
        }

        /// <summary>
        /// Retrieves the user’s stored preferences.
        /// </summary>
        /// <returns>List of preferences.</returns>
        public List<string> GetPreferences() 
        {
            // 1. Retrieve the list of preferences from a storage (e.g., database).
            // 2. Return the list.
            return new List<string>(); 
        }

        /// <summary>
        /// Adds a new preference to the user's profile.
        /// </summary>
        /// <param name="preference">The preference to add.</param>
        public void AddPreference(string preference) 
        {
            // 1. Add the preference to the user's preference list.
            // 2. Optionally, update the backend server/database.
        }

        /// <summary>
        /// Removes an existing preference from the user's profile.
        /// </summary>
        /// <param name="preference">The preference to remove.</param>
        public void RemovePreference(string preference) 
        {
            // 1. Remove the preference from the user's preference list.
            // 2. Optionally, update the backend server/database.
        }

        /// <summary>
        /// Returns a list of recommended content based on the user's profile preferences.
        /// </summary>
        /// <returns>List of recommended videos.</returns>
        public List<Video> GetRecommendations() 
        {
            // 1. Use the user's preferences to query the recommendation engine.
            // 2. Return a list of video recommendations.
            return new List<Video>(); 
        }
        /// <summary>
        /// Allows users to connect with friends on the platform.
        /// </summary>
        /// <param name="friend">The user account to be added as a friend.</param>
        public void AddFriend(UserAccount friend)
        {
            // 1. Add the 'friend' UserAccount to the current user's friend list.
        }

        /// <summary>
        /// Allows users to share content with friends on their feed.
        /// </summary>
        /// <param name="video">The video to be shared.</param>
        public void ShareContent(Video video)
        {
            // 1. Post the 'video' to the user's social feed.
            // 2. Notify the user's friends or followers about the new shared content.
        }

        /// <summary>
        /// Fetches recommendations based on viewing patterns and preferences of a user's friends.
        /// </summary>
        /// <returns>List of recommended videos.</returns>
        public List<Video> GetFriendRecommendations()
        {
            // 1. Aggregate viewing data and preferences from the user's friends.
            // 2. Use this aggregated data to fetch recommendations.
            return new List<Video>();
        }

    }
}
