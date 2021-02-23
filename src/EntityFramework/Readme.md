EntityFramework assemblies:
1. EntityFramework contain the DBcontext configuration for the application


## When you modify data model 

add-migration [MIGRATION NAME] -OutputDir EntityFramework\Migrations -StartupProject EntityFramework 

##After add-migration database schema will auto update on running the application
