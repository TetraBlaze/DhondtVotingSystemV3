using System;
using System.Collections.Generic;
using System.Text;

namespace dhondt_panic
{
    /// <summary>
    /// Vote data for a party
    /// </summary>
    public class PartyVotes
    {
        #region Constructor

        /// <summary>
        /// Creates a new instance of <see cref="PartyVotes"/>
        /// </summary>
        /// <param name="name">party name</param>
        /// <param name="votes">total number of votes for party</param>
        public PartyVotes(string name, int votes)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Party name is required", nameof(name));
            Name = name;
            TotalVotes = votes;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Name of the party
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Total number of votes for the party
        /// </summary>
        public int TotalVotes { get; private set; }

        /// <summary>
        /// List of seat Ids
        /// </summary>
        public IList<string> SeatIds => new List<string>();

        #endregion

        #region Methods
        /// <summary>
        /// Add seat ID to <see cref="PartyVotes"/>
        /// </summary>
        /// <param name="id">seat ID</param>
        public void AddSeatId(string id)
        {
            SeatIds.Add(id);
        }

        #endregion
    }
}
