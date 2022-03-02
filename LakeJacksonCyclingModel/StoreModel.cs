using System.ComponentModel.DataAnnotations;

namespace LakeJacksonCyclingModel
{
    public class StoreModel
    {
        public int storeid {get;set;}

        private string sName;
        public string  StoreName
        {
            get{ return sName; }
                set
                {
                    if(value != null)
                    {
                        sName = value;
                    }
                    else
                    {
                        throw new ValidationException("Please provide a store namea");
                    }
                }
        }
       
        public string StoreAddress{get;set;}
        
        private string sPhone;
        public string Phone 
        {get
            { return sPhone; }
            set
            {
                if(value != null)
                {
                    sPhone = value;
                }
                else
                {
                    throw new ValidationException("Please provide a store Phone Number");
                }
            }
        }

        private string productName;
        public string pName {
            get{ return productName; }
            set
            {
                if(value != null)
                {
                    productName = value;
                }
                else
                {
                    throw new ValidationException("Please provide a product name");
                }
            }
        }
        public int orderid {get;set;}
        public int productid {get;set;}

        public decimal orderTotal{get;set;}


        public override string ToString(){
            return $"Orderid: {orderid}" + " " + $"Product Name: {pName} " + " " + $"Product ID: {productid}" + "" + $"Orders Total: {orderTotal}";
        }
    }
    
    
}