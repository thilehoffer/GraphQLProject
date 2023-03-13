using GraphQL.Types;
using GraphQLProject.Query;

namespace GraphQLProject.Mutation
{
    public class RootMutation : ObjectGraphType 
    {
        public RootMutation()
        {
            Field<MenuMutation>("menuMutation", resolve: context => new { });
            Field<SubMenuMutation>("submenuMutation", resolve: context => new { });
            Field<ReservationMutation>("reservationMutation", resolve: context => new { });
        }
    }
}
