using System.ComponentModel.DataAnnotations.Schema;

namespace DevFreela.API.Models
{
    public class CreateProjectModel
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)] 
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
