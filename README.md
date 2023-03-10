# VoellminMelanie_LB151 - Glücksrad

Diese Blazor-Applikation ist ein "Replika" des Spieles "Glücksrad", bei welchem man ein Rad dreht, und danach eine Phrase/ein Wort raten muss. Für jeden richtig geratenen Buchstaben gibt es einen Betrag x, der beim Drehen des Rades bestimmt wird. Das Rad kann auch einen sofortigen Bankkrott herbeirufen.

## Anleitung Installierung

### Code herunterladen

Der Code kann entweder als .zip heruntergeladen oder gleich das gesamte Repository geklont werden. Als IDE habe ich Visual Studio genutzt und würde dies auch weiterempfehlen.

Der heruntergeladene Ordner muss noch entzippt werden und dann sollte mit einem Klick auf die .sln-Datei das Projekt (falls installiert) in Visual Studio geöffnet werden. Eventuell muss noch das NuGet-Packet "FirebaseDatabse.net" von StepUpLabs installiert werden. Danach kann auf "Start" (oben circa mittig, mit grünem Pfeil) geklickt werden und die Applikation sollte sich in einem Browserfenster öffnen.

### Datenbank

Die Datenbank des Spieles ist auf Firebase gehosted. Da im Code bereits der Link zu meiner Datenbank gegeben ist, und der Zugang unbeschränkt ist, muss keine Veränderung vorgenommen werden.

Falls gewünscht, kann jedoch gerne eine eigenen Datenbank auf Firebase erstellt werden. Mein Link muss dann einfach durch den Eigenen ersetzt werden. Der aktuelle Datenbankstand ist ebenfalls im Repository zu finden und kann auf Firebase hochgeladen werden, damit schon mal Anfang besteht.

### Datenverwaltung und Adminlogin

Für das Adminlogin gibts es einen Account mit folgenden Daten:

**Benutzername: adminlogin**

**Passwort: difficultAdminLoginPassw0rd**

### Probleme 

Das Verändern der Daten aktualisiert die Ansicht nicht immer. Ein Highscore kann gelöscht werden und die Ansicht wird sofort aktualisiert. Bei Wörtern wird die Ansicht jedoch nicht aktualisiert. Egal ob ein Wort gelöscht, hinzugefügt oder bearbeitet wird, man muss die Ansicht verlassen und wieder zurückkommen um eine angepasst Ansicht zu bekommen. Die Daten werden im Hintergrund jedoch korrekt verarbeitet. 
