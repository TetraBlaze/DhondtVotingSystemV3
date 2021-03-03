using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace dhondt_panic
{
    /// <summary>
    /// vote processing engine
    /// </summary>
    public class VoteProcessor
    {
        #region MemberData

        private string _filePath;
        private IList<PartyVotes> _partyList = new List<PartyVotes>();

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

        #region properties

        /// <summary>
        /// Title of the file
        /// </summary>
        public string FileTitle { get; private set; }

        /// <summary>
        /// Number of seats
        /// </summary>
        public int NumberOfSeats { get; private set; }

        /// <summary>
        /// Total number of votes for all parties
        /// </summary>
        public int TotalVotes { get; private set; }

        #endregion

        #region Methods
        /// <summary>
        /// Load file into memory
        /// </summary>
        /// <returns><c>true</c> if file loaded ok; <c>false</c> if load failed.</returns>
        public void LoadData()
        {
            if (!File.Exists(_filePath))
            {
                throw new InvalidOperationException($"File not found: {_filePath}");
            }

            using var fileStream = new StreamReader(_filePath);

            if ((FileTitle = fileStream.ReadLine()) == null)
            {
                throw new InvalidOperationException("File missing title record(line 1)");
            }

            if (!int.TryParse(fileStream.ReadLine(), out var count))
            {
                throw new InvalidOperationException("Invalid number of seats(line 2)");
            }
            NumberOfSeats = count;

            if (!int.TryParse(fileStream.ReadLine(), out count))
            {
                throw new InvalidOperationException("Invalid number of votes(line 3)");
            }
            TotalVotes = count;


            var lineNumber = 4;
            for (var line = fileStream.ReadLine(); line != null; line = fileStream.ReadLine(), lineNumber++)
            {
                // check line ends with semicolon
                if (!line.EndsWith(";"))
                {
                    throw new InvalidOperationException($"Invalid line format(line{lineNumber})(missing semicolon)");
                }
                line = line.Substring(0, line.Length - 1);

                // break line up into parts
                var parts = line.Split(",".ToCharArray());
                if (parts.Length < 3)
                {
                    throw new InvalidOperationException($"Line {lineNumber} has less than 3 fields");
                }

                if (!int.TryParse(parts[1], out var voteCount))
                    throw new InvalidOperationException($"Invalid vote count on line {lineNumber}");
                var partyVotes = new PartyVotes(parts[0], voteCount);
                for (int i = 2; i < parts.Length; i++)
                {
                    partyVotes.AddSeatId(parts[i]);
                }
                _partyList.Add(partyVotes);
            }

            // check vote total matches file header 
            var totalPartyVotes = _partyList.Sum(p => p.TotalVotes);
            if (TotalVotes != totalPartyVotes)
            {
                throw new InvalidOperationException($"Total votes in header ({TotalVotes}) does not match total of party votes({totalPartyVotes})");
            }

        }

        #endregion
    }
}

