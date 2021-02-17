using System;
using System.Collections.Generic;

namespace Voting.Domain.Models
{
    public class Voting
    {
        public int Id { get; }
        public string Title { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int VotesQuantity { get; set; }
        public VotingStatus Status { get; set; }
        public List<VotingParticipant> Participants { get; set; }
    }
}
