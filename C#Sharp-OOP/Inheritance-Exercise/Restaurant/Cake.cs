using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    public class Cake : Dessert
    {
        private const double cakegrams = 250;
        private const double cakecalories = 1000;
        private const decimal cakeprice = 5;
        public Cake(string name, decimal price, double grams, double calories) : base(name, cakeprice, cakegrams, cakecalories)
        {
            
        }
    }
}
