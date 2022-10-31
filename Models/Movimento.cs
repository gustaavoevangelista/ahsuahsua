using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Final_Project_2._1.Models
{
    public class Movimento
    {
        [Key]
        public int Id_mov { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Data_hora { get; set; }
        public float Importancia { get; set; }
        
        //Foreign Key
        [Display(Name = "Cliente")]
        public virtual int ClienteId { get; set; }

        [ForeignKey("ClienteId")]
        public virtual Cliente? Cliente { get; set; }


    }
}
