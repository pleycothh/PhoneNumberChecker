# PhoneNumberChecker

## Get Started:
Step 1: Set up the environment
1. Instal Angular (use ```ng version``` to check install correctly )
2. Clon this project to VS code
3. Create two terminals in VS code for each folder under this repository

Step 2: Run Backend
1. Navigate to Asp.Net project  : ```cd .\PhoneNumberChecker.Api.App\PhoneNumberChecker.Api\```
2. Run server                   : ```dotnet run```

Step 3: Run frontend
1. Navigate to Angular project  : ```cd .\PhoneNumberChecker-Angular\```
2. Run                          : ```ng serve -o```

## Stack:
Frontend: Angular
Backend: Asp.Net 6 Web Api
Database: EF SQL server 18

## Features:
1. Verify the phone number to check if is valid using Nuget package (libphonenumber-csharp).
2. Store verify results in the database and display them as history.
3. Download the current CSV result.
4. Download the CSV result from the history list.
