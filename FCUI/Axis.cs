using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCUI
{
    public class Axis
    {
        [DisplayName("id")]
        public int Id { get; set; }

        [DisplayName("AxisId")]
        public int AxisId { get; set; }

        [DisplayName("AxisName")]
        public string AxisName { get; set; }

        [DisplayName("ValueFormat")]
        public string ValueFormat { get; set; }
       
        //Axis Value
        [DisplayName("ReadPLCKey")]
        public string ReadPLCKey { get; set; }

        //Calibration
        [DisplayName("CalibPLCKey")]
        public string CalibPLCKey { get; set; }

        [DisplayName("ActiveCalibPLCKey")]
        public string ActiveCalibPLCKey { get; set; }

        [DisplayName("ActiveCalibPLCKeyType")]
        public string ActiveCalibPLCKeyType { get; set; }

        //Jog
        [DisplayName("SelectPLCKey")]
        public string SelectPLCKey { get; set; }

        [DisplayName("PlusActionPLCKey")]
        public string PlusActionPLCKey { get; set; }

        [DisplayName("MinusActionPLCKey")]
        public string MinusActionPLCKey { get; set; }

        [DisplayName("SpeedPLCKey")]
        public string SpeedPLCKey { get; set; }
    }
}
