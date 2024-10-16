# CMPG323_Project
# CCD Share2Teach

## Overview
Share2Teach is a web-based educational platform. It is designed to provide a shared learning environment. It is a space where users can contribute to learning resources, search specific resources and rate the various learning resources. The platform is accessible via a web browser and open to educators, moderators and students. 

## Share2Teach Features
-**Account Creation & Secure Sign-in**: Create account and secure sign in for users via an authentication system.
-**File Uploading & Storage**: Upload for education documentation. This is tagged for easy searching. 
-**Document Moderation**: Review, Approve or Reject of documents by moderators. 
-**Document Searching**: Allow users to search specific documents using tags and filters.
-**Analytics**: The platform tracks user engagement and provide information based on the user engagements to the administrators. 
-**Document Rating**: Rating system for quality of documents. 
-**FAQ**: The frequently asked questions (FAQ) section provides feedback on the most commonly asked questions.


## Technologies Used
-**Front End**: HTML5 and JavaScript
-**Back End**: RESTful API
-**Database**: MariaDB - Hosted with Afrihost at 102.222.124.17
-**File Storage**: Nextcloud integrated with domain www.xcondev.com
-**Security**: OAuth 2.0 for API's and User roles allocation to individual user accounts

## API Usage
The platform uses a RESTful API for back end interaction. Examples thereof are:

### User Authentication

-**authorisation/login
Log in the user and return a token.
Request body:

public async Task<ActionResult<USERS>> GetUser(int id)
{
if (_usersContext.USERS is null)
{
return NotFound();
}
var uservar = await _usersContext.USERS.FindAsync(id);
if (uservar is null)
{
return NotFound();
}
return uservar;
}

-**register/user

Register a new user.
Request body:
{
public class USERS
{
        public int Id { get; set; }
        public string? username { get; set; }
        public string? password { get; set; }
        public string? email { get; set; }
        public int roleID { get; set; }
        public DateTimeOffset? createddate { get; set; }
        public DateTimeOffset? lastlogin { get; set; }
}
Response:
{
“message”: “Welcome, your account is successfully created”
}

### Documents Upload

-**document/upload
Upload of documents. It requires authentication.
Request body:
{
public class DOCUMENTS
{
public int Id { get; set; }
public string? title { get; set; }
public int tags { get; set; }
public int grade { get; set; }
public int rating { get; set; }
public string? description { get; set; }
public string? filepath { get; set; }
public string? filetype { get; set; }
public DateTimeOffset? createddate { get; set; }
public int createdby { get; set; }
public DateTimeOffset? updateddate { get; set; }
public int updatedby { get; set; }
public DateTimeOffset? accessdate { get; set; }
public int accessby { get; set; }
}
}

### Moderation
-**documents/moderate/{id}
Approve or reject a document. Must only be done by moderator
Request body:
{
public class MODERATIONS
{
public int Id { get; set; }
public int documentid { get; set; }
public int moderatorid { get; set; }
public enum status
{
PENDING,APPROVED,DENIED
}
public string? comment { get; set; }
public DateTimeOffset? createdat { get; set; }
public DateTimeOffset? updatedat { get; set; }
}
}

## Setup Instructions
-**To run the backend locally, you will be required to install:
-	PHPStorm
-	MariaDB
-	Git
-	Node.js

### Installation
-** Use Git Bash
-** Clone the repository:
-** Git clone 
https://github.com/Cross-Continental-Development/CMPG323_Project
-** cd CMPG323_Project
-**Install dependencies
-	composer install
-**Configure the environmental variables
-	Database Name: xcondea8o1p9_SHARE2TEACH
-	Host: 102.222.124.17
-	Port: 3306
-	UserName: xcondea8o1p9_Admin
-	Password: adminshare2teach
-	Start the back end server:

-** Database Migration
-	Run Migrations via php artisan migrate

-** Verify the migration
-	Verify via the PHPStorm tool that the tables are created in the database hosted on AfriHost. 

## API Integration
-** Integrate the backend with the API endpoints. Share2Teach backend provides RESTful APIs for interaction with the system. 

-** The API is hosted at 102.222.124.17

### Authentication
-** The API makes use of OAuth 2.0 for authentication. An access token must be obtained via the OAuth provider. 
-** Authentication steps
-	Sent POST request to OAuth token endpoint with your credentials
-	Use the token in the Authorisation header for API requests

### API Endpoints
-**API endpoints if provided for different operations. Below is the example of the structure in the main API categories

-** User
-	api.uSERSGet
-	api.uSERSIdDelete
-	api.uSERSIdGet
-	api.uSERSPost 
-	api.uSERSPut

-** Documents
-	api.dOCUMENTSGet
-	api.dOCUMENTSIdDelete
-	api.dOCUMENTSIdGet
-	api.dOCUMENTSPost 
-	api.dOCUMENTSPut


-** Moderations
-	api.mODERATIONSGet
-	api.mODERATIONSIdDelete
-	api.mODERATIONSIdGet
-	api.mODERATIONSPost 
-	api.mODERATIONSPut



## API Documentation
-** The API documentation is accessible at https://xcondev.com/api/index#api-Documents-dOCUMENTSGet


## Database Setupdate
-** Connect to database
-	Database Name: xcondea8o1p9_SHARE2TEACH
-	Host: 102.222.124.17
-	Port: 3306
-	UserName: xcondea8o1p9_Admin
-	Password: adminshare2teach

-** Import the database schema file

## Local Environment Setup
-** Install Node.js dependencies and run command
-	npm install
-** Create a .env file in the root directory and add:
-	DataBase_Host=102.222.124.17
-	DataBase_User=xcondea8o1p9_Admin
-	DataBase_Password=adminshare2teach
-	DataBase_Name=xcondea8o1p9_SHARE2TEACH
-	DataBase_Port=3306
-	OAUTH_User=<your_id>
-	OAUTH_Secret=<your_secret>
-	OAUTH_URI=<your_uri>
-** Start backend Server via the command
-	npm start

## Frontend Overview  
The frontend is designed to deliver a user-friendly and responsive interface, styled using `CSS/home.css`. 

### Key Pages:  
- **Home Page (`index.html`)**: Provides an overview of the platform and quick links to various sections.  
- **User Authentication Pages (`login.html`, `register.html`)**: Enables user login, registration, and password recovery.  
- **Dashboard (`dashboard.html`)**: Displays dynamic content and statistics from the backend.  
- **Moderation Panel**: Allows moderators to review and approve or reject documents.  
- **Upload Page**: Enables users to upload and tag educational documents.

### CSS Styling:  
- **Path**:`CSS/home.css`  
- **Description**: Provides consistent styling across all pages, with responsive design for different screen sizes. The stylesheet covers:  
  - Layout and spacing  
  - Typography and color schemes  
  - Button and input field styles  
  - Form validation indicators  

## Licence
-** The project is licenced under CC BY-NC-ND 4.0. A copy of the licence can be viewed at https://creativecommons.org/licenses/by-nc-nd/4.0/

