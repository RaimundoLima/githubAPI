using github.Domain.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace github.Domain.DTO
{
    public class UpdateWebhookDTO
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public Dictionary<string,string> Config { get; set; }
    }
}
