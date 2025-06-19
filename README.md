# ChatBox
A practice project of trying microservice architecture with variants backend languages and database types on different services  

-----
### Backend:
.NET core api, Node.js, python FastAPI  
### Frontend:
vue.js  
### Database:
PostgreSQL on cloud database Supabase, MongoDB on cloud database MongoDB Atlas  

-----
## Additional packages added
### .NET Backend:
- EntityFrameworkCore:For object-relational mapping (ORM), simplifying database operations and migrations
- BCrypt:For password hashing
- JwtBearer:For JWT token verification
- Npgsql:For connection with PorstgreSQL
  
#### Python FastAPI Backend:
- FastAPI:For python backend api implement
- Uvicorn:For python backend command compile
- Python-dotenv:For enviroment attributes loading
- Mailjet-rest:For mail sending
  
### Vue Frontend:
- Tailwindcss:For css styling
- PostCSS:For transforming and processing CSS with plugins
- Autoprefixer:A PostCSS plugin that adds vendor prefixes automatically for better browser compatibility
- Pinia:For data storage and sync
- Axios:For api request
- vue-i18n:For multiple languages supporting
- vue-router:For website router operation

-----
## Project setup and compile on development
For user backend part:  
1. Create a visual studio 2022 .net core web api project in LifeAccounting folder.
2. When need to compile and test via cmd, enter the following commands:  
```sh
cd ChatBox/ChatBox_Backend/ChatBox_User/ChatBox_User
```  
```sh
dotnet run
```  
  
For notification backend part:  
1. Create a folder in backend folder.
2. Create venv and download package by the following commands:  
```sh
cd ChatBox/ChatBox_Backend/ChatBox_Notification
```  
```sh
python -m venv venv
```  
```sh
venv\Scripts\activate
```  
```sh
pip install fastapi uvicorn python-dotenv mailjet-rest
```  

3. When need to compile and test via cmd, enter the following commands:  
```sh
cd ChatBox/ChatBox_Backend/ChatBox_Notification
```  
```sh
uvicorn main:app --host 0.0.0.0 --port 8000
```  

For frontend part:  
1. Create a new vue default project by the following commands and steps:  
```sh
cd ChatBox
```  
```sh
npm create vite@latest ChatBox_Frontend
```  

2. Select framework as vue, choose variant as TypeScript.  
```sh
npm install
```  

3. When need to compile and test via cmd, enter the following commands:  
```sh
cd ChatBox/ChatBox_Frontend
```  
```sh
npm run dev
```  
