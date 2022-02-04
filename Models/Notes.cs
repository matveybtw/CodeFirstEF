using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstEF.Models
{
    [Table("Notes")]
    public class Note
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public decimal Summ { get; set; }
        [Required]
        public Category category { get; set; }

    }
}
/*using (var context = new DatabaseEntities())
{
    var t = new test
    {
        ID = Guid.NewGuid(),
        name = "blah",
    };
    context.AddTotest(t);
    context.SaveChanges();
}   */