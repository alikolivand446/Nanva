using Nanva.Model.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MM = Nanva.Model.Models;

namespace Nanva.Function
{
    public class AgentRequest
    {
        public int Id { get; set; }

        [Display(Name="کارشناس")]
        public int? AgentId { get; set; }

        [Display(Name = "درخواست")]
        public int? RequestId { get; set; }
    }
    public partial class Mapper
    {
        public static AgentRequest Map(MM.AgentRequest entity)
        {
            return new AgentRequest()
            {
                Id = entity.Id,
                RequestId = entity.RequestId,
                AgentId = entity.AgentId,
            };
        }
        public static MM.AgentRequest Map(AgentRequest entity)
        {
            return new MM.AgentRequest()
            {
                Id = entity.Id,
                RequestId = entity.RequestId,
                AgentId = entity.AgentId,
            };
        }
        public static IEnumerable<AgentRequest> Map(IEnumerable<MM.AgentRequest> entity)
        {
            var ListResult = new List<AgentRequest>();
            foreach (var Itemlist in entity)
            {
                ListResult.Add(Map(Itemlist));
            }
            return ListResult;
        }
    }
}
