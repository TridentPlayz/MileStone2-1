using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;
using MileStone2;

namespace MileStone2
{
    class Module : Student
    {
        string ModuleName;

        public Module(string moduleName)
        {
            ModuleName = moduleName;
        }

        public Module(int StudentID, string Name, string Surname, int DateOfBirth, string Gender, int Phone, int Address, int Fees, double Payment, string ModuleCode) : base(StudentID, Name, Surname, DateOfBirth, Gender, Phone, Address, Fees, Payment, ModuleCode)
        {

        }

        public override double CalculatePayment()
        {
            throw new NotImplementedException();
        }
    }
}
class mod
{
    int age;
    int petID;
    string name;
    string petType;

    public mod() { }

    public mod(int age, int petID, string name, string petType)
    {
        this.Age = age;
        this.PetID = petID;
        this.Name = name;
        this.PetType = petType;
    }

    public int Age { get => age; set => age = value; }
    public int PetID { get => petID; set => petID = value; }
    public string Name { get => name; set => name = value; }
    public string PetType { get => petType; set => petType = value; }

    public List<mod> GetPets(int number)
    {
        List<mod> myPets = new List<mod>();
        try
        {
            DataHandler dh = new DataHandler();
            foreach (DataRow item in dh.ReadUserPet(number).Rows)
            {
                mod p = new mod(Convert.ToInt32(item[3].ToString()), Convert.ToInt32(item[0].ToString()), item[1].ToString(), item[2].ToString());
                myPets.Add(p);
            }
            return myPets;
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
            return myPets;

        }
    }
}

