using DepthChart.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace DepthChart.Service
{
    public interface ISportConverter
    {
        SportType Convert(string sportType);

    }

    public class SportConverter : ISportConverter
    {
        Dictionary<SportType, Func<Sport>> dict = new Dictionary<SportType, Func<Sport>>();
        public SportConverter()
        {
            dict.Add(SportType.NFL, GetNFL);
        }
        public SportType Convert(string sportType)
        {
            SportType enumName;
            Enum.TryParse(sportType.ToString(), true, out enumName);
            return enumName;
        }

        NFL GetNFL()
        {
            return JsonConvert.DeserializeObject<NFL>(File.ReadAllText("NFLDepthChart.json"));
        }
       
    }
}
