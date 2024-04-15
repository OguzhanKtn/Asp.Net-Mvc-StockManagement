using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MvcTraining.Models;

public partial class Tblmusteriler
{
    public int Musteriid { get; set; }

    [Required(ErrorMessage ="Bu alanı boş bırakamazsınız !")]
    [StringLength(50,ErrorMessage ="En fazla 50 karakterlik isim girin")]
    public string? Musteriad { get; set; }

    [Required(ErrorMessage = "Bu alanı boş bırakamazsınız !")]
    [StringLength(50, ErrorMessage = "En fazla 50 karakterlik isim girin")]
    public string? Musterisoyad { get; set; }

    public virtual ICollection<Tblsatislar> Tblsatislars { get; set; } = new List<Tblsatislar>();
}
