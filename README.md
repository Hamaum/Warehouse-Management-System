# Projekt systemu i aplikacji do zarządzania magazynem i pracownikami

**Autor:** Artur Bosyk

## 📌 Wstęp i Cel projektu
Celem projektu jest stworzenie nowoczesnego, zintegrowanego systemu informatycznego, który umożliwi kompleksowe zarządzanie magazynem oraz personelem w jednej, intuicyjnej platformie dostępnej zarówno jako aplikacja internetowa dla kadry zarządzającej, jak i aplikacja mobilna dla pracowników magazynu.

System umożliwi szybkie planowanie i przydzielanie zadań, monitorowanie postępów pracy w czasie rzeczywistym oraz sprawną wymianę informacji.

## 🛠 Stos technologiczny
Realizacja systemu opiera się na ekosystemie Microsoft .NET, co zapewnia spójność kodu oraz wysoką wydajność:
* **Backend (API):** ASP.NET Core Web API – centralny punkt wymiany danych.
* **Baza danych:** Microsoft SQL Server – relacyjna baza danych (Entity Framework Core).
* **Aplikacja Webowa:** Blazor Server – interaktywny panel administracyjny dla managerów.
* **Aplikacja Mobilna:** .NET MAUI – aplikacja działająca natywnie na systemach Android i iOS.

## ⚙️ Architektura systemu
System zbudowany jest w architekturze Klient-Serwer:
1. **Serwer (API):** Przetwarza żądania, autoryzuje użytkowników i komunikuje się z bazą danych.
2. **Klienci (Mobile & Web):** Wysyłają zapytania HTTP (REST API) do serwera.
3. **Synchronizacja:** Zmiany wprowadzone w panelu webowym są natychmiast widoczne w aplikacji mobilnej (opóźnienie < 300ms).

## 🗄️ Projekt bazy danych (Wybrane tabele)

### Tabela `Users` (Aktorzy systemu)
Przechowuje dane wszystkich aktorów systemu (magazynierów i managerów).

| Nazwa pola | Typ danych | Opis |
| :--- | :--- | :--- |
| **Id** | Integer, PK | Unikalny identyfikator użytkownika. |
| **FirstName** | NVARCHAR(50) | Imię pracownika. |
| **LastName** | NVARCHAR(50) | Nazwisko pracownika. |
| **Role** | ENUM (Int) | Rola w systemie (Magazynier, Manager, Admin). |
| **TeamId** | Integer, FK | Przypisanie do zespołu stałego. |

### Tabela `Tasks` (Zlecenia magazynowe)
Główna tabela operacyjna reprezentująca zlecenia.

| Nazwa pola | Typ danych | Opis |
| :--- | :--- | :--- |
| **Id** | Integer, PK | Numer zadania. |
| **Title** | NVARCHAR(150) | Tytuł zadania. |
| **Status** | ENUM (Int) | Status: Nowe, W toku, Wstrzymane, Zakończone. |
| **Priority** | ENUM (Int) | Priorytet wykonania: Niski, Średni, Wysoki. |
| **CreatedByUserId** | Integer, FK | ID managera zlecającego zadanie. |

### Tabela `Products` (Asortyment)
Katalog asortymentu magazynowego.

| Nazwa pola | Typ danych | Opis |
| :--- | :--- | :--- |
| **Id** | Integer, PK | Identyfikator produktu. |
| **SKU** | NVARCHAR(50) | Unikalny kod magazynowy. |
| **Name** | NVARCHAR(100) | Nazwa towaru. |
| **Location** | NVARCHAR(20) | Lokalizacja w magazynie (Alejka/Półka). |

---
*Status projektu: W fazie rozwoju architektonicznego i implementacji API.*
