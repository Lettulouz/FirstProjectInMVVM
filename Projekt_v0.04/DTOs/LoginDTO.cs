using System;
using System.ComponentModel.DataAnnotations;

namespace Projekt_v0._04.DTOs;

public class LoginDTO
{
    [Key]
    public Guid ID { get; set; }
    public string loginUsername { get; set; }
    public string loginPassword { get; set; }
}