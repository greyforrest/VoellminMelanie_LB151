using Firebase.Database;
using Firebase.Database.Query;
using Google.Cloud.Firestore;

namespace Glücksrad.Data
{
    public class FirebaseService
    {
        private FirebaseClient firebaseClient = new FirebaseClient("https://gluecksrad-f1399-default-rtdb.europe-west1.firebasedatabase.app");

        public bool isLoggedIn { get; set; } = false;
        public string spinResult { get; set; } = "Noch nicht gedreht";

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

            await firebaseClient.Child("phrases").OrderBy("word").EqualTo(phrase.word).DeleteAsync(); 
        }

        public async void editPhrase(Phrase phrase, Phrase newPhrase)
        {
            await firebaseClient.Child("phrases").OrderBy("word").EqualTo(phrase.word).PutAsync(newPhrase);
        }

        public async void addPhrase(Phrase phrase)
        {
            List<Phrase> all = await getAllWords();
            await firebaseClient.Child("phrases").Child(all.Count.ToString()).PutAsync(new {word =  phrase.word, category =  phrase.category});
        }
        
        public async Task<bool> checkLogin(string name, string passwort)
        {
            var data = await firebaseClient.Child("admin").OnceAsync<string>();

            List<string> correctData = data.Select(data=> data.Object).ToList();

            return correctData[0].Equals(name) && correctData[1].Equals(passwort);
        }

    }
}
