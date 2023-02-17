using Firebase.Database;
using Firebase.Database.Query;

namespace Glücksrad.Data
{
    public class FirebaseService
    {
        private FirebaseClient firebase = new FirebaseClient("https://gluecksspiel-8822f-default-rtdb.europe-west1.firebasedatabase.app/");


        public async Task<List<KeyValuePair<string, Phrase>>> getAllWords()
        {
            var words = await firebase.Child("phrases").OnceAsync<Phrase>();
            return words?.Select(x => new KeyValuePair<string, Phrase>(x.Key, x.Object)).ToList();

        }

        public async Task<string> getCategoryById(int catNumber)
        {
            var category = await firebase.Child("categories").Child(catNumber.ToString()).OnceAsync<string>();
            return category.ToString();
        }

        public async void addHighscore(Player player)
        {
            await firebase.Child("highscore").PostAsync(player);
        }
    }
}
