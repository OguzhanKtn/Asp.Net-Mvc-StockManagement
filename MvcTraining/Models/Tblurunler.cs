using System;
using System.Collections.Generic;

namespace MvcTraining.Models;

public partial class Tblurunler
{
    public int Urunid { get; set; }

    public string? Urunad { get; set; }

    public string? Marka { get; set; }

    public short? Urunkategori { get; set; }

    public decimal? Fiyat { get; set; }

    public byte? Stok { get; set; }

    public virtual ICollection<Tblsatislar> Tblsatislars { get; set; } = new List<Tblsatislar>();

    public virtual Tblkategoriler? UrunkategoriNavigation { get; set; }
}
