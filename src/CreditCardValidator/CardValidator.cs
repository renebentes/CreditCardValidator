using System.Text.RegularExpressions;

namespace CreditCardValidator;

public partial class CardValidator
{
    public static bool TryValidateCardNumber(string cardNumber, out string error)
    {
        error = string.Empty;

        if (string.IsNullOrWhiteSpace(cardNumber))
        {
            error = "Card number cannot be null or empty.";
            return false;
        }

        if (!OnlyDigitsPattern().IsMatch(cardNumber))
        {
            error = "Card number must contain only digits.";
            return false;
        }

        int sum = 0;
        bool alternate = false;

        for (int i = cardNumber.Length - 1; i >= 0; i--)
        {
            int n = int.Parse(cardNumber[i].ToString());

            if (alternate)
            {
                n *= 2;
                if (n > 9)
                {
                    n -= 9;
                }
            }

            sum += n;
            alternate = !alternate;
        }

        if (sum % 10 != 0)
        {
            error = $"Card number {cardNumber} is invalid.";
            return false;
        }

        return true;
    }

    [GeneratedRegex(@"^\d+$")]
    private static partial Regex OnlyDigitsPattern();
}