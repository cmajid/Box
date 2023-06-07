# Box
The application is a document library intended to give its users a web based solution to store and share their documents with others.

### BOX
**Functional Requirements**
- Design and implement the application’s UI / API based on the requirements:
-- available document types for uploading 
--- PDF / Excel / Word/ txt/ pictures documents
--- display / get a list of available documents
--- name of the document
--- icon based on its type
--- a preview image of its content 1st page content
--- date and time of upload
--- number of downloads
- download / upload a document
- download / upload several documents
- a document can be shared with other users via a generated link which is publicly available for the specified time period (e.g.: 1 hour, 1 day, etc.)


**Backend**
- Framework:
-- ASP.NET Core 7.0 
---- Web API

- ORM:
-- EF Core 7.0.5

- Authentication:
-- Microsoft.AspNetCore.Authentication.JwtBearer 7.0.5
-- Microsoft.AspNetCore.OpenApi 7.0.5

- Test 
-- xUnit 2.4.2
-- Moq 4.x


**Frontend**
- Libaray
-- react 18.2.0
---- react-router-dom 5.x

- State Managment
-- Reduxt-Toolkit
---- RTK-Query (normalized state structure)

- Tools
-- Vite
-- axios
-- react-hook-form
-- react-icons
-- react-hot-toast

- Language
 -- TypeScript

- CSS Framework
 - Tailwind CSS