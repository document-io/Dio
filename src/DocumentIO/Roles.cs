namespace DocumentIO
{
	public static class Roles
	{
		public const string Admin = "admin";
		public const string User = "user";

		public static string[] All { get; } = { Admin, User };
	}
}