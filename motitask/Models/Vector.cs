using System.ComponentModel.DataAnnotations;

namespace motitask;

public class Vector
{
    [Key]
    public int V_id { get; set; }
    public int A_id { get; set; }
    public int M_id { get; set; }
}