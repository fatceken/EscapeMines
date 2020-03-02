# EscapeMines

PreRequisites :
● .NETFramework,Version=v4.6.1 or higher
● Game config file

Escape Mines is a console application game

A turtle must walk through a minefield. Program reads the initial game settings (path must be defined in app.config) and one or more sequences of moves. For each move sequence, the program outputs whether the sequence leads to the success or failure of the turtle.

● The board (or minefield) is a grid of N by M number of tiles.
● The starting position is a tile, represented by a set of zero based coordinates (x, y) and the initial
direction (i.e.: N, S, W or E).
● The exit point is a tile (x, y)
● The mines are defined as a list of tiles (x, y)

Example config :
5 4
1,1 1,3 3,3
4 2
0 1 N
R M L M M
R M M M

● The first line should define the board size
● The second line should contain a list of mines (i.e. list of coordinates separated by a space)
● The third line of the file should contain the exit point.
● The fourth line of the file should contain the starting position of the turtle.
● The fifth line to the end of the file should contain a series of moves.

R = Rotate 90 degrees to the right
L = Rotate 90 degrees to the left
N = North direction
S = South direction
W = West direction
E = East direction
M = Move


Results can be:
● Success – if the turtle finds the exit point
● Mine Hit – if the turtle hits a mine
● Still in Danger – it the turtle has not yet found the exit or hit a mine
● Out Of Board - if the turtle leaves the board
