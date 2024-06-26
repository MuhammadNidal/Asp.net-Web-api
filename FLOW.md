# Follow below steps to perform CRUD on any entity

# . 1 : In Fophex.Core project create directory with the same as your Entity
# . 2 : Create your Entity class e.g Employee.cs with all required properties
# . 3 : Create a Configuration class here we'll define all attributes for an entity like Required, Max, Min Lenght etc name of the should be as EntityName + EntityTypeConfiguration
# . 4 : Inherit your Entity from Audited Entity
# . 5 : Add your entity to either ApplicationDbContext or FophexDbContext, In each task I'll be mentioning this where to add your entity
#		However If entity belongs to the Tenant then we'll add it into thAOe ApplicationDbContexts
#		If entity belongs to the overall application which has impact on each tenant then will add in FophexDbContext
#   6   Marge your code before SENDING REQUEST FOR ADD MIGRATION
# . 7 : Add Migration make sure while adding migration Default Project should be Fophex.EntityFrameworkCore
#	    Below are migration commands for each Db Context
#		Add-Migration MigrationName -context FophexDbContext -o Migrations/FophexDb      
#		Add-Migration MigrationName -context ApplicationDbContext -o Migrations/AppDb
#		Note Change MigrationName as per your migration
#		======================================
#		NO NEED TO RUN UPDATE-DATABASE COMMAND, ON APPLICATION RUN IT EXECUTED AUTO
#		======================================


# . 8 : In Fophex.Application.Share create a directory with Entity name (Must be plural) e.g Employees inside this directory create another directory with name Dto and an interface Interface name would be I + EntityName + AppService

# . 9 : In Fophex.Application create a class file with name Entity + AppService
# . 10 : Also we can add mappers inside Fophex.Application
# . 11 : Add your Interface and App Service to the dependency injection class
# . 12 : Now the final step is to create controller and add required functionality
	