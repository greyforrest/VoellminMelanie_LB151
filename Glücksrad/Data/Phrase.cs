namespace Glücksrad.Data
{
    public class Phrase
    {
        public string category { get; set; }

        public string word { get; set; }

        public Phrase()
        {

        }

        public Phrase(string category, string word)
        {
            this.category = category;
            this.word = word;
        }
    }
}
