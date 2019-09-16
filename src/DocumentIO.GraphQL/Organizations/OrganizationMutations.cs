namespace DocumentIO
{
	public static class OrganizationMutations
	{
		public static void AddOrganizationMutations(this DocumentIOMutation mutation)
		{
			mutation.Field<ReadOrganizationGraphType, ReadOrganizationModel>()
				.Name("createOrganization")
				.Argument<CreateOrganizationGraphType>("payload")
				.ResolveAsync(async context =>
				{
					var databaseContext = context.GetUserContext().DatabaseContext;

					var model = context.GetArgument<CreateOrganizationModel>("payload");
					var organization = await model.Create(databaseContext);

					await databaseContext.SaveChangesAsync();

					return new ReadOrganizationModel
					{
						Id = organization.Id,
						Name = organization.Name
					};
				});
		}
	}
}