using System;
using System.Linq;
using System.Collections.Generic;

//Setting up the basket/checkout so that books and quanitites can be saved

namespace mission10.Models
{
    public class Basket
    {
        public List<BasketLineItem> Items { get; set; } = new List<BasketLineItem>();

        public void AddItem(Books book, int qty)
        {
            BasketLineItem line = Items
                .Where(b => b.Books.BookId == book.BookId)
                .FirstOrDefault();

            if (line == null)
            {
                Items.Add(new BasketLineItem
                {
                    Books = book,
                    Quantity = qty
                });
            }
            else
            {
                line.Quantity += qty;
            }
        }

        public double CalculateTotal()
        {
            double sum = Items.Sum(x => x.Quantity * 25);

            return sum;
        }
    }

    public class BasketLineItem
    {
        public int LineID { get; set; }
        public Books Books { get; set; }
        public int Quantity { get; set; }
    }
}

