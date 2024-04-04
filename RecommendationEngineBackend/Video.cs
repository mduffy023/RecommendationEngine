namespace RecommendationEngine
{
    /// <summary>
    /// Represents a video and its properties.
    /// </summary>
    public class Video
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string URL { get; set; }
        public Platform Platform { get; set; }

        // Additional properties like Tags, ViewCount, etc., can be added here.
        //will need to look into this 
         
    }
}