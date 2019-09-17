using GraphQL.Types;

namespace DocumentIO
{
    public class CreateAccountGraphType : InputObjectGraphType<CreateAccountModel>
    {
        public CreateAccountGraphType()
        {
            Name = "CreateAccount";

            Field(x => x.Identifier);
            Field(x => x.Password);
            Field(x => x.FirstName);
            Field(x => x.MiddleName);
            Field(x => x.LastName);
        }
    }
}