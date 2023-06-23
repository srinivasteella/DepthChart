using DepthChart.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace DepthChart.Service
{
    public interface IPositionConverter
    {
        Position Convert(AddPlayer sportObj);

    }

    public class PositionConverter : IPositionConverter
    {
        Dictionary<PositionType, Func<AddPlayer, Position>> dict = new Dictionary<PositionType, Func<AddPlayer, Position>>();
        public PositionConverter()
        {
            dict.Add(PositionType.LWR, GetPosition<LWR>);
            dict.Add(PositionType.RWR, GetPosition<RWR>);
            dict.Add(PositionType.RB, GetPosition<RB>);

        }
        public Position Convert(AddPlayer sportObj)
        {
            return dict[sportObj.position.PositionType].Invoke(sportObj);
        }

        T GetPosition<T>(AddPlayer sportObj)
        {
            return JsonConvert.DeserializeObject<T>(JsonConvert.SerializeObject(sportObj.position));
        }
       
    }
}
