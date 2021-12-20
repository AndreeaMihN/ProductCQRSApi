using Microsoft.EntityFrameworkCore;
using ProductCQRSApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductCQRSApi.Context
{
    public interface IApplicationContext
    {
        DbSet<Product>Products { get; set; }
        Task<int> SaveChanges();
    }
}
