using EscapeMines.Business.Core.Configuration.Interfaces;
using EscapeMines.Business.Enums;
using EscapeMines.Business.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscapeMines.Business.Core.Configuration
{
    /// <summary>
    /// Holds information about game moves configuration
    /// </summary>
    public class MoveConfiguration : IMoveConfiguration
    {
        private IEnumerable<string> Configuration = null;

        public List<List<MoveType>> GetMoves()
        {
            List<List<MoveType>> result = new List<List<MoveType>>();

            if (Configuration == null)
            {
                throw new ArgumentNullException("configuration");
            }

            List<MoveType> resultListItem = null;

            foreach (string move in Configuration)
            {
                if (String.IsNullOrEmpty(move))
                {
                    continue;
                }

                List<string> splittedMoves = move.Trim().Split(Constants.Space).ToList();
                resultListItem = new List<MoveType>();

                foreach (string splittedMove in splittedMoves)
                {
                    if (string.IsNullOrEmpty(splittedMove))
                    {
                        continue;
                    }

                    MoveType moveType = Conversion.GetMoveType(splittedMove.Trim());

                    if (moveType == MoveType.Undefined)
                    {
                        throw new FormatException(string.Format("move type : {0} is invalid. Check configuration file. Valid move must be one of (R,M,L).", splittedMove));
                    }

                    resultListItem.Add(moveType);
                }
                result.Add(resultListItem);
                resultListItem = null;
            }
            return result;
        }

        public MoveConfiguration(IEnumerable<string> configuration)
        {
            this.Configuration = configuration;
        }
    }
}
