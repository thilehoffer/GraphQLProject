using GraphQL.Types;

namespace GraphQLProject.Type
{
    public class SubMenuInputType : InputObjectGraphType   
    {
        public SubMenuInputType()
        {
            Field<IntGraphType>("id");
            Field<StringGraphType>("name"); 
            Field<StringGraphType>("imageUrl");
            Field<StringGraphType>("description");
            Field<FloatGraphType>("price");
            Field<IntGraphType>("menuId");
        }
    }
}
