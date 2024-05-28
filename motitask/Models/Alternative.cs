using System.ComponentModel.DataAnnotations;

namespace motitask;

public class Alternative
{
    [Key]
    public int A_id { get; set; }
    public string A_name { get; set; }
}