using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Globalization;
//using Coding4Fun.Toolkit.Controls;

namespace RoRInvest
{
    public partial class npv : PhoneApplicationPage
    {
        Int64 init;
        Int64 counter=2;
        private bool check;// jika true maka init bertambah
        private helper h;
        private List<Product> productList = new List<Product>();
        public npv()
        {
            InitializeComponent();
            init=(Int64)PhoneApplicationService.Current.State["yourparam"];
            h = new helper();           
            this.setControl();
            check = false;
        }

        private void insertData()
        {
            Product prod = new Product();
            try
            {
                prod.Name = name.Text;
                double varInitialCost = Convert.ToDouble(initialCost.Text);
                double varAnnualProfit = Convert.ToDouble(annualProfit.Text);
                prod.LifetimeProject = Convert.ToInt64(lifetimeProject.Text);
                prod.Marr = Convert.ToDouble(marr.Text);
                double counter = 0;
                double temp2 = (1 + (prod.Marr / (double)100));

                for (int i = 1; i <= prod.LifetimeProject; i++)
                {
                    double temp = varAnnualProfit / (double)Math.Pow(temp2, i);
                    counter += temp;
                }
                double varNpv = counter - varInitialCost;
                
                if (varNpv <= -1)
                {
                    prod.Status = "Not Qualified";
                }
                else
                {
                    prod.Status = "Qualified";
                }
                prod.countIRR(varInitialCost, varAnnualProfit, prod.LifetimeProject);
                prod.InitialCost = string.Format(CultureInfo.CurrentCulture, "{0:C}", varInitialCost);
                prod.AnnualProfit = string.Format(CultureInfo.CurrentCulture, "{0:C}", varAnnualProfit);
                prod.Npv = string.Format(CultureInfo.CurrentCulture, "{0:C}", varNpv);
                productList.Add(prod);
                check = true;
            }
            catch
            {
                MessageBox.Show("Data invalid");
                check = false;
            }
        }
        private void clearTextBox()
        {
            initialCost.Text = "";
            annualProfit.Text = "";
            lifetimeProject.Text = "";
            name.Text = "";
            marr.Text = "";
        }
        //private static ToastPrompt GetToast()
         //{
            //return new ToastPrompt
            //{
              //TextOrientation = System.Windows.Controls.Orientation.Vertical,
              //Message = "Please, FIll Next Plan"
            //};
        //}
        private void ApplicationBarIconButton_Click(object sender, EventArgs e)
        {
            this.insertData();
            if (check)
            {
                if (counter <= init)
                {
                    numbPP.Text = "Plan " + counter.ToString();

                    this.clearTextBox();
                    counter++;
                   // var toast = GetToast();
                   // toast.TextWrapping = TextWrapping.Wrap;

                    //toast.Show();
                }
                else
                {
                    PhoneApplicationService.Current.State["yourparam"] = productList;
                    NavigationService.Navigate(new Uri("/ShowDataNpv.xaml", UriKind.Relative));

                }
            }
        }

        private void setControl()
        {
            h.setInputScope(initialCost);
            h.setInputScope(lifetimeProject);
            h.setInputScope(annualProfit);
            h.setInputScope(marr);

        }

        private void ApplicationBarIconButton_Click_1(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
        }
    }
}
