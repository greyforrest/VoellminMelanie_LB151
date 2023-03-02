namespace Glücksrad.Data
{
    public class Spieler
    {

        public string name { get; set; }
        public int kontostand { get; set; }
        public int lebenspunkte { get; set; }
        public List<string> bereitsGespielteWörter { get; set; }
        public int runden { get; set; }
        public DateTime zeitpunkt { get; set; }
        public string datenbankID { get; set; }


        public Spieler() { }
        public Spieler(string name)
        {
            this.name = name;
            kontostand = 0;
            lebenspunkte = 3;
            runden = 0;
            bereitsGespielteWörter = new List<string>();
            zeitpunkt = DateTime.Now;
        }

        //Gibt *false* zurück, wenn das Wort bereits in der Liste ist, ansonst wird das Wort hinzugefügt und returned true
        public bool wortHinzufügen(string wort)
        {
            if (bereitsGespielteWörter.Contains(wort))
            {
                return false;
            }
            else
            {
                bereitsGespielteWörter.Add(wort);
                return true;
            }
        }

        public void rundenzahlErhöhen()
        {
            runden++;
        }

        public void kontostandÄndern(int änderung)
        {
            kontostand += änderung;
        }

        public void kontostandLeeren()
        {
            kontostand = 0;
        }

        //Zieht ein Lebenspunkt ab und gibt dann aus, ob der Spieler noch lebt (true/false)
        public bool lebenspunktAbziehen()
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
