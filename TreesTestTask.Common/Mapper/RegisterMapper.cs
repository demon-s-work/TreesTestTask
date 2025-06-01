using Mapster;
using TreesTestTask.Core.Contracts.Models;
using TreesTestTask.Dal.Contracts.Entities;
using TreesTestTask.Dal.Contracts.Models;

namespace TreesTestTask.Common.Mapper
{
	public class RegisterMapper : IRegister
	{
		public void Register(TypeAdapterConfig config)
		{
			config.RequireDestinationMemberSource = true;
			config.NewConfig<JournalRecord, JournalRecordDto>();
			config.NewConfig<Node, NodeDto>();
			config.NewConfig<NodeDto, Node>()
			      .Ignore(n => n.Parent!);
			config.NewConfig<JournalRecordDto, JournalEntryResponseModel>();
			config.NewConfig<NodeDto, GetOrCreateTreeResponseModel>();
			config.NewConfig<JournalRecord, JournalRecordInfoModel>();
		}
	}
}