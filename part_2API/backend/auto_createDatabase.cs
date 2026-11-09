using System.Data.SqlClient;
using System.Diagnostics;

namespace part_2API.backend
{
    public class auto_createDatabase
    {
        private readonly string instanceName = "part_2_api";
        private readonly string databaseName = "part_2";
        private readonly string masterConnectionString;
        private readonly string databaseConnectionString;

        public auto_createDatabase()
        {
            this.masterConnectionString = $@"Server=(localdb)\{this.instanceName};Database=master;Integrated Security=true;TrustServerCertificate=true;";

            this.databaseConnectionString = $@"Server=(localdb)\{this.instanceName};Database={this.databaseName};Integrated Security=true;TrustServerCertificate=true;";
        }

        public void Create()
        {
            CreateInstance();
            CreateDatabase();
            CreateTables();
        }

        private void CreateInstance()
        {
            RunSqlLocalDb($"create \"{this.instanceName}\"");
            RunSqlLocalDb($"start \"{this.instanceName}\"");
        }

        private void RunSqlLocalDb(string arguments)
        {
            ProcessStartInfo processInfo = new ProcessStartInfo
            {
                FileName = "SqlLocalDB.exe",
                Arguments = arguments,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            using (Process process = Process.Start(processInfo))
            {
                process.WaitForExit();
            }
        }

        private void CreateDatabase()
        {
            using (SqlConnection connection = new SqlConnection(this.masterConnectionString))
            {
                connection.Open();

                // Check first — if it exists, do nothing
                string checkCommand = $"SELECT DB_ID('{this.databaseName}');";
                using (SqlCommand checkCmd = new SqlCommand(checkCommand, connection))
                {
                    object result = checkCmd.ExecuteScalar();
                    if (result != null && result != System.DBNull.Value)
                    {
                        return; // Database already exists, do nothing
                    }
                }

                // Only reached if the database does NOT exist
                string createDatabaseCommand = $"CREATE DATABASE [{this.databaseName}];";
                using (SqlCommand createCmd = new SqlCommand(createDatabaseCommand, connection))
                {
                    createCmd.ExecuteNonQuery();
                }
            }
        }

        private void CreateTables()
        {
            using (SqlConnection connection = new SqlConnection(this.databaseConnectionString))
            {
                connection.Open();

                string[] createTableCommands = new string[]
                {
                    "IF OBJECT_ID('users','U') IS NULL CREATE TABLE users(" +
                    "id INT PRIMARY KEY IDENTITY(1,1)," +
                    "fullname VARCHAR(100)," +
                    "email VARCHAR(150)," +
                    "role VARCHAR(20)," +
                    "password VARCHAR(255));",

                    "IF OBJECT_ID('category','U') IS NULL CREATE TABLE category(" +
                    "id INT PRIMARY KEY IDENTITY(1,1)," +
                    "name VARCHAR(50)," +
                    "description VARCHAR(255)," +
                    "organizer_id INT," +
                    "FOREIGN KEY(organizer_id) REFERENCES users(id));",

                    "IF OBJECT_ID('Events','U') IS NULL CREATE TABLE Events(" +
                    "eventID INT IDENTITY(1,1) PRIMARY KEY," +
                    "eventName VARCHAR(60)," +
                    "description VARCHAR(255)," +
                    "date DATE," +
                    "location VARCHAR(70)," +
                    "distance DECIMAL(5,2)," +
                    "eventType VARCHAR(60)," +
                    "age INT," +
                    "startTime TIME," +
                    "user_id INT NOT NULL," +
                    "category_id INT NOT NULL, image varchar(100)," +
                    "FOREIGN KEY (user_id) REFERENCES users(id)," +
                    "FOREIGN KEY (category_id) REFERENCES category(id));",

                    "IF OBJECT_ID('Enrolments','U') IS NULL CREATE TABLE Enrolments(" +
                    "enrolmentID INT IDENTITY(1,1) PRIMARY KEY," +
                    "enrolmentDate DATE," +
                    "eventID INT," +
                    "user_id INT," +
                    "FOREIGN KEY (eventID) REFERENCES Events(eventID)," +
                    "FOREIGN KEY (user_id) REFERENCES users(id));",

                    "IF OBJECT_ID('Results','U') IS NULL CREATE TABLE Results(" +
                    "resultID INT IDENTITY(1,1) PRIMARY KEY," +
                    "finishTime TIME," +
                    "finishPosition INT," +
                    "enrolmentID INT," +
                    "FOREIGN KEY (enrolmentID) REFERENCES Enrolments(enrolmentID));"
                };

                foreach (string createTableCommand in createTableCommands)
                {
                    using (SqlCommand command = new SqlCommand(createTableCommand, connection))
                    {
                        command.ExecuteNonQuery();
                    }
                }
            }
        }
    }
}