using GraphQL.Types;
using GraphQLProject.Models;

namespace GraphQLProject.Type
{
    public class ProductType : ObjectGraphType<Product>
    {
        public ProductType() {
            Field(f => f.Id);
            Field(f => f.Name);
            Field(f => f.Price);
        }
    }
}
