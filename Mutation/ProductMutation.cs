﻿using GraphQL;
using GraphQL.Types;
using GraphQLProject.Interfaces;
using GraphQLProject.Models;
using GraphQLProject.Type;

namespace GraphQLProject.Mutation
{
    public class ProductMutation : ObjectGraphType
    {
        public ProductMutation(IProduct productService)
        {

            Field<ProductType>("createProduct",
               arguments: new QueryArguments(new QueryArgument<ProductInputType> { Name = "product" }),
               resolve: context =>
               {
                   var productObj = context.GetArgument<Product>("product");
                   return productService.AddProduct(productObj);
               });

            Field<ProductType>("updateProduct",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "id" },
                new QueryArgument<ProductInputType> { Name = "product" }),
                resolve: context =>
                {
                    var productObj = context.GetArgument<Product>("product");
                    var productId = context.GetArgument<int>("id");
                    return productService.UpdateProduct(productId, productObj);
                });

            Field<StringGraphType>("deleteProduct",
                  arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "id" }),
                  resolve: context =>
                  {
                      var productId = context.GetArgument<int>("id");
                      productService.DeleteProduct(productId);
                      return $"Product with if of {productId} has been deleted";
                  });


        }


    }
}
