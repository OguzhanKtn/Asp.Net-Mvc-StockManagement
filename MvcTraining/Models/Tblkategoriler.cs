using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MvcTraining.Models;

public partial class Tblkategoriler
{
    public short Kategoriid { get; set; }

    [Required(ErrorMessage ="Kategori adını boş bırakamazsınız !")]
    public string? Kategoriad { get; set; }

    public virtual ICollection<Tblurunler> Tblurunlers { get; set; } = new List<Tblurunler>();
}
