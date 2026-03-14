namespace FlyweightLazyLoading.Model.Forest
{
    public class Forest
    {
        private readonly List<Tree.Tree> _trees = new();

        public void PlantTree(int x, int y, string name, string color, string texture)
        {
            var type = TreeFactory.GetTreeType(name, color, texture);
            _trees.Add(new Tree.Tree(x, y, type));
        }

        public void Draw()
        {
            foreach (var tree in _trees)
                tree.Draw();
        }
    }

}
