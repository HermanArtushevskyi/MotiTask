using System.ComponentModel.DataAnnotations;

namespace motitask;

public class Mark
{
    [Key]
    public int M_id { get; set; }
    public int C_id { get; set; }
    public string M_name { get; set; }
    public int M_range { get; set; }
    public int M_num { get; set; }
    public double M_norm { get; set; }
}