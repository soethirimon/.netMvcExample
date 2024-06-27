using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCExample.Web.Features.Student
{
   
    public class StudentRequestModel
    {
        public int StudentId { get; set; }
        [Required] [StringLength(50)] public string StudentName { get; set; }
        [Required] [StringLength(100)] public string StudentAddress { get; set; }
        [Required] [StringLength(200)] public string StudentDescription { get; set; }
    }
}
