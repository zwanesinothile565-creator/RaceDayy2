# RaceDayy (ASP.NET Core MVC)

PROG6212 POE – Part 3

An ASP.NET Core MVC web application containerised with Docker. It integrates with Azure Blob Storage and is built automatically with GitHub Actions.





 Features
- MVC architecture (Models, Views, Controllers)
- Azure Blob Storage integration for file/image storage
- Dockerised for consistent deployment
- GitHub Actions workflow that builds the MVC project on every push

<!-- Replace/extend with your actual features -->

Tech Stack
- C# / ASP.NET Core MVC (.NET version: _fill in, e.g. 8.0_)
- Azure Blob Storage
- Docker
- GitHub Actions
- Visual Studio 2022 (v17.14)

Project Structure
```
RaceDayy/
├── Controllers/
├── Models/
├── Views/
├── wwwroot/
├── Dockerfile
├── appsettings.json
├── Program.cs
└── README.md
```
<!-- Adjust to match your repository -->

## Prerequisites
- [.NET SDK](https://dotnet.microsoft.com/download) (matching your project version)
- [Docker Desktop](https://www.docker.com/products/docker-desktop/) (running)
- An Azure Storage account (for Blob Storage)
- Git

## Run Locally (Visual Studio)
1. Clone the repository:
  
   git clone :https://github.com/zwanesinothile565-creator/RaceDayy2.git
  
2. Open the `.sln` file in Visual Studio.
3. Add your Blob Storage connection string (see [Configuration](#configuration)).
4. Press **F5** to run.

## Run with Docker

All commands are run from the folder that contains the `Dockerfile`.

 1. Build the image

docker build -t my-mvc-racedayy .

> Docker image and container names must be **lowercase**.

 2. Run the container

docker run -d -p 8080:8080 --RaceDayy mvc-racedayy  my-mvc-racedayy


| Part | Meaning |

| `-d` | Run in the background (detached) |
| `-p 8080:8080` | Map port 8080 on your PC to port 8080 in the container |
| `--name mvc-racedayy` | Name of the running container |
| `my-mvc-racedayy` | The image to run |

3. Open the app
Go to: http://localhost:8080

4. Useful commands

docker ps                      # list running containers
docker logs mvc-racedayy       # view logs
docker stop mvc-racedayy       # stop the container
docker rm mvc-racedayy         # remove the container


Configuration
Set the Blob Storage values in `appsettings.json` (do **not** commit real secrets), or pass them as environment variables.

json
{
  "AzureBlob": {
    "ConnectionString": "UseDevelopmentStorage=true",
    "ContainerName": "event-banners"
  }
}




 CI/CD
A GitHub Actions workflow (`.github/workflows/`) restores, builds, and tests the MVC project on every push and pull request.

 Troubleshooting
- **Port already in use:** change the left side of the mapping, e.g. `-p 9090:8080`, then browse to `http://localhost:9090`.
- **Container exits immediately:** run `docker logs mvc-racedayy` to see the error.
- **Image not found:** make sure the name in `docker run` matches the one used in `docker build`.
- **Blob errors:** check the connection string and that the container exists in your storage account.

 Author
Name* Sinothile Mhlengi Zwane 
Student number: St10465232
Module: PROG6212
