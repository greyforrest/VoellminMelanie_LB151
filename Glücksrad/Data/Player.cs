namespace Glücksrad.Data
{
    public class Player
    {

        public string name { get; set; }
        public int kontostand { get; set; }
        public int lebenspunkte { get; set; }
        public List<string> bereitsGespielteWörter { get; set; }
        public int runden { get; set; }


        public Player() { }
        public Player(string name)
        {
            this.name = name;
            kontostand = 0;
            lebenspunkte = 3;
            runden = 0;
            bereitsGespielteWörter = new List<string>();
        }

        //Gibt *false* zurück, wenn das Wort bereits in der Liste ist, ansonst wird das Wort hinzugefügt und returned true
        public bool addWord(string word)
        {
            if (bereitsGespielteWörter.Contains(word))
            {
                return false;
            }
            else
            {
                bereitsGespielteWörter.Add(word);
                return true;
            }
        }

        public void increaseRunden()
        {
            runden++;
        }

        public void changeKontostand(int number)
        {
            kontostand += number;
        }

        public void emptyKontostand()
        {
            kontostand = 0;
        }

        //Zieht ein Lebenspunkt ab und gibt dann aus, ob der Spieler noch lebt (true/false)
        public bool removeLebenspunkt()
        {
            lebenspunkte -= 1;
            if (lebenspunkte > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
