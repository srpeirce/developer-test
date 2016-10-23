# Objective-3

## Commands

I like the use of commands and handlers. This could however be improved upon using a command bus and configuring via our IOC container.
At the moment the Controller that raises the commands is instantiating the commandhandler. The controller has too much knowledge of the
command handlers and would mean changes to the controller if we added or changed the command handlers - this breaks Single Responsibility Principle.

I would consider pulling out different contexts into their own projects - this would allow for clear seperation of responsibilities.
This may be over kill die to the limited nature of this project.
* OrangeBricks.Offers.Domain
* OrangeBricks.Offers.Commands
* OrangeBricks.Offers.CommandHandlers
* etc.


## Entities

Our entities are currently tightly coupled to Entity Fraemwork - we are using data attributes to define Keys and required fields.
I would suggest using the EF fluent mappings instead.

All entities currently have a "CreatedAt" and "UpdatedAt" DateTime property. I would consider creating an abstract Entity base class for these entities to extend which contains the properties. If there are more complicated audit requirements in future, perhaps extending the Commands solution to record events, seperately from the actual entity.
