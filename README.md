# GED-EXM01-PJT
Project for exam 1 of Game Engines course.

- INTRO -
Along with Unity, I use GIMP to create the mazes, and apply them as heightmaps.
I use the maze renderer (Filters > Render > Pattern > Maze), then make changes afterwards.
The mazes are rendered as 512 X 512 images, and have their colours inverted.
The reason why is because the lighter a pixel the higher the corresponding geometry.

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
		- Checkpoint
	* (0, 0, 255) [BLUE]
		- Ending Position

	* (255, 255, 0) [YELLOW] 
		- Vertical Moving Platform
	* (0, 255, 255) [CYAN]
		- Horizontal Moving Platform
	* (255, 0, 255) [MAGENTA]
		- Diagonal Moving Platform
	
	* (


- CHECKPOINTS -
The maze works by 
TBD