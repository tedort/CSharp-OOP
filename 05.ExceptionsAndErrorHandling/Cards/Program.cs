namespace Cards
{
    public class Card
    {
        private readonly HashSet<string> validFaces = new HashSet<string> { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };
        private readonly HashSet<string> validSuits = new HashSet<string> { "S", "H", "D", "C"};

        private string face;
        private string suit;

        public Card(string face, string suit)
        {
            Face = face;
            Suit = suit;
        }

        public string Face 
        { 
            get => face;
            private set
            {
                if (!validFaces.Contains(value))
                {
                    throw new ArgumentException("Invalid card!");
                }
                face = value;
            }
        }
        public string Suit 
        {
            get => suit;
            private set
            {
                if (!validSuits.Contains(value))
                {
                    throw new ArgumentException("Invalid card!");
                }
                suit = value;
            }
        }

        public override string ToString()
        {
            char suitCharacter = Suit switch
            {
                "S" => '\u2660',
                "H" => '\u2665',
                "D" => '\u2666',
                "C" => '\u2663'
            };
            return $"[{Face}{suitCharacter}]";
        }
    }
    
    public class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            List<Card> cards = new List<Card>();
            string[] cardPairs = input.Split(", ", StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < cardPairs.Length; i++)
            {
                string[] cardTokens = cardPairs[i].Split(" ", StringSplitOptions.RemoveEmptyEntries);
                try
                {
                    Card card = CreateCard(cardTokens[0], cardTokens[1]);
                    cards.Add(card);
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            Console.WriteLine(string.Join(" ", cards));
        }

        public static Card CreateCard(string face, string suit)
        {
            Card card = new Card(face, suit);
            return card;
        }
    }
}
