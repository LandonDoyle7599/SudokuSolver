Hey Trey, here is some info about my sudoku solver.

My Solver implements 7 different solving algorithms and can solve every puzzle found in the sample puzzles. This qualifies my submission
for the 10 points of extra credit for implementing more than 3 algorithms and being able to solve all the puzzles. 

When running my program it will ask you for a path of the puzzle you want to solve, I would use an absolute path. I have included the unsolved sample puzzles for 
your convenience. After it solves the puzzle, if solvable, it will show you the finished puzzle and you can optionally enter a filepath to save the puzzle to, or you can just terminate the program.

Quick warning, puzzles 16-0201, 16-0901, and 16-0902 take about 3 minutes to solve on my machine, 16-0301 takes about 1 minute. The rest of
the puzzles can be solved very fast. I still deem this a solid solution as those puzzles are particularly challenging based on everyone I've spoken with.
My machine is also fairly slow so you may find better results if you test with one of those puzzles.

My UML is found within the documents directory and my unit tests are all in the UnitTests project.

My Solver class contains my use of the facade pattern as it provides a simple point of use for the client code, yet
it implements a number of complex algorithms and dictates their usage. The Solver also uses the Strategy pattern to a degree
as it uses successive algorithms at runtime, if a client provides a puzzle that is relatively simple the program will terminate before more involved
algorithms are used, where as particularly difficult puzzles will use the entire suite of algorithms.

My SudokuCellSolvers class implements the Template method pattern as it provides a structure for all solving algorithms to adhere to 
to ensure that the solver class can use them in a consistent manner. This is useful as the individual algorithms have widely varying levels
of complexity, but by implementing the template method pattern it makes their use simple in the solver class. 

