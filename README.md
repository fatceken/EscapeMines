# EscapeMines

PreRequisites :<br/>
● .NETFramework,Version=v4.6.1 or higher <br/>
● Game config file<br/>
<br/>
Escape Mines is a console application game<br/>
<br/>
A turtle must walk through a minefield. Program reads the initial game settings (path must be defined in app.config) and one or more sequences of moves. For each move sequence, the program outputs whether the sequence leads to the success or failure of the turtle.
<br/>
● The board (or minefield) is a grid of N by M number of tiles.<br/>
● The starting position is a tile, represented by a set of zero based coordinates (x, y) and the initial<br/>
direction (i.e.: N, S, W or E).<br/>
● The exit point is a tile (x, y)<br/>
● The mines are defined as a list of tiles (x, y)<br/>
<br/>
Example config :<br/>
5 4<br/>
1,1 1,3 3,3<br/>
4 2<br/>
0 1 N<br/>
R M L M M<br/>
R M M M<br/>
<br/>
● The first line should define the board size<br/>
● The second line should contain a list of mines (i.e. list of coordinates separated by a space)<br/>
● The third line of the file should contain the exit point.<br/>
● The fourth line of the file should contain the starting position of the turtle.<br/>
● The fifth line to the end of the file should contain a series of moves.<br/>
<br/>
R = Rotate 90 degrees to the right<br/>
L = Rotate 90 degrees to the left<br/>
N = North direction<br/>
S = South direction<br/>
W = West direction<br/>
E = East direction<br/>
M = Move<br/>
<br/>
<br/>
Results can be:<br/>
● Success – if the turtle finds the exit point<br/>
● Mine Hit – if the turtle hits a mine<br/>
● Still in Danger – it the turtle has not yet found the exit or hit a mine<br/>
● Out Of Board - if the turtle leaves the board<br/>
