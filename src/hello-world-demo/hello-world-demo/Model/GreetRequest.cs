using System.ComponentModel.DataAnnotations;

namespace hello_world_demo.Model
{
    public class GreetRequest
    {
        [Required]
        public string Person { get; set; }
    }
}
