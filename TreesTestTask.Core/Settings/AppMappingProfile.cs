using AutoMapper;
using TreesTestTask.Core.Contracts.Models;
using TreesTestTask.Dal.Contracts.Entities;
using TreesTestTask.Dal.Contracts.Models;

namespace TreesTestTask.Settings
{
	public class AppMappingProfile : Profile
	{
		public AppMappingProfile()
		{
			CreateMap<JournalRecord, JournalRecordDto>().ReverseMap();
			CreateMap<Node, NodeDto>().ReverseMap();
			CreateMap<JournalRecord, JournalEntryResponseModel>()
				.ForMember(m => m.CreatedAt, mo => mo.MapFrom(map => map.Timestamp));
		}
	}
}