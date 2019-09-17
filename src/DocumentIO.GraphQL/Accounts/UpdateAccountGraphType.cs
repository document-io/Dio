using GraphQL.Types;

namespace DocumentIO
{
    public class UpdateAccountGraphType : InputObjectGraphType<UpdateAccountModel>
    {
        public UpdateAccountGraphType()
        {
            Name = "UpdateAccount";
            
            Field(x => x.Email, nullable: true);
            Field(x => x.Password, nullable: true);
            Field(x => x.FirstName, nullable: true);
            Field(x => x.MiddleName, nullable: true);
            Field(x => x.LastName, nullable: true);
        }
    }
}