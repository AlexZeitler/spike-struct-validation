using System;
using Xunit;

namespace StructValidation.Tests;

public record UsernameStruct
{
  private string Value { get; }

  public UsernameStruct(string value)
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

public class UsernameStructTests
{
  [Fact]
  public void ShouldThrow()
  {
    Assert.Throws<ArgumentNullException>(() => new UsernameStruct(null));
  }
  
  [Fact]
  public void ShouldSerializeToString()
  {
    var username = new UsernameStruct("test");
    // TODO: wie serialisiert marten das?
    Assert.Equal("test", username.ToString());
  }
}
