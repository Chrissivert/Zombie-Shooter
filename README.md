# Zombie-Shooter
Zombie Shooter in unity

[Watch the Demo Video][https://youtu.be/RzxeqmjFKvw}


*IMPORTANT*
The latest version doesn't work

The player can switch between a pistol and shotgun or use bombs to kill the zombies.
The pistol fires one shot, while the shotgun fires three. The guns have a set amount
of ammo.

Each bullet deals random damage within a range and will sometimes be a critical shot.

There are power ups that randomly spawn within the spawn area which gives the player
different power ups, such as increased bulletspeed, increased movementspeed, increased
firerate or kill all zombies currently spawned.

The current objective is to survive until all the zombies are killed, the zombies are 
spawned in waves. If the player takes too much damage the player loses and the game restarts.

The sound and music used is from the unity asset store.

Further work:
* Clean the code and code structure
* Create "smarter" zombies which can traverse through hindrances (currently they
  only go straight towards the player)
* Limit the amount of bombs the user has and make it possible to get more ammo/bombs
* Add bigger map with interactive elements such as purchasing weapons, perks etc.
* Fix bug where the player can be trapped between several zombies but not take damage
* Fix bug where zombies and powerups spawn outside spawn area
* Fix bug where bullets collide with each other
