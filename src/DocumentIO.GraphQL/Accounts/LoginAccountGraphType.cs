using GraphQL.Types;

namespace DocumentIO
{
    public class LoginAccountGraphType : InputObjectGraphType<LoginAccountModel>
    {
        public LoginAccountGraphType()
        {
            Name = "LoginAccount";
            
            Field(x => x.Email);
            Field(x => x.Password);
        }
    }
}