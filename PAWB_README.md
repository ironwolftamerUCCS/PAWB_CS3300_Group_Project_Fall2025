# PAWB Password Manager — README

## 1. Overview

PAWB is a secure and user-friendly password manager developed as a WPF desktop application. It allows users to store, access, and manage login credentials across multiple accounts. The application features a graphical interface themed around its mascot, **PAWB**.

This README provides step-by-step instructions for installing, configuring, running, and evaluating the PAWB software prototype on UCCS IT systems.

## 2. System Requirements

### 2.1 Hardware Requirements
- RAM: 1 GB
- Processor: Intel 8th Generation processor or later
- Storage: 256 MB
- Graphics: Integrated Graphics Card

### 2.2 Software Requirements
- Operating System: Windows 11
- IDE: Visual Studio 2022
- .NET 9.0.11
- Required Libraries (Included in Repository):
  - Microsoft.EntityFrameworkCore.Design
  - .NET Desktop Development workload

### 2.3 VS 2022 Packages ###
Ensure the following packages are installed in VS 2022:
- Azure Data Lake and Stream Analytics Tools
- CLR data types for SQL Server
- Data sources for SQL Server Support
- SQL Server Command Line Utilities
- SQL Server Data Tools
- SQL Server Express 2019 LocalDB
- SQL Server OBDC Driver

## 3. Installation Instructions

### 3.1 Pre-Installation Checklist
Ensure the following:
- A Windows 11 environment
- Visual Studio 2022 installed
- .NET Desktop Development workload enabled
- Internet access

### 3.2 Download the Project
Clone the repository:

```
https://github.com/ironwolftamerUCCS/PAWB_CS3300_Group_Project_Fall2025.git
```

### 3.3 Open in Visual Studio
1. Open Visual Studio 2022.
2. Select *Open a Project or Solution*.
3. Open `PAWB.sln`.

### 3.4 Restore Dependencies
If not automatic, Navigate to the following:
- Tools → NuGet Package Manager → Restore NuGet Packages

## 4. Database Configuration

1.	Open Visual Studio 2022. Select Open a Project or Solution. Open `PAWB.sln`
2.	In the top menu, navigate to tools -> NuGet Package manager -> Package Manager Console
3.	In the package manager console, change the default project to `PAWB.EntityFramework`
4.	Execute the command `update-database` in the Package Manager Console
5.	The database is now configured. This process only needs to be completed on the program's first startup

## 5. Executing the Software

### 5.1 Launching the Application
1. Set startup project to `PAWB.WPF` if not already done so by right clicking `PAWB.WPF` in the solution explorer and selecting `Set as Startup Project`
3. Click *Start (▶)* PAWB.WPF in the upper menu.
4. Wait for the build to complete and for the project window to open.

### 5.2 Account Setup and Login

#### Sign Up
- Click *Sign-Up here*
- Fill in the account information
- Click *Sign Up*. You will be redirected back to the login screen.

#### Login
- Enter user credentials
- Click *Login*

## 6. User Interface Guide

### 6.1 Home Page Features
- **View Stored Entries** – Entry names are automatically displayed on the homepage. To view details, click the *Details* button.  
- **Add Entry** – Entries can be added though the *Add Account* button at the top of the screen
- **Theme Options** – Light and spooky mode can be toggled using the slider at the top of the home page
- **Cursor Options** - Several cursor options can be chosen using the selections at the bottom of the home page
- **Logout** – To logout, click the *Logout* button in the bottom right corner of the screen 

## 7. Troubleshooting

### Common Issues

| Issue | Cause | Solution |
|-------|--------|----------|
| Build fails | Missing dependencies | Restore NuGet packages, see section 3.4|
| Login fails | Incorrect credentials | Create a new account |
| UI blank | Wrong startup project | Set `PAWB.WPF` as startup project, see section 5.1|
| Entry doesn't display| Database limitations | Wait a couple of minutes and the entry will populate|
| Cannot re-login| Login bug | Navigate to and from the sign-up page and login again|

### Error Messages
- "Username does not exist" -> Attempt another username or create a new account
- "Password is incorrect" -> Retry with another password or create a new account
- "Login Failed" -> Reattempt login or create a new account
- "Passwords do not match" -> Ensure the same password is entered in each box
- "Username already exists" -> Enter another username
- "Email already exists" -> Enter another email
- "One or more of the fields are empty, please fill out all fields" -> Ensure all fields are filled out
- "Registration Failed" -> Reattempt signup

## 8. Support Information

**Developer Contact**  
- Name: Evan Futey  
- Email: efutey@uccs.edu  
- Phone: +1 (719)-660-1028  

### Documentation Resources
- WPF: https://learn.microsoft.com/en-us/dotnet/desktop/wpf/
- .NET: https://learn.microsoft.com/en-us/dotnet/
- MVVM Toolkit: https://learn.microsoft.com/en-us/dotnet/communitytoolkit/mvvm/

## 9. Appendix

### Glossary
- **Credential Entry:** Saved username/password pair
- **MVVM:** UI architecture pattern  

### Notes
- PAWB is an academic prototype, not meant for production use.
