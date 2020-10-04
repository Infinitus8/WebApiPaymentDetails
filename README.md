# WebApiPaymentDetails
Simple REST API that stores PaymentDetails in database.

To connect your SQL Database to API:
1. Enter your SQL Server's User ID and Pswd to "PaymentsConnection" string in appsettings.json
2. Create migration using command "dotnet ef migrations add <MirationName>"
3. Update EF database using command "dotnet ef database update"
