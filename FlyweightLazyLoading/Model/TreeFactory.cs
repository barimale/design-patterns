using FlyweightLazyLoading.Model.Forest.Tree;

namespace FlyweightLazyLoading.Model
{
    public class TreeFactory
    {
        private static readonly Dictionary<string, Lazy<TreeType>> _cache = new();

        public static TreeType GetTreeType(string name, string color, string texture)
        {
            string key = $"{name}_{color}_{texture}";

            if (!_cache.ContainsKey(key))
            {
                _cache[key] = new Lazy<TreeType>(() =>
                {
                    Console.WriteLine($"[LAZY] Tworzę pyłek dopiero teraz: {key}");
                    return new TreeType(name, color, texture);
                });
            }

            return _cache[key].Value; // inicjalizacja dopiero tutaj
        }
    }

}
