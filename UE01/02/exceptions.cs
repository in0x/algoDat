using System;

namespace ExceptionHandling {

	public class InvalidStringException: Exception
	{
	    public InvalidStringException()
	    {
	    }

	    public InvalidStringException(string message): base(message)
	    {
	    }
	}

	public class InvalidEscapeCharException: Exception
	{
	    public InvalidEscapeCharException()
	    {
	    }

	    public InvalidEscapeCharException(string message): base(message)
	    {
	    }
	}
}


