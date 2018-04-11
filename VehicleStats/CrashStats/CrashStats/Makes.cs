using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CrashStats
{
    class Makes
    {
        //public static async Task<YearRootObject> GetMakes(string y){}
    }

    [DataContract]
    public class MakeResult
    {
        [DataMember]
        public int ModelYear { get; set; }
        [DataMember]
        public string Make { get; set; }
        [DataMember]
        public int VehicleId { get; set; }
    }

    [DataContract]
    public class MakeRootObject
    {
        [DataMember]
        public int Count { get; set; }
        [DataMember]
        public string Message { get; set; }
        [DataMember]
        public List<Result> Results { get; set; }
    }
}
