  

# Projekts beskrivelse

Løbssystemet er et system hvor man kan sætte motions event som løb, stjerneløb eller cykle tur.

Skolen laver en rute med skanneposter, hvor eleverne vil skanne deres brik.

Man skal kunne se statistik på eleverne, f.eks. bedste løber i klassen dreng/pige, hurtigst klasse, klasse med flest gennemsnitlig km løbet osv.

Kunden ønsker også en event der kan tilpasses med variablene f.eks. point, omgange, osv.

  
  
 # Project Details
| Platform       | GUI         | Timeframe | Database Solution                   |
|----------------|-------------|-----------|-------------------------------------|
| Web Aplication | Blazor Webassembly | August - October    | Entity FrameWork |

  
  
  

# Shortcuts

* **Information**

* [Contact](#Contact)

* [Links](#Links)

* [Authors](#Authors)

* **Diagrams**

* [Class Diagram](#Class_Diagram)

* [Entity Diagram](#Entity_Diagram)

* **Dependencies**
* **Deployment**
* [Produktion Deployment](#Produktion_Deployment)
  

# Links
#### [Git](#https://git.pcsyd.dk/rene069g/lobsystemv2)
# Contact
#### Ole (Kunde) - olfr@sonderborg.dk

#### Jesper (Kunde) - jeqv@sonderborg.dk

#### Stefan (Sønderborg Kommune IT) - sla2@sonderborg.dk
# Authors

- [@Rene Rasmussen](https://www.github.com/rene069)

- [@Benjamin Lank](https://www.github.com/StarkillerBB)

# Dependencies
 
### Domain

 - https://www.nuget.org/packages/Microsoft.AspNetCore.Components.WebAssembly.Server/7.0.11?_src=template
 - https://www.nuget.org/packages/Microsoft.AspNetCore.Identity.EntityFrameworkCore/7.0.11?_src=template
 - https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.Design/7.0.11?_src=template
 - https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.SqlServer/7.0.11?_src=template

### Server

 - https://www.nuget.org/packages/Microsoft.AspNetCore.Components.WebAssembly.Server/7.0.11?_src=template
 - https://www.nuget.org/packages/Microsoft.AspNetCore.Identity.EntityFrameworkCore/7.0.11?_src=template
 - https://www.nuget.org/packages/Microsoft.AspNetCore.Mvc.NewtonsoftJson/7.0.11?_src=template
 - https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.Design/7.0.11?_src=template
 - https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.SqlServer/7.0.11?_src=template
 - https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.Tools/7.0.11?_src=template

### Client
   - https://www.nuget.org/packages/Blazored.LocalStorage/4.4.0?_src=template
 - https://www.nuget.org/packages/Blazored.Modal/7.1.0?_src=template
 - https://www.nuget.org/packages/Blazored.Toast/4.1.0?_src=template
 - https://www.nuget.org/packages/Microsoft.AspNetCore.Components.Authorization/7.0.11?_src=template
 - https://www.nuget.org/packages/Microsoft.AspNetCore.Components.WebAssembly/7.0.11?_src=template
 - https://www.nuget.org/packages/Microsoft.AspNetCore.Components.WebAssembly.DevServer/7.0.11?_src=template

# Deployment

  
### Produktion Deployment

Publish Lobsystem.Server

* Configuration: Release

* Target Framework: Net7.0

* Deployment Mode: Self-contained

* Target Runtime: Depended on target System

Change Connectionstring in Appsettings in Lobsystem.Server

Database should create itself on first run, if not in the terminal with Lobsystem.Server as Startup Project and as SBO.Lobsystem.Domain as Default Project

Then run the Command 

    Update-Database


# API Diagram


# Class Diagrams

## DTO's  

## Services

# Authorization Service Diagram

# Entity Diagram

