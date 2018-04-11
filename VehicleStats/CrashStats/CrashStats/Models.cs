using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CrashStats
{
    class Models
    {
        //public static async Task<YearRootObject> GetModels(string y){}
    }

    [DataContract]
    public class ModelResult
    {
        [DataMember]
        public int ModelYear { get; set; }
        [DataMember]
        public string Make { get; set; }
        [DataMember]
        public string Model { get; set; }
        [DataMember]
        public int VehicleId { get; set; }
    }

    [DataContract]
    public class ModelRootObject
    {
        [DataMember]
        public int Count { get; set; }
        [DataMember]
        public string Message { get; set; }
        [DataMember]
        public List<ModelResult> Results { get; set; }
    }
}
