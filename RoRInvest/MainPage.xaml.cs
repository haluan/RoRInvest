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
            setControl();
        }
        private static Int16 sumofschemeCount = 0;


        public Int16 getSumOfSchemeCount()
        {
            return sumofschemeCount;
        }
        private void getNavigate(String xaml)
        {
            NavigationService.Navigate(new Uri("/"+xaml, UriKind.Relative));
        }

        private void ApplicationBarMenuItem_Click(object sender, EventArgs e)
        {
            if (manyPlan.Text.IndexOf("-") != -1)
            {
                MessageBox.Show("Negative value not allowed");
            }
            else if (manyPlan.Text.IndexOf(".") != -1)
            {
                MessageBox.Show("Number format not allowed!");
            }
            else
            {
                try
                {
                    PhoneApplicationService.Current.State["yourparam"] = Convert.ToInt64(manyPlan.Text);
                    NavigationService.Navigate(new Uri("/NpvForm.xaml", UriKind.Relative));
                    manyPlan.Text = "";
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Your data input is empty or false");
                }
            }
           
        }

        private void ApplicationBarMenuItem_Click_1(object sender, EventArgs e)
        {

            if (manyPlan.Text.IndexOf("-") != -1 )
            {
                MessageBox.Show("Negative value not allowed");
            }
            else if (manyPlan.Text.IndexOf(".") != -1)
            {
                MessageBox.Show("Number format not allowed!");
            }
            else
            {
                try
                {
                    PhoneApplicationService.Current.State["yourparam"] = Convert.ToInt64(manyPlan.Text);
                    NavigationService.Navigate(new Uri("/FutureValueForm.xaml", UriKind.Relative));
                    manyPlan.Text ="";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Your data input is empty or false");
                }
            }
        }

        private void setControl()
        {
            h.setInputScope(manyPlan);

        }

        private void SavedPlan_CLick(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/SavedData.xaml", UriKind.Relative));
        }

        private void Help(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/Help.xaml", UriKind.Relative));
        }

        private void About(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/About.xaml", UriKind.Relative));
        }

       
    }
}