﻿namespace SubstationTracker.Application.Utilities.Exceptions;

public class BusinessException : Exception
{
    public BusinessException(string message) : base(message)
    {
    }
}