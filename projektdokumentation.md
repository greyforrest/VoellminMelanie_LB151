# Projekt-Dokumentation

Völlmin

| Datum | Version | Zusammenfassung                                              |
| ----- | ------- | ------------------------------------------------------------ |
| 09.01.2023 | 0.0.1   | Vorarbeit Dokumentation bis und mit Aufgabe 4 |
|       | 0.0.2   |                                                              |
|       | 0.0.3   |                                                              |
|       | 0.0.4   |                                                              |
|       | 0.0.5   |                                                              |
|       | 0.0.6   |                                                              |
|       | 1.0.0   |                                                              |

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

Die Firebase-Datenbank wird mit Firebase-Nugetpackages angesprochen (Firebase und Firebase.Database). Die Verbindung stellt man durch einen Link der Datenbank her. Die Datenbank hat die Form eines JSON-Baums und kann einfach ausgelesen werden. Über die Firebase-Konsole kann man auf die Datenbank zugreifen und auch die Sicherheitsregeln einstellen. Man kann von dort aus Daten in die Datenbank schreiben und vorhandene Daten löschen, jedoch nicht bearbeiten.

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
| 10 | Muss | Funktional | Als Kandidat*/in möchte ich jeder Zeit aufhören und meinen Geldbetrag in die Highscore-Liste eintragen können, damit ich einen guten Highscore erzielen kann. |
| 11 | Muss | Funktional | Als Kandidat*/in möchte ich beim Aufhören wissen, wie viele Runden ich gespielt habe, damit ich das Verhältnis meines Geldbetrages mit den gespielten Runden mit den anderen Spieler in der Highscore-Liste vergleichen kann. |
| 12 | Muss | Rand | Als Entwickler möchte ich, dass einfache Textfelder sowohl client- als auch serverseitig geprüft werden, damit der Benutzer keinen Einfluss auf die Validierung haben kann. |
| 13 | Muss | Rand | Als Entwickler möchte ich die Applikation so sicher wie möglich halten, damit meine Datenbank schützen und meinen Benutzern eine tolle Erfahrung bieten kann. |
| A | Kann | Qualität | Als Kandidat*/in möchte ich die Rangliste zu jedem Zeitpunkt herunterladen können, damit ich meinen Rang dieses Moments für immer behalten kann. |

# 4.2 Testfälle

| TC-№ | Vorbereitung | Eingabe | Erwartete Ausgabe |
| ---- | ------------ | ------- | ----------------- |
| 1.1 | Website geöffnet, Admin noch nicht eingeloggt | Der Admin gibt beim Admin-Login korrekte Daten ein. | Der Admin hat nun Zugriff auf eine weitere Seite, auf welcher er die Wörter und Kategorien des Spiels verwalten kann. |
| 1.2 | Website geöffnet, Admin noch nicht eingeloggt | Der Admin gibt beim Admin-Login falsche Daten ein. | Der Admin hat keinen Zugriff auf die Verwaltungsseite und ist nicht eingeloogt. |
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

✍️ Erstellen Sie Prototypen für das GUI (Admin-Interface und Quiz-Seite).

# 6 Implementation

✍️ Halten Sie fest, wann Sie welche User Story bearbeitet haben

| User Story | Datum | Beschreibung |
| ---------- | ----- | ------------ |
| ...        |       |              |

# 7 Projektdokumentation

| US-№ | Erledigt? | Entsprechende Code-Dateien oder Erklärung |
| ---- | --------- | ----------------------------------------- |
| 1    | ja / nein |                                           |
| ...  |           |                                           |

# 8 Testprotokoll

✍️ Fügen Sie hier den Link zu dem Video ein, welches den Testdurchlauf dokumentiert.

| TC-№ | Datum | Resultat | Tester |
| ---- | ----- | -------- | ------ |
| 1.1  |       |          |        |
| ...  |       |          |        |

✍️ Vergessen Sie nicht, ein Fazit hinzuzufügen, welches das Test-Ergebnis einordnet.

# 9 `README.md`

✍️ Beschreiben Sie ausführlich in einer README.md, wie Ihre Applikation gestartet und ausgeführt wird. Legen Sie eine geeignete Möglichkeit (Skript, Export, …) bei, Ihre Datenbank wiederherzustellen.

# 10 Allgemeines

- [ ] Ich habe die Rechtschreibung überprüft
- [ ] Ich habe überprüft, dass die Nummerierung von Testfällen und User Stories übereinstimmen
- [ ] Ich habe alle mit ✍️ markierten Teile ersetzt
