# ContactsAPI
evolunt assignment

# general
step 0. clone repository to local machine.

# database 
step 1. find 'dbScript.sql' and execute on any(local) ms-sqlServer.
or 
step 1. find 'ContactDB.bak' and create database using restore db to create new.

# API
step 2. open folder 'ContactsAPI' and open solution file in visual studio.
step 3. open appSettings.json file and change connection string to your database which is created in step 1.
step 4. run solution, if you are able to see weather forecast json data. webAPI is fine to go
step 5. search url '' if you are able to see some json records web API working fine.

# angular
step 6. open folder 'Contactreg' in visual code or any IDE
step 7. run 'npm i' to install packages
step 8. run 'ng serve --o' and it will open in default browser.
	it will show the evolunt health contacts page and few contacts loaded.
	left side add/update window
	right side table to show records
	record can be added using edit icon
	record can be deleted using delete icon
	user can add record and on save it will populate in contact list

still not able to view the application and perform actions.
step 9. review 'evolunt health-contact assignment.docx' word document summary in the root folder.
