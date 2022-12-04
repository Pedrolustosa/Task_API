using System.ComponentModel.DataAnnotations.Schema;

namespace Task_API.Data
{
    [Table("Tasks")]
    public record Task(int Id, string Activity, string Status);

}
