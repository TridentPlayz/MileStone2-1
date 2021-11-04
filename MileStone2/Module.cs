using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MileStone2
{
    class Module:Student
    {
        string ModuleName;

        public Module(int StudentID, string Name, string Surname, int DateOfBirth, string Gender, int Phone, int Address, int Fees, double Payment, string ModuleCode) : base(StudentID, Name, Surname, DateOfBirth, Gender, Phone, Address, Fees, Payment, ModuleCode)
        {

        }
    }
}
