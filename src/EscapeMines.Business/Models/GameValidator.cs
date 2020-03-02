using EscapeMines.Business.Enums;
using EscapeMines.Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscapeMines.Business.Models
{
    /// <summary>
    /// Holds information about a game validatior
    /// </summary>
    public class GameValidator : IGameValidator
    {
        private IBoard Board;
        private List<ICoordinate> Mines;
        private ICoordinate Exit;
        private IPosition StartPosition;
        private List<List<MoveType>> Moves;
        private ITurtle Turtle;

        public GameValidator(IBoard board, List<ICoordinate> mines, ICoordinate exit, IPosition start, List<List<MoveType>> moves, ITurtle turtle)
        {
            Board = board;
            Mines = mines;
            Exit = exit;
            StartPosition = start;
            Moves = moves;
            Turtle = turtle;
        }

        public void Validate()
        {
            foreach (ICoordinate mine in Mines)
            {
                if (StartPosition.Coordinate.X == mine.X && StartPosition.Coordinate.Y == mine.Y)
                {
                    throw new FormatException("Start Position can not be on mine");
                }

                if (!Board.IsInBoard(mine))
                {
                    throw new FormatException("Mines must be in board");
                }

                if (Exit.X == mine.X && Exit.Y == mine.Y)
                {
                    throw new FormatException("Exit Position can not be on mine");
                }
            }

            if (!Board.IsInBoard(StartPosition.Coordinate))
            {
                throw new FormatException("Start Position must be in board");
            }

            if (!Board.IsInBoard(Exit))
            {
                throw new FormatException("Exit Position must be in board");
            }

            if (Exit.X == StartPosition.Coordinate.X && Exit.Y == StartPosition.Coordinate.Y)
            {
                throw new FormatException("Start and Exit Positions must be different");
            }
        }
    }
}
