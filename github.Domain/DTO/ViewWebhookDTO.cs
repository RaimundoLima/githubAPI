using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace github.Domain.DTO
{
    public class ViewWebhookDTO
    {
        public string Type { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }
        public List<string> Events { get; set; }
        public Dictionary<string, string> Config { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public string Url { get; set; }
        public string TestUrl { get; set; }
        public string PingUrl { get; set; }
    }
}
