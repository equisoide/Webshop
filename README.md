# Webshop

The Database project (DbSchema) contains the Database definitions (Tables, Relations, Contraints, etc).

To run the Web project go to Src, open Webshop.Web.sln and execute the solution.

This project uses the Repository Pattern to manage Data Access, and implements two Repository strategies:
 - Memory Storage: To store the data into the current Session
 - Database Storage: To store the data into a local database (MDF file)
 
By default, Database Storare is enabled

See Demo.webm.
