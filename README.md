# Purchase api 

## Running project local

Install docker and docker-compose 

Create a .env file with the information below
```
#DOT NET CORE
APP_PORT=8081

#DATABASE
DATABASE_PORT=4002

#ContainerDabase
DBServer=database
DBPort=3306
DBName=amazonpurchase
DBUser=root
DBPassword=1234

#APPLICATION VARIABLES
API_TITLE=Dream team purchase
API_VERSION=v1
SWAGGER_ENDPOINT=/swagger/v1/swagger.json

#API ADDRESS
PRODUCT_ADDRESS=http://host.docker.internal:8082/api/
```

after this start application run the command docker-compose up -d

# Swagger documentation
http://localhost:8081/swagger-ui.html

It's necessary to run Product-API to execute this project.
