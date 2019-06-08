namespace Deck.ComplexObject
{

    //Класс хранит информацию об 1 карте
    public class Card
    {
        public string Name { get; set; } //значение
        public string Suit { get; set; } //масть

        public override string ToString()
        {
            return string.Concat(Name, ".", Suit, " ");
        }
    }
}
