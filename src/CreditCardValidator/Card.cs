
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;

namespace CreditCardValidator;

public sealed partial record Card
{
    private static readonly ReadOnlyDictionary<CardType, Regex> Patterns = new Dictionary<CardType, Regex>(
    [
        new KeyValuePair<CardType, Regex>(CardType.AmericanExpress, AmericanExpressPattern()),
        new KeyValuePair<CardType, Regex>(CardType.DinersClub, DinersClubPattern()),
        new KeyValuePair<CardType, Regex>(CardType.Discover, DiscoverPattern()),
        new KeyValuePair<CardType, Regex>(CardType.Elo, EloPattern()),
        new KeyValuePair<CardType, Regex>(CardType.Hipercard, HipercardPattern()),
        new KeyValuePair<CardType, Regex>(CardType.Jcb, JcbPattern()),
        new KeyValuePair<CardType, Regex>(CardType.Mastercard,MasterCardPattern()),
        new KeyValuePair<CardType, Regex>(CardType.Visa, VisaPattern())
    ]).AsReadOnly();

    private Card(string number)
        => Number = number;

    public string Number { get; init; }

    public bool IsValid { get; private set; }

    public CardType GetCardType()
        => Patterns.SingleOrDefault(pattern => pattern.Value.IsMatch(Number)).Key;

    public static Card TryCreate(string number, out string error)
    {
        number = number.Replace(" ", "")
            .Replace("-", "");
        var card = new Card(number);
        if (CardValidator.TryValidateCardNumber(card.Number, out error))
        {
            card.IsValid = true;
        }
        return card;
    }

    [GeneratedRegex(@"^3[47][0-9]{13}$")]
    private static partial Regex AmericanExpressPattern();

    [GeneratedRegex(@"^3(0[0-5]|[68])[0-9]{11}$")]
    private static partial Regex DinersClubPattern();

    [GeneratedRegex(@"^6(?:011|5[0-9]{2})[0-9]{12}$|^64[4-9][0-9]{13}$|^622(1[2-9][6-9]|[2-8][0-9]{2}|9[0-1][0-9]|92[0-5])[0-9]{10}$")]
    private static partial Regex DiscoverPattern();

    [GeneratedRegex(@"^(636368|438935|504175|451416|509[0-9]{3})[0-9]{10}$")]
    private static partial Regex EloPattern();

    [GeneratedRegex(@"^(606282|3841)[0-9]{10,12}$")]
    private static partial Regex HipercardPattern();

    [GeneratedRegex(@"^35(2[89]|[3-8][0-9])[0-9]{12}$")]
    private static partial Regex JcbPattern();

    [GeneratedRegex(@"^5[1-5][0-9]{14}$|^2(2[2-9][1-9]|[3-6][0-9]{2}|7[0-1][0-9]|720)[0-9]{12}$")]
    private static partial Regex MasterCardPattern();

    [GeneratedRegex(@"^4[0-9]{12}(?:[0-9]{3})?$")]
    private static partial Regex VisaPattern();
}
