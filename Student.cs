using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASM2_Code
{
    public class Student
    {
        public string stdId { get; set; }
        public string stdName { get; set; }
        public string stdDateofbirth { get; set; }
        public string stdEmail { get; set; }
        public string stdAddress { get; set; }
        public string stdClassbatch { get; set; }
        public override string ToString()
        {
            return stdId + "#" + stdName + "#" + stdDateofbirth + "#" + stdEmail + "#" + stdAddress + "#" + stdClassbatch;
        }

    }
}
