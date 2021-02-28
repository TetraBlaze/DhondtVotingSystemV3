using System;
using System.Collections.Generic;
using System.Text;

namespace dhondt_panic
{
    /// <summary>
    /// vote processing engine
    /// </summary>
    public class VoteProcessor
    {
        #region MemberData

        private string _filePath;

        #endregion

        #region Constructor

        /// <summary>
        /// Create new instance of Vote Processor
        /// </summary>
        /// <param name="filePath">path of file to process</param>
        public VoteProcessor(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath))
                throw new ArgumentException("File path required", nameof(filePath));
            _filePath = filePath;
        }

        #endregion

        #region Methods
        /// <summary>
        /// Load file into memory
        /// </summary>
        /// <returns><c>true</c> if file loaded ok; <c>false</c> if load failed.</returns>
        public bool LoadFile()
        {
            return false;
        }

        #endregion
    }
}
