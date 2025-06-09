
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;

namespace CreditCardValidator;

public sealed partial record Card
{
    private static readonly ReadOnlyDictionary<CardTypes, Regex> Patterns = new Dictionary<CardTypes, Regex>(
    [
        new KeyValuePair<CardTypes, Regex>(CardTypes.Visa, VisaPattern()),
        new KeyValuePair<CardTypes, Regex>(CardTypes.AmericaExpress, AmexPattern()),
        new KeyValuePair<CardTypes, Regex>(CardTypes.Mastercard,MasterCardPattern())
    ]).AsReadOnly();

    private Card(string number)
        => Number = number;

    public string Number { get; init; }

    public bool IsValid { get; private set; }

    public CardTypes GetCardType()
    {
        var keyValuePair = Patterns.SingleOrDefault(pattern => pattern.Value.IsMatch(Number)).Key;

        return keyValuePair;
    }

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
    private static partial Regex AmexPattern();

    [GeneratedRegex(@"^5[1-5][0-9]{14}$|^2(2[2-9][1-9]|[3-6][0-9]{2}|7[0-1][0-9]|720)[0-9]{12}$")]
    private static partial Regex MasterCardPattern();

    [GeneratedRegex(@"^4[0-9]{12}(?:[0-9]{3})?$")]
    private static partial Regex VisaPattern();
}
