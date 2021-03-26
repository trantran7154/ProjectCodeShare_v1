//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CodeShare.Model.EF
{
    using System;
    using System.Collections.Generic;
    
    public partial class User
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public User()
        {
            this.Bills = new HashSet<Bill>();
            this.Codes = new HashSet<Code>();
            this.News = new HashSet<News>();
            this.TakePrices = new HashSet<TakePrice>();
            this.Tools = new HashSet<Tool>();
            this.Groups = new HashSet<Group>();
        }
    
        public int user_id { get; set; }
        public string user_email { get; set; }
        public string user_phone { get; set; }
        public Nullable<bool> user_sex { get; set; }
        public Nullable<System.DateTime> user_birth { get; set; }
        public string user_token { get; set; }
        public Nullable<int> user_role { get; set; }
        public string user_name { get; set; }
        public Nullable<int> user_coin { get; set; }
        public Nullable<System.DateTime> user_datecreate { get; set; }
        public Nullable<System.DateTime> user_dateupdate { get; set; }
        public string user_code { get; set; }
        public Nullable<int> user_active { get; set; }
        public Nullable<bool> user_option { get; set; }
        public Nullable<bool> user_del { get; set; }
        public string user_fa { get; set; }
        public string user_none { get; set; }
        public Nullable<int> user_view { get; set; }
        public string user_facode { get; set; }
        public string user_pass { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Bill> Bills { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Code> Codes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<News> News { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TakePrice> TakePrices { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tool> Tools { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Group> Groups { get; set; }
    }
}
