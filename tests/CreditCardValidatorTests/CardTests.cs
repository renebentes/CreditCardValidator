
using CreditCardValidator;

namespace CreditCardValidatorTests;

public class CardTests
{

    [Fact]
    public void GetCardType_Unknown_ReturnsUnknown()
    {
        var number = "6011000990139424";
        var card = Card.TryCreate(number, out var error);
        Assert.True(card.IsValid);
        Assert.Equal(CardTypes.Unknown, card.GetCardType());
    }

    [Theory]
    [InlineData("1234567890123456")]
    [InlineData("")]
    [InlineData("1111-1111-1111-1111")]
    [InlineData("ABC1-1111-1111-1111")]
    public void TryCreate_InvalidCardNumber_ReturnsFalse(string number)
    {
        var card = Card.TryCreate(number, out var error);

        Assert.False(card.IsValid);
    }

    [Theory]
    [InlineData("4111 1111 1111 1111")]
    [InlineData("4085 8666 7736 8692")]
    [InlineData("4763789783890")]
    [InlineData("4050-7335-8552-0130")]
    // [InlineData("378282246310005", CardTypes.Amex)]
    public void GetReturnType_ValidCardNumber_ReturnsVisa(string number)
    {
        var card = Card.TryCreate(number, out var error);

        Assert.True(card.IsValid);
        Assert.Equal(CardTypes.Visa, card.GetCardType());
        Assert.Empty(error);
    }

    [Theory]
    [InlineData("5591 6664 1066 6848")]
    [InlineData("5256 9606 0525 3942")]
    [InlineData("5188 4928 6737 9416")]
    [InlineData("5500000000000004")]
    [InlineData("2221 5603 6693 4877")]
    [InlineData("2500 8760 1607 8929")]
    [InlineData("2720 3028 0679 1013")]
    public void GetReturnType_ValidCardNumber_ReturnsMastercard(string number)
    {
        var card = Card.TryCreate(number, out var error);

        Assert.True(card.IsValid);
        Assert.Equal(CardTypes.Mastercard, card.GetCardType());
        Assert.Empty(error);
    }

    [Theory]
    [InlineData("378282246310005")]
    [InlineData("3400 2516 9528 342")]
    [InlineData("3710 2308 2861 371")]
    [InlineData("3711-5189-3112-518")]
    public void GetReturnType_ValidCardNumber_ReturnsAmex(string number)
    {
        var card = Card.TryCreate(number, out var error);

        Assert.True(card.IsValid);
        Assert.Equal(CardTypes.AmericaExpress, card.GetCardType());
        Assert.Empty(error);
    }
}