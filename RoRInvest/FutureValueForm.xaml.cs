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

namespace RoRInvest
{
    public partial class futureValue : PhoneApplicationPage
    {
        Int64 init = 0;
        Int64 counter=2;
        private helper h;
        private bool check;// jika true maka init bertambah
        private List<Product> productList = new List<Product>();
        public futureValue()
        {
            InitializeComponent();
            init = (Int64)PhoneApplicationService.Current.State["yourparam"];
            h = new helper();
            this.setControl();
            check = false;
        }

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
                }
                else
                {
                    PhoneApplicationService.Current.State["yourparam"] = productList;
                    NavigationService.Navigate(new Uri("/ShowDataFV.xaml", UriKind.Relative));
                    this.clearTextBox();
                }
            }
        }
        private void setControl()
        {
            h.setInputScope(initialCost);
            h.setInputScope(lifetimeProject);
            h.setInputScope(interest);

        }
        private void insertData()
        {
            Product prod = new Product();
            try
            {
                prod.Name = name.Text;
                double varInitialCost = Convert.ToDouble(initialCost.Text);
                prod.LifetimeProject = Convert.ToInt64(lifetimeProject.Text);
                prod.Marr = Convert.ToDouble(interest.Text);
                double varFutureValue = varInitialCost * (Math.Pow((1 + (prod.Marr / (double)100)), prod.LifetimeProject));
                prod.InitialCost = string.Format(CultureInfo.CurrentCulture, "{0:C}", varInitialCost);
                prod.FutureValue = string.Format(CultureInfo.CurrentCulture, "{0:C}", varFutureValue);
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
            interest.Text = "";
            lifetimeProject.Text = "";
            name.Text = "";
        }
        private void ApplicationBarIconButton_Click_1(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
        }
    }
}
