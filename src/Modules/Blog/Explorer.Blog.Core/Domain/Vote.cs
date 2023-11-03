﻿using Explorer.BuildingBlocks.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Explorer.Blog.Core.Domain
{
    public enum VoteType { DOWNVOTE, UPVOTE }
    public class Vote : ValueObject
    {
        public long UserId { get; init; }
        public VoteType VoteType { get; private set; }

        [JsonConstructor]
        public Vote(long userId, VoteType voteType)
        {
            UserId = userId;
            VoteType = voteType;
        }

        public void SetToVoteType(VoteType voteType)
        {
            VoteType = voteType;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return UserId;
        }
    }
}
