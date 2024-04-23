namespace ProductModel
{
    public class Product
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }
        override
        public string ToString()
        {
            return $"ID:{ID} Name:{Name} DEscription{Description}";
        }
    }
}
