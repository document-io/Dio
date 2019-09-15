namespace DocumentIO
{
	public static class Roles
	{
		public const string User = "user";
		public const string Admin = "admin";

		public static string[] All { get; } = { User, Admin };
	}
}