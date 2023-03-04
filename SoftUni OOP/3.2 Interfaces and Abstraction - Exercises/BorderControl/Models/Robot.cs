using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BorderControl
{
    public class Robot : IMachine, IIdentifiable
    {
        public Robot(string model, string id)
        {
            Id = id;
            Model = model;
        }

        public string Model { get; set; }

        public string Id { get; set; }
    }
}
