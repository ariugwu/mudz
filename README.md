# mudz
Game we're making with the skills we cover in the live stream (http://www.twitch.tv/ariugwu). Text adventure. Zombie survival. Tribute to MajorMud.

## Milestones
_I'll do my best to mark which commits line up with which code katas (from the twitch sessions)._

#### Phase I - The foundation of our game mechanics.
* Factory Pattern _(Creational Pattern)_:  Get us off the ground and create some objects.
* Strategy Pattern _(Behavorial Pattern)_: Help deal with some granular complexity of our players. This pattern has a lot in common with the Bridge Pattern and is often confused. The key difference we're high lighting is that our behavior in a Strategy Pattern is coupled witht he context (player)
* Bridge Pattern _(Strutural Pattern)_:  Start getting some of our monster code organized. We might do something similar with inventory items so this will be a good test.

#### Phase II - Building out our world and fine tuning interactions with that world.
* Builder Pattern _(Creational Pattern)_: Help create our world (Environment).
* Abstract Factory _(Creational Pattern)_: Take advantage of our builder pattern to create a clean api (i.e - MonsterFactory.Create(MonsterType.Foo)), and also show how we can implement a wide range of diversity in monsters without needless code or performance hits (i.e. - a 'boss' might have a ton of complexity where as a trivial monster would not. So there's not need to have _all_ monsters implement a complexity that only the smallest percentage utilize). 
* State Pattern _(Behavorial Pattern)_: Add some more complexity to our game Actors (Players/Monsters) to deal with *temporary* changes to them (i.e - scared, excited, brunk, etc).
* Decorator Pattern _(Strutural Pattern)_: Organize the various things that can impact actions and attributes for our Actors and have them be applied in a uniform way. For example: A _drunk_ player of type _medic_ who tries to _heal_ will need to have all three things factor into how well they peform that action.

#### Phase III - *(TBD)* The game engine is the god of our world and will enforce all of our laws.
* CQRS Pattern:
* Event Sourcing:
* Observer _(Behavorial Pattern)_:
* Chain of Responsibility _(Behavorial Pattern)_:
* Command Pattern _(Behavorial Pattern)_:

#### Phase IV - *(TBD)* Storage and Retrival
* Unit of Work:
* Repository:

#### Phase V - *(TBD)* Explore Advanced Patterns via https://msdn.microsoft.com/en-us/library/dn600223.aspx
