using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication4.Models;

[Table("Status")]
public class Status
{
    
    [Key]
    [Column("ID")]
    public int StatusID { get; set; }
    
    [Column("Name")]
    [MaxLength(50)]
    public string StatusName { get; set; }
    
    public IEnumerable<Order> Orders { get; set; }

}