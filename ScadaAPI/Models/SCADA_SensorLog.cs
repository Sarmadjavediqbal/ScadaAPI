using MessagePack;
using System.ComponentModel.DataAnnotations.Schema;

namespace ScadaAPI.Models
{
    public class SCADA_SensorLog
    {
        [Column("SensorLogID")]
        public int SensorLogID { get; internal set; }

        public int SensorID { get; set; }

        public decimal SensorData { get; set; }

        public DateTime SensorTime { get; internal set; }
        /*

        public DateTime AddedStamp;

        public string AddedByNetworkID;

        public DateTime LastUsedStamp;

        public string LastUsedByNetworkID;

        public DateTime ModifiedStamp;

        public string ModifiedByNetworkID;*/
        private IEnumerable<int> enumerable1;
        private IEnumerable<decimal> enumerable2;

        public SCADA_SensorLog(int sensorID, decimal sensorData)
        {
            List<SCADA_SensorLog> SensorLogs = new List<SCADA_SensorLog>();

            foreach (var log in SensorLogs)
            {
                SensorLogs.Select(x => new
                {
                    A = log.SensorID = sensorID,
                    B = log.SensorData = sensorData,
                });
            }
        }

        public SCADA_SensorLog()
        {
        }

        public SCADA_SensorLog(IEnumerable<int> enumerable1, IEnumerable<decimal> enumerable2)
        {
            this.enumerable1 = enumerable1;
            this.enumerable2 = enumerable2;
        }
    }
}
