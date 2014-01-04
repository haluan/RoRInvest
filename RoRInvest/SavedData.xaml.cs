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

namespace RoRInvest
{
    public partial class SavedData : PhoneApplicationPage
    {
        private List<Product> lisNPV,lisFV;
        
        public SavedData()
        {
            
            lisNPV = new List<Product>();
            lisFV = new List<Product>();
            InitializeComponent();
            this.targetSavedFv.ItemsSource = (List<FutValue>)this.GetFv();
            this.targetSavedNpv.ItemsSource = (List<NetPresValue>)this.GetNpv();
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

        private void deleteDataFV(FutValue fv)
        {
            using (FutureValueDataContext context = new FutureValueDataContext())
            {
                // find a city to update
                IQueryable<FutValue> fvQuery = from f in context.Futurevalue where f.futureValueId==fv.futureValueId select f;
                FutValue fvTODelete = new FutValue();
                try
                {
                    fvTODelete = fvQuery.FirstOrDefault();
                    //hapus data yang diseleksi
                    context.Futurevalue.DeleteOnSubmit(fvQuery.FirstOrDefault());                   
                    // save changes to the database
                    context.SubmitChanges();
                }
                catch
                {
                    
                }
            }
        }

        private void deleteDataNPV(NetPresValue npv)
        {
            using (NpvDataContext context = new NpvDataContext())
            {
                // find a city to update
                IQueryable<NetPresValue> npvQuery = from n in context.Npv where n.npsvId == npv.npsvId select n;
                NetPresValue npvToDelete = new NetPresValue();
                try
                {
                    npvToDelete = npvQuery.FirstOrDefault();
                    //hapus data yang diseleksi
                    context.Npv.DeleteOnSubmit(npvQuery.FirstOrDefault());
                    // save changes to the database
                    context.SubmitChanges();
                }
                catch
                {
                   
                }
            }
        }

        private void deletFV_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            if (MessageBox.Show("Are you sure?", "Delete this plan?", MessageBoxButton.OKCancel) == MessageBoxResult.OK)
            {
                FutValue f = (FutValue)targetSavedFv.SelectedItem;
                f = (FutValue)targetSavedFv.SelectedItem;
                this.deleteDataFV(f);
                this.targetSavedFv.ItemsSource = (List<FutValue>)this.GetFv();
            }
        }

        private void deleteNPV_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            if (MessageBox.Show("Are you sure?", "Delete this plan?", MessageBoxButton.OKCancel) == MessageBoxResult.OK)
            {
                NetPresValue n = (NetPresValue)targetSavedNpv.SelectedItem;
                this.deleteDataNPV(n);
                this.targetSavedNpv.ItemsSource = (List<NetPresValue>)this.GetNpv();
            }
        }
        }
       
    }
