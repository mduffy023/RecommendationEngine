
namespace front_end.EndPoints
{
	public class TestEndPoint
	{
		public static void Map(WebApplication app)
		{
#pragma warning disable CS8632 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context.
			app.MapGet("/yttrack/", (string? id, string? title, string? channelname, int? numoflikes, string? vidsrc) =>
			{
				return new TestReply() { Success = true };

			});
#pragma warning restore CS8632 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context.
		}



		public class TestReply
		{
			public bool Success { get; set; } = false;
			public string Message { get; set; } = "";
		}
	}
}
