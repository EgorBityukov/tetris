using Microsoft.Extensions.Options;
using System.Text.Json;
using tetris.Models;

namespace tetris.Service
{
    public class ConfigService : IConfigService
    {
        public IOptions<Config> _cfg { get; set; }

        public ConfigService(IOptions<Config> cfg)
        {
            _cfg = cfg;
        }

        public List<Shape> GetShapes()
        {
            return _cfg.Value.shapes;
        }

        public void SaveCfg(List<Shape> list)
        {
            _cfg.Value.shapes = list;

            using (FileStream fs = new FileStream("figures.json", FileMode.OpenOrCreate))
            {
                JsonSerializer.Serialize<Config>(fs, _cfg.Value);
            }
        }
    }
}
