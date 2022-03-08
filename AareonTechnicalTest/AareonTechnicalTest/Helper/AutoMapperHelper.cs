using AareonTechnicalTest.BL.Models;
using AareonTechnicalTest.Models;
using AutoMapper;

namespace AareonTechnicalTest.Helper
{
	public class AutoMapperHelper
	{
		public static IMapper Mapper { get; set; }
		public static void Configure()
		{
			var config = new MapperConfiguration(cfg =>
			{
				cfg.CreateMap<Ticket, TicketModel>();
				cfg.CreateMap<TicketModel, Ticket>();
			});

			Mapper = new Mapper(config);
		}

		public static TDest Map<TSource, TDest>(TSource source)
		{
			return Mapper.Map<TSource, TDest>(source);
		}
	}
}
