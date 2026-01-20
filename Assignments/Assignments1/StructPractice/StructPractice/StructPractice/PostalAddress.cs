namespace StructPractice
{
    struct PostalAddress
    {
        private int houseNumber;
        public int HouseNumber
        {
            get { return houseNumber; }
            set { houseNumber = value; }
        }

        public string StreeName { get; set; }
        public string City { get; set; }

        private int zipCode;
        public int ZipCode
        {

            get { return zipCode; }
            set
            {
                try
                {
                    if (value < 0)
                    {
                        throw new ArgumentException("Zip code cannot be negative.");
                    }
                    zipCode = value;
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public PostalAddress(int houseNumber, string streetName, string city, int zipCode)
        {
            this.houseNumber = houseNumber;
            this.StreeName = streetName;
            this.City = city;
            this.zipCode = zipCode;
        }


    }
}
