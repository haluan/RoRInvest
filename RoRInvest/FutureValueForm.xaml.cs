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
        //menampung jumlah rencana yang diajukan
        Int64 init = 0;
        //counter langsung diasing 2 karena minimal perulangan ada satu kali
        Int64 counter=2;
        private helper h;
        // jika true maka init bertambah
        private bool check;
        private List<Product> productList = new List<Product>();
        public futureValue()
        {
            InitializeComponent();
            //mendapatkan nilai dari form sebelumnya
            init = (Int64)PhoneApplicationService.Current.State["yourparam"];
            h = new helper();
            //memanggil fungsi setControl
            this.setControl();
            //inisialisasi check ke dalam false
            check = false;
        }

        private void ApplicationBarIconButton_Click(object sender, EventArgs e)
        {
            //memasukkan data ketika di click
            this.insertData();
            //selama check true 
            if (check)
            {
                //jika counter masih kurang/samadengan init
                if (counter <= init)
                {
                    //merubah nomor rencana
                    numbPP.Text = "Plan " + counter.ToString();
                    //mengosongkan textbox
                    this.clearTextBox();
                    //counter ditambah
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
        //mengeset keyboard ke numerical
        private void setControl()
        {
            h.setInputScope(initialCost);
            h.setInputScope(lifetimeProject);
            h.setInputScope(interest);
            

        }
        //memasukkan data ke List
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
       //mengahpus isi textbox
        private void clearTextBox()
        {
            initialCost.Text = "";
            interest.Text = "";
            lifetimeProject.Text = "";
            name.Text = "";
        }
        //membatalkan aksi
        private void ApplicationBarIconButton_Click_1(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
        }
    }
}
