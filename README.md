# Todo List API
This API allows you to Create, Edit, Update, and Delete ToDo tasks for productivity tracking!

### Running the API with docker
1. From the root directory of the project execute the following command

    `docker compose up api --build`

    Note: `--build` is only required once

2. API should now be available on localhost port 8080

    Swagger docs available at http://localhost:8080/swagger/index.html

### Shut down the containers
1. From the root directory execute the following command

    `docker compose down`

### Debugging the API
1. Bring up only the database container

    `docker compose up -d db`

2. In VSCode simply hit F5 to begin debugging the API