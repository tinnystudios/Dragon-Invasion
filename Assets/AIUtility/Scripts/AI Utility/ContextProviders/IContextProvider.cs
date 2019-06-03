using System;

public interface IContextProvider
{
    bool Validate { get; }
    Type Type { get; }
}