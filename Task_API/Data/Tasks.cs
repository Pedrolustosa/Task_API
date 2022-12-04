using System.ComponentModel.DataAnnotations.Schema;

namespace Task_API.Data
{
    [Table("Tasks")]
    public record Tasks(int Id, string Activities, string Status);

}
