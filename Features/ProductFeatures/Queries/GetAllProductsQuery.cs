using MediatR;
using Microsoft.EntityFrameworkCore;
using ProductCQRSApi.Context;
using ProductCQRSApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ProductCQRSApi.Features.ProductFeatures.Commands
{
    public class GetAllProductsQuery: IRequest<IEnumerable<Product>>
    {
        public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, IEnumerable<Product>>
        {
            private readonly IApplicationContext _context;

            public GetAllProductsQueryHandler(IApplicationContext context)
            {
                _context = context;
            }
            public async Task<IEnumerable<Product>> Handle(GetAllProductsQuery query, CancellationToken cancellationToken)
            {
                var productList = await _context.Products.ToListAsync();
                if(productList == null)
                {
                    return null;
                }
                return productList.AsReadOnly();
            }
        }
        
    }
}
