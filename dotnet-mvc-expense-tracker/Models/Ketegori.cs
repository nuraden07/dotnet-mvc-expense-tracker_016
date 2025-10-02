using System.ComponentModel.DataAnnotations;

namespace dotnet_mvc_expense_tracker.Models
{
    public class Kategori
    {
        public int Id { get; set; }

        [Required]
        public string Tipe { get; set; } = string.Empty; // income / expense

        [Required]
        public string Nama { get; set; } = string.Empty;

        public string? Deskripsi { get; set; }

        [Required]
        public string Status { get; set; } = "active"; // active / not active
    }
}
