using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecommendationEngine
{
    /// <summary>
    /// Tracks user interactions with a video, including view count and watch duration.
    /// </summary>
    public class VideoHistoryItem
    {
        public Video Video { get; set; }
        public DateTime LastWatched { get; set; }
        public TimeSpan watchTime { get; set; }
        public int watchCount { get; set; }

        /// <summary>
        /// Initializes a new instance of the VideoHistoryItem class.
        /// </summary>
        /// <param name="video">The video being watched.</param>
        public VideoHistoryItem(Video video)
        {
            Video = video;
            LastWatched = DateTime.Now;
            watchTime = TimeSpan.Zero;
            watchCount = 0;
        }

        /// <summary>
        /// Updates the watch time and increments the watch count.
        /// </summary>
        /// <param name="duration">Duration of the video watch.</param>
        public void UpdateWatchTime(TimeSpan duration)
        {
            watchTime += duration;
            watchCount++;
        }

        /// <summary>
        /// Retrieves the total watch duration for this video.
        /// </summary>
        /// <returns>Total watch duration as a TimeSpan.</returns>
        public TimeSpan GetViewDuration()
        {
            return watchTime;
        }
    }
}
