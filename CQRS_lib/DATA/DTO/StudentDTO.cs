using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS_lib.DATA.DTO
{
    public  class StudentDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
       public string imageUrl { get; set; }
        public int DepartmentID { get; set; }

    }
}
