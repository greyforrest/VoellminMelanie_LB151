namespace Glücksrad.Data
{
    public class Phrase
    {
        public string kategorie { get; set; }

        public string phrase { get; set; }

        public Phrase()
        {

        }

        public Phrase(string category, string word)
        {
            this.kategorie = category;
            this.phrase = word;
        }
    }
}
