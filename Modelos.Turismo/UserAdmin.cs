using System.ComponentModel.DataAnnotations;

namespace Turismo.Modelos
{
    public class UserAdmin
    {
        [Key] public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
