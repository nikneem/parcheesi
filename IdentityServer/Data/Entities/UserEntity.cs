using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HexMaster.Parcheesi.IdentityServer.Data.Entities
{
    [Table("Users")]
    public class UserEntity
    {
        [Key]
        public Guid Id { get; set; }

        [MaxLength(30)]
        public string DisplayName { get; set; }
        [MaxLength(30)]
        [Required]
        public string Username { get; set; }
        [MaxLength(200)]
        [Required]
        public string Password { get; set; }
        [MaxLength(64)]
        [Required]
        public string Secret { get; set; }
        public bool IsVerified { get; set; }
        public bool IsEnabled { get; set; }
        [MaxLength(64)]
        [Required]
        public string UserVerificationCode { get; set; }
        [Required]
        public string EmailAddress { get; set; }
        public string NewEmailAddress { get; set; }
        public string EmailVerificationCode { get; set; }
        public DateTime FirstActivityOn { get; set; }
        public DateTime LastActivityOn { get; set; }

    }
}
