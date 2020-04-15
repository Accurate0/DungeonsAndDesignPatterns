using System;

namespace DnDesignPattern.Model
{
    public class PlayerInventoryException : Exception
    {
        public PlayerInventoryException(string str) : base(str)
        {}
    }
}
