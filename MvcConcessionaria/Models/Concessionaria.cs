using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MvcConcessionaria.Models;

public class Concessionaria
{
    public int Id { get; set; }
    public string? Modello { get; set; }
    public string? Genere { get; set; }
    [DataType(DataType.Date)]
    [DisplayName("Data di Rilascio")]
    public DateTime DataDiRilascio { get; set; }
    public decimal Prezzo { get; set; }
    public decimal Cavalli { get; set; }
    public decimal Cilindrata { get; set; }
    public string? Alimentazione { get; set; }
}