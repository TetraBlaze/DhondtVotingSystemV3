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
        #region members

        private int _totalVotes;

        #endregion

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
        public int TotalVotes
        {
            get => SeatIds.Count != 0 ? _totalVotes : 0;
            set => _totalVotes = value;
        }

        /// <summary>
        /// List of seat Ids
        /// </summary>
        public IList<string> SeatIds { get; } = new List<string>();

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

        /// <summary>
        /// Take next seat from list and half the vote count.
        /// </summary>
        /// <returns>Next seat from the list</returns>
        public string TakeNextSeat()
        {
            if (SeatIds.Count == 0)
                throw new InvalidOperationException("No seats left");
            TotalVotes /= 2;
            //TODO: may be better to use a Queue<> for the list of seats? 
            var seat = SeatIds[0];
            SeatIds.RemoveAt(0);
            return seat;
        }

        #endregion
    }
}
