using System;

public class BindAttribute : Attribute
{
	public bool Singleton { get; }

	public BindAttribute(bool singleton)
	{
		Singleton = singleton;
	}
}
