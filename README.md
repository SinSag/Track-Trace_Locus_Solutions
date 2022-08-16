# locustrace
 Track&Trace-application for Locus Solutions TMS (Bachelor thesis 2022).

 This is a application developed for Locus Solutions AS, as a bachelor thesis for a group of 
 students from USN (University of Southeastern-Norway).

//weaknesses we are aware of, but choose to not prioritize due to other demands (core functionality)
Known weaknesses in the app:
- token being stored in session (unsecure)
	- fix: HttpCookie...
- user credentials being sent in plain text (somewhat unsecure, uses https)
	- cryptation/obfuscation
- grantType and departmentId is stored in a local config-file (locustrace.Client/wwwroot/appsettings.json)
	- fix: not really a huge risk, but probably better ways to solve it

To launch app from VS-console:
- navigate to correct folder: cd locustrace\Server
- start app (with debugger): dotnet watch run debug