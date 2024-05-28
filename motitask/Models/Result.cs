using System.ComponentModel.DataAnnotations;

namespace motitask;

public class Result
{
    [Key]
    public int R_id { get; set; }
    public int L_id { get; set; }
    public int A_id { get; set; }
    public int L_range { get; set; }
    public double A_weight { get; set; }
}