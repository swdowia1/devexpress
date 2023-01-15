using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracaXaf.Module.BusinessObjects
{

    [NavigationItem("GUS")]
    public class GUS : BaseObject
    {
        public GUS(Session session) : base(session) { }
        string regon;
        public string Regon
        {
            get { return regon; }
            set { SetPropertyValue(nameof(Regon), ref regon, value); }
        }
        //========================================
        string nazwa;
        public string Nazwa
        {
            get { return nazwa; }
            set { SetPropertyValue(nameof(Nazwa), ref nazwa, value); }
        }
        //========================================
        string miejscowosc;
        public string Miejscowosc
        {
            get { return miejscowosc; }
            set { SetPropertyValue(nameof(Miejscowosc), ref miejscowosc, value); }
        }
        string nip;
        public string Nip
        {
            get { return nip; }
            set { SetPropertyValue(nameof(Nip), ref nip, value); }
        }
    }
}
