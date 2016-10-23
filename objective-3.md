# Objective-3
Note: I edited this file directly in GitHub. For a production app I would of edited the file outside to keep a clean history of commits.

## Testing
Acceptance and intergration tests should be considered.

## Commands

I like the use of commands and handlers. This could be improved upon using a command bus and potentially configuring via our IOC container.
At the moment the Controller that raises the commands is instantiating the commandhandler. The controller has too much knowledge of the
command handlers and would mean changes to the controller if we added or changed the command handlers - this breaks Single Responsibility Principle.

I would consider splitting the project into different contexts (projects) - this would allow for a clearer seperation of concerns.

Offers Context consisting of:
* OrangeBricks.Offers.Domain
* OrangeBricks.Offers.Commands
* OrangeBricks.Offers.CommandHandlers
* etc.

## Controllers - Split some responsibilities
From my understanding of the domain, there is a clear seperation between the actions of buyers and sellers.
With this clear seperation in mind, I would split existing controllers for a clear seperation between these actions.
As part of objective-1 I created the "MyOffersController" that holds the actions for offers for a buyer, leaving the "OffersController" for seller actions. These could be renamed for clarity.

I would also move the "MakeOffer" logic away from the Property context and into the Offers context.

## Entities

Our entities are currently tightly coupled to Entity Fraemwork - we are using data attributes to define Keys and required fields.
I would suggest using the EF fluent mappings instead that will be in a seperate class to the entity.

All entities have a "CreatedAt" and "UpdatedAt" DateTime property. I would consider extracting these properties into an abstract Entity base class for the entities to extend. 

If there are more complicated audit requirements in future, perhaps extending the Commands solution to record events, seperately from the actual entity.

## Routes and URLs

I am not a fan of the "Default" route in Routeconfig that acts as a catch all, in my experience this can cause problems and route debugging headaches. I would remove this and be a little more granular with my route config. 

I would give more thought to the URLs that we are using in the site.

E.g. As part of objective-2 I added the following route:
property/{propertyId}/viewings/book

I would begin using this as a convention, changing urls to match. e.g change make an offer
 * From: Property/MakeOffer/{propertyId}
 * Potentially to: property/{propertyId}/offers/make
 
 The benefit is that the url is more readable, a customer could even remove the end of the url and still have a valid url
 .
These changes would need to be discussed with stakeholders - changing the urls once the application is in production could cause major issues.
 
 
