namespace AutoMapperGenericBidirectionalAdapter.Abstraction
{
    public interface IBidirectionalAdapter<TSource, TTarget>
    {
        TTarget ToTarget(
            TSource source,
            Action<TSource, TTarget>? custom = null);

        TSource ToSource(
            TTarget target,
            Action<TSource, TTarget>? custom = null);

        IEnumerable<TTarget> ToTargetCollection(
            IEnumerable<TSource> source,
            Action<TSource, TTarget>? custom = null);

        IEnumerable<TSource> ToSourceCollection(
            IEnumerable<TTarget> target,
            Action<TSource, TTarget>? custom = null);
    }

}
