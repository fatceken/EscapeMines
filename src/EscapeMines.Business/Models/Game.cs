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

        public List<Status> ResultList { get; private set; }
        public ITurtle Turtle { get; private set; }
        public List<List<IPosition>> VisitedPositions { get; private set; }
        public string FinishInfo { get; private set; }

        public Game()
        {
            Configure();
            Validate();
            CreateElements();
        }

        /// <summary>
        /// Configures game elements
        /// </summary>
        private void Configure()
        {
            IGameConfiguration configuration = new GameConfiguration();
            Board = configuration.BoardConfiguration.GetBoard();
            Mines = configuration.MinesConfiguration.GetMines();
            Exit = configuration.ExitConfiguration.GetExitPoint();
            StartPosition = configuration.StartConfiguration.GetStartPoint();
            Moves = configuration.MoveConfiguration.GetMoves();
        }

        /// <summary>
        /// Validates initial rules of the game, if any validation fails throws exception
        /// </summary>
        private void Validate()
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

        /// <summary>
        /// Creates the game elements
        /// </summary>
        private void CreateElements()
        {
            Turtle = new Turtle(StartPosition);
            ResultList = new List<Status>(Moves.Count);
            VisitedPositions = new List<List<IPosition>>(Moves.Count);
        }

        /// <summary>
        /// Runs the game algorithm
        /// </summary>
        public void Run()
        {
            MoveFactory factory = new MoveFactory();

            int counter = 0;
            foreach (var moveRow in Moves)
            {
                ResultList.Add(Status.StillInDanger);

                foreach (MoveType moveType in moveRow)
                {
                    VisitedPositions.Add(new List<IPosition>(moveRow.Count));

                    IMove move = factory.GetMove(moveType);
                    IPosition tempPosition = move.Move(Turtle.CurrentPosition);

                    if (Board.IsInBoard(tempPosition.Coordinate)) // target position must be in board
                    {
                        VisitedPositions[counter].Add(tempPosition);
                        Turtle.CurrentPosition = tempPosition;

                        if (CheckMine(Turtle.CurrentPosition.Coordinate))
                        {
                            ResultList[counter] = Status.MineHit;
                            break;
                        }

                        if (CheckExit(Turtle.CurrentPosition.Coordinate))
                        {
                            ResultList[counter] = Status.Success;
                            break;
                        }
                    }
                    else
                    {
                        ResultList[counter] = Status.OutOfBoard;
                        VisitedPositions[counter].Add(tempPosition);
                        break;
                    }
                }
                counter++;
                Turtle.CurrentPosition = StartPosition;
            }

            PrepareFinishInfo();
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
        /// Checks a corrdinate has mine 
        /// </summary>
        /// <param name="coordinate">coordinate to be checked</param>
        /// <returns>True if the input point is on mine,otherwise false </returns>
        private bool CheckMine(ICoordinate coordinate)
        {
            return Mines.Any(t => t.X == coordinate.X && t.Y == coordinate.Y);
        }

        /// <summary>
        /// Creates an information text about played game
        /// </summary>
        private void PrepareFinishInfo()
        {
            //foreach (var item in VisitedPositions)
            //{
            //    item.Insert(0, StartPosition);
            //}

            StringBuilder stringBuilder = new StringBuilder();

            for (int i = 0; i < ResultList.Count; i++)
            {
                stringBuilder.AppendLine(string.Format("Sequence {0} = {1} ", i, ResultList[i].ToString()));
                stringBuilder.Append("Visited Positions : ");
                VisitedPositions[i].ForEach(item =>
                {
                    stringBuilder.Append(string.Format("[ {0} {1} {2} ]  ", item.Coordinate.X, item.Coordinate.Y, item.Direction.ToString()));
                });

                stringBuilder.Append("\n");

                //stringBuilder.Append("Moves : ");
                //Moves[i].ForEach(item =>
                //{
                //    stringBuilder.Append(string.Format("{0} ", item.ToString()));
                //});

                stringBuilder.AppendLine("\n");
            }
            this.FinishInfo = stringBuilder.ToString();
        }
    }
}
