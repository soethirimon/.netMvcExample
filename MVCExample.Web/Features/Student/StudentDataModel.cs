using MVCExample.Web.Features.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCExample.Web.Features.Student
{
    [Table("Tbl_Student")]
    public class StudentDataModel : BaseDataModel
    {
        [Key]
        public int StudentId { get; set; }
        public string StudentName { get; set; } 
        public string StudentAddress { get; set; }
        public string StudentDescription { get; set; }

        
    }
}
