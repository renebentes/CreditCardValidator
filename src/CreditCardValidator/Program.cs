using CreditCardValidator;

Console.WriteLine("Enter a credit card number:");
string number = Console.ReadLine() ?? string.Empty;

var card = Card.TryCreate(number, out string error);

if (card.IsValid)
{
    Console.WriteLine($"Card Number: {card.Number} is valid and is of type {card.GetCardType()}.");
}
else
{
    Console.WriteLine(error);
}