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
using System.Data.Linq;
using Microsoft.Phone.Data.Linq;
using Microsoft.Phone.Data.Linq.Mapping;
namespace RoRInvest
{
    public class FutureValueDataContext : DataContext
    {
        //insisialsisasi nama database
        public const string ConnectionString = "Data Source=isostore:/Fv.sdf";
        public FutureValueDataContext() : base(ConnectionString)
        {
            //jika database belum ada maka dibuat dahulu
            if (!this.DatabaseExists())
            {
                this.CreateDatabase();
            }
        }
        //mengembalikan table dari database
        public Table<FutValue> Futurevalue{
            get
            {
                return this.GetTable<FutValue>();
            }
        }
    }
}
