using System;
using Xunit;

namespace StructValidation.Tests;

public readonly record struct Username
{
  private string Value { get; }

  public Username() : this(null) {}
  
  public Username(string value)
  {
    if (string.IsNullOrEmpty(value))
    {
      throw new ArgumentNullException(nameof(value));
    }

    Value = value;
  }

  public override string ToString()
  {
    return Value;
  }
}

public class UnitTest1
{
  [Fact]
  public void Test1()
  {
    Assert.Throws<ArgumentNullException>(() => new Username());
  }
}
