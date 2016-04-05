﻿using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace TestRail.Types
{
    /// <summary>stores information about a plan</summary>
    public class Plan : BaseTestRailType
    {
        #region Public Properties
        /// <summary>id of the plan</summary>
        public ulong ID { get; set; }

        /// <summary>name of the plan</summary>
        public string Name { get; set; }

        /// <summary>description of the plan</summary>
        public string Description { get; set; }

        /// <summary>id of the milestone associated with the plan</summary>
        public ulong? MilestoneID { get; set; }

        /// <summary>The ID of the user who created the test plan</summary>
        public uint CreatedBy { get; set; }

        /// <summary>The date/time when the test plan was created</summary>
        public DateTime CreatedOn { get; set; }

        /// <summary>true if the plan has been completed</summary>
        public bool IsCompleted { get; set; }

        /// <summary>date on which the plan was completed</summary>
        public DateTime? CompletedOn { get; set; }

        /// <summary>number of tests in the plan that passed</summary>
        public uint PassedCount { get; set; }

        /// <summary>number of tests in the plan that are blocked</summary>
        public uint BlockedCount { get; set; }

        /// <summary>number of tests in the plan that are untested</summary>
        public uint UntestedCount { get; set; }

        /// <summary>number of tests in the plan that need to be retested</summary>
        public uint RetestCount { get; set; }

        /// <summary>number of tests in the plan that failed</summary>
        public uint FailedCount { get; set; }

        /// <summary>id of the project associated with the plan</summary>
        public ulong ProjectID { get; set; }

        /// <summary>ID of the user the plan is assigned to</summary>
        public ulong? AssignedToID { get; set; }

        /// <summary>url to view the results of the plan</summary>
        public string Url { get; set; }

        /// <summary>Custom Status 1 Count</summary>
        public ulong CustomStatus1Count { get; set; }

        /// <summary>Custom Status 2 Count</summary>
        public ulong CustomStatus2Count { get; set; }

        /// <summary>Custom Status 3 Count></summary>
        public ulong CustomStatus3Count { get; set; }

        /// <summary>Custom Status 4 Count</summary>
        public ulong CustomStatus4Count { get; set; }

        /// <summary>Custom Status 5 Count</summary>
        public ulong CustomStatus5Count { get; set; }

        /// <summary>Custom Status 6 Count</summary>
        public ulong CustomStatus6Count { get; set; }

        /// <summary>Custom Status 7 Count</summary>
        public ulong CustomStatus7Count { get; set; }

        public List<PlanEntry> Entries { get; set; }
        #endregion Public Properties

        #region Public Methods
        /// <summary>string representation of the object</summary>
        /// <returns>string representation of the object</returns>
        public override string ToString()
        {
            return Name;
        }

        /// <summary>parses json into a plan</summary>
        /// <param name="json">json to parse</param>
        /// <returns>plan corresponding to the json</returns>
        public static Plan Parse(JObject json)
        {
            var p = new Plan
            {
                JsonFromResponse = json,
                ID = (ulong) json["id"],
                Name = (string) json["name"],
                Description = (string) json["description"],
                MilestoneID = (ulong?) json["milestone_id"],
                CreatedBy = (uint) json["created_by"],
                CreatedOn = new DateTime(1970, 1, 1).AddSeconds((int) json["created_on"]),
                IsCompleted = (bool) json["is_completed"],
                CompletedOn = (null == (int?) json["completed_on"]) ? (DateTime?) null : new DateTime(1970, 1, 1).AddSeconds((int) json["completed_on"]),
                PassedCount = (uint) json["passed_count"],
                BlockedCount = (uint) json["blocked_count"],
                UntestedCount = (uint) json["untested_count"],
                RetestCount = (uint) json["retest_count"],
                FailedCount = (uint) json["failed_count"],
                ProjectID = (ulong) json["project_id"],
                AssignedToID = (ulong?) json["assignedto_id"],
                Url = (string) json["url"],
                CustomStatus1Count = (ulong) json["custom_status1_count"],
                CustomStatus2Count = (ulong) json["custom_status2_count"],
                CustomStatus3Count = (ulong) json["custom_status3_count"],
                CustomStatus4Count = (ulong) json["custom_status4_count"],
                CustomStatus5Count = (ulong) json["custom_status5_count"],
                CustomStatus6Count = (ulong) json["custom_status6_count"],
                CustomStatus7Count = (ulong) json["custom_status7_count"],
            };

            var jarray = json["entries"] as JArray;
            if (null != jarray)
            {
                p.Entries = JsonUtility.ConvertJArrayToList<PlanEntry>(jarray, PlanEntry.Parse);
            }

            return p;
        }

        /// <summary>Get the json object that describes this object</summary>
        /// <returns>the json object</returns>
        public JObject GetJson()
        {
            dynamic jsonParams = new JObject();
            if (!string.IsNullOrWhiteSpace(Name)) { jsonParams.name = Name; }
            if (!string.IsNullOrWhiteSpace(Description)) { jsonParams.description = Description; }
            if (null != MilestoneID) { jsonParams.milestone_id = MilestoneID; }
            if (null != Entries && 0 < Entries.Count)
            {
                JArray jarray = new JArray();
                foreach (PlanEntry pe in Entries)
                {
                    if (null != pe)
                    {
                        jarray.Add(pe.GetJson());
                    }
                }
                jsonParams.entries = jarray;
            }

            return jsonParams;
        }
        #endregion Public Methods
    }
}
