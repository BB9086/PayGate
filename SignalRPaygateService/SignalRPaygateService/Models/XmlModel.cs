using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRPaygateService.Models
{
    public class XmlModel
    {
        public string PAY_REQUEST_ID { get; set; }
        public string TRANSACTION_STATUS { get; set; }
        public string CHECKSUM { get; set; }
    }
}
