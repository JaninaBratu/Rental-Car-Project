//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RentalCar.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblRezervation
    {
        public int RezervationId { get; set; }
        public int ClientId { get; set; }
        public int CarId { get; set; }
        public System.DateTime StartDate { get; set; }
        public System.DateTime EndDate { get; set; }
        public string StartLocation { get; set; }
        public string EndLocation { get; set; }
        public double Price { get; set; }
    
        public virtual tblCar tblCar { get; set; }
        public virtual tblClient tblClient { get; set; }
    }
}