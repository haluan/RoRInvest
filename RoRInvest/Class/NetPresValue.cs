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
using System.Data.Linq.Mapping;
using System.Data.Linq;
using Microsoft.Phone.Data.Linq;
using Microsoft.Phone.Data.Linq.Mapping;
namespace RoRInvest
{
    //tabel
    [Table]
    public class NetPresValue : Product
    {
        //column primary key dengan id auto increment
        [Column(IsPrimaryKey = true, IsDbGenerated = true,
            DbType = "INT NOT NULL Identity", CanBeNull = false,
        AutoSync = AutoSync.OnInsert)]
        public int npsvId { get; set; }
        [Column]
        public String Name { get; set; }
        [Column]
        public String InitialCost { get; set; }
        [Column]
        public String AnnualProfit { get; set; }
        [Column]
        public double Marr { get; set; }
        [Column]
        public Int64 LifetimeProject { get; set; }
        [Column]
        public String Npv { get; set; }
        [Column]
        public String Status { get; set; }
        [Column]
        public double Irr { get; set; }

    }
}
