using AutoMapper;

namespace Project.MovieStore.Application.Results
{
    public class ServiceResult<T> : BaseServiceResult where T : class 
    {
        private IMapper _mapper;
        public T? Data { get; set; }

        public ServiceResult<T> Build<E>(E data) where E : class
        {
            var result = new ServiceResult<T>();

            if (_mapper is null)
            {
                var config = new MapperConfiguration(cfg => { cfg.AddMaps(AppDomain.CurrentDomain.GetAssemblies()); });
                _mapper = config.CreateMapper();
            }

            Data = _mapper.Map<T>(data);
            
            return this;
        }

    }
}
