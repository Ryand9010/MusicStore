using FinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinalProject.Controllers
{
    public class ShoppingCartController : Controller
    {

        StoreDB storeDB = new StoreDB();
        private string strCart = "Cart";
        // GET: ShoppingCart
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult OrderNow(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            if (Session[strCart] == null)
            {
                List<Cart> lsCart = new List<Cart>
                {
                    new Cart(storeDB.Products.Find(id),1)
                };
                Session[strCart] = lsCart;
            }
            else
            {
                List<Cart> lsCart = (List<Cart>)Session[strCart];
                int check = isExistingCheck(id);

                if (check == -1)
                {
                    lsCart.Add(new Cart(storeDB.Products.Find(id), 1));
                }
                else
                {
                    lsCart[check].Quantity++;
                }

                Session[strCart] = lsCart;
            }
            return View("Index");
        }



        private int isExistingCheck (int? id)
        {
            List<Cart> lsCart = (List<Cart>)Session[strCart];
            for (int i = 0; i < lsCart.Count; i++)
            {
                if (lsCart[i].Product.ProductId == id)
                {
                    return i;
                }
            }
            return -1;
        }


        public ActionResult Remove(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            int check = isExistingCheck(id);
            List<Cart> lsCart = (List<Cart>) Session[strCart];
            lsCart.RemoveAt(check);
            return View("Index");
        }

        public ActionResult Checkout(FormCollection frc)
        {
            return View("Checkout");
        }

        public ActionResult ProcessOrder(FormCollection frc)
        {
            
            List<Cart> lsCart = (List<Cart>)Session[strCart];
            //1. Savew the order into Order Table
            Order order = new Order()
            {
                FirstName = frc["cusFName"],
                LastName = frc["cusLName"],
                Phone = frc["cusPhone"],
                Email = frc["cusEmail"],
                Address = frc["cusAddress"],
                City = frc["cusCity"],
                State = frc["cusState"],
                PostalCode = frc["cusPostalCode"],
                OrderDate= DateTime.Now,

            };
            storeDB.Orders.Add(order);
            storeDB.SaveChanges();
            //2. Save the order detail into the Order Detail table
            foreach(Cart cart in lsCart)
            {
                OrderDetail orderDetail = new OrderDetail()
                {
                    OrderId = order.OrderId,
                    ProductId = cart.Product.ProductId,
                    Quantity = cart.Quantity,
                    UnitPrice = cart.Product.Price
                };
                storeDB.OrderDetails.Add(orderDetail);
                storeDB.SaveChanges();
            }
            //3.Remove the shopping cart session
            Session.Remove(strCart);
            return View("OrderSuccess");
        }

    }
}