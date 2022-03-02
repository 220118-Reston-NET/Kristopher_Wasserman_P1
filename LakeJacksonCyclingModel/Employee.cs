using System.ComponentModel.DataAnnotations;

namespace LakeJacksonCyclingModel
{
    public class Employee
    {
        public int employeeID {get;set;}

        private string eName;
        public string Name
        {
            get{ return eName; }
            set
            {
                if(value != null)
                {
                    eName = value;
                }
                else
                {
                    throw new ValidationException("You must have a name");
                }
            } 
        }
        private string _dname;
        public string Department
        {
            get {return _dname; }
            set
            {
                if(value != " " && value != null)
                {
                    _dname = value;
                }
                else
                {
                    throw new ValidationException(" Enter a name for the item");

                }
            }
        }
 
        public string password{get;set;} 

        public bool isEmployee {get;set;}
        public bool IsAdmin {get;set;}
    }
}