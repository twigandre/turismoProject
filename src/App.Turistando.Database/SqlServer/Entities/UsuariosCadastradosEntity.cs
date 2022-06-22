using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Turistando.Database.SqlServer.Entities
{
    [Table("tur_usr_cadastrados")]
    public class UsuariosCadastradosEntity
    {
        [Key]
        [Column("usc_id")]
        public int Id { get; set; }

        [Required]
        [Column("usc_username")]
        public string Name { get; set; }

        [Required]
        [Column("usc_password")]
        public string Password { get; set; }

        [Required]
        [Column("usc_role_description")]
        public string Role { get; set; }

        [Required]
        [Column("usc_dt_registration")]
        public DateTime DtRegister { get; set; }

        [Required]
        [Column("usc_is_active")]
        [StringLength(1)]
        public string IsActive { get; set; }

        [Required]
        [Column("usc_email")]
        public string Email { get; set; }

    }
}
