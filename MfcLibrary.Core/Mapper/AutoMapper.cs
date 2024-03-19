using AutoMapper;

namespace MfcLibrary.Core.Mapper
{
    /// <summary>
    /// AutoMapper 
    /// 
    /// If you want to use Auto Mapper in the future, it can be quickly adapted using the methods here.
    /// 
    /// </summary>
    public class AutoMapper : Profile
    {

        private readonly MapperConfiguration configuration;

        /// <summary>
        /// Mapping with AutoMapper
        /// </summary>
        public AutoMapper()
        {
            // Sample using
            // CreateMap<Book, BookSelectDto>().ReverseMap();

            configuration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(this);
            });

        }

        /// <summary>
        /// AutoMapper base.
        /// </summary>
        /// <typeparam name="TOutput"></typeparam>
        /// <typeparam name="TInput"></typeparam>
        /// <param name="input"></param>
        /// <returns></returns>
        public TOutput Map<TOutput, TInput>(TInput input)

            where TInput : class, new()
            where TOutput : class, new()

        {
            IMapper mapper = configuration.CreateMapper();

            try
            {
                return mapper.Map<TOutput>(input);
            }
            catch (Exception)
            {
                return null;
            }
        }

    }
}
