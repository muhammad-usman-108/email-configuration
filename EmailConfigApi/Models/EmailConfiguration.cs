using System.ComponentModel.DataAnnotations;

namespace EmailConfigApi.Models
{
    public enum ProviderType
    {
        Exchange,
        IMAP
    }

    public class EmailConfiguration
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(200)]
        public string Name { get; set; } = null!;

        [Required, MaxLength(1000)]
        public string WatchedFolder { get; set; } = null!;

        [Required]
        public ProviderType Provider { get; set; }

        public bool StoreAttachments { get; set; }
    }
}
