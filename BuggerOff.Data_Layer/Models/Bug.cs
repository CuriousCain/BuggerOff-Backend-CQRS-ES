using System.ComponentModel.DataAnnotations;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Metadata;

namespace Data_Layer.Models
{
    public class Bug
    {
        public int ID { get; set; }
        
        [Required(ErrorMessage = "Bug description required")]
        public string Description { get; set; }
        public bool Fixed { get; set; }
    }
}