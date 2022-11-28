using Template.Domain.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Template.Domain.Users
{

    [Table("Users")]
    public partial class User : DeleteEntity<int>
    {

        public string UserName { get; set; }

        [EmailAddress]
        public string Email { get; set; }


    }
}