
using CreditCardValidator;

namespace CreditCardValidatorTests;

public class CardTests
{

    [Fact]
    public void GetCardType_Unknown_ReturnsUnknown()
    {
        var number = "670958585610242150";
        var card = Card.TryCreate(number, out var error);
        Assert.True(card.IsValid);
        Assert.Equal(CardType.Unknown, card.GetCardType());
    }

    [Theory]
    [InlineData("378282246310005")]
    [InlineData("3400 2516 9528 342")]
    [InlineData("3710 2308 2861 371")]
    [InlineData("3711-5189-3112-518")]
    public void GetReturnType_ValidCardNumber_ReturnsAmericanExpress(string number)
    {
        var card = Card.TryCreate(number, out var error);

        Assert.True(card.IsValid);
        Assert.Equal(CardType.AmericanExpress, card.GetCardType());
        Assert.Empty(error);
    }

    [Theory]
    [InlineData("3002 6311 7301 20")]
    [InlineData("3052 9520 9660 21")]
    [InlineData("30366094205167")]
    [InlineData("3055-1070-4925-70")]
    public void GetReturnType_ValidCardNumber_ReturnsDinersClub(string number)
    {
        var card = Card.TryCreate(number, out var error);

        Assert.True(card.IsValid);
        Assert.Equal(CardType.DinersClub, card.GetCardType());
        Assert.Empty(error);
    }

    [Theory]
    [InlineData("6011 2621 3439 5961")]
    [InlineData("6221 2687 5844 4692")]
    [InlineData("6508 0834 7667 7281")]
    [InlineData("6524-2411-1030-0898")]
    public void GetReturnType_ValidCardNumber_ReturnsDiscover(string number)
    {
        var card = Card.TryCreate(number, out var error);

        Assert.True(card.IsValid);
        Assert.Equal(CardType.Discover, card.GetCardType());
        Assert.Empty(error);
    }

    [Theory]
    [InlineData("6363 6890 7893 7230")]
    [InlineData("5041 7565 3298 3282")]
    [InlineData("5090 4897 3358 7633")]
    public void GetReturnType_ValidCardNumber_ReturnsElo(string number)
    {
        var card = Card.TryCreate(number, out var error);

        Assert.True(card.IsValid);
        Assert.Equal(CardType.Elo, card.GetCardType());
        Assert.Empty(error);
    }

    [Theory]
    [InlineData("6062 8230 0547 5048")]
    [InlineData("3841 0933 9223 2726")]
    [InlineData("3841 0006 9026 4103")]
    [InlineData("6062 8217 8583 4814")]
    public void GetReturnType_ValidCardNumber_ReturnsHipercard(string number)
    {
        var card = Card.TryCreate(number, out var error);

        Assert.True(card.IsValid);
        Assert.Equal(CardType.Hipercard, card.GetCardType());
        Assert.Empty(error);
    }

    [Theory]
    [InlineData("3528 6715 0025 5240")]
    [InlineData("3569 1025 3600 8874")]
    [InlineData("3589 7195 6365 1155")]
    [InlineData("3529-9671-7397-8400")]
    public void GetReturnType_ValidCardNumber_ReturnsJcb(string number)
    {
        var card = Card.TryCreate(number, out var error);

        Assert.True(card.IsValid);
        Assert.Equal(CardType.Jcb, card.GetCardType());
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
        Assert.Equal(CardType.Mastercard, card.GetCardType());
        Assert.Empty(error);
    }

    [Theory]
    [InlineData("4111 1111 1111 1111")]
    [InlineData("4085 8666 7736 8692")]
    [InlineData("4763789783890")]
    [InlineData("4050-7335-8552-0130")]
    public void GetReturnType_ValidCardNumber_ReturnsVisa(string number)
    {
        var card = Card.TryCreate(number, out var error);

        Assert.True(card.IsValid);
        Assert.Equal(CardType.Visa, card.GetCardType());
        Assert.Empty(error);
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

}