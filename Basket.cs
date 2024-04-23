using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketCheckout
{
    public class Basket
    {
        private Dictionary<string, int> _items;
        public Basket()
        {
            _items = new Dictionary<string, int>();
        }

        public void AddItem(string item)
        {
            if (_items.ContainsKey(item))
            {
                _items[item]++;
            }
            else
            {
                _items[item] = 1;
            }
        }

        public void RemoveItem(string item)
        {
            if (_items.ContainsKey(item))
            {
                _items[item]--;
                if (_items[item] == 0)
                {
                    _items.Remove(item);
                }
            }
        }
        public int GetQuantity(string item)
        {
            if (_items.ContainsKey(item))
            {
                return _items[item];
            }
            return 0;
        }

        public Dictionary<string, int> GetItems()
        {
            return _items;
        }
    }
}