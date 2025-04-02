using Utilbox.Response;

namespace Utilbox.Tests.Response;

public class OperationValidationErrorTests
{
    [Fact]
    public void Constructor_ShouldInitializeProperties()
    {
        // Arrange
        var field = "TestField";
        var message = "TestMessage";
        var code = "TestCode";

        // Act
        var error = new OperationValidationError(field, message, code);

        // Assert
        Assert.Equal(field, error.Field);
        Assert.Equal(message, error.Message);
        Assert.Equal(code, error.Code);
    }

    [Fact]
    public void Constructor_ShouldInitializeProperties_WithNullCode()
    {
        // Arrange
        var field = "TestField";
        var message = "TestMessage";

        // Act
        var error = new OperationValidationError(field, message);

        // Assert
        Assert.Equal(field, error.Field);
        Assert.Equal(message, error.Message);
        Assert.Null(error.Code);
    }

    [Fact]
    public void DefaultConstructor_ShouldInitializePropertiesToNull()
    {
        // Act
        var error = new OperationValidationError();

        // Assert
        Assert.Null(error.Field);
        Assert.Null(error.Message);
        Assert.Null(error.Code);
    }

    [Fact]
    public void Properties_ShouldGetAndSetValues()
    {
        // Arrange
        var error = new OperationValidationError();
        var field = "TestField";
        var message = "TestMessage";
        var code = "TestCode";

        // Act
        error.Field = field;
        error.Message = message;
        error.Code = code;

        // Assert
        Assert.Equal(field, error.Field);
        Assert.Equal(message, error.Message);
        Assert.Equal(code, error.Code);
    }
}