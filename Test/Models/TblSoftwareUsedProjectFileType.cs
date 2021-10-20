using System;
using System.Collections.Generic;

#nullable disable

namespace Test.Models
{
    public partial class TblSoftwareUsedProjectFileType
    {
        public Guid FldSoftwareUsedProjectFileTypeId { get; set; }
        public Guid FldSoftwareUsedId { get; set; }
        public Guid FldProjectFileTypeId { get; set; }

        public virtual TblProjectFileType FldProjectFileType { get; set; }
        public virtual TblSoftwareUsed FldSoftwareUsed { get; set; }
    }
}
