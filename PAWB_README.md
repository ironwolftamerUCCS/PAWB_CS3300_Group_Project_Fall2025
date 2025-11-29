# PAWB Password Manager — README

## 1. Overview

PAWB is a secure and user-friendly password manager developed as a WPF desktop application. It allows users to store, access, and manage login credentials across multiple accounts. The application features a graphical interface themed around its mascot, **PAWB**.

This README provides step-by-step instructions for installing, configuring, running, and evaluating the PAWB software prototype on **UCCS IT systems**.

## 2. System Requirements

### 2.1 Hardware Requirements
- RAM: Minimum requirement for .NET/WPF applications
- Processor: Modern CPU
- Storage: Sufficient space for project files
- Graphics: Standard Windows graphics support

### 2.2 Software Requirements
- Operating System: Windows
- IDE: Visual Studio 2022
- Required Libraries:
  - Microsoft.EntityFrameworkCore.Design
  - .NET Desktop Development workload

## 3. Installation Instructions

### 3.1 Pre-Installation Checklist
Ensure:
- Windows environment
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
3. Open `PAWB.WPF.sln`.

### 3.4 Restore Dependencies
If not automatic:
- Tools → NuGet Package Manager → Restore NuGet Packages

## 4. Configuration

No additional configuration is required. EFCore and database structures load automatically.

## 5. Executing the Software

### 5.1 Launching the Application
1. Set startup project to `PAWB.WPF`.
2. Click *Start (▶)*.

### 5.2 Account Setup and Login

#### Sign Up
- Click *Sign Up*
- Enter user information
- Click *Complete Sign Up*

#### Login
- Enter credentials
- Click *Login*

## 6. User Interface Guide

### 6.1 Home Page Features
- **View Stored Entries** – click an entry to view details  
- **Add Entry** – add new credential  
- **Delete Entry** – remove saved credentials  
- **Theme Options** – switch light/dark mode, change cursor  
- **Logout** – return to login screen  

## 7. Troubleshooting

### Common Issues

| Issue | Cause | Solution |
|-------|--------|----------|
| Build fails | Missing dependencies | Restore NuGet packages |
| Login fails | Wrong credentials | Create a new account |
| UI blank | Wrong startup project | Set `PAWB.WPF` as startup |
| DB locked | Multiple instances | Close extra windows |

### Error Messages
- “Cannot restore packages” → Restore via NuGet  
- “Entry not found” → Deleted entry accessed  
- “Database locked” → Close duplicate instances  

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
- **EFCore:** ORM for .NET  
- **MVVM:** UI architecture pattern  

### Notes
- PAWB is an academic prototype, not meant for production use.
