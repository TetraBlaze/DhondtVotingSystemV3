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

        public VoteProcessor(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath))
                throw new ArgumentException("File path required", nameof(filePath));
            _filePath = filePath;
        }

        #endregion
    }
}
