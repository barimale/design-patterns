namespace AutoMapperGenericBidirectionalAdapter.Abstraction
{
    public interface IBidirectionalAdapter<TSource, TTarget>
    {
        TTarget ToTarget(
            TSource source,
            Action<TTarget>? custom = null);

        TSource ToSource(
            TTarget target,
            Action<TSource>? custom = null);

        IEnumerable<TTarget> ToTargetCollection(
            IEnumerable<TSource> source,
            Action<TTarget>? custom = null);

        IEnumerable<TSource> ToSourceCollection(
            IEnumerable<TTarget> target,
            Action<TSource>? custom = null);

        IQueryable<TTarget> ToTargetQueryable(IQueryable<TSource> source);
        IQueryable<TSource> ToSourceQueryable(IQueryable<TTarget> target);
    }

}
