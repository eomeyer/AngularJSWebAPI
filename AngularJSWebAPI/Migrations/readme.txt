--Step 1
Enable-Migrations -EnableAutomaticMigrations -ContextTypeName AngularJSWebAPI.Contexts.AuthContext  -ConnectionStringName AuthContext

--Step 2
Enable-Migrations -EnableAutomaticMigrations -ContextTypeName AngularJSWebAPI.Contexts.SqlDbContext  -ConnectionStringName SqlDbContext

--Step 3
add-migration Initial-SQL-Schema -IgnoreChanges -ConfigurationTypeName ConfigurationSql -ConnectionStringName SqlDbContext

--Step 4
Update-Database -ConfigurationTypeName ConfigurationSql  -ConnectionStringName SqlDbContext


Add-Migration Initial-Db-Create -ConfigurationTypeName ConfigurationAuth -ConnectionStringName AuthContext


Add-Migration Initial-Db-Create-Sql -ConfigurationTypeName ConfigurationSql -ConnectionStringName SqlDbContext