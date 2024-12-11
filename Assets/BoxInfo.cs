using UnityEngine;

public class BoxInfo : MonoBehaviour
{
    public string productID;          // Unique ID of the product (medicine name)
    public string manufacturingDate;  // Manufacturing date
    public string expiryDate;         // Expiry date
    public string location;           // Location of the box in the warehouse
    public float randomTemperature;   // Random temperature value for the box

    // List of medicine names to assign as product IDs
    private string[] medicineNames = new string[]
    {
        "Crocin", "Dolo 650", "Brufen", "Mox", "Taxim-O", 
        "Nise", "Amlogard", "Glyciphage", "Pantocid", 
        "Cetzine", "Calcirol", "Becosules"
    };

    void Start()
    {
        // Assign a random medicine name as productID
        productID = medicineNames[Random.Range(0, medicineNames.Length)];

        // Assign a random manufacturing date
        manufacturingDate = GenerateRandomDate("2024-01-01", "2024-12-30");

        // Assign a random expiry date (at least 6 months later than manufacturing date)
        expiryDate = GenerateExpiryDate(manufacturingDate);

        // Assign a random location in the warehouse (random coordinates)
        location = $"Row-{Random.Range(1, 10)}, Column-{Random.Range(1, 10)}, Shelf-{Random.Range(1, 5)}";

        // Assign a random temperature for this box
        randomTemperature = Random.Range(15f, 25f); // Temperature range between 15°C and 25°C
    }

    // Generate a random date between two dates
    private string GenerateRandomDate(string startDate, string endDate)
    {
        System.DateTime start = System.DateTime.Parse(startDate);
        System.DateTime end = System.DateTime.Parse(endDate);

        // Get a random time span between the start and end dates
        System.TimeSpan randomSpan = new System.TimeSpan(Random.Range(0, (int)(end - start).TotalDays), 0, 0, 0);
        return start.Add(randomSpan).ToString("yyyy-MM-dd"); // Return the date in "YYYY-MM-DD" format
    }

    // Generate an expiry date (at least 6 months after manufacturing date)
    private string GenerateExpiryDate(string manufacturingDate)
    {
        System.DateTime manuDate = System.DateTime.Parse(manufacturingDate);

        // Add a random number of days to ensure expiry is at least 6 months later
        int minDays = 180; // Minimum 6 months
        int maxDays = 720; // Maximum 2 years
        return manuDate.AddDays(Random.Range(minDays, maxDays)).ToString("yyyy-MM-dd");
    }
}
