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
        public double Irr{get; set;}
        public Int64 LifetimeProject { get; set; }
        public String Status { get; set; }

        //menghitung Internal rate of return
        public void countIRR(double InitialCost, double AnnualProfit, Int64 LifetimeProject)
        {
            double Interest=0;
            double actual = InitialCost / AnnualProfit;
            do
            {
                double x = (Math.Pow((1 + (Interest / (double)100)), LifetimeProject) - 1)/(double)((Interest/(double)100)*(Math.Pow((1+((Interest/(double)100))),LifetimeProject)));
                if ((x - actual) < 0.001)
                {
                    break;
                }
                else
                {
                    Interest += 0.01;
                }
            } while (1 != 0);
            this.Irr = Interest;
            
        }

    }
}
