using System;

namespace DnDesignPattern.Controller
{
    public class ShopLoaderException : Exception
    {
        public ShopLoaderException(string str) : base(str)
        {}
        public ShopLoaderException(string str, Exception inner) : base(str, inner)
        {}
    }
}
