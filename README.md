# Toy Robot
This repository contains a solution for the \*ToyRobot coding exercise.

## Command Loading / Validation
Loading of a command file can handle x and y coordinates outside the specfied range, as well as an invalid facing direction.
If a Place command has x and y coordinates that are invalid integers or there are not three parameters after the Place keyword then an exception will be thrown in the command reading process and the application will terminate.

## Command Execution
When and invalid Place command is executed it is ignored as per the requirements.  

## Getting Started

To run the application, launch it from the command line and pass the command file as the first parameter.<br/>
e.g. ToyRobot.exe SampleInvalidPlacements.txt

If you are running the application from within Visual Studio then edit then *launchSettings.json* to change the sample command file used. Be sure to save *launchSettings.json* before running or the old command file name will be used.

If the application is run in debug mode then there will be logging for all commands executed whether they are valid or not.

## Testing

There are a number of test files included to test various scenarios.<br/>


- TestInvalidPlacements.txt
	This tests an invalid Place command followed by some move/rotate commands. It then has a valid Place command followed by some move/rotate commands.

- TestScenarioA.txt
	This tests example A from **Example Input and Output**.

- TestScenarioB.txt
	This tests example B from **Example Input and Output**.

- TestScenarioC.txt
	This tests example C from **Example Input and Output**.

- TestRotate.txt
	This tests a full rotation going both left and right.

- TestTopLeft.txt
	Starting at the Top/Left of the board this tests various move scenarios attempting to move off the board.

- TestTopRight.txt
	Starting at the Top/Right of the board this tests various move scenarios attempting to move off the board.

- TestBottomRight.txt
	Starting at the Bottom/Right of the board tests various move scenarios attempting to move off the board.

- TestLoadExceptionA.txt
	Tests raising exceptions when loading a command file with a place command containing and invalid X or Y cordinate.

- TestLoadExceptionB.txt
	Tests raising exceptions when loading a command file with a place command containing an incorrect number of parameters.
	


<br/><br/>
\**No Chat Gippitys were consulted in the creation of this solution.*
