# RENTAL SYSTEM APP
Aplikacja konsolowa napisana w języku C# symulująca działanie wypożyczalni sprzętu.
Celem projektu było praktyczne zastosowanie zasad programowania obiektowego i zasad SOLID

# INSTRUKCJA URUCHOMIENIA
** Aplikacja została napisana z wykorzystaniem .NET 10.0 SDK
1. Sklonuj repozytorium:
`git clone <link_do_repozytorium>`
2. Otwórz projekt w twoim ulubionym IDE lub:
   3. Zbuduj projekt w głównym folderze, w terminalu wpisz:
   `dotnet build`
   4. Uruchom aplikacje komendą:
   `dotnet run`

# OPIS DECYZJI PROJEKTOWYCH
## ODPOWIEDZIALNOŚĆ KLAS
W projekcie rozdzieliłem model domenowy, logikę biznesową oraz interfejs użytkownika,
aby struktura projektu była jak najbardziej przejrzysta i łatwa w rozwoju oraz późniejszej eksploatacji:
- Modele (np. 'Equipment', 'User') - Ich zadaniem jest jedynie przechowywać podstawe dane jakichś wzorców, nie zawierają logiki
- Logika (np. 'RentalService') - Skupia się na wykonywaniu różnych operacji np. weryfikacja dostępności sprzętu, obliczanie kary za opóźniony zwrot
- Magazyn danych ('DataStore) - W tym projekcie baza danych typu MySQL itp. nie została wykorzystana, dlatego w ramach symulacji został stworzony
tymczasowy magazyn danych w celu symulacji
- Interfejs użytkownika ('DisplayManager') - Odpowiada za wypisywanie w konsoli formatowanych list, raportów itp.

## KOHEZJA
- Klasy skupiają się na własnych funkcjach, są ściśle powiązane z nimi
- np. Klasa 'Rental' zawiera tylko właściwości, które faktycznie opisują wypożyczenie. Nie ma w niej funkcji do zarządzania listą użytkowników itp.
- Ukryte settery narzucają świadome zarządzanie obiektami

## COUPLING
- Zmiany w jednej części systemu nie będą psuć innej
- Np. Polimorfizm dla różnych typów użytkownika. Modele użytkoników same definują swój limit wypożyczeń; Klasy 'Program.cs', 'DisplayManager' nie znają reguł naliczania kar, wypożyczania sprzętu itp.