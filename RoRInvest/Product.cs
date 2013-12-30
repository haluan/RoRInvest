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
namespace RoRInvest
{
    public class Product
    {
        //private double initialCost, futureValue, irr ,annualProfit, marr, compoundAmount, npv;
        //private String name;
        //private Int64 lifetimeProject;
        
        public String InitialCost { get; set; }
        public String FutureValue { get; set; }
        public String AnnualProfit{get;set;}
        public double Marr { get; set; }
        public String Npv { get; set; }
        public String Name { get; set; }
        public Int64 LifetimeProject { get; set; }
        public String Status { get; set; }



    }
}
