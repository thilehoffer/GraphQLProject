using GraphQL.Types;
using GraphQLProject.Models;

namespace GraphQLProject.Type
{
    public class SubMenuType : ObjectGraphType<SubMenu>
    {
        public SubMenuType() {
            Field(s => s.Id);
            Field(s => s.Name);
            Field(s => s.Description);
            Field(s => s.ImageUrl);
            Field(s => s.Price);
            Field(s => s.MenuId);
        }
    }
}
