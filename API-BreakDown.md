# API BREAKDWON
#  1. POST ENDPOINT:

>[!info] Summary:
> _Purpose_: Receive new student data and record them in our Students table

### How it Works:
• We receive CSV file in application (or JSON payload),
``` JSON 
{
  "FirstName": "John",
  "SecondName": "Molepo",
  "Score": 92
}
```
• Parse this, convert to student object, and call insert function for our database.

---
#  2. GET ENDPOINT:  Return the score of a specific student.

>[!info] Summary:
>  _Purpose_: Return the score of a specific student.

## How it works:

- Client requests `/student?firstName=Alice&secondName=Smith`
    
- Server queries the database for that student and returns their score as JSON.

---

# 3.  GET ENDPOINT: Retrieve Top Score(s)

>[!info] Summary:
>_Purpose_: Return the highest score(s) in the database.


- **How it works:**
    
    - Server queries the database to find the maximum score:
    - ``` SQL
      SELECT * FROM Students WHERE Score = (SELECT MAX(Score) FROM Students)
      ```
        
    - Returns all students with the top score in **alphabetical order**.
        
---
# 4. SECURE ENDPOINTS:

Require and **API KEY/ TOKEN** in requests to POST or GET. 
Dont just let anyone see scores, give each client a _key_ that requires HTTPS.


---

# 5.  HOSTING:

- **API Hosting:**
    
    - Use **Azure App Service**  to host the .NET API.
        
    - Reasons: handles scaling, deployment, and HTTPS automatically.
        
- **Database:**
    
    - Use **Azure SQL Database**.
        
    - Reason: reliable, persistent storage accessible from the cloud.
        
- **User Interface:**
    
    - Could build a **React** application.
        
    - Host on **Azure Static Web Apps**.
        
- **Flow:**
    
    1. User opens app in browser
        
    2. app/ui calls API endpoints to add/retrieve scores
        
    3. API saves/fetches data from cloud database
        
    4. Security enforced via HTTPS + API keys or tokens
