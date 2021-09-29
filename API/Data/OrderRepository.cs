using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs;
using API.Entities;
using API.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class OrderRepository : IOrderRepository
    {
        private readonly DataContext _context;
        public OrderRepository(DataContext context)
        {
            this._context = context;
        }

        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;
            
        }

        public async Task<List<ProductCart>> getOrderByUserId(string username)
        {
            var query = _context.ProductCarts.AsQueryable();

            query = query.Where(u => u.UserId == username);
            if(query == null) return null;
            
            return await query.ToListAsync();
        }

       
    }
}