using System;
using System.Collections.Generic;

namespace MvcTraining.Models;

public partial class Tblsatislar
{
    public int Satisid { get; set; }

    public int? Urun { get; set; }

    public int? Musteri { get; set; }

    public byte? Adet { get; set; }

    public decimal? Fiyat { get; set; }

    public virtual Tblmusteriler? MusteriNavigation { get; set; }

    public virtual Tblurunler? UrunNavigation { get; set; }
}
