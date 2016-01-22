RouteSecurity  Module
=====================

 

What is this?

This is a simple httpmodule which prevents brute force URL tracing and attacks.
The  module is simple  just need to include the DLL in bin directory and then
change the following 3 settings in Web.config to enable the module.

 

 

Register this HttpModule

 

~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
<httpModules>
      //.....Other modules
      <add type="RouteSecurity.RouteSecurityModule, RouteSecurity, Version=1.0.0.0, Culture=neutral" name="RouteSecurityModule" />
</httpModules>
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

 

Enable the RouteSecurityModule

 

~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
<modules runAllManagedModulesForAllRequests="true">
    <add name="RouteSecurityModule" type="RouteSecurity.RouteSecurityModule, RouteSecurity, Version=1.0.0.0, Culture=neutral" />      
//.....Other modules
</modules> 
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~



Update the regular expression in below setting (below reg.ex. to match any
\*.php  related URL(s) on mydomain.com :

~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
<appSettings>
    //.....Other app settings.
    <add key="RouteSecurityRegEx" value="^((http[s]?|ftp):\/\/)?(.*\.)?(mydomain\.com)(.*)\.php(.*)" />
</appSettings>
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
