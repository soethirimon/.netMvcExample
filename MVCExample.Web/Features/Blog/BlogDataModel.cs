using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MVCExample.Web.Features.Base;

namespace MVCExample.Web.Features.Blog;

[Table("Tbl_Blog")]
public class BlogDataModel : BaseDataModel
{
    [Key]
    public int BlogId { get; set; }
    
    public string BlogTitle { get; set; }
    
    public string BlogAuthor { get; set; }
    
    public string BlogContent { get; set; }
}