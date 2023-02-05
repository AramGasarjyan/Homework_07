using System;

//Ստեղծել կլաս որը իրենից կներկայացնի “նորություն” իր մեջ կունենա իվենթ, որի միջոցով մեզ տեղյակ կպահի նորությունների մասին
//Ձևափոխել subscription, subscribe լինելուց հետո տպել գրանցված  մեթոդների քանակը

Item item = new Item();
Novelty novelty = new Novelty("Car", 25000);
item.SetNovelty(novelty);
novelty.OnNovelty();

//Կազմակերպել կոդի ճիշտ իրականացումը, երբ տեղի է ունեցել ինչ որ սխալ

int[] numbers = new int[5];
FillAndPrintArray(ref numbers);

try
{
    try
    {
        int first, second;
        Console.WriteLine("Choose index of first number");
        int.TryParse(Console.ReadLine(), out first);
        Console.WriteLine("Choose index of second number");
        int.TryParse(Console.ReadLine(), out second);
        if (second == 5)
        {
            throw new FiveException();
        }
        int sum = numbers[first] + numbers[second];
    }
    catch (IndexOutOfRangeException ex)
    {
        Console.WriteLine(ex.Message);
    }
}
catch (FiveException ex)
{
    Console.WriteLine(ex.Message);
}





void FillAndPrintArray(ref int[] arr)
{
    Random random = new Random();
    for (int i = 0; i < arr.Length; i++)
    {
        arr[i] = random.Next(0, 10);
        Console.WriteLine(arr[i]);
    }
}


class FiveException : Exception
{
    public string Message = "The second index can not be 5";
}

public class Novelty
{
    public string name { get; private set; }
    public double price { get; private set; }

    public delegate void MyDelegate(Novelty novelty);
    public event MyDelegate myEvent;

    public Novelty(string name, double price)
    {
        this.name = name;
        this.price = price;

    }

    public void OnNovelty()
    {
        if (myEvent != null)
            myEvent(this);
    }
}

class Item
{
    private int count;
    public void SetNovelty(Novelty novelty)
    {
        novelty.myEvent += printNovelty;
        count++;
        Console.WriteLine("Novelty : " + count);
    }

    private void printNovelty(Novelty novelty)
    {
        Console.WriteLine($"Name {novelty.name} Price {novelty.price}");
    }
}
