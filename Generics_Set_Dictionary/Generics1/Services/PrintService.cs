using System;
using System.Collections.Generic;
using System.Text;

namespace Generics1.Services
{
    internal class PrintService<Type>
    {
        private Type[] _values = new Type[10];
        private int _count = 0;

        public void AddValues(Type values)
        {
            if (_count == 10)
            {
                throw new InvalidOperationException("PrintServicec is full");
            }
            _values[_count] = values;
            _count++;
        }

        public Type GetFirst() 
        {
            if (_count == 0)
            {
                throw new InvalidOperationException("PrintServicec is empty");
            }
            return _values[0];
        }

        public void Print()
        {
            Console.Write("[");
            for (int i = 0; i < _count - 1; i++)
            {
                Console.Write(_values[i] + ", ");
            }
            if(_count > 0)
            {
                Console.Write(_values[_count - 1]);
            }
            Console.WriteLine("]");
        }
    }
}
