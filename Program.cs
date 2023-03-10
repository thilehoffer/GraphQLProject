using GraphQL.Server;
using GraphQL.Server.Ui.GraphiQL;
using GraphQL.Types;
using GraphQLProject.Data;
using GraphQLProject.Interfaces;
using GraphQLProject.Mutation;
using GraphQLProject.Query;
using GraphQLProject.Schema;
using GraphQLProject.Services;
using GraphQLProject.Type;
using Microsoft.EntityFrameworkCore;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddTransient<IProduct, ProductService>();
builder.Services.AddTransient<ProductType>();
builder.Services.AddTransient<ProductQuery>();
builder.Services.AddTransient<ProductMutation>();
builder.Services.AddTransient<ISchema, ProductSchema>();

builder.Services.AddGraphQL(options => {
    options.EnableMetrics = false; }).AddSystemTextJson();
 


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<GraphQLDbContext>(
    option => option.UseSqlServer(
        @"Data Source= (localdb)\MSSQLLocalDB;Initial Catalog=GraphQLDb;Integrated Security = True"
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
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<GraphQLDbContext>();
    dbContext.Database.EnsureCreated();
}
app.UseGraphQLGraphiQL("/graphql");
app.UseGraphQL<ISchema>();
app.Run();
