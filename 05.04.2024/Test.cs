// Задание 4
var products = new Dictionary<string, List<string>>();
products.Add("Овощи", new List<string> { "Морковь", "Кабачок", "Денис" });
products.Add("Чай", new List<string> { "Черный", "Зеленый", "Фруктовый" });
foreach (var category in products.Keys)
{
    Console.WriteLine(category);
}

Console.WriteLine("\n**************\n");

// Задание 5 
T[] ReverseArray<T>(T[] array)
{
    var result = new T[array.Length];
    for (int i = 0; i < array.Length; i++)
        result[i] = array[array.Length - i - 1];
    return result;
}

int[] a = new int[10];
for (int i = 0; i < 10; i++) a[i] = i;
foreach(var i in ReverseArray(a)) // Для интов
    Console.WriteLine(i);

MyClass[] b = new MyClass[10];
for (int i = 0; i < 10; i++)
    b[i] = new MyClass { age = i, name = i.ToString() };

foreach (var i in ReverseArray(b)) // Для пользовательских классов
    Console.WriteLine(i);


class MyClass
{
    public string name;
    public int age;
    public override string ToString()
    {
        return $"{age}, {name}";
    }
}