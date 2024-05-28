using System.ComponentModel.DataAnnotations;

namespace motitask;

public class LPR
{
    [Key]
    public int L_id { get; set; }
    public string L_name { get; set; }
    public int L_range { get; set; }
}