using System.Threading.Tasks;
using Projekt_v0._04.Models;

namespace Projekt_v0._04.Services.RegisterConfictValidatiors;

public interface IRegisterConflictValidator
{
    Task<Login> GetConflictingRegister(Login login);
}