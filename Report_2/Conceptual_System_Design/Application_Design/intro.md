# Conceptional System Design

## Application Design
COS is going to be split up into a number of different parts, Front End, Back End,  ML Server. The Front End will be responsible for everything the end user will see on screen. The Back End will handle all the logic, and data storage of the application. And the ML Server will host and serve the results of the data provided to it. All three parts will work together to provide a seamless experience to the end user.

The set of technologies we decided to use to create the application side of the course primarily comes from Microsoft and the open source community. The main components coming from Microsoft being the use the MS SQL database, Azure Blob Storage, ASP.NET MVC web development framework, the use of C# as the primary development language, and the use of Azure. We choose these technologies since it was what we could be the most productive in. Another major reason is that Azure is the only cloud provider that conforms to medical data protections standards in Canada, and it the only cloud provider with two data centers in the country. This is very important since by law all medical data that would be collect can never cross the boarder, and we are required to have replicate our data in two separate data centers for redundancy reasons.

![alt text](/Report_2/Conceptual_System_Design/Application_Design/HighLevelDesignOverView.png)
