﻿using Explorer.BuildingBlocks.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Tours.Core.Domain
{
    public class TourExecutionSession : Entity
    {
        public TourExecutionSessionStatus Status { get; private set; }
        public long TourId { get; init; }
        public long TouristId { get; init; }
        public long NextKeyPointId { get; private set; }
        public double Progress { get; private set; }
        public DateTime LastActivity { get; private set; }
        public TourExecutionSession(long tourId, long touristId, long nextKeyPointId) 
        {
            Status = TourExecutionSessionStatus.Started;
            LastActivity = DateTime.UtcNow;
            TourId = tourId;
            TouristId = touristId;
            NextKeyPointId = nextKeyPointId;
            Progress = 0;
        }
        public void Abandon()
        {
            LastActivity = DateTime.UtcNow;
            Status = TourExecutionSessionStatus.Abandoned;
        }
        public void Complete()
        {
            LastActivity = DateTime.UtcNow;
            Status = TourExecutionSessionStatus.Completed;
            Progress = 100;
            NextKeyPointId = -1;
        }
        public void SetNextKeyPointId(long keyPointId)
        {
            LastActivity = DateTime.UtcNow;
            NextKeyPointId = keyPointId;
        }

        public void UpdateProgress(double progress)
        {
            if (progress > Progress) Progress = progress;
        }
    }

    public enum TourExecutionSessionStatus
    {
        Started,
        Abandoned,
        Completed
    }
}