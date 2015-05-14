# mudz
Game we're making with the skills we cover in the live stream (http://www.twitch.tv/ariugwu). Text adventure. Zombie survival. Tribute to MajorMud.

## Milestones
_I'll do my best to mark which commits line up with which code katas (from the twitch sessions)._

#### Phase I - The foundation of our game mechanics.
* Factory Pattern _(Creational Pattern)_:  Get us off the ground and create some objects.
* Strategy Pattern _(Behavioral Pattern)_: Help deal with some granular complexity of our players. This pattern has a lot in common with the Bridge Pattern and is often confused. The key difference we're high lighting is that our behavior in a Strategy Pattern is coupled witht he context (player)
* Bridge Pattern _(Structural Pattern)_:  Start getting some of our monster code organized. We might do something similar with inventory items so this will be a good test.

#### Phase II - Building out our world and fine tuning interactions with that world.
* Command Pattern _(Behavioral Pattern)_: Introduce a way to cleanly handle commands. Sets us up nicely for event-sourcing later.
* State Pattern _(Behavioral Pattern)_: Add some more complexity to our game Actors (Players/Monsters) to deal with *temporary* changes to them (i.e - scared, excited, brunk, etc).
* Flyweight Pattern _(Structural Pattern)_: Find ways to load our game assets and reuse them efficiently.

#### Phase III - Take another look at some of our patterns and see where we can expand/refine
* Adapter Pattern _(Structural)_:
* Chain of Responsibility _(Behavioral Pattern)_:
* Interpreter Pattern _(Behavioral Pattern)_:
* Decorator Pattern _(Structural Pattern)_: Organize the various things that can impact actions and attributes for our Actors and have them be applied in a uniform way. For example: A _drunk_ player of type _medic_ who tries to _heal_ will need to have all three things factor into how well they peform that action.

#### Phase IV - *(TBD)* The game engine is the god of our world and will enforce all of our laws.
* CQRS Pattern:
* Event Sourcing:
* Observer _(Behavorial Pattern)_:
* Chain of Responsibility _(Behavorial Pattern)_:
* Command Pattern _(Behavorial Pattern)_:

#### Phase IV - *(TBD)* Storage and Retrival
* Unit of Work:
* Repository:

#### Phase V - *(TBD)* Explore Advanced Patterns via https://msdn.microsoft.com/en-us/library/dn600223.aspx
