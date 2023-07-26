## Health Center Backend Project

This readme.txt provides an overview of the Health Center Backend Project, which is built using C#. The project aims to manage patients (users), medical records, and medical sheets for a health center or medical institution.

### Features

The Health Center Backend Project includes the following main features:

1. **Patient Management**: The backend provides APIs to manage patient records, including adding new patients, retrieving patient information, updating patient details, and deleting patient records.

2. **Medical Record Management**: The backend allows medical practitioners to manage medical records for patients. This includes creating new medical records, viewing existing records, updating medical information, and deleting medical records when necessary.

3. **Medical Sheet Management**: The backend handles the management of medical sheets. Medical practitioners can create new sheets, view and update existing ones, and delete sheets as needed.

### Project Structure

The backend project is structured as follows:

- `Models`: Contains C# classes representing entities such as patients, medical records, and medical sheets. These classes define the data structure for the respective entities.

- `Controllers`: Contains C# classes representing API controllers. These controllers handle incoming HTTP requests related to patient, medical record, and medical sheet management.

- `Services`: Contains C# classes providing services to perform CRUD (Create, Read, Update, Delete) operations on patient, medical record, and medical sheet data. These classes interact with the database and implement the business logic.

- `DbContext`: Contains the C# class representing the Entity Framework database context. This class is responsible for managing the connection and operations with the database.

- `Data`: Contains the database migration files and the initial database seeding scripts.

### Technologies Used

- C# (ASP.NET Core): The backend is developed using C# programming language with ASP.NET Core framework, which provides the infrastructure to build web applications and APIs.

- Entity Framework Core: Entity Framework Core is used as the Object-Relational Mapping (ORM) tool to interact with the database and handle data operations.

- Microsoft SQL Server: The backend uses Microsoft SQL Server as the database to store patient, medical record, and medical sheet data.

### API Endpoints

The backend project exposes the following API endpoints:

- `GET /api/patients`: Get a list of all patients.

- `GET /api/patients/{id}`: Get details of a specific patient by ID.

- `POST /api/patients`: Create a new patient.

- `PUT /api/patients/{id}`: Update patient details by ID.

- `DELETE /api/patients/{id}`: Delete a patient record by ID.

- `GET /api/medicalrecords`: Get a list of all medical records.

- `GET /api/medicalrecords/{id}`: Get details of a specific medical record by ID.

- `POST /api/medicalrecords`: Create a new medical record for a patient.

- `PUT /api/medicalrecords/{id}`: Update medical record details by ID.

- `DELETE /api/medicalrecords/{id}`: Delete a medical record by ID.

- `GET /api/medicalsheets`: Get a list of all medical sheets.

- `GET /api/medicalsheets/{id}`: Get details of a specific medical sheet by ID.

- `POST /api/medicalsheets`: Create a new medical sheet.

- `PUT /api/medicalsheets/{id}`: Update medical sheet details by ID.

- `DELETE /api/medicalsheets/{id}`: Delete a medical sheet by ID.

### Database Configuration

The backend project is configured to use Microsoft SQL Server as the database. Make sure to update the database connection string in the `appsettings.json` file with your SQL Server credentials and database name.

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost;Database=HealthCenterDB;User=YourUsername;Password=YourPassword;"
}
```

### Usage

1. Set up the database: Run the Entity Framework database migration to create the required tables in the SQL Server database.

2. Start the backend server: Build and run the backend project to start the API server. The server will listen on the specified port (default is `5000`) and be ready to handle incoming API requests.

3. Use API endpoints: You can now use API testing tools like Postman to test the various API endpoints and interact with the backend services.

### Contributing

This project is for personal practice, but if you have any suggestions or improvements for the Health Center Backend Project, feel free to submit a pull request. Any constructive contributions are welcome.

### License

This code is available under the [License Name]. Check the LICENSE file for more details.

### Resources

- [C# Documentation](https://docs.microsoft.com/en-us/dotnet/csharp/)
- [ASP.NET Core Documentation](https://docs.microsoft.com/en-us/aspnet/core/introduction-to-aspnet-core)
- [Entity Framework Core Documentation](https://docs.microsoft.com/en-us/ef/core/)
- [Microsoft SQL Server Documentation](https://docs.microsoft.com/en-us/sql/sql-server/sql-server-technical-documentation)
