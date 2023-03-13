using GraphQL;
using GraphQL.Types;
using GraphQLProject.Interfaces;
using GraphQLProject.Type;

namespace GraphQLProject.Query
{
    public class MenuQuery : ObjectGraphType
    {
        
        public MenuQuery(IMenu menuService)
        {
            Field<ListGraphType<MenuType>>("menus",
               resolve: context => { return menuService.GetMenus(); }); 
             
        }
    }
}
