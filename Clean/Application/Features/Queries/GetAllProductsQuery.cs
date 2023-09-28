using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Queries
{
    public class GetAllProductsQuery : IFeatureCommand
    {
        public class GetAllProductsQueryHandler
        {
            private readonly IApplicationContext _context;

            public GetAllProductsQueryHandler(IApplicationContext context)
            {
                _context = context;
            }

            public async Task<IEnumerable<Product>> Handle(GetAllProductsQuery query)
            {
                var productList = await _context.Products.ToListAsync();

                return productList?.AsReadOnly();
            }
        }
    }
}
