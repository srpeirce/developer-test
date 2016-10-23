# Objective-3

I like the use of commands and handlers. This could however be improved upon using a command bus and configuring via our IOC container.
At the moment the Controller that raises the commands is instantiating the commandhandler. The controller has too much knowledge of the
command handlers and would mean changes to the controller if we added or changed the command handlers - this breaks Single Responsibility Principle.

