namespace Glücksrad.Data
{
    public class Player
    {

        private string name;
        private int kontostand;
        private int lebenspunkte;
        private List<string> bereitsGespielteWörter = new List<string>();
        private int runden;

        public Player(string name)
        {
            this.name = name;
            kontostand = 0;
            lebenspunkte = 3;
            runden = 1;
        }

        //Gibt *false* zurück, wenn das Wort bereits in der Liste ist, ansonst wird das Wort hinzugefügt und returned true
        public bool addWord(string word)
        {
            if(bereitsGespielteWörter.Contains(word))
            {
                return false;
            } else
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

        //Zieht ein Lebenspunkt ab und gibt dann aus, ob der Spieler noch lebt (true/false)
        public bool removeLebenspunkt()
        {
            lebenspunkte -= 1;
            if(lebenspunkte > 0)
            {
                return true;
            } else
            {
                return false;
            }
        }

        public string getName()
        {
            return name;
        }

        public int getKontostand() {
            return kontostand;
        }

        public int getRunden()
        {
            return runden;
        }

        public int getLebenspunkte()
        {
            return lebenspunkte;
        }

    }
}
