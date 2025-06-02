using RecommendationEngine;

namespace UserInterface.Data
{
    /// <summary>
    /// Service for tracking video view history in-memory.
    /// </summary>
    public class DataService
    {
        /// <summary>
        /// In-memory list to store history entries for each tracked video
        /// </summary>
        List<VideoHistoryItem> _videoHistory = new();

        /// <summary>
        /// Adds a view record for the specified video.  
        /// If the video already exists in history, updates its last-watched timestamp and increments the watch count.  
        /// Otherwise, adds a new history entry.
        /// </summary>
        /// <param name="v">The video to record a view for.</param>
        public void AddVideoView(Video v)
        {
            bool found = false;  // Flag to track if the video already exists in history

            // Iterate through the existing video history items
            foreach (var item in _videoHistory)
            {
                // Check for a matching video URL
                if (item != null && item.Video.URL == v.URL)
                {
                    item.LastWatched = DateTime.Now;  // Update the last-watched timestamp
                    item.watchCount++;                // Increment the watch count for this video
                    found = true;                     // Mark as found so we don’t add a duplicate
                }
            }

            // If the video wasn’t found in the history list, add it as a new entry
            if (!found)
            {
                VideoHistoryItem nvhi = new(v);  // Create a new history item from the Video
                _videoHistory.Add(nvhi);         // Add the new item to the history list
            }
        }
    }
}
