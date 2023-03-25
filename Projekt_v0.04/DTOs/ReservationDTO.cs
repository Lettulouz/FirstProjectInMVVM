using System;
using System.ComponentModel.DataAnnotations;

namespace Projekt_v0._04.DTOs;

public class ReservationDTO
{
    [Key]
    public Guid ID { get; set; }
    public string Miasto { get; set; }
    public string Hotel { get; set; }
    public string Użytkownik { get; set; }
    public int NumerPokoju { get; set; }
    public DateTime DataPrzyjazdu { get; set; }
    public DateTime DataWyjazdu { get; set; }
    public bool RezerwacjaPotwierdzona { get; set; }
}