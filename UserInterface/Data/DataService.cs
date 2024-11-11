using RecommendationEngine;

namespace front_end.Data
{
    public class DataService
    {
        List<VideoHistoryItem> _videoHistory = new();

        public void AddVideoView(Video v)
        {
            //logic to update the videohistorylist
            foreach (var item in _videoHistory)
            {
                if (item != null && item.Video.URL == v.URL)
                {
                    item.LastWatched = DateTime.Now;
                    item.watchCount++;
                }
            }

            var foundvideo = _videoHistory.Where(i => i.Video.URL == v.URL).First();
            foundvideo.LastWatched = DateTime.Now;
            foundvideo.watchCount++;
        }

    }
}
