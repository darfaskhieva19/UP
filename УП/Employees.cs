//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace УП
{
    using System;
    using System.Collections.Generic;
    
    public partial class Employees
    {
        public int ID { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Patronymic { get; set; }
        public string Number { get; set; }
        public int Password { get; set; }
        public int IDRole { get; set; }
        public string Photo { get; set; }
    
        public virtual Roles Roles { get; set; }
    }
}
