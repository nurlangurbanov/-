//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Архивариус
{
    using System;
    using System.Collections.Generic;
    
    public partial class Issuance
    {
        public int ID_Issuance_index { get; set; }
        public int Archive_ID { get; set; }
        public System.DateTime Date_of_issue { get; set; }
        public System.DateTime Date_return { get; set; }
        public string To_whom_issued { get; set; }
        public int Reg_ID { get; set; }
    
        public virtual Archive_work Archive_work { get; set; }
        public virtual Reg Reg { get; set; }
    }
}
