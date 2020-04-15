using System;

namespace DnDesignPattern.Model
{
    public class InvalidItemException : Exception
    {
        public InvalidItemException(string str) : base(str)
        {}

        public InvalidItemException(string str, Exception inner) :  base(str, inner)
        {}
    }
}
