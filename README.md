# GED-EXM01-PJT
Project for exam 1 of Game Engines course.

- INTRO -
Along with Unity, I use GIMP to create the mazes, and apply them as heightmaps.
I use the maze renderer (Filters > Render > Pattern > Maze), then make changes afterwards.
The mazes are rendered as 512 X 512 images, and have their colours inverted.
The reason why is because the lighter a pixel the higher the corresponding geometry.

- CONTROLS -
W: apply motion forward
S: apply motion backward
A/LEFT ARROW: rotate left
D/RIGHT ARROW: rotate right
UP ARROW: look upwards
DOWN ARROW: look downwards
P: stop momentum on x-axis and z-axis


R: reset Camera to original position and orientation
PAGE_UP: reset Camera y-axis rotation
PAGE_DOWN: reset Camera x-axis rotation

- FILES -
The maze works by using a greyscale raw file, and a regular png file.
* Greyscale .RAW File 
	* The .RAW file is used as a heightmap. It MUST be set to greyscale before exporting.
	* The reason why is because not doing so will export colour information that will interfere with the map.
	* Simply having only black, white, and shades of grey without setting to greyscale will still cause this problem.
* Color-Coded .PNG File
	* The .PNG file of the same name is used to place objects into the game world.
	* The 
	* This doesn't need to be a PNG, but GIMP (the program I'm using to create these mazes) does not export colours properly if done as a JPEG.
	* For some reason, when exporting as a JPEG Gimp's colours are slightly off (e.g. a red value will go from (255, 0, 0) to (254, 0, 0) when exported).
	* I don't know why this is the case, but the reader requires the colour values to be exactly the same.

-- Mazes --
Mazes are named "maze###A" with the last character being a letter from A to Z.
The lettering convention is as follows:
* A: Greyscale Maze - used for heightmap
* B: Coloured Maze - ued for placing objects

- COLOURS -
Color Codes:
The colour codes for objects are shown below. The alpha values are disregarded for comparisons.
Heightmap Values:
	* (0, 0, 0) [BLACK]
		- The lowest point in the maze, which acts as the floor.
	* (255, 255, 255) [WHITE]
		- The highest point in the maze.
	* [0, 255] [GREY] 
		- Range of height in the maze.

Map Values:
	* (255, 0, 0) [RED]
		- Starting Position
	* (0, 255, 0) [GREEN]
		- Ending Position
	* (0, 0, 255) [BLUE]
		- Checkpoint

	* (255, 255, 0) [YELLOW] 
		- X-Movement Platform
	* (0, 255, 255) [CYAN]
		- Y-Movement Platform
	* (255, 0, 255) [MAGENTA]
		- Z-Movement Platform
	
	* (255, 165, 10) [ORANGE]
		- X-Movement Wall
	* (238, 130, 238) [VIOLET]
		- Y-Movement Wall
	* (165, 42, 42) [BROWN]
		- Z-Movement Wall


- CHECKPOINTS -
The checkpoints are blue squares that must be collided with to be triggered. They will disappear afterwards.
The player will respawn at said checkpoints if they fall off the map.

- MUSIC -
There is an audio object attached to the end goal. The idea was to have the music get louder as you get near it, but that didn't work.
As such, the audio has just been attached to the player instead. 4 songs have been included.
There is no in-game system to change songs; they must be manually switched from the player's audio listener.

* PAC-MAN - Super Smash Bros. for Nintendo 3DS / Wii U - Copyright BANDAI NAMCO & Nintendo
* Scrap Brain Zone - Sonic the Hedgehog (1991) - Copyright Masato Nakamura
* Snake Eater (Instrumental) - Metal Gear Solid 3: Snake Eater - Copyright Konami
* Theme of Solid Snake - Metal Gear 2: Solid Snake - Copyright Konami