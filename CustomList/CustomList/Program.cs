namespace CustomList;

internal class Program
{
    static void Main(string[] args)
    {
        CustomList<int> myList = new CustomList<int>();
        myList.Add(1);
        myList.Add(2);
        myList.Add(3);
        myList.Add(4);
        myList.Add(5); 

        Console.WriteLine($"Count: {myList.Count}");
        Console.WriteLine($"Capacity: {myList.Capacity}");

        Console.WriteLine("------------------------");

        Console.WriteLine(myList.Remove(4));
        Console.WriteLine("------------------------");
        foreach (int i in myList)
        {
            Console.WriteLine(i);
        }
        Console.WriteLine("------------------------");
        Console.WriteLine( myList.RemoveAll(x => x == 1 ));
        Console.WriteLine("------------------------");
        Console.WriteLine(myList.Find(x => x%2 == 0));
        Console.WriteLine("------------------------");
        var filteredList = myList.FindAll(x => x > 2);
        foreach (var item in filteredList)
        {
            Console.WriteLine(item);
        }
    }

}
