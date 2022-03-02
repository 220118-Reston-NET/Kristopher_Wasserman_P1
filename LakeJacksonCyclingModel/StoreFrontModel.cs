using System.ComponentModel.DataAnnotations;

namespace LakeJacksonCyclingModel
{
    public class StoreFrontModel
    {
      
        public int storeId {get;set;}
        private string sName;
        public string StoreName 
        {
            get{ return sName; }
            set
            {
                if(value != null || value != " ")
                {
                    sName = value;
                }
                else
                {
                    throw new ValidationException("Please provide a store namea");
                }
            }
        }
        public string Address {get;set;}
        public string Phone {get;set;}
        
        public override string ToString()
        {
            return $"ID: {storeId}\n Name: {StoreName}";
        }
    }
    
}