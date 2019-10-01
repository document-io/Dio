namespace DocumentIO
{
	public class InvitesFilterType : DocumentIOFilterType<Invite, InvitesFilter>
	{
		public InvitesFilterType()
		{
			NullField(x => x.Id);
			NullField(x => x.Role);
			NullField(x => x.Description);
		}
	}
}