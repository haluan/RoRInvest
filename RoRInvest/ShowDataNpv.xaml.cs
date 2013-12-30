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
    public partial class ShowDataNpv : PhoneApplicationPage
    {
        
        private List<Product> lis;
        public ShowDataNpv()
        {
            InitializeComponent();
            lis = new List<Product>();
            lis =(List<Product>) PhoneApplicationService.Current.State["yourparam"];
            this.targetOn.ItemsSource = lis;
            this.targetSaved.ItemsSource = (List<NetPresValue>) this.GetNpv();
        }

      
        public IList<NetPresValue> GetNpv()
        {
            IList<NetPresValue> npvList = null;
            using (NpvDataContext context = new NpvDataContext())
            {
                try
                {
                    IQueryable<NetPresValue> query = from n in context.Npv select n;
                    npvList = query.ToList();
                }
                catch
                {
                }
            }
            return npvList;
        }

        private void insertData(Product p)
        {
            using (NpvDataContext context = new NpvDataContext())
            {
                if (p != null)
                {
                    NetPresValue npv = new NetPresValue();
                    npv.InitialCost = p.InitialCost;
                    npv.Name = p.Name;
                    npv.AnnualProfit = p.AnnualProfit;
                    npv.Marr = p.Marr;
                    npv.LifetimeProject = p.LifetimeProject;
                    npv.Npv = p.Npv;
                    npv.Status = p.Status;
                    try
                    {
                       
                        context.Npv.InsertOnSubmit(npv);
                        context.SubmitChanges();
                        this.targetSaved.ItemsSource = (List<NetPresValue>)this.GetNpv();
                    }
                    catch
                    {
                        MessageBox.Show("P : " + p.Name + " NPV : " + npv.Name);
                        if (!context.DatabaseExists())
                        {
                            context.CreateDatabase();
                        }
                    }

                }
                else
                {
                    MessageBox.Show("NOTHING");
                }

            }
        }

        private void StackPanel_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            if (MessageBox.Show("Are you sure?", "Save this plan?", MessageBoxButton.OKCancel) == MessageBoxResult.OK)
            {
                Product p = new Product();
                p = (Product)targetOn.SelectedItem;
                this.insertData(p);
                
            }
        }
    }
}