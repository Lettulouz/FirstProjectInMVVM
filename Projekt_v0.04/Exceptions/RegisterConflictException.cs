using System;
using Projekt_v0._04.Models;

namespace Projekt_v0._04.Exceptions;

public class RegisterConflictException : Exception
{
    public Login ExistingUser { get; }
    public Login IncomingUser { get; }

    public RegisterConflictException(Login existingUser, Login incomingUser)
    {
        ExistingUser = existingUser;
        IncomingUser = incomingUser;
    }

    public RegisterConflictException(string message, Login existingUser, Login incomingUser) : base(message)
    {
        existingUser = existingUser;
        IncomingUser = incomingUser;
    }

    public RegisterConflictException(string message, Exception innerException, Login existingUser, Login incomingUser)
    {
        existingUser = existingUser;
        IncomingUser = incomingUser;
    }
    
}