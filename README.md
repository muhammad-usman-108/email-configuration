# Email Configuration Manager

This project is an **Email Configuration Manager** with a **.NET backend** and an **Angular frontend**. The backend uses PostgreSQL for storage. The project is fully Dockerized so that users can run it without installing PostgreSQL or .NET locally.

---

## Table of Contents

- [Prerequisites](#prerequisites)
- [Backend Setup](#backend-setup)
- [Frontend Setup](#frontend-setup)
- [Running the Application](#running-the-application)

---

## Prerequisites

Make sure you have the following installed:

- [Docker](https://www.docker.com/get-started)
- [Docker Compose](https://docs.docker.com/compose/install/)
- [Node.js + npm](https://nodejs.org/) (for frontend development)
- [Angular CLI](https://angular.io/cli) (optional, for local development)

---

## Backend Setup

The backend is a **.NET 8 Web API** that connects to PostgreSQL.

1. Open the terminal and move to directory `EmailConfigApi`:
   `cd EmailConfigApi`

2. Run the backend application:
    `docker-compose up --build`

    It will create two docker container one for backend services and one for Postgresql.

## Backend services testing using Swagger UI

1. Open the browser and hit the url
`http://localhost:5182/swagger/index.html`

2. The GET and POST endpoints are available and you can test the backend service separately if you want.


## Frontend Setup

1. Move to folder `email-config-app` and install dependencies:
    `cd email-config-app`
    `npm install`

2. Run the FE application:
    `ng serve`

3. Open the browser and hit the url.
    `http://localhost:4200/`

4. Test the functionalities of create email configuration, show all the email configuration and show the selected email configuration.
