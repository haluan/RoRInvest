﻿using System;
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
    public partial class ShowDataFV : PhoneApplicationPage
    {
        private List<Product> lis;
        public ShowDataFV()
        {
            lis = new List<Product>();
            InitializeComponent();
            lis = (List<Product>)PhoneApplicationService.Current.State["yourparam"];
            this.targetOn.ItemsSource = lis;
            this.targetSaved.ItemsSource = (List<FutValue>)this.GetFv();
        }
        public IList<FutValue> GetFv()
        {
            IList<FutValue> fvList = null;
            using (FutureValueDataContext context = new FutureValueDataContext())
            {
                try
                {
                    IQueryable<FutValue> query = from f in context.Futurevalue select f;
                    fvList = query.ToList();
                }
                catch
                {
                }
            }
            return fvList;
        }
        private void insertData(Product p)
        {
            using (FutureValueDataContext context = new FutureValueDataContext())
            {
                if (p != null)
                {
                    FutValue fv = new FutValue();
                    fv.InitialCost = p.InitialCost;
                    fv.Name = p.Name;
                    fv.InitialCost = p.InitialCost;
                    fv.Marr = p.Marr;
                    fv.LifetimeProject = p.LifetimeProject;
                    fv.FutureValue = p.FutureValue;
                    try
                    {

                        context.Futurevalue.InsertOnSubmit(fv);
                        context.SubmitChanges();
                        this.targetSaved.ItemsSource = (List<FutValue>)this.GetFv();
                    }
                    catch
                    {
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
        private void deleteDataFV(FutValue fv)
        {
            using (FutureValueDataContext context = new FutureValueDataContext())
            {
                // find a city to update
                IQueryable<FutValue> fvQuery = from f in context.Futurevalue where f.Name == fv.Name select f;
                FutValue fvTODelete = new FutValue();

                fvTODelete = fvQuery.FirstOrDefault();
                MessageBox.Show(fvQuery.FirstOrDefault().Name);
                //hapus data yang diseleksi

                try
                {
                    context.Futurevalue.DeleteOnSubmit(fvQuery.FirstOrDefault());

                    // save changes to the database
                    context.SubmitChanges();
                }
                catch
                {

                }
            }
        }

        private void StackPanel_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            if (MessageBox.Show("Are you sure?", "Save this plan?", MessageBoxButton.OKCancel) == MessageBoxResult.OK)
            {
                Product p = (Product)targetOn.SelectedItem;
               
                this.insertData(p);
            }
        }

        private void Delete_Selected(object sender, System.Windows.Input.GestureEventArgs e)
        {
            if (MessageBox.Show("Are you sure?", "Delete this plan?", MessageBoxButton.OKCancel) == MessageBoxResult.OK)
            {
                FutValue f = (FutValue)targetSaved.SelectedItem;
                this.deleteDataFV(f);
            }
        }
    }
}