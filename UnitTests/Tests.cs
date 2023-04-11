using System;
using NUnit.Framework;
using SudokuSolver;

namespace UnitTests
{
    public class Tests
    {
        [Test]
        public void ValidSudokuInput_ReturnsTrue()
        {
            // Arrange
            string[] input =
            {
                "4",
                "1 2 3 4",
                "1 - - -",
                "- 3 - -",
                "- - 2 -",
                "- - - 4"
            };

            // Act
            bool result = Sudoku.ValidateInput(input);

            // Assert
            Assert.True(result);
        }

        [Test]
        public void InvalidSudokuInput_ReturnsFalse()
        {
            // Arrange
            string[] input =
            {
                "5",
                "1 2 3 4 5",
                "1 0 0 0",
                "0 3 0 0",
                "0 0 2 0",
                "0 0 0 4"
            };

            // Act
            var result = Sudoku.ValidateInput(input);

            // Assert
            Assert.False(result);
        }

        private readonly string[] _puzzleInput1 =
        {
            "4",
            "1 2 3 4",
            "2 - 3 1",
            "1 3 - 4",
            "3 1 4 -",
            "- 2 1 3"
        };

        private readonly string[] _puzzleInput2 =
        {
            "9",
            "1 2 3 4 5 6 7 8 9",
            "- 2 - - - 5 - - 7",
            "- - - 6 8 - - 9 -",
            "3 - 9 - - - - - -",
            "- - - - - 3 - - 8",
            "4 - 7 - 9 - 3 - 2",
            "5 - - 1 - - - - -",
            "- - - - - - 4 - 1",
            "- 1 - - 7 6 - - -",
            "9 - - 3 - - - 6 -",
        };

        private readonly string[] _puzzleInput3 =
        {
            "4",
            "1 2 3 4",
            "- - - 1",
            "1 - - 4",
            "- - 4 -",
            "- 2 - -"
        };

        private readonly string[] _puzzleInput4 =
        {
            "9",
            "1 2 3 4 5 6 7 8 9",
            "- 2 - - - 5 - - 7",
            "- - - 6 8 - - 9 -",
            "3 - 9 - - - - - -",
            "- - - - - 3 - - 8",
            "4 - 7 - 9 - 3 - 2",
            "5 - - 1 - - - - -",
            "- - - - - - 4 - 1",
            "- 1 - - 7 6 - - -",
            "9 - - 3 - - - 6 -",
        };

        private readonly string[] _puzzleInput5 =
        {
            "16",
            "1 2 3 4 5 6 7 8 9 A B C D E F G",
            "- - - - D 4 - B - - 7 - 3 - 2 -",
            "7 B 6 - - - - - - 8 C - A - D F",
            "- - - - - - C - - 2 D - B - - E",
            "- - - - E - - 9 - - - - - C 4 8",
            "- 4 - - 3 - - F 6 - 1 - - B 9 C",
            "C E - - - - - - - - A B - - - 2",
            "- 2 B - 9 - - E - - - 8 - - 3 -",
            "- 6 3 F C B - 1 G - - 9 - 4 - -",
            "- - C - 4 - - 6 A - 8 D E 1 F -",
            "- D - - A - - - 1 - - C - 2 B -",
            "G - - - 7 C - - - - - - - - 8 9",
            "6 1 F - - 3 - 5 2 - - 7 - - C -",
            "D C 7 - - - - - 8 - - F - - - -",
            "B - - 2 - 8 3 - - 1 - - - - - -",
            "4 5 - G - F 9 - - - - - - E A B",
            "- 8 - A - 5 - - E - B 2 - - - -",
        };

        private readonly string[] solvedPuzzle =
        {
            "36",
            "0 1 2 3 4 5 6 7 8 9 A B C D E F G H I J K L M N O P Q R S T U V W X Y Z",
            "C R E 3 6 2 8 V X A Y I T H Z S O F M N J 9 K B U 4 0 W 1 5 7 Q P L G D",
            "O P G M 8 A Z W 1 6 N 0 I J Q 7 E C T U 5 V H D X L 3 S F 9 B Y R 2 4 K",
            "Q N 0 H X B 9 E R 5 O K G 6 4 U V 1 2 L S 8 I 7 P M Y T D Z W F C A J 3",
            "1 V J W K 4 7 T Q 2 M D B 8 R X Y L P E 3 Z 6 F G O H N C A S 5 U I 9 0",
            "L I Y T D F U H J G 4 S P 3 2 5 9 0 A C X 1 W R Q 6 E K B 7 8 V Z O N M",
            "U 9 7 5 S Z B P 3 L C F A D K N M W 4 Y O Q G 0 J 2 I R 8 V 1 H X 6 E T",
            "Y J D O G 5 6 S E 8 X 9 N 7 1 I F B R W 4 L T V C Z Q M U 3 0 P A K H 2",
            "A Q X V T S I K P M U N C 5 3 G 6 4 Z 1 E D Y 2 B W J 7 0 H O R L 9 F 8",
            "7 U 6 I 2 N T 0 5 W 1 B E O 8 L Z V G K H M Q 9 A Y P 4 R F X 3 S J D C",
            "K F 4 B W C R 7 Z H 3 Q 9 S U J P M O 5 0 A X 6 8 N 1 L 2 D V T I G Y E",
            "H 0 R 8 E M J F 4 O L Y W 2 D A T Q U 3 P C 7 I 9 X K V S G N Z 6 5 1 B",
            "Z 3 9 P L 1 C 2 G V D A K 0 X Y H R J B 8 F N S 5 T O 6 E I Q W 7 4 M U",
            "I D B E M L S 1 6 7 9 8 Z F Y K A J W G C X U T 4 Q 5 2 V 0 H O N P 3 R",
            "F G O J Q K M C D B A H S U L P R N 3 4 7 2 8 5 1 E 9 I Y 6 Z 0 V W T X",
            "V X Z 0 3 Y P I L T J W 8 4 5 9 1 6 K H B S M Q O C U F N R 2 7 E D A G",
            "6 C 1 2 9 8 V N K E F G 0 W H T X 3 I R L J P O M 7 D A Z B 5 S 4 Q U Y",
            "N T A 7 U P 4 R O Q 5 2 V B G C D E 6 Z 9 Y 0 1 S 3 X H W 8 L J F M K I",
            "5 W S R 4 H Y 3 U Z 0 X M I O Q 7 2 N D V E F A L K T G P J 6 C 8 1 B 9",
            "E S V G N D W B 7 K 8 C U L 6 0 J H 1 9 A P Z 3 T R 4 5 I Y F 2 M X O Q",
            "4 K U Q P J H O N D T 3 Y Z 7 V G A B 2 M W R L F 0 8 1 9 X C I 5 E 6 S",
            "M B H Y C 7 1 4 F 9 S P R T W D 8 I X 6 Q O 5 E Z J L 3 G 2 U A K N 0 V",
            "2 L I 1 F 0 G 5 V X Q U 3 N M E S O C 8 T 7 J H W P 6 D A K Y B 9 Z R 4",
            "R 5 8 A O 9 0 Z M Y 6 E 2 1 P F 4 X D I G N S K V U C B 7 Q 3 L H T W J",
            "W 6 3 X Z T L A I J 2 R 5 9 C B Q K F 0 U 4 V Y N S M E H O G D 1 7 8 P",
            "D O C K V X N 8 2 0 7 L F A E R 3 P Y M 1 H 9 W I G Z Q 6 T J 4 B U S 5",
            "8 2 M 6 B I A J C F G T O X V Z U 7 Q S R 3 D 4 0 1 W 9 5 E K N Y H P L",
            "G 7 T Z J E 5 Q S 3 V 4 D Y N H W 8 0 F I 6 A C K B 2 P L U M 9 O R X 1",
            "3 H Q N 0 U O 6 B R P M L K 9 1 I S 8 T Z 5 E J Y F 7 C X 4 A G D V 2 W",
            "9 1 P 4 5 W K D Y I H Z 6 M 0 2 C T L X N G B U R V A O J S E 8 Q 3 7 F",
            "S Y F L A R X 9 W U E 1 Q G J 4 B 5 V 7 2 K O P H D N 8 3 M I 6 T 0 C Z",
            "J 8 W C R V 2 L H S I 7 X Q T 6 N G 5 O F U 1 M D 9 B 0 K P 4 E 3 Y Z A",
            "B 4 N 9 I G E Y 0 1 W 5 H V F O K Z 7 P D T C X 3 A S J M L R U 2 8 Q 6",
            "P M L S 7 3 Q U T C Z V 4 R B W 0 Y 9 A 6 I 2 8 E H G X O 1 D K J F 5 N",
            "X E K F H 6 D M 9 N R O J P A 8 L U S Q Y B 3 G 2 5 V Z 4 W T 1 0 C I 7",
            "T A 5 U 1 O F X 8 P K J 7 C S 3 2 D E V W 0 4 Z 6 I R Y Q N 9 M G B L H",
            "0 Z 2 D Y Q 3 G A 4 B 6 1 E I M 5 9 H J K R L N 7 8 F U T C P X W S V O"
        };



        [Test]
        public void TestBruteForce()
        {
            Sudoku puzzle = new Sudoku(_puzzleInput2);
            BruteForceSolver solver = new BruteForceSolver(puzzle);
            Solver solver2 = new Solver(puzzle);

            solver.Solve();

            Assert.True(solver2.CheckIfSolved());
        }

        [Test]
        public void TestNakedSingleSolver()
        {
            Sudoku puzzle = new Sudoku(_puzzleInput1);
            AssignPossibleValues apvSolver = new AssignPossibleValues(puzzle);
            apvSolver.Solve();
            NakedSingleSolver solver = new NakedSingleSolver(puzzle);
            Solver solver2 = new Solver(puzzle);

            solver.Solve();

            Assert.True(solver2.CheckIfSolved());
        }

        [Test]
        public void TestHiddenSinglesSolver()
        {
            Sudoku puzzle = new Sudoku(_puzzleInput3);
            AssignPossibleValues apvSolver = new AssignPossibleValues(puzzle);
            apvSolver.Solve();
            HiddenSingles solver = new HiddenSingles(puzzle);
            Solver solver2 = new Solver(puzzle);

            solver.Solve();

            Assert.True(solver2.CheckIfSolved());
        }

        [Test]
        public void TestNakenHiddenPairsSolver()
        {
            Sudoku puzzle = new Sudoku(_puzzleInput4);
            AssignPossibleValues apvSolver = new AssignPossibleValues(puzzle);
            apvSolver.Solve();
            NakedPairsSolver solver = new NakedPairsSolver(puzzle);
            HiddenPairsSolver solver2 = new HiddenPairsSolver(puzzle);
            Solver solver3 = new Solver(puzzle);

            solver.Solve();
            solver2.Solve();

            Assert.True(solver3.CheckIfSolved());
        }

        [Test]
        public void TestEntireSolver()
        {
            Sudoku puzzle = new Sudoku(_puzzleInput5);
            Solver solver = new Solver(puzzle);
            solver.Solve();

            Assert.True(solver.CheckIfSolved());
        }

        [Test]
        public void TestCheckIfSolved()
        {
            Sudoku puzzle = new Sudoku(solvedPuzzle);
            Solver solver = new Solver(puzzle);

            Assert.True(solver.CheckIfSolved());
        }

    }

}