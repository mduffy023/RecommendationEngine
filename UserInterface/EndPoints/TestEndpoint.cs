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
#pragma warning disable CS8632 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context.
			app.MapGet("/yttrack/{id}", (string id, string title, string channelname, int nubmeroflikes, string vidsrc, DataService ds) =>
			{
				// create a new Video instance to cupture the incoming data
				var newVideo = new Video();

				newVideo.Title = title;
				//...etc

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
