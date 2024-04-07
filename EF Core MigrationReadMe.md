			**EF Core Migration Procedure**
##NOTE: Run Migration and update the database.


 To Add Migration

1. Install dotnet 7 sdk for your editor NB: This is a .Net 7 project, therefore some projects will not load if .Net 7 sdk is not installed.
2. Open Solution StringConverter.sln

3. Open Migration Folder.

4. Delete the Migration files '20230904155824_InitialMigration' and 'StringConverterDbContextModelSnapshot' respectively.

5. Open appsettings.json and point the connectionString to your localDB instance.
	StringConverterConnectionString = "Server=DESKTOP-OOBUVHM\\SQLEXPRESS;Database=TranslatorDb;Trusted_Connection=True;TrustServerCertificate=Yes"

6. Change only the server name for "StringConverterContextConnection": "Server=DESKTOP-OOBUVHM\\SQLEXPRESS;Database=StringConverter;Trusted_Connection=True;MultipleActiveResultSets=true"

7. Go to 'Package Manager' console, make sure default project is 'StringConverter'.

8. Type Add-Migration "Migration Name" eg; Add-Migration InitialMigration.

9. After successfully executing, type "Update-Database".

10. Open 'SQLQueryScriptedAllSpcs' file, copy the script and paste in SSMS New Query Window and execute.

10. Execute the solution