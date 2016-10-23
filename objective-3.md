# Objective-3

## Testing
Acceptance and intergration tests should be considered.

## Commands

I like the use of commands and handlers. This could be improved upon using a command bus and potentially configuring via our IOC container.
At the moment the Controller that raises the commands is instantiating the commandhandler. The controller has too much knowledge of the
command handlers and would mean changes to the controller if we added or changed the command handlers - this breaks Single Responsibility Principle.

I would consider pulling splitting the project into different contexts (projects) - this would allow for a clearer seperation of concerns.
* OrangeBricks.Offers.Domain
* OrangeBricks.Offers.Commands
* OrangeBricks.Offers.CommandHandlers
* etc.

## Controllers - Split some responsibilities
For objective-1 I created the "MyOffersController". This could potentially have a better name, but in effect it holds the actions for offers for a buyer. From my understanding of the domain, there is a clear seperation between what a buyer and sellers actions.

I would possibly refactor the existing "PropertyController" and split this into buyer and seller actions. This will also simplify the authorization as to what roles can do what actions.

I would also move the "MakeOffer" logic away from the Property context and into the Offers context.

## Entities

Our entities are currently tightly coupled to Entity Fraemwork - we are using data attributes to define Keys and required fields.
I would suggest using the EF fluent mappings instead.

All entities currently have a "CreatedAt" and "UpdatedAt" DateTime property. I would consider creating an abstract Entity base class for these entities to extend which contains the properties. If there are more complicated audit requirements in future, perhaps extending the Commands solution to record events, seperately from the actual entity.


## Routes and URLs

I am not a fan of the "Default" route in Routeconfig that acts as a catch all. I would remove this and be a little more granular with my route config. 

I would give more thought to the URLs that we are using in the site.

As part of objective-2 I added the following route:
property/{propertyId}/viewings/book

I would begin using this as a convention, changing urls to match. e.g change make an offer
 * From: Property/MakeOffer/{propertyId}
 * Potentially to: property/{propertyId}/offers/make
 
 These changes would be discussed with stakeholders in real life before making such changes - changing the urls once the application is in production could cause major issues.
 
 
