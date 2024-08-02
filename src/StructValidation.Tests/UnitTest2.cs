using System;
using Xunit;

namespace StructValidation.Tests;

public record Username2
{
  private string Value { get; }

  public Username2(string value)
  {
    if (string.IsNullOrEmpty(value))
    {
      throw new ArgumentNullException(nameof(value));
    }

    Value = value;
  }

  // public static implicit operator string(Username2 d) => d.Value;
  public override string ToString()
  {
    return Value;
  }
}

public class UnitTest2
{
  [Fact]
  public void ShouldThrow()
  {
    Assert.Throws<ArgumentNullException>(() => new Username2(null));
  }
  
  [Fact]
  public void ShouldSerializeToString()
  {
    var username = new Username2("test");
    Assert.Equal("test", username.ToString());
  }
}
