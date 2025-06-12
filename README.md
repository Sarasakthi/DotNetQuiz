
# ASP.NET Blazor Quiz Application 🎯

An interactive, web-based Quiz Application built using **ASP.NET Core Blazor Server** and **MudBlazor UI**.  
Users can select the number of questions, attempt quizzes, and receive instant results with visual feedback.

---

## 🚀 Features
- ✅ Randomized quiz questions from a SQL database  
- ✅ Question navigation with answer selection  
- ✅ Real-time score tracking  
- ✅ Responsive UI powered by **MudBlazor**  
- ✅ Visual feedback on quiz performance  
- ✅ Option to restart and retake the quiz

---

## 🛠️ Tech Stack
- **Frontend & Backend:** Blazor Server (.NET 8 / .NET 7)
- **UI Components:** MudBlazor  
- **Database:** SQL Server (Azure SQL or Local)  
- **ORM:** ADO.NET or Entity Framework (if used)  
- **Dependency Injection:** Blazor’s built-in DI

---

## 📂 Project Structure
```bash
ASP_NET_Quiz/
├── Pages/
│   ├── _Host.cshtml       # Blazor Server Host Page
│   ├── Quiz.razor         # Main Quiz Component
│   ├── Home.razor         # Optional Landing Page
├── Shared/
│   ├── MainLayout.razor   # Main Layout for pages
│   ├── NavMenu.razor      # Navigation Menu
├── Services/
│   ├── IQuizService.cs    # Quiz Service Interface
│   ├── QuizService.cs     # Quiz Service Implementation
├── wwwroot/
│   ├── app.css            # Custom CSS
├── Program.cs             # Application Startup
├── App.razor              # Root Component for Routing
├── appsettings.json       # Connection String Configuration
└── README.md              # Project Documentation
```

---

## ⚙️ Setup Instructions

### Prerequisites
- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download)
- SQL Server or Azure SQL Database
- Visual Studio 2022+ or Visual Studio Code

---

### Database Setup
1. Create two tables:
   - `QuizQuestions`  
     Columns: `QuestionNumber (PK)`, `Question`, `CorrectResponse`, `Explanation`
   - `QuizOptions`  
     Columns: `OptionID (PK)`, `QuestionNumber (FK)`, `OptionText`, `OptionIndex`

2. Populate the tables with quiz questions and options.

3. Add your SQL Server connection string in `appsettings.json`:
```json
"ConnectionStrings": {
  "DefaultConnection": "Server=YOUR_SERVER;Database=YOUR_DB;User Id=YOUR_USER;Password=YOUR_PASSWORD;TrustServerCertificate=True;"
}
```

---

### Running the Project
```bash
# Restore dependencies
dotnet restore

# Run the application
dotnet run
```

> Open `https://localhost:5001` or the URL displayed in your terminal.

---

## 📸 Screenshots
| Quiz Home | Quiz In Progress | Quiz Results |
|-----------|------------------|--------------|
| ![Home](screenshots/home.png) | ![Quiz](screenshots/quiz.png) | ![Result](screenshots/result.png) |

> _You can create a `screenshots/` folder and upload relevant images for visual representation._

---

## 🗇️ Key Files
- **_Host.cshtml**: Boots the Blazor app (server-side)
- **App.razor**: Handles routing and MudBlazor providers
- **Quiz.razor**: Core quiz logic and UI
- **QuizService.cs**: Database fetch and quiz logic

---

## 🔧 Configuration Notes
- Ensure your database is accessible and the connection string is correct.
- If using Azure SQL, set `TrustServerCertificate=True;` in the connection string to avoid SSL issues during development.
- MudBlazor is loaded via `_Host.cshtml` and doesn’t require separate setup if added via NuGet.

---

## 💡 Future Improvements
- Add timer functionality per question.
- Enable quiz categories.
- Store quiz results per user (authentication support).
- Enhance UI/UX with animations and transitions.

---

## 🤝 Contributions
Pull requests are welcome!  
If you have feature suggestions or bugs, please open an issue.

---

## 📄 License
This project is licensed under the MIT License.

---

Thank you for using the **ASP.NET Blazor Quiz Application**! Feel free to reach out for improvements or suggestions.
