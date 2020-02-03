using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASM2_Code
{
    public class Lecturer
    {
        public string lecId { get; set; }
        public string lecName { get; set; }
        public string lecDob { get; set; }
        public string lecEmail { get; set; }
        public string lecAddress { get; set; }
        public string lecDept { get; set; }
        public override string ToString()


        {
            return lecId + "#" + lecName + "#" + lecDob + "#" + lecEmail + "#" + lecAddress + "#" + lecDept;
        }
    }
}
