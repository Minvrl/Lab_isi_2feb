using labisi;
using System.Data;
using System.Xml;

List<Product> products = new List<Product>();

Product pr1= new Product("milk",24.5,24,new DateTime(2024,02,05));
Product pr2 = new Product("mushrooms", 16.4,16, new DateTime(2023, 02, 05));
Product pr3 = new Product("instant coffee", 0.5,0.2, new DateTime(2025, 07, 12));
Product pr4 = new Product("pepper", 2,1, new DateTime(2023, 06, 12));
Product pr5 = new Product("apple juice", 19.99,14, new DateTime(2024, 02, 27));

Store store = new Store();
store.Products = products;
products.Add(pr1);
products.Add(pr2);
products.Add(pr3);
products.Add(pr4);
products.Add(pr5);

double profits = store.TotalProfits(products);
Console.WriteLine($"Total profits - {profits}");
var prdcts = store.ApplyDiscount(products);
ShowAll(prdcts);
profits = store.TotalProfits(products);
Console.WriteLine($"Profits after discount - {profits}");




//Console.WriteLine("Expired products;");
//var pastExpireDate = products.FindAll(x => x.ExpireDate.Date < DateTime.Now);
//ShowAll(pastExpireDate);

//Console.WriteLine("\nPrice bigger than 10,left 1 month to expire;");
//var currentDate = DateTime.Now;
//var afterOneMonth = currentDate.AddMonths(1);
//var resultProducts = products.FindAll(x => x.Price > 10 && x.ExpireDate > currentDate && x.ExpireDate <= afterOneMonth) ;
//ShowAll(resultProducts);

//Console.WriteLine("\n Products with A in their names;");
//var aProducts = products.FindAll(x=> x.Name.Contains("a"));
//ShowAll(aProducts);

//Console.WriteLine("\n Remove products past expire date;");
//var rmvExpProdc = products.RemoveAll(x => x.ExpireDate.Date < DateTime.Now);
//ShowAll(products);

string opt, name, priceStr, dateStr, noStr, search;
int no;
double price;
DateTime date;
do
{
    Console.WriteLine("\n1. Add product");
    Console.WriteLine("2. Remove product by no");
    Console.WriteLine("3. Show product by no");
    Console.WriteLine("4. Remove expired prodycts");
    Console.WriteLine("5. Search for products");
    Console.WriteLine("6. Show all products");
    opt = Console.ReadLine();

    switch (opt)
    {
        case "1":
            do
            {
                Console.Write("\nEnter the product's name - ");
                name = Console.ReadLine();
            } while (string.IsNullOrEmpty(name));
            do
            {
                Console.Write(" Price - ");
                priceStr = Console.ReadLine();
            } while (!double.TryParse(priceStr, out price) || price < 0);
            do
            {
                Console.Write("  Expiry date - ");
                dateStr = Console.ReadLine();
            } while (!DateTime.TryParse(dateStr, out date));
            Product prd = new Product(name, price, date);
            products.Add(prd);
            Console.WriteLine("Product added !");
            break;
        case "2":
            ShowAll(products);
            do
            {
                Console.Write("\n Enter product no - ");
                noStr = Console.ReadLine();
            } while (!int.TryParse(noStr, out no) || no < 0);
            var check = products.Exists(x => x.No == no);
            if (check)
            {
                var foundRmv = products.RemoveAll(x => x.No == no);
                Console.WriteLine("Product removed !");
            }
            else Console.WriteLine("Not found !");
            break;
        case "3":
            do
            {
                Console.Write("\n Enter product no - ");
                noStr = Console.ReadLine();
            } while (!int.TryParse(noStr, out no) || no < 0);
            var found = products.Find(x => x.No == no);
            if (found == null) Console.WriteLine("Not found!");
            else Console.WriteLine(found);
            break;
        case "4":
            var rmvExpProdc = products.RemoveAll(x => x.ExpireDate.Date < DateTime.Now);
            Console.WriteLine("Expired products removed !");
            break;
        case "5":
            do
            {
                Console.Write("\nEnter search value - ");
                search = Console.ReadLine();
            } while (string.IsNullOrEmpty(search));
            var founds = products.FindAll(x => x.Name == search);
            if (founds.Count == 0) Console.WriteLine("Not found !");
            ShowAll(founds);
            break;
        case "6":
            ShowAll(products);
            break;
        case "0":
            Console.WriteLine("Finished,goodbye !");
            break;

        default:
            Console.WriteLine("Please enter a correct opt !");
            break;
    }
} while (opt != "0");





static void ShowAll( List<Product> products)
{
    Console.WriteLine("\n === PRODUCTS ===");
    foreach (var item in products)
    {
        Console.WriteLine(item);
    }

}