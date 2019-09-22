namespace DocumentIO
{
	public class CreateInviteType : DocumentIOInputGraphType<Invite>
	{
		public CreateInviteType()
		{
			Field(x => x.Role);
			Field(x => x.Description);
			NullField(x => x.DueDate);
		}
	}
}