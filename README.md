# 2245 The Arcade Game [Unity]

A top down shooter arcade game developed for the final project in Games Programming module.
Inspired by 1945 the arcade game on the atari.
The game mainly functions on [Kino’s Camera filters](https://github.com/keijiro/KinoGlitch)to glitch out the game and increase difficulty.(https://imgur.com/a/pNTSO40)
### Inspiration
Inspiration was drawn from the arcade classic game ‘Strikers 1945’ for the atari system. This game was a top down shooter that focuses on combat between planes from the Second World war. The idea for the game resulted in being a simple version of 1945 but instead of focusing on the Second World War it would focus on a future war in 2245. When one thinks of arcade games, one of the first things that come into mind is difficulty. I wanted to make this game incredibly difficult while also being fair and fun enough to play.
### Main Menu
When creating the idea for the game, a question came up which was “How does one make this game look good without actually downloading various assets from the unity store?”. The game needed a certain aesthetic, a futuristic aesthetic. What I ended up deciding on was to use Kino’s Camera filters, to not only have an aesthetic for the menu but to also add difficulty to the game. This all lined up with the certain theme of a difficult arcade shooter set in the future.
The menu has a glitch effect applied to the camera, which creates the whole futuristic aesthetic of the game. Link supplied shows the entire menu effect in gif form.
The buttons are simple TextMeshPro buttons with TextMeshPro Text, these buttons have an event script on click that load the game scene and quit the game respectively.
### Enemies
Upon starting the game the player is spawned in the bottom center location, immediately level one spawn wave of enemies is created. Enemies are randomly arranged, there are 4 body types, custom created by me, six movement patterns and a range for the shoot speed so that all of the enemies don’t shoot at the exact same time each time.
Body types were created in blender for all of the enemies and the player.
Enemies have a shooting method of requesting the position of the player from the game manager and then shooting a bullet at that location. The slight time difference improves the overall difficulty of the game as the bullets themselves are very accurate but with enough skill it is very easy to avoid them.
There are six enemy movement patterns that the enemies follow and are assigned randomly:
1. Horizontal, based on given y value on spawn.
2. Point to point, two random points generated, traverse between them.
3. Enclosed triangle movement, cycles through three points.
4. V movement, same as above but without enclosement.
5. Inverse V moment, same as above but with an upward direction.
6. Random co-ord generated each time the enemy reaches its goal location.
Upon colliding with player bullets, the enemy loses health based on what type of player bullet has interacted with. There are three given types, the basic bullet which is lime green and does five damage, the more advanced bullet that is light blue and does ten damage and finally the advanced bullet that does 15 damage.
### Player
The player is spawned by the game manager and includes a movement function based on translation of horizontal and vertical axis and is thus more suited for controller input.The player is bounded by the camera space through the player bounds script, which clamps its transform position through the viewpoint of the camera and the screen size.
The player has a shooting function attached that varies with the player level, depending on the level of the player different bullets are shot from different muzzles either just the front muzzle, side muzzles or all three.
he player also has a health script which is dependant on its collider, upon colliding with an enemy bullet , the script checks if a shield is currently active, if a shield is active then the user is invincible and thus is immune to damage, otherwise it reduces the player level, if level reaches 0 then a life is removed from the player.
