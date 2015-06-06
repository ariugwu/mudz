# mudz
Game we're making with the skills we cover in the live stream (http://www.twitch.tv/ariugwu). Text adventure. Zombie survival. Tribute to MajorMud.

## Milestones
_I'll do my best to mark which commits line up with which code katas (from the twitch sessions)._

### First 'Semester' ###

#### Phase I - Let's build a prototype game logic engine with a text ui for testing.
* Week 1 - Factory Pattern _(Creational Pattern)_: 
  * **Description:** _Get us off the ground and create some objects_
  * [[Video(s)]](https://www.youtube.com/watch?v=IlWQk2WRS3g)
  * Commit:
* Strategy Pattern _(Behavioral Pattern)_:
  * **Description:** _Help deal with some granular complexity of our players. This pattern has a lot in common with the Bridge Pattern and is often confused. The key difference we're high lighting is that our behavior in a Strategy Pattern is coupled witht he context (player)_
  * [[Video(s)]](https://www.youtube.com/watch?v=obRmu-qJVRE)
  * **Commit:**
* Bridge Pattern _(Structural Pattern)_:
  * **Description:** Start getting some of our monster code organized. We might do something similar with inventory items so this will be a good test.
  * [[Video(s)]](https://www.youtube.com/playlist?list=PLpYfe60H9lRsrrMbj_hsx-cRNL-C-z4kW)
  * **Commit:**

#### Phase II - Building out our world and fine tuning interactions with that world.
* Command Pattern _(Behavioral Pattern)_:
  * **Description:** Introduce a way to cleanly handle commands. Sets us up nicely for event-sourcing later.
  * [[Video(s)]](https://www.youtube.com/playlist?list=PLpYfe60H9lRuFpmif1JiZTa-Cx-1UJKGf)
  * **Commit:**
* State Pattern _(Behavioral Pattern)_:
  * **Description:**
  * [[Video(s)]](https://www.youtube.com/playlist?list=PLpYfe60H9lRvl5DeE5AOAw2-kYsd_xrMX): Add some more complexity to our game Actors (Players/Monsters) to deal with *temporary* changes to them (i.e - scared, excited, brunk, etc).
  * **Commit:**
* Flyweight Pattern _(Structural Pattern)_:
  * **Description:** Find ways to load our game assets and reuse them efficiently.
  * [[Video(s)]](https://www.youtube.com/playlist?list=PLpYfe60H9lRte4o8Ld_fTpG7iaJlSpV_B)
  * **Commit:**

##### Bonus [[Video(s)]](https://www.youtube.com/playlist?list=PLpYfe60H9lRu9yxvQfaMO6Avp15kkXfJt):
* Adapter Pattern _(Structural)_: We use this but never did a kata for it because it's so similar to our core 6.
* Interpreter Pattern _(Behavioral Pattern)_: We use this but never did a kata for it because it's so similar to our core 6.

### Second 'Semester ###
#### Phase III - First things first: Build a TCP Server and Client to start playing our game with other people.
* Singleton _(Creational)_: Since we have tcp sockets and connections flying around we want to make sure that our game engine is only created once.
* Decorator Pattern _(Structural Pattern)_: Organize the various things that can impact actions and attributes for our Actors and have them be applied in a uniform way. For example: A _drunk_ player of type _medic_ who tries to _heal_ will need to have all three things factor into how well they peform that action.
* Chain of Responsibility _(Behavorial Pattern)_:

#### Phase IV - *(TBD)* The game engine is the god of our world and will enforce all of our laws.
* CQRS Pattern: We have a lot going on and while we've done a bit to structure our commands we might want to make things a bit more formal.
* Event Sourcing: 
* Observer _(Behavorial Pattern)_:
* Proxy _()_:

### Summer School ###

#### Phase V - *(TBD)* Storage and Retrival
* Unit of Work:
* Repository:

#### Phase VI - *(TBD)* Explore Advanced Patterns via https://msdn.microsoft.com/en-us/library/dn600223.aspx
