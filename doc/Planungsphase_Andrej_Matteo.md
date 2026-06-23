# Planungsphase
## Skizzen
Login:

![alt text](image-8.png)


Main Menü:
![alt text](image-10.png)


Quiz Auswahl:
![alt text](image-19.png)

Quiz:
![alt text](image-7.png)


Shop:
![alt text](image-15.png)


Achievements:
![alt text](image-13.png)


Fortschritt Checker:
![alt text](image-12.png)





## Benutzer Navigation
Die Benutzernavigation unserer Quiz-App wurde so aufgebaut, dass sich der Benutzer schnell und einfach in der Anwendung zurechtfinden kann. Nach dem Start der App gelangt der Nutzer in das Loginmenü. Dort kann er sich mit seiner E-Mail anmelden oder ein neuen Benutzer erstellen. Nach dem Loginvorgang kommt der User ist Mainmanü. Von dort aus können alle wichtigen Bereiche der Anwendung erreicht werden, wodurch die Bedienung übersichtlich bleibt.

Im Hauptmenü hat der Benutzer die Möglichkeit: ein Quiz zu starten, den Shop zu öffnen, seinen Fortschritt anzusehen oder die Achievements anzusehen. Zusätzlich kann die Anwendung über den Exit-Button beendet werden. 

Wählt der Benutzer den Bereich „Quiz“, gelangt er zuerst zur Quiz-Auswahl. Dort kann zwischen verschiedenen Fächern wie POS, NSCS, CABS, Englisch oder Geschichte gewählt werden. Nach der Auswahl startet direkt das passende Quiz. Während des Quiz werden Fragen mit vier Antwortmöglichkeiten, Richtig oder Falsch oder Textbox-Fragen (teilweise KI-bewertet) angezeigt. Der Benutzer beantwortet die Fragen. Nach Abschluss des Quiz wird der Fortschritt gespeichert und der Benutzer kann zum Hauptmenü zurückkehren.

Im Shop können neue Button-Designs mit Coins freigeschaltet werden. Zusätzlich gibt es einen Achievement-Bereich, in dem besondere Erfolge angezeigt werden, zum Beispiel das Erreichen von 100 % in einem Quiz oder das Freischalten aller Designs.

Der Fortschritt-Checker dient dazu, die bisherigen Ergebnisse übersichtlich darzustellen. Über Fortschrittsbalken kann der Benutzer schnell erkennen, wie gut er in den einzelnen Quizen abgeschnitten hat.

## Klassendiagramme:

@startuml

skinparam classAttributeIconSize 0

class Logging {
    + {static} logger: Serilog.Core.Logger
    + {static} Init(): void
}

enum ShopItem {
    Button1
    Button2
    Button3
    Background1
    Background2
    Background3
}

class Shop <<(S, #00aaff)>> {
    + {static} Freigeschaltet: List<ShopItem>
    + {static} Money: double
    + {static} Load(): void
    + {static} Save(): void
    + {static} Purchase(item: ShopItem): void
}

class Achievement {
    + Name: string
    + IsUnlocked: bool
}

class Achievements <<(S, #00aaff)>> {
    - {static} achievements: List<Achievement>
    + {static} Unlock(name: string): void
    + {static} Load(): void
    + {static} Save(): void
}

class Progress {
    + Subjects: List<Checker>

    + Progress()
    + Save(): void
    + Load(): void
}


class Quizclass {
    + ausgewaehlt: int
    + Questions: List<Frage>

    + Quizclass()
    + Load(): void
    + Save(): void
    + Guess(): bool
    + Add(frage: Frage): void
}

class Frage {
    + frage: string
    + antworten: List<string>
    + richtig: int

    + Frage(frage: string, antworten: List<string>, richtig: int)
    + Check(ausgewaehlt: int): bool
}

class Zahlung {
    - client: HttpClient
    - clientSecret: string
    + Zahlung()
    - InitializeAsync(amount: decimal): Task<string>
    - OpenStripeCheckoutAsync(): Task
}

class Checker {
    + Quizzes_correct: int
    + Quizzes_prozent: int

    + AddCorrect() void
    + Calculate(gesamt: int) void
}

' Beziehungen


Progress --> Checker
Quizclass --> "*" Frage
Quizclass --> Checker
Achievements --> "*" Achievement
Shop --> ShopItem

@enduml

<style>

</style>

<style>

</style>

<style>

</style>


## Tabellarischer Zeitplan
![alt text](image-17.png)
![alt text](image-18.png)