//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HealthyLifestyle
{
    using System;
    using System.Collections.Generic;
    
    public partial class Users
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Users()
        {
            this.DailyRation = new HashSet<DailyRation>();
        }
    
        public int UserId { get; set; }
        public Nullable<int> GenderId { get; set; }
        public string Login { get; set; }
        public Nullable<double> Weight { get; set; }
        public Nullable<double> Height { get; set; }
        public Nullable<int> ActivityId { get; set; }
        public Nullable<int> GoalId { get; set; }
        public Nullable<int> Calories { get; set; }
        public Nullable<double> Squirrels { get; set; }
        public Nullable<int> DateOfBirth { get; set; }
        public string Password { get; set; }
        public Nullable<double> Fats { get; set; }
        public Nullable<double> Carbohydrates { get; set; }
    
        public virtual Activities Activities { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DailyRation> DailyRation { get; set; }
        public virtual Genders Genders { get; set; }
        public virtual Goals Goals { get; set; }
    }
}
