using System;
using BlogSystem.Models;

namespace Problem01.BlogSystemApplicationWeb
{
    public static class ConvertTo
    {
        public static Gender GenderType(string gender)
        {
            switch (gender)
            {
                case "male": return Gender.Male;
                case "female": return Gender.Female;
                case "other": return Gender.Other;
                default: throw new ArgumentException("wrong gender type");
            }
        }
    }
}