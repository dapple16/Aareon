using System.ComponentModel.DataAnnotations;

namespace AareonTechnicalTest.Models
{
	public class Audit
	{
        [Key]
        public int Id { get; }

        public string Log { get; set; }
    }
}