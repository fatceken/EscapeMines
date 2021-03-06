﻿using EscapeMines.Business.Enums;
using EscapeMines.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscapeMines.Business.Interfaces
{
    /// <summary>
    /// Represents the game
    /// </summary>
    public interface IGame
    {
        /// <summary>
        /// Runs the game
        /// </summary>
        GameResult Run();
    }
}
