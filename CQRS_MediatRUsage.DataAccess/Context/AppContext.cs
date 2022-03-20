using CQRS_MediatRUsage.Entities.Concrete;
using System;
using System.Collections.Generic;

namespace CQRS_MediatRUsage.DataAccess.Context
{
    public static class AppContext 
    {
       static List<Product> product = new List<Product> {
         new() { Id = Guid.NewGuid(), Name = "Example 1", Price = 150, Quantity = 20, CreateTime = DateTime.Now.AddDays(1) },
         new() { Id = Guid.NewGuid(), Name = "Example 2", Price = 300, Quantity = 40, CreateTime = DateTime.Now.AddDays(2) },
         new() { Id = Guid.NewGuid(), Name = "Example 3", Price = 450, Quantity = 60, CreateTime = DateTime.Now.AddDays(3) }
        };

        public static List<Product> Products => product;
    }
}
