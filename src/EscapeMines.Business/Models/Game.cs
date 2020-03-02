using EscapeMines.Business.Core.Configuration;
using EscapeMines.Business.Core.Configuration.Interfaces;
using EscapeMines.Business.Core.Factory.Move;
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
    /// Holds information about the Game
    /// </summary>
    public class Game : IGame
    {
        private IBoard Board;
        private List<ICoordinate> Mines;
        private ICoordinate Exit;
        private IPosition StartPosition;
        private List<List<MoveType>> Moves;
        private ITurtle Turtle;

        public Game(IBoard board, List<ICoordinate> mines, ICoordinate exit, IPosition start, List<List<MoveType>> moves, ITurtle turtle, IGameValidator validator)
        {
            //Validate game settings
            validator.Validate();

            Board = board;
            Mines = mines;
            Exit = exit;
            StartPosition = start;
            Moves = moves;
            Turtle = turtle;
        }

        public GameResult Run()
        {
            GameResult gameResult = new GameResult(Moves.Count);
            MoveFactory factory = new MoveFactory();

            int counter = 0;
            foreach (var moveRow in Moves)
            {
                gameResult.ResultList.Add(Status.StillInDanger);

                foreach (MoveType moveType in moveRow)
                {
                    IMove move = factory.GetMove(moveType);
                    IPosition tempPosition = move.Move(Turtle.CurrentPosition);
                    gameResult.VisitedPositions.Add(new List<IPosition>(moveRow.Count));

                    if (Board.IsInBoard(tempPosition.Coordinate)) // target position must be in board
                    {
                        gameResult.VisitedPositions[counter].Add(tempPosition);
                        Turtle.CurrentPosition = tempPosition;

                        if (CheckMine(Turtle.CurrentPosition.Coordinate))
                        {
                            gameResult.ResultList[counter] = Status.MineHit;
                            break;
                        }

                        if (CheckExit(Turtle.CurrentPosition.Coordinate))
                        {
                            gameResult.ResultList[counter] = Status.Success;
                            break;
                        }
                    }
                    else
                    {
                        gameResult.ResultList[counter] = Status.OutOfBoard;
                        gameResult.VisitedPositions[counter].Add(tempPosition);
                        break;
                    }
                }
                counter++;
                Turtle.CurrentPosition = StartPosition;
            }

            return gameResult;
        }

        /// <summary>
        /// Checks a coordinate is the exit point
        /// </summary>
        /// <param name="coordinate">coordinate to be checked</param>
        /// <returns>True if the input point is exit, otherwise false</returns>
        private bool CheckExit(ICoordinate coordinate)
        {
            return coordinate.X == Exit.X && coordinate.Y == Exit.Y;
        }

        /// <summary>
        /// Checks a coordinate has mine 
        /// </summary>
        /// <param name="coordinate">coordinate to be checked</param>
        /// <returns>True if the input point is on mine,otherwise false </returns>
        private bool CheckMine(ICoordinate coordinate)
        {
            return Mines.Any(t => t.X == coordinate.X && t.Y == coordinate.Y);
        }
    }
}
