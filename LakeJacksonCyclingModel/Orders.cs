using System.ComponentModel.DataAnnotations;

namespace LakeJacksonCyclingModel
{
    public class Orders
    {
        public int orderID {get;set;}
        private string pIName;
        public int productID {get;set;}
        public string pName 
        {
            get {return pIName; }
            set
            {
                if(value != null)
                {
                    pIName = value;
                }
                else
                {
                    throw new ValidationException("Name must be included in product for order!");
                }
            }
        }
        private string address;
        public string pAddress
        {
            get{ return address; }
            set
            {
                if(address != null || address != "")
                {
                    address = value;
                }
                else
                {
                    throw new ValidationException("Store must have an address");
                }
            }
        }
        public double Price {get;set;}
        public int storeid {get;set;}

        private string sName;
        public string storeName 
        {
            get{ return sName; }
            set
            {
                if(value!= null)
                {
                    sName = value;
                }
                else
                {
                    throw new ValidationException("You must have a name");
                }
            }
            
        }

        private string SAddress;
        public string StoreAddress 
        {
            get{return SAddress; }
            set
            {
                if(value != null )
                {
                    SAddress = value;
                }
                else
                {
                    throw new ValidationException("Please add an address for the store");
                }
            }
        }
        public decimal OrderTotal {get;set;}

        private int q;
        public int Quantity 
        {
            get { return q; }
            set
            {
                if(value != 0)
                {
                    q = value;
                }
                else
                {
                    throw new ValidationException("Out-Of-Stock - Sorry");
                }
            }
        }
       
        public List<ItemLines> LineItems{get;set;}

         public override string ToString()
         {
             return $"Order Id: {orderID}" + " " + $" Store ID: {storeid} \nProduct Name: {pName} " +  " " +$" Price: {Price} \n Total Price: {OrderTotal} " + " " + $"Quantity Ordered: {Quantity}\n ";
         }
    }
}