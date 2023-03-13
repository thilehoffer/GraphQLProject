using GraphQL;
using GraphQL.Types;
using GraphQLProject.Interfaces;
using GraphQLProject.Models;
using GraphQLProject.Type;

namespace GraphQLProject.Mutation
{
    public class MenuMutation : ObjectGraphType
    {
        public MenuMutation(IMenu menuService) {
            Field<MenuType>("createMenu",
               arguments: new QueryArguments(new QueryArgument<MenuInputType> { Name = "menu" }),
               resolve: context =>
               { 
                   return menuService.AddMenu(context.GetArgument<Menu>("menu"));
               }); 
        }
    }
}
