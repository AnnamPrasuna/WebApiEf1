using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiEf1.Models;
using WebApiEf1.DAL;

namespace WebApiEf1.Controllers
{
    public class ProductController : ApiController
    {
        [HttpGet]
        public List<Product> SelectProduct()
        {
            ProductContext pc = new ProductContext();
            List<Product> lp = pc.Products.ToList();
            return lp;
        }
       
        public Product GetProductById(int Id)
        {
            ProductContext pc = new ProductContext();
            Product p = null;
            p = pc.Products.Find(Id);
            return p;
        }
        [HttpPut]
        public Product UpdateProduct(int Id,Product p)
        {
            ProductContext pc = new ProductContext();
            Product p1 = null;
            p1= pc.Products.Find(Id);
            if(Id==p.Id)
            {
                if(p1!=null)
                {
                    p1.Name = p.Name;
                    p1.Price= p.Price;
                    p1.Quantity= p.Quantity;
                    pc.SaveChanges();
                    return p1;
                }
                else
                {
                    return p1;
                }
            }
            
            return null;

        }
        [HttpDelete]
        public Product RemoveProduct(int Id)
        {
            ProductContext pc = new ProductContext();
            Product p = null;
            p = pc.Products.Find(Id);
            pc.Products.Remove(p);
            pc.SaveChanges();
            return p;

        }

        [HttpPost]
        public Product SaveProduct(Product p)
        {
            ProductContext pc = new ProductContext();
            pc.Products.Add(p);
            pc.SaveChanges();
            return p;
        }


    }
}
