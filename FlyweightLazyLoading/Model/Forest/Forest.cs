using FlyweightLazyLoading.Model;
using FlyweightLazyLoading.Model.Trees;
using System;
using System.Collections.Generic;
using System.Text;

namespace FlyweightLazyLoading.Model.Forest
{
    public class Forest
    {
        private readonly List<Tree> _trees = new();

        public void PlantTree(int x, int y, string name, string color, string texture)
        {
            var type = TreeFactory.GetTreeType(name, color, texture);
            _trees.Add(new Tree(x, y, type));
        }

        public void Draw()
        {
            foreach (var tree in _trees)
                tree.Draw();
        }
    }

}
