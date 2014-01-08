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

namespace RoRInvest
{
    public partial class MainPage : PhoneApplicationPage
    {
        helper h ;
        // Constructor
        public MainPage()
        {
            InitializeComponent();
            h = new helper();
            //mengesset keyboard ke numerical
            setControl();
        }
        //inisialsi jumlah rencana yang dikehendaki
        private static Int16 sumofschemeCount = 0;


        public Int16 getSumOfSchemeCount()
        {
            return sumofschemeCount;
        }
        
        //ke npv form
        private void ApplicationBarMenuItem_Click(object sender, EventArgs e)
        {
            //pengecekan nilai negatif
            if (manyPlan.Text.IndexOf("-") != -1)
            {
                MessageBox.Show("Negative value not allowed");
            }
            //pengecekan awalan "."
            else if (manyPlan.Text.IndexOf(".") != -1)
            {
                MessageBox.Show("Number format not allowed!");
            }
            else
            {
                try
                {
                    //mengirimkan data ke form selanjutnya
                    PhoneApplicationService.Current.State["yourparam"] = Convert.ToInt64(manyPlan.Text);
                    //pindah ke form berikutnya
                    NavigationService.Navigate(new Uri("/NpvForm.xaml", UriKind.Relative));
                    manyPlan.Text = "";
                }
                catch(Exception ex)
                {
                    //jika data masukkan kosong/salah
                    MessageBox.Show("Your data input is empty or false");
                }
            }
           
        }

        //pindah ke FV form
        private void ApplicationBarMenuItem_Click_1(object sender, EventArgs e)
        {
            //pengecekan nilai negatif
            if (manyPlan.Text.IndexOf("-") != -1 )
            {
                MessageBox.Show("Negative value not allowed");
            }
            //pengecekan awalan "."
            else if (manyPlan.Text.IndexOf(".") != -1)
            {
                MessageBox.Show("Number format not allowed!");
            }
            else
            {
                try
                {
                    //mengirimkan data ke form selanjutnya
                    PhoneApplicationService.Current.State["yourparam"] = Convert.ToInt64(manyPlan.Text);
                    //pindah ke form berikutnya
                    NavigationService.Navigate(new Uri("/FutureValueForm.xaml", UriKind.Relative));
                    manyPlan.Text ="";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Your data input is empty or false");
                }
            }
        }
        //mengeset keyboard ke numerical
        private void setControl()
        {
            h.setInputScope(manyPlan);

        }

        //melihat form yang di save
        private void SavedPlan_CLick(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/SavedData.xaml", UriKind.Relative));
        }
        //melihat form help
        private void Help(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/Help.xaml", UriKind.Relative));
        }
        //melihat form about
        private void About(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/About.xaml", UriKind.Relative));
        }

       
    }
}