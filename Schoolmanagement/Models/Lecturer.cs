using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schoolmanagement.Models
{
    internal class Lecturer
    {
        public int LecturerId { get; set; }
        public string LecturerName { get; set; }
        public string LecturerAddress { get; set; }
        public int PhoneNumber { get; set; }
        public int CourseId { get; set; }

        internal void Add(Lecturer lecturer)
        {
            throw new NotImplementedException();
        }
    }
}
