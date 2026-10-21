using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web_Api_Projesi.Models
{
    public class Kategoriler
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int KategoriId { get; set; }
        public string KategoriAdi { get; set; }

    }
}
