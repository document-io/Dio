using System.Linq;
using GraphQL.Types;
using GraphQL.Server.Ui.Voyager;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Phema.Validation;

namespace DocumentIO.Web
{
	public class Startup
	{
		private readonly IConfiguration configuration;

		public Startup(IConfiguration configuration)
		{
			this.configuration = configuration;
		}

/*
query {
  boards {
		columns {
			cards {
			}
		}
	}

	organization {
		boards {
			columns {
				cards {
				}
			}
		}

		invites {
		}

		accounts {
		}
	}
}
*/

		public void ConfigureServices(IServiceCollection services)
		{
			services.AddDatabaseContext(configuration.GetConnectionString("PostgreSQL"));

			services.AddDocumentIOGraphQL();
			services.AddDocumentIOGraphQLAuthorization();

			services.AddAuthorization()
				.AddDocumentIOAuthentication();

			services.AddValidation(options =>
				options.ValidationPartResolver = ValidationPartResolvers.CamelCase);

			services.AddHttpContextAccessor();
			services.AddGraphQLValidation<CreateOrganizationModel, CreateOrganizationModelValidation>();
			services.AddGraphQLValidation<CreateAccountModel, CreateAccountModelValidation>();
			services.AddGraphQLValidation<LoginAccountModel, LoginAccountModelValidation>();
			services.AddGraphQLValidation<UpdateAccountModel, UpdateAccountModelValidation>();
			services.AddGraphQLValidation<CreateInviteModel, CreateInviteModelValidation>();
			services.AddGraphQLValidation<CreateBoardModel, CreateBoardModelValidation>();
			services.AddGraphQLValidation<UpdateBoardModel, UpdateBoardModelValidation>();
			services.AddGraphQLValidation<CreateColumnModel, CreateColumnModelValidation>();
			services.AddGraphQLValidation<UpdateColumnModel, UpdateColumnModelValidation>();

			services.AddSpaStaticFiles(options =>
			{
				options.RootPath = configuration.GetValue<string>("Spa:RootPath");
			});
		}

		public void Configure(IApplicationBuilder app, IWebHostEnvironment environment)
		{
			app.UseDatabaseMigrations();
			app.UseHttpsRedirection();

			app.UseAuthentication();
			app.UseAuthorization();

			app.Use(async (context, next) =>
			{
				await next();

				var databaseContext = context.RequestServices.GetRequiredService<DatabaseContext>();

				var shouldSaveChanges = databaseContext
					.ChangeTracker
					.Entries()
					.Any(x => x.State == EntityState.Added || x.State == EntityState.Deleted || x.State == EntityState.Modified);

				if (shouldSaveChanges)
				{
					await databaseContext.SaveChangesAsync();
				}
			});
			
			app.UseGraphQL<ISchema>();
			app.UseGraphiQLServer();
			app.UseGraphQLVoyager();

			app.UseSpaStaticFiles();
			app.UseSpa(spa =>
			{
				spa.Options.SourcePath = configuration.GetValue<string>("Spa:SourcePath");

				if (environment.IsDevelopment())
				{
					spa.UseReactDevelopmentServer(configuration.GetValue<string>("Spa:NpmScript"));
				}
			});
		}
	}
}