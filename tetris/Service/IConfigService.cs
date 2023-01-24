using tetris.Models;

namespace tetris.Service
{
    public interface IConfigService
    {
        public List<Shape> GetShapes();
        public void SaveCfg(List<Shape> config);
    }
}
