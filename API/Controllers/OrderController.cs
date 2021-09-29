using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using API.Data;
using API.DTOs;
using API.Entities;
using API.Extensions;
using API.Interface;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("/api/order")]
    public class OrderController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IOrderRepository _orderRepository;
        private readonly IBookRepository _bookRepository;
        public OrderController(DataContext context, IOrderRepository orderRepository, IBookRepository bookRepository)
        {
            this._bookRepository = bookRepository;
            this._orderRepository = orderRepository;
            this._context = context;
        }

        [HttpPost]
        public IActionResult CreateOrder([FromBody] OrderDTO orderDTO)
        {

            ProductCart ProductCartEntity = new ProductCart();
            ProductCartEntity.bookserialno = orderDTO.bookserialno;
            ProductCartEntity.Count = orderDTO.Count;
            ProductCartEntity.Price = orderDTO.Price;
            ProductCartEntity.Total = orderDTO.Total;
            String UUID = Guid.NewGuid().ToString();
            ProductCartEntity.Transaction_id = UUID;
            ProductCartEntity.UserId = orderDTO.UserId;
            
             _context.Add(ProductCartEntity);
            bool result = _orderRepository.SaveAll().Result;

            if(!result) return BadRequest("Order failed!!");

            return Ok();

        }

        [HttpGet("{id}/")]
        public ActionResult<List<OrderDTO>> getUserTransactions(string id)
        {
             Task<List<ProductCart>> list =  _orderRepository.getOrderByUserId(id);
             List<ProductCart> listresult = list.Result;
             List<OrderDTO> transactionList = new List<OrderDTO>();
              for(int i =0;i<listresult.Count;i++)
              {
                  OrderDTO orderDTO = new OrderDTO();
                    orderDTO.Transaction_id  = listresult[i].Transaction_id;
                    orderDTO.Price = listresult[i].Price;
                     orderDTO.bookserialno = listresult[i].bookserialno ; //[TODO]
                    orderDTO.Count = listresult[i].Count;
                    orderDTO.Total  = listresult[i].Total;        
                    orderDTO.UserId  = listresult[i].UserId;
                    
                    transactionList.Add(orderDTO);
              }


             return transactionList;
        }



    }
}