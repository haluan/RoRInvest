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
    public class NpvDataContext : DataContext
    {
        public const string ConnectionString = "Data Source=isostore:/NpvNew.sdf";
        public NpvDataContext() : base(ConnectionString)
        {
            if (!this.DatabaseExists())
            {
                this.CreateDatabase();
            }
        }
        public Table<NetPresValue> Npv
        {
            get
            {
                return this.GetTable<NetPresValue>();
            }
        }
    }
}
