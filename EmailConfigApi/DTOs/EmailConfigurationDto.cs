using System.ComponentModel.DataAnnotations;
using EmailConfigApi.Models;

namespace EmailConfigApi.DTOs
{
    public class EmailConfigurationCreateDto
    {
        [Required, MaxLength(200)]
        public string Name { get; set; } = null!;

        [Required, MaxLength(1000)]
        public string WatchedFolder { get; set; } = null!;

        [Required]
        public ProviderType Provider { get; set; }

        public bool StoreAttachments { get; set; }
    }

    public class EmailConfigurationReadDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string WatchedFolder { get; set; } = null!;
        public ProviderType Provider { get; set; }
        public bool StoreAttachments { get; set; }
    }
}
