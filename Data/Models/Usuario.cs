using System.ComponentModel.DataAnnotations;

namespace WorldCities.Data.Models
{
    public class Usuario
    {
        #region Constructor
        public Usuario()
        {
        }
        #endregion
        #region Properties
        /// <summary>
        /// The unique id and primary key for this Country
        /// </summary>
        [Key]
        [Required]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public string Genero { get; set; }
        #endregion
    }
}
