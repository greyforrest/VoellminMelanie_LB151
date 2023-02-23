﻿using Firebase.Database;
using Firebase.Database.Query;
using Google.Cloud.Firestore;

namespace Glücksrad.Data
{
    public class FirebaseService
    {
        private FirebaseClient firebaseClient = new FirebaseClient("https://gluecksrad-f1399-default-rtdb.europe-west1.firebasedatabase.app");


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
                runden = x.Object.runden
            }).ToList();
        }
    }
}
