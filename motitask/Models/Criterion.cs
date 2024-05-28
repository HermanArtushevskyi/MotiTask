using System.ComponentModel.DataAnnotations;

namespace motitask;

public class Criterion
{
    [Key]
    public int C_id { get; set; }
    public string C_name { get; set; }
    public int C_range { get; set; }
    public double C_weight { get; set; }
    public string C_type { get; set; }
    public string optim_type { get; set; }
}