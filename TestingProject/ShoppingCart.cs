using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace TestingProject
{
    internal class ShoppingCart
    {
        private Dictionary<string, double> _items = new Dictionary<string, double>();

        private double _discount = 0; 

        public bool AddItem(string name, double value)
        {
            if (_items.ContainsKey(name))
            {
                return false;
            }
            else
            {
                _items.Add(name, value);
                return true;
            }
        }

        public double CalculateTotalPrice()
        {
            double totalPrice = 0;
            foreach (string key in _items.Keys)
            {
                totalPrice += _items[key];
            }
            return Math.Round(totalPrice - (totalPrice * _discount), 2); 
        }

        public double ApplyDiscount(double discount)
        {
            if ((discount < 0) || (discount > 1)) {
                throw new ArgumentException("Discount out of range"); 
             }

            _discount = discount;
            return _discount; 
        }

    }
}
