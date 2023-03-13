using GraphQL.Types;
using GraphQLProject.Models;

namespace GraphQLProject.Type
{
    public class ReservationType :ObjectGraphType<Reservation>
    {
        public ReservationType() {
            Field(r => r.Id);
            Field(r => r.Name);
            Field(r => r.Phone);
            Field(r => r.Email);
            Field(r => r.TotalPeople);
            Field(r => r.Time);
            Field(r => r.Date);
        }    
    }
}
