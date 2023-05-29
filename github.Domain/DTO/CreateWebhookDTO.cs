using github.Domain.Entity;
using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace github.Domain.DTO
{
    public class CreateWebhookDTO
    {
        [Required]
        public string Name { get; set; }
        public bool? Active { get; set; }
        public List<string>? Events { get; set; }
        [Required]
        public Dictionary<string,string> Config { get; set; }
    }
}
