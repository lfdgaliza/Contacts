# Domain
The application's Domain

Must include all contracts and used entities in addition to virtual objects and data transfer objects.

## Difference between DTOs and VOs
DTOs (Data Transfer Objects), in the context of this architecture, are used to transport information to the external world through the API.

VOs (Virtual Objects), in the context of this architecture, are used to make very customized queries where performance can be an issue. It is a manner to lack a little of OO to obtain other gains.

### Resume
DTOs are used to communicate with the external world.

VOs are used to make personalized entities to be used inside the application.

### Important
Even when the developer wants to expose the exact information that is on a VO or Entity, it is highly recommended to make a new DTO to expose this information with the help of the AutoMapper.