# Klassendiagramme:

@startuml

class Logging{
    + {static} logger: Serilog.Core.Logger
    + {static} init(): void
}

class Quizclass{
    + Quizes: List<Quiz>
    + CurrentQuestion: int
    + Quizclass(): void
    + Load(): void
    + Save(): void
    + Guess(): bool
    + AddQuiz(): void
}

class Quiz{
    + Frage: List<string>
    + Antwort1: List<string>
    + Antwort2: List<string>
    + Antwort3: List<string>
    + Antwort4: List<string>
    - Richtige: List<int>
    + Quiz(): void
    + Check(int currentquestion): bool
}

class User{
    + Id: int
    + Name: string
    + E-Mail: string
    + Passwort: string
    + User(int id, string name, string email, string password): void
}

class User_list{
    + Users: List<User>
    + User_list(): void
    + Load_users(): void
}

class Zahlung{
    - _client: HttpClient
    - _clientSecret: string
    + Zahlung(): void
    - InitializeAsync(string orderId, decimal amount): Task
    - OpenStripeCheckoutAsync(): Task
}

Quiz <-- Quizclass
User_list <-- User

@enduml