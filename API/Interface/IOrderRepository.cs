using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using API.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Interface
{
    public interface IOrderRepository
    {
         Task<bool> SaveAll();
         //Task<List<AppUser>> GetOrderById(int id);
         Task<List<ProductCart>> getOrderByUserId(string username);

    }
}