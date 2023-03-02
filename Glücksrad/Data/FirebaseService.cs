using Firebase.Database;
using Firebase.Database.Query;

namespace Glücksrad.Data
{
    public class FirebaseService
    {
        private FirebaseClient firebaseClient = new FirebaseClient("https://gluecksrad-f1399-default-rtdb.europe-west1.firebasedatabase.app");

        public bool eingeloggt { get; set; } = false;
        public string radResultat { get; set; } = "Noch nicht gedreht";

        public async Task<List<Phrase>> getAllePhrasen()
        {
            var phrasen = await firebaseClient.Child("phrases").OnceAsListAsync<Phrase>();
            return phrasen?.Select(x => new Phrase()
            {
                kategorie = x.Object.kategorie,
                phrase = x.Object.phrase
            }).ToList();

        }

        public async void highscoreHinzufügen(Spieler spieler)
        {
            await firebaseClient.Child("highscore").PostAsync(spieler);

        }

        public async Task<List<Spieler>> getAlleHighscores()
        {
            var phrasen = await firebaseClient.Child("highscore").OnceAsync<Spieler>();
            return phrasen?.Select(x => new Spieler()
            {
                name = x.Object.name,
                kontostand = x.Object.kontostand,
                lebenspunkte = x.Object.lebenspunkte,
                zeitpunkt = x.Object.zeitpunkt,
                bereitsGespielteWörter = x.Object.bereitsGespielteWörter,
                runden = x.Object.runden,
                datenbankID = x.Key
            }).ToList();
        }

        public async void spielerLöschen(Spieler spieler)
        {
            await firebaseClient.Child("highscore").Child(spieler.datenbankID).DeleteAsync();
        }

        public async void phraseLöschen(Phrase phrase)
        {
            List<Phrase> alles = await getAllePhrasen();
            for(int i = 0; i < alles.Count; i++)
            {
                if (alles[i].phrase ==  phrase.phrase && alles[i].kategorie == phrase.kategorie)
                {
                    alles.RemoveAt(i);
                }
            }
            await firebaseClient.Child("phrases").PutAsync(alles); 
        }

        public async void phraseBearbeiten(Phrase phrase, Phrase neuePhrase)
        {
            List<Phrase> alles = await getAllePhrasen();
            for (int i = 0; i < alles.Count; i++)
            {
                if (alles[i].phrase == phrase.phrase && alles[i].kategorie == phrase.kategorie)
                {
                    alles[i] = neuePhrase;
                }
            }
            await firebaseClient.Child("phrases").PutAsync(alles);
        }

        public async void phraseHinzufügen(Phrase phrase)
        {
            List<Phrase> alles = await getAllePhrasen();
            alles.Add(phrase);
            await firebaseClient.Child("phrases").PutAsync(alles);
        }
        
        public async Task<bool> loginÜberprüfung(string name, string passwort)
        {
            var data = await firebaseClient.Child("admin").OnceAsync<string>();

            List<string> correctData = data.Select(data=> data.Object).ToList();

            return correctData[0].Equals(name) && correctData[1].Equals(passwort);
        }

    }
}
