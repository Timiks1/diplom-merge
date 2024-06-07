using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityACS.Core.Entities;

namespace UniversityACS.Core.DTOs.Responses
{
    public class ReviewResponseDto
    {
        public Guid Id { get; set; }
        public ApplicationUser Teacher { get; set; }
        public Student Student { get; set; }
        public DateTime Date { get; set; }
        public string Discipline { get; set; }
        public string Comment { get; set; }
    }
}
