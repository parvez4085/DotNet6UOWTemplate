using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace Template.Domain.Users
{

    [Table("Users")]
    public partial class User : IdentityUser
    {
        //[Key]
        //public Guid Id { get; set; }
        public bool IsDeleted { get; set; }
        //public string UserName { get; set; }

        //[EmailAddress]
        //public string Email { get; set; }


    }
}