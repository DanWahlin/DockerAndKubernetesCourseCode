# ASP.NET Core with PostgreSQL and Docker Demo

Application demo designed to show how ASP.NET Core and PostgreSQL can be run in Docker containers. 
The app uses Entity Framework to create a simple database that stores Docker commands and examples.

##To run the app with Docker Containers:

###Running the App with Docker Compose

1. Install `Docker for Mac` or `Docker for Windows` (or Docker Toolbox: http://docker.com/toolbox if you have to)

1. Navigate to the `AspNetCorePostgreSQLDockerApp` subfolder in a console window

1. Open a separate command prompt window.

3. Run `docker-compose build`

4. Run `docker-compose up`

1. Navigate to http://localhost:5000 (http://192.168.99.100:5000 if using Docker Toolbox) in your browser to view the site.
