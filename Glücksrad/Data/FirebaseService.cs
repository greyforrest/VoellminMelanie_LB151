using Firebase.Database;
using Firebase.Database.Query;
using Google.Cloud.Firestore;

namespace Glücksrad.Data
{
    public class FirebaseService
    {
        private FirebaseClient firebaseClient = new FirebaseClient("https://gluecksrad-f1399-default-rtdb.europe-west1.firebasedatabase.app");

        public bool isLoggedIn { get; set; } = false;

        public async Task<List<Phrase>> getAllWords()
        {
            var words = await firebaseClient.Child("phrases").OnceAsListAsync<Phrase>();
            return words?.Select(x => new Phrase()
            {
                category = x.Object.category,
                word = x.Object.word
            }).ToList();

        }

        public async void addHighscore(Player player)
        {
            await firebaseClient.Child("highscore").PostAsync(player);

        }

        public async Task<List<Player>> getAllHighscores()
        {
            var words = await firebaseClient.Child("highscore").OnceAsync<Player>();
            return words?.Select(x => new Player()
            {
                name = x.Object.name,
                kontostand = x.Object.kontostand,
                lebenspunkte = x.Object.lebenspunkte,
                bereitsGespielteWörter = x.Object.bereitsGespielteWörter,
                runden = x.Object.runden,
                databaseId = x.Key
            }).ToList();
        }

        public async void deletePlayer(Player player)
        {
            await firebaseClient.Child("highscore").Child(player.databaseId).DeleteAsync();
        }

        public async void deletePhrase(Phrase phrase)
        {
            List<Phrase> old = await getAllWords();
            for(int i = 0; i < old.Count; i++)
            {
                if (old[i].word == phrase.word && old[i].category == phrase.category)
                {
                    old.Remove(old[i]);
                    break;
                }
            }
            await firebaseClient.Child("phrases").PutAsync(old);
        }

        public async void editPhrase(Phrase phrase, Phrase newPhrase)
        {
            List<Phrase> old = await getAllWords();
            for (int i = 0; i < old.Count; i++)
            {
                if (old[i].word == phrase.word && old[i].category == phrase.category)
                {
                    old[i] = newPhrase;
                    break;
                   
                }
            }
            await firebaseClient.Child("phrases").PutAsync(old);

        }

        public async void addPhrase(Phrase phrase)
        {
            List<Phrase> old = await getAllWords();
            old.Add(phrase);
            await firebaseClient.Child("phrases").PutAsync(old);
        }
        
        public async Task<bool> checkLogin(string name, string passwort)
        {
            var data = await firebaseClient.Child("admin").OnceAsync<string>();

            List<string> correctData = data.Select(data=> data.Object).ToList();

            return correctData[0].Equals(name) && correctData[1].Equals(passwort);
        }

    }
}
