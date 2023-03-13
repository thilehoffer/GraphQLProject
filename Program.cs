using GraphQL.Server; 
using GraphQL.Types;
using GraphQLProject.Data;
using GraphQLProject.Interfaces;
using GraphQLProject.Mutation;
using GraphQLProject.Query;
using GraphQLProject.Schema;
using GraphQLProject.Services;
using GraphQLProject.Type;
using Microsoft.EntityFrameworkCore;
 

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddTransient<IMenu, MenuService>();
builder.Services.AddTransient<ISubMenu, SubMenuService>();
builder.Services.AddTransient<IReservation, ReservationService>();

builder.Services.AddTransient<MenuType>();
builder.Services.AddTransient<SubMenuType>();
builder.Services.AddTransient<ReservationType>();

builder.Services.AddTransient<MenuQuery>();
builder.Services.AddTransient<SubMenuQuery>();
builder.Services.AddTransient<ReservationQuery>(); 
builder.Services.AddTransient<RootQuery>();

builder.Services.AddTransient<MenuInputType>();
builder.Services.AddTransient<SubMenuInputType>();
builder.Services.AddTransient<ReservationInputType>();


builder.Services.AddTransient<MenuMutation>();
builder.Services.AddTransient<SubMenuMutation>();
builder.Services.AddTransient<ReservationMutation>();
builder.Services.AddTransient<RootMutation>();
builder.Services.AddTransient<ISchema, RootSchema>();

builder.Services.AddGraphQL(options => {
    options.EnableMetrics = false; }).AddSystemTextJson();
 


//// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<GraphQLDbContext>(
    option => option.UseSqlServer(
        @"Data Source= (localdb)\MSSQLLocalDB;Initial Catalog=CoffeeShopDb;Integrated Security = True"
    )) ;


var app = builder.Build();

//// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}


//app.UseHttpsRedirection();

//app.UseAuthorization();

//app.MapControllers();
//using (var scope = app.Services.CreateScope())
//{
//    var dbContext = scope.ServiceProvider.GetRequiredService<GraphQLDbContext>();
//    dbContext.Database.EnsureCreated();
//}
app.UseGraphQLGraphiQL("/graphql");
app.UseGraphQL<ISchema>();
app.Run();
