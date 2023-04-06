namespace ColizeumDaily.Exceptions;

public class MaximumStockException : Exception
{
    public MaximumStockException(string message)
        : base(message) { }
}

public class UserAlreadyCheckException : Exception
{
    public UserAlreadyCheckException(string message)
        : base(message) { }
}

public class UserAlreadyExistsException : Exception
{
    public UserAlreadyExistsException(string message)
        : base(message) { }
}

public class MaximumNightPacksException : Exception
{
    public MaximumNightPacksException(string message)
        : base(message) { }
}