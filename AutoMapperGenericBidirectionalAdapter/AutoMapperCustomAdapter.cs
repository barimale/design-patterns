using AutoMapper;
using AutoMapper.QueryableExtensions;
using AutoMapperGenericBidirectionalAdapter.Abstraction;

namespace AutoMapperGenericBidirectionalAdapter
{

    public class AutoMapperCustomAdapter<TSource, TTarget>
        : IBidirectionalAdapter<TSource, TTarget>
    {
        private readonly IMapper _mapper;
        private readonly IConfigurationProvider _config;

        public AutoMapperCustomAdapter(IMapper mapper)
        {
            _mapper = mapper;
            _config = mapper.ConfigurationProvider;
        }

        public TTarget ToTarget(TSource source, Action<TTarget>? custom = null)
        {
            var result = _mapper.Map<TTarget>(source);
            custom?.Invoke(result);
            return result;
        }

        public TSource ToSource(TTarget target, Action<TSource>? custom = null)
        {
            var result = _mapper.Map<TSource>(target);
            custom?.Invoke(result);
            return result;
        }

        public IEnumerable<TTarget> ToTargetCollection(IEnumerable<TSource> source, Action<TTarget>? custom = null)
        {
            foreach (var item in source)
            {
                var mapped = _mapper.Map<TTarget>(item);
                custom?.Invoke(mapped);
                yield return mapped;
            }
        }

        public IEnumerable<TSource> ToSourceCollection(IEnumerable<TTarget> target, Action<TSource>? custom = null)
        {
            foreach (var item in target)
            {
                var mapped = _mapper.Map<TSource>(item);
                custom?.Invoke(mapped);
                yield return mapped;
            }
        }

        public IQueryable<TTarget> ToTargetQueryable(IQueryable<TSource> source)
            => source.ProjectTo<TTarget>(_config);

        public IQueryable<TSource> ToSourceQueryable(IQueryable<TTarget> target)
            => target.ProjectTo<TSource>(_config);
    }

}
