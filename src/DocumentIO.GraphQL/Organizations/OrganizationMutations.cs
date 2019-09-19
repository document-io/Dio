using GraphQL.Types;

namespace DocumentIO
{
	public static class OrganizationMutations
	{
		public static void AddOrganizationMutations(this DocumentIOMutations mutations)
		{
			mutations.Field<ReadOrganizationGraphType, ReadOrganizationModel>("createOrganization")
				.Argument<NonNullGraphType<CreateOrganizationGraphType>>("payload")
				.ResolveWithValidation(async context =>
				{
					var databaseContext = context.GetDatabaseContext();
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