# Projekt-Dokumentation

Völlmin

| Datum | Version | Zusammenfassung                                              |
| ----- | ------- | ------------------------------------------------------------ |
| 09.01.2023 | 0.0.1   | Vorarbeit Dokumentation bis und mit Aufgabe 4 |
| 12.01.2023 | 0.0.2   | GUI Design  (Aufgabe 5) |
| 26.01.2023 | 0.0.3   | Erste Version erstellt (Funktionalität etwa 70%) |
| 17.02.2023 | 0.0.4   | Design und Logikupdates, Probleme mit Firebase |
| 23.02.2023 | 0.0.5   | Funktionalität circa 95%, Adminlogin fehlt |
| 01.03.2023 | 0.0.6   | Funktionalität 100% inklusive Adminlogin |
| | 1.0.0   | |

# 0 Ihr Projekt

In dieser Webapplikation soll der Nutzer ein Quiz spielen können, dass ähnlich wie das Quiz aus der Fernsehserie "Glückspiel" ist und in dem es darum geht, Wörter oder Sätze zu erraten, um Geld zu gewinnen.

# 1 Analyse

* Tier 1 (Presentation): Login-Seite für Administratoren, Startseite mit Namensfeld für Benutzer, Verwaltung von Wörtern/Sätzen und Kategorien für Administratoren, Highscore-Liste, Glücksspielseite
* Tier 2 (Webserver): steuert das GUI und verbindet GUI mit tieferen Schichten
* Tier 3 (Application Server): Logik der Applikation, liest Daten aus der Datenbank aus und schreibt Daten in die Datenbank, überprüft Eingaben serverseitig
* Tier 4 (Dataserver): Speichert die Daten für das Spiel, die Login-Daten der Administratoren und den Highscore von Benutzern

# 2 Technologie

* Tier 1 (Presentation): HTML, CSS (Blazor)
* Tier 2 (Webserver): Blazor
* Tier 3 (Application Server): C#
* Tier 4 (Dataserver): Firebase Realtime Database (JSON Struktur)

# 3 Datenbank

Die Firebase-Datenbank wird mit Firebase-Nugetpackages angesprochen (FirebaseDatabase.net von StepUpLabs). Die Verbindung stellt man durch einen Link der Datenbank her. Die Datenbank hat die Form eines JSON-Baums und kann einfach ausgelesen werden. Über die Firebase-Konsole kann man auf die Datenbank zugreifen und auch die Sicherheitsregeln einstellen. Man kann von dort aus Daten in die Datenbank schreiben und vorhandene Daten löschen, jedoch nicht bearbeiten.

# 4.1 User Stories

| US-№ | Verbindlichkeit | Typ  | Beschreibung                       |
| ---- | --------------- | ---- | ---------------------------------- |
| 1 | Muss | Funktional | Als Administrator möchte ich mich mit einem Admin-Login anmelden können, damit ich die Wörter/Sätze und Kategorien des Spiels zu verwalten und Highscore-Einträge löschen kann. |
| 2 | Muss | Funktional | Als Administrator möchte ich die Wörter und Sätze des Spiels verwalten können, damit das Spiel spannend gehalten wird.|
| 3 | Muss | Funktional | Als Administrator möchte ich Kategorien anlegen können, damit ich die Wörter und Sätze des Spiels Kategorien zuordnen kann. |
| 4 | Muss | Funktional | Als Administrator möchte ich einzelne Highscore-Einträge löschen können, damit die Highscore Liste ordentlich gehalten wird.|
| 5 | Muss | Funktional | Als Kandidat*/in möchte ich mich zu Beginn einen Namen angeben können, damit ich mich in der Highscore-Liste verewigen kann. |
| 6 | Muss | Funktional | Als Kandidat*/in möchte ich zu jeder Zeit mein Kontostand und meine aktuellen Lebenspunkte sehen können, damit ich weiss, wie ich im Spiel stehe. |
| 7 | Muss | Funktional | Als Kandidat*/in möchte ich wissen, ob meine Antwort richtig oder falsch wahr, damit ich mit dem Spiel fortfahren kann. |
| 8 | Muss | Qualität | Als Kandidat*/in möchte ich Rangliste nach Geldbetrag sortiert haben, damit ich sehe, wie ich im Vergleich zu anderen Spielern stehe.|
| 9 | Muss | Funktional | Als Kandidat*/in möchte ich Wörter und Phrasen nur einmal spielen, damit das Spiel spannend gehalten wird.|
| 10 | Muss | Funktional | Als Kandidat*/in möchte ich jederzeit aufhören und meinen Geldbetrag in die Highscore-Liste eintragen können, damit ich einen guten Highscore erzielen kann. |
| 11 | Muss | Funktional | Als Kandidat*/in möchte ich beim Aufhören wissen, wie viele Runden ich gespielt habe, damit ich das Verhältnis meines Geldbetrages mit den gespielten Runden mit den anderen Spieler in der Highscore-Liste vergleichen kann. |
| 12 | Muss | Rand | Als Auftraggeber möchte ich, dass einfache Textfelder sowohl client- als auch serverseitig geprüft werden, damit der Benutzer keinen Einfluss auf die Validierung haben kann. |
| 13 | Muss | Rand | Als Auftraggeber möchte ich, dass die Applikation so sicher wie möglich ist, damit ich meine Daten schützen und meinen Benutzern eine tolle Erfahrung bieten kann. |
| A | Kann | Qualität | Als Kandidat*/in möchte ich die Rangliste zu jedem Zeitpunkt herunterladen können, damit ich meinen Rang dieses Moments für immer behalten kann. |
| B | Muss | Rand | Als Entwickler möchte ich diese Webapplikation mit Blazor umsetzen, damit ich auch neuere Webframeworks kennenlerne. |

# 4.2 Testfälle

| TC-№ | Vorbereitung | Eingabe | Erwartete Ausgabe |
| ---- | ------------ | ------- | ----------------- |
| 1.1 | Website geöffnet, Admin noch nicht eingeloggt | Der Admin gibt beim Admin-Login korrekte Daten ein. | Der Admin hat nun Zugriff auf eine weitere Seite, auf welcher er die Wörter und Kategorien des Spiels verwalten kann. |
| 1.2 | Website geöffnet, Admin noch nicht eingeloggt | Der Admin gibt beim Admin-Login falsche Daten ein. | Der Admin hat keinen Zugriff auf die Verwaltungsseite und ist nicht eingeloggt. |
| 1.3 | Website geöffnet, Admin noch nicht eingeloggt | Der Admin gibt beim Admin-Login korrekte Daten ein. | Der Admin kann Einträge von der Highscore-Liste entfernen. |
| 1.4 | Website geöffnet, Admin noch nicht eingeloggt | Der Admin gibt beim Admin-Login falsche Daten ein. | Der Admin ist nicht eingeloggt und kann somit auch nichts an der Highscore-Liste verändern. |
| 2.1 | Website geöffnet, Admin eingeloggt, Verwaltungsseite geöffnet | Der Admin klickt bei einem Wort/Satz aus der Wortliste auf den Mülleimer (= "löschen"). | Das Wort verschwindet aus der Liste und der Datenbank, und wird auch bei erneutem Öffnen der Seite nicht mehr angezeigt. |
| 2.2 |  Website geöffnet, Admin eingeloggt, Verwaltungsseite geöffnet | Der Admin klickt bei einem Wort/Satz aus der Wortliste auf den Stift (= "bearbeiten"). | Der Admin kann das Wort/den Satz umschreiben, die Kategorie wechseln und dann so speichern. |
| 2.3 | Website geöffnet, Admin eingeloggt, Verwaltungsseite geöffnet | Der Admin klickt oberhalb der Wortliste auf das Plus (= "hinzufügen"). | Der Admin kann ein neues Wort/einen neuen Satz hinzufügen. |
| 3.1 | Website geöffnet, Admin eingeloggt, Verwaltungsseite geöffnet | Der Admin klickt oberhalb der Kategorieliste auf das Plus (= "hinzufügen"). | Der Admin kann eine neue Kategorie hinzufügen. |
| 4.1 | Website geöffnet, Admin eingeloggt, Highscore-Liste geöffnet | Der Admin klickt hinter einem Eintrag auf den Mülleimer (= "löschen"). | Der Eintrag verschwindet aus der Highscore-Liste und der Datenbank, und wird auch bei erneutem Öffnen der Seite nicht mehr angezeigt. |
| 5.1 | - | Der Kandidat öffnet die Webseite "Glücksspiel". | Es wird eine Seite mit einem Eingabefeld für den Namen und einem Start-Knopf angezeigt. |
| 6.1 | Glücksspiel gestartet | - | Der Kontostand und die Lebenspunkte sind zusehen. |
| 7.1 | Glücksspiel gestartet | Der Kandidat gibt eine richtige Antwort. | Das Spiel zeigt das Wort/den Satz an. |
| 7.2 | Glücksspiel gestartet | Der Kandidat gibt eine falsche Antwort. | Es erscheint eine Meldung, dass diese Eingabe falsch war. Ein Lebenspunkt wird abgezogen. |
| 8.1 | Highscore-Liste beinhaltet mindestens 2 Einträge | Highscore-Seite wird geöffnet | Die Highscore-Liste ist nach Rängen sortiert. Rang 1 ist die Person mit dem grössten Geldbetrag, Rang 2 die Person mit dem zweitgrössten Geldbetrag, usw. |
| 9.1 | Glücksspiel gestartet, erste Runde | Der Kandidat hat ein Wort/ein Satz erraten. | Das nächste Wort/der nächste Satz ist nicht dasselbe. |
| 9.2 | Glücksspiel gestartet, zweite Runde | Der Kandidat hat das zweite Wort/den zweiten Satz erraten. | Das nächste Wort/der nächste Satz ist weder das Wort/der Sart aus der ersten Runde, noch das/der aus der Zweiten. |
| 9.3 | Glücksspiel gestartet, dritte Runde | Der Kandidat hat das dritte Wort/den zweiten Satz erraten. | Das nächste Wort/der nächste Satz ist weder das Wort/der Sart aus den ersten zwei Runden, noch das/der aus der letzten. |
| 10.1 | Glücksspiel gestartet | - | Ein Button "aufhören" ist zu sehen. |
| 10.2 | Glücksspiel gestartet | Die Kandidatin klickt auf "aufhören". | Das Spiel wird beendet und der Geldbetrag der Kandidatin wird mit Name, Rundenanzahl und Zeitpunkt in die Highscore-Liste eingetragen. |
| 11.1 | Glücksspiel gestartet | Die Kandidatin klickt auf "aufhören". | Das Spiel wird beendet und die Rundenanzahl der Kandidatin wird mit Name, Geldbetrag und Zeitpunkt in die Highscore-Liste eingetragen. |
| A.1 | Highscore-Liste hat mindestens einen Eintrag, Highscore-Seite geöffnet | Die Kandidatin klickt auf das Download-Symbol. | Es wird lokal ein File heruntergeladen, dass die aktuelle Rangliste beinhaltet. |

# 5 Prototyp

![Design Spielseite](https://user-images.githubusercontent.com/69569613/212004119-1d4f64f6-71b5-46d7-9a41-e18e5e8c6541.png)

![Design Adminseite und Datenverwaltung](https://user-images.githubusercontent.com/69569613/212004220-323a1a46-76ed-470c-bb65-55cfac574b3c.png)



# 6 Implementation

✍️ Halten Sie fest, wann Sie welche User Story bearbeitet haben

| User Story | Datum | Beschreibung |
| ---------- | ----- | ------------ |
| 5 | 26.01.2023 | Name kann eingegeben werden, wird noch nicht für die Highscoreliste gespeichert |
| 6 | 26.01.2023 | Lebenspunkte und Kontostand sichtbar, Lebenspunkte verändern sich, Kontostand noch nicht |
| 7 | 26.01.2023 | Feedback auf Eingabe wird gegeben, nicht sehr präzisiert und auch nicht sehr hilfreich, da die Buchstaben nicht eingesetzt werden |
| 7 | 17.02.2023 | Richtig geratenen Buchstaben werden eingesetzt |
| 9 | 17.02.2023 | Gespielte Wörter können im Spieler gespeichert werden, inklusive Feedback, ob das Wort schon mal gespielt wurde oder nicht |
| 10 | 17.02.2023 | Button "Spiel beenden" ist zu sehen und sollte die aktuellen Werte in Firebase speichern, wird jedoch noch nicht übertragen |
| 5 | 23.02.2023 | Name kann eingegeben werden, wird für die Highscoreliste verwendet |
| 6 | 23.02.2023 | Lebenspunkte und Kontostand sichtbar, Lebenspunkte verändern sich, Kontostand verändert sich ebenfalls |
| 8 | 23.02.2023 | Rangliste ist nach Geldbeträgen sortiert |
| 10 | 23.02.2023 | Button "Spiel beenden" ist zu sehen und speichert aktuellen Stand in der Datenbank, Spiel wird beendet |
| 11 | 23.02.2023 | Anzahl gespielte Runden werden in der Highscoreliste angezeigt |
| 1 | 01.03.2023| Admin kann sich mit Login "adminlogin" und "difficultAdminLoginPassw0rd" einloggen.  |
| 2 | 01.03.2023| Eingeloggter Admin kann Wörter und Kategorien hinzufügen, bearbeiten und löschen.  |
| 3 | 01.03.2023| Eingeloggter Admin kann die Kategorien der Wörter bearbeiten und neue Kategorien hinzufügen. |
| 4 | 01.03.2023| Eingeloggter Admin kann Highscore-Einträge löschen. |
| A | 01.03.2023| Highscore kann als .txt heruntergeladen werden. |


# 7 Projektdokumentation

| US-№ | Erledigt? | Entsprechende Code-Dateien oder Erklärung |
| ---- | --------- | ----------------------------------------- |
| 1 | ja | Adminlogin auf der Seite "Datenverwaltung.razor", Passwort und Benutzername auf Firebase gespeichert |
| 2 | ja | Eingeloggter Admin sieht auf Seite "Datenverwaltung.razor" alle Wörter und Kategorien, gespeichert in Firebase, können bearbeitet, gelöscht und neu hinzugefügt werden. |
| 3 | ja | Kategorien sind nicht separat sichtbar, nur gemeinsam mit Wörtern, ebenfalls in "Datenverwaltung.razor" |
| 4 | ja | Highscore-Liste wird ebenfalls in "Datenverwaltung.razor" angezeigt, jeder Eintrag kann gelöscht werden. |
| 5 | ja | "Glücksspiel.razor" fragt zuerst nach einem Namen, dieser wird dann in Datenbank gespeichert. |
| 6 | ja | "Glücksspiel.razor" zeigt während des Spiels immer Lebenspunkte und Kontostand an. |
| 7 | ja | Falsche Antwort: Nichts passiert/ Richtige Antwort: Buchstabe(n) wird (werden) eingesetzt. Datei: Glücksspiel.razor |
| 8 | ja | "Highscores.razor" sortiert die Liste nach Geldbeträgen. |
| 9 | ja | Gespielte Wörter werden im Spieler abgespeichert, bei ausgewähltem Wort wird zuerst überprüft, ob es bereits gespielt wurde. Datei: Player.cs |
| 10 | ja | "Glücksspiel.razor" zeigt Knopf, um das Spiel zu stoppen. |
| 11 | ja | "Highscores.razor" zeigt Anzahl gespielte Runden an. |
| 12 | nein | Textfelder werden nicht überprüft, es wird keine Validierung vorgenommen.  |
| 13 | nein | Passwort des Admins wurde in der Datenbank aus zeitlichen Gründen nicht gehashet, Link zu Firebasedatenbank ist auf Github sichtbar und somit für andere zugreifbar. |
| A | ja | "Highscores.razor" hat einen Knopf "Herunterladen", der die Rangliste als .txt herunterlädt. Das Herunterladen wird via .js gemacht (siehe "download.js" in wwwroot). |
| B | ja | Wurde in Blazor umgesetzt, deswegen auch "Seitennname.**razor**" |


# 8 Testprotokoll

**Link zum Testvideo: https://youtu.be/OMwECtYwAjI **

| TC-№ | Datum | Resultat | Tester |
| ---- | ----- | -------- | ------ |
| 1.1 | 02.03.2023 | OK | Melanie Völlmin |
| 1.2 | 02.03.2023 | OK | Melanie Völlmin |
| 1.3 | 02.03.2023 | OK | Melanie Völlmin |
| 1.4 | 02.03.2023 | OK | Melanie Völlmin |
| 2.1 | 02.03.2023 | OK | Melanie Völlmin |
| 2.2 | 02.03.2023 | OK | Melanie Völlmin |
| 2.3 | 02.03.2023 | OK | Melanie Völlmin |
| 3.1 | 02.03.2023 | (OK) | Melanie Völlmin |
| 4.1 | 02.03.2023 | OK | Melanie Völlmin |
| 5.1 | 02.03.2023 | OK | Melanie Völlmin |
| 6.1 | 02.03.2023 | OK | Melanie Völlmin |
| 7.1 | 02.03.2023 | OK | Melanie Völlmin |
| 7.2 | 02.03.2023 | (OK) | Melanie Völlmin |
| 8.1 | 02.03.2023 | OK | Melanie Völlmin |
| 9.1 | 02.03.2023 | OK | Melanie Völlmin |
| 9.2 | 02.03.2023 | OK | Melanie Völlmin |
| 9.3 | 02.03.2023 | OK | Melanie Völlmin |
| 10.1 | 02.03.2023 | OK | Melanie Völlmin |
| 10.2 | 02.03.2023 | OK | Melanie Völlmin |
| 11.1 | 02.03.2023 | OK | Melanie Völlmin |
| A.1 | 02.03.2023 | OK | Melanie Völlmin |

Die Tests wurden gut erfüllt, das Raten eines falschen Buchstabens könnte verdeutlicht werden, ist jedoch in Ordnung. Testfall 3.1 kann nicht so durchgeführt werden, da die Ansicht anders umgesetzt wurde und es keine Kategorie-Ansicht gibt, sondern nur die Worte mit Kategorien gemeinsam. Trotzdem können Kategorien hinzugefügt, gelöscht und auch bearbeitet werden.
