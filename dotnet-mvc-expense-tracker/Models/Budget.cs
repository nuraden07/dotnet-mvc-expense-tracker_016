using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace dotnet_mvc_expense_tracker.Models
{
    public class Budget
    {
        public int Id { get; set; }

        [Required]
        public int KategoriId { get; set; }        // FK ke Kategori

        [ForeignKey("KategoriId")]
        public Kategori? Kategori { get; set; }    // navigation (optional, digunakan hanya untuk tampil)

        [Required]
        public string Nama { get; set; } = string.Empty;

        public string? Deskripsi { get; set; }

        [Required]
        public decimal TotalBudget { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }

        public bool IsRepeat { get; set; }

        [Required]
        public string Status { get; set; } = "active";
    }
}
