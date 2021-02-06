
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------


namespace ProjectDatabaseLib
{

using System;
    using System.Collections.Generic;
    
public partial class Location
{

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public Location()
    {

        this.BlogSpaces = new HashSet<BlogSpace>();

        this.Hotels = new HashSet<Hotel>();

        this.TouristPlaces = new HashSet<TouristPlace>();

        this.Flights = new HashSet<Flight>();

    }


    public int Id { get; set; }

    public int Pincode { get; set; }

    public string LocationName { get; set; }

    public double Longitude { get; set; }

    public double Latitude { get; set; }

    public Nullable<bool> IsActive { get; set; }



    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<BlogSpace> BlogSpaces { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<Hotel> Hotels { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<TouristPlace> TouristPlaces { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<Flight> Flights { get; set; }

}

}
