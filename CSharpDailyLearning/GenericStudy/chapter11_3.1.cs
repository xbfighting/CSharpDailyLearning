using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericStudy
{
    public class BinaryTree<T> where T : IComparable<T>
    {
        private Pair<BinaryTree<T>> _SubItems;
        private T _Item;

        public BinaryTree(T item)
        {
            _Item = item;
        }

        public T Item { get; set; }

        // Pair<T> 是一个类型
        public Pair<BinaryTree<T>> SubItems
        {
            get { return _SubItems; }
            set
            {
                var first = value.First.Item;
                if (first.CompareTo(value.Second.Item) < 0)
                {
                    //..
                }
                else
                {
                    //..
                }
                _SubItems = value;
            }
        }
    }
}
