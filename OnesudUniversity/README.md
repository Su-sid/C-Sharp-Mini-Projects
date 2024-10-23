# Onesud University Mini Project

**Overview**

This ASP.NET Core MVC project, named Onesud University, is designed to manage student data within a university setting. It utilizes Entity Framework Core (EF Core) for data access and persistence.

**Key Features:**

* **Student Management:**
  - Create, read, update, and delete student records.
  - View student details, including personal information and enrollment history.
* **Data Persistence:**
  - Employs EF Core to interact with a database (e.g., SQL Server) and store student data.
* **MVC Architecture:**
  - Adheres to the Model-View-Controller pattern for separation of concerns and maintainability.

**Getting Started:**

1. **Clone the Repository:**
   ```bash
   git clone https://github.com/your-username/onesud-university.git
   ```
2. **Install Dependencies:**
   ```bash
   cd onesud-university
   dotnet restore
   ```
3. **Configure Database:**
   - Create a database with the appropriate schema (e.g., using the provided migration scripts).
   - Update the connection string in `appsettings.json` to point to your database.
4. **Run the Application:**
   ```bash
   dotnet run
   ```
5. **Access the Application:**
   - Open a web browser and navigate to `http://localhost:5000` (or the specified port).

**Technologies Used:**

* ASP.NET Core MVC
* Entity Framework Core
* C#
* HTML, CSS, JavaScript

**Additional Notes:**

* This README provides a basic overview. Refer to the project's source code for more in-depth information.
* Consider adding more specific details about the project's features, functionality, and any additional technologies or libraries used.


