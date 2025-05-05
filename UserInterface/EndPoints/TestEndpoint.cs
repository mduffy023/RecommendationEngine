using front_end.Data;
using RecommendationEngine;

namespace front_end.EndPoints
{
	public class TestEndPoint
	{
        /// <summary>
        /// Registers the YouTube tracking endpoint on the WebApplication.
        /// </summary>
        /// <param name="app">The WebApplication to configure.</param>
        public static void Map(WebApplication app)
		{
            //Get the point at "/yttrack/{id}" for now onlty using for tests 
            app.MapGet("/yttrack/{id}", (string id, string title, string channelname, int nubmeroflikes, string vidsrc, DataService ds) =>
			{
				// create a new Video instance to cupture the incoming data
				var newVideo = new Video();
				
				//Data records 
				newVideo.Title = title; //title of video
				newVideo.ChannelName = channelname; //channel name 
				newVideo.NumberOfLikes = nubmeroflikes; // num of like on video
				newVideo.URL = vidsrc; //video soruce URL 
                //TODO implement!

                //records the data (note data will be easrsed after runtime stops, no DB added yet //TODO implementation)
                ds.AddVideoView(newVideo);

				//return a success message 
				return new TestReply() { Success = true };

			});
		}

        /// <summary>
        /// A simple reply object indicating operation success.
        /// </summary>
        public class TestReply
		{
            //return a success message 
            public bool Success { get; set; } = false;
		}
	}
}
