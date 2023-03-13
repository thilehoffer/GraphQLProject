using GraphQL;
using GraphQL.Types;
using GraphQLProject.Interfaces;
using GraphQLProject.Type;

namespace GraphQLProject.Query
{
    public class SubMenuQuery : ObjectGraphType
    {
        
        public SubMenuQuery(ISubMenu SubMenuService)
        {
            Field<ListGraphType<SubMenuType>>("submenus",
               resolve: context => { return SubMenuService.GetSubMenus(); });
             
            Field<ListGraphType<SubMenuType>>(
                "submenuById",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "id" }),
                resolve: context =>
                {
                    return SubMenuService.GetSubMenus(context.GetArgument<int>("id"));
                }); 
        }
    }
}
