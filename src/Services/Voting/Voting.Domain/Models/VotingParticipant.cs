using System;

namespace Voting.Domain.Models
{
    public class VotingParticipant
    {
        public int Id { get; set; }
        public int VotingId { get; set; }
        public string Name { get; set; }
        public Uri PictureUrl { get; set; }
        public int VotesQuantity { get; set; }
        public int VotesPercentage { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
