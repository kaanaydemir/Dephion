# Dephion
**Room Reservation**

## Getting Started
Make sure you have installed docker in your environment. After that, you can run the below commands from the **/src/** directory and get started with the `Dephion` immediately.

```powershell
docker-compose -f docker-compose.yml -f docker-compose.override.yml up --build
```
# Architecture overview
This reference application is cross-platform at the server and client side.
Services capable of running on Linux or Windows containers depending on your Docker host, and to Xamarin for mobile apps running on Android, iOS 
The architecture proposes a microservice oriented architecture implementation with multiple autonomous microservices 
and implementing different approaches within each microservice (simple CRUD vs. DDD/CQRS patterns)

![image](https://drive.google.com/uc?export=view&id=1fFI5zRvVQpqw6qZqc7L3rV4zmuI3yMtt)

## Running / Development

* Install Docker
* Open project location at terminal and run `docker-compose -f docker-compose.yml -f docker-compose.override.yml up --build`
* Visit your UI at [http://localhost:8003/swagger/index.html](http://localhost:8003/swagger/index.html).
* Visit your RoomApi at [http://localhost:8000/swagger/index.html](http://localhost:8000/swagger/index.html).
* Visit your ItemApi at [http://localhost:8001/swagger/index.html](http://localhost:8001/swagger/index.html).
* Visit your Reservation at [http://localhost:8002/swagger/index.html](http://localhost:8002/swagger/index.html).
* Visit your Apigateway at [http://localhost:7000](http://localhost:7000).


