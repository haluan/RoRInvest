using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Data.Linq;

namespace RoRInvest
{
    public class ProductDataContext :DataContext
    {
        public const string ConnectionString = "Data Source=isostore:/Product.sdf";
        public ProductDataContext() : base(ConnectionString)
        {
        }
        public Table<Product> Products{get;set;}

    }
}
