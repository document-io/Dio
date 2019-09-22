namespace DocumentIO
{
	public class InviteFilterType : DocumentIOFilterType<Invite, InviteFilter>
	{
		public InviteFilterType()
		{
			NullField(x => x.Id);
			NullField(x => x.Role);
			NullField(x => x.Description);
		}
	}
}