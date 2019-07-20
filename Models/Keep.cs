using System.ComponentModel.DataAnnotations;

namespace keepr
{
  public class Keep
  {
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public string Description { get; set; }
    public string UserId { get; set; }
    public string Image { get; set; }
    public bool IsPrivate { get; set; }

    public int NumViews { get; set; }

    public int NumShares { get; set; }

    public int NumKeeps { get; set; }

  }
}