using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shop.Web.Models
{
    public class BaseModel
    {
        public BaseModel()
        {
            Timestamp = DateTime.Now;
        }
        [Key] // tells entityframework that this will be the Primary key
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] 
        public int Id { get; set; }
        public DateTime Timestamp { get; set; }
    }
}