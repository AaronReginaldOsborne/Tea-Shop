using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeaShop
{
    // a checkout that you can edit once and will change all instances of it and you call it from everypage
    public static class StaticCheckOutList
    {
        static List<CheckOut> Cart { get; set; }
        static StaticCheckOutList()
        {
            Cart = new List<CheckOut>();
        }
        public static void Add(CheckOut value)
        {
            Cart.Add(value);
        }
        public static void EditQty(int index,int qty)
        {
            Cart[index].Quntity = qty;
            Cart[index].ProductTotal = Cart[index].ProductCost * qty;
        }

        public static void Remove(int index)
        {
            Cart.RemoveAt(index);
        }

        public static List<CheckOut> GetList()
        {
            return Cart;
        }
        public static void SetList(List<CheckOut> json)
        {
            Cart = json;
        }

        public static int Count()
        {
            return Cart.Count();
        }

        public static CheckOut GetByIndex (int Index)
        {
            return Cart[Index];
        }
    }
}
