using System.ComponentModel.DataAnnotations.Schema;

namespace MVCExample.Web.Features.Base;

public class BaseDataModel
{
    public DateTime CreatedDate { get; set; }
    
    public int CreatedUser { get; set; }
    
    public DateTime? ModifiedDate { get; set; }
   
    public int ModifiedUser { get; set; }
    
    public bool IsDelete { get; set; }
}