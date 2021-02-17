# Dephion

Dephion MeetingRoom Reservation Project with Microservice Architecture 

Project integrates with swaggerUI

In order to run the project you need to install docker
To build to project open a terminal run below code where docker.compose file located.After that you'll be able to see API and make able to send request through swaggerUI

docker-compose -f docker-compose.yml -f docker-compose.override.yml up -d

Description
RoomDb and ItemDb stores information about rooms and items that can used in meetingrooms.Reservation detail stores inside reservationDb.


Databases
Roomdb : MongoDb
Itemdb : MongoDb
ReservationDb : Sql Server

RoomApi : http://localhost:8000/swagger/index.html
ItemApi : http://localhost:8001/swagger/index.html
ReservationApi : http://localhost:8002/swagger/index.html
