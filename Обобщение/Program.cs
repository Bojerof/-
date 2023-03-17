//Напишите обобщенный класс, который может хранить в массиве объекты любого типа.
//Кроме того, данный класс должен иметь методы для добавления данных в массив,
//удаления из массива, получения элемента из массива по индексу и метод, возвращающий длину массива.
//Для упрощения работы можно пересоздавать массив при каждой операции добавления и удаления
//Используя средства языка C# разработать класс LSearch<T>, содержащий методы,
//которые осуществляют поиск заданного ключа в одномерном массиве. В классе реализовать:
//внутренние переменные для сохранения данных;
//конструкторы и методы доступа к внутренним данным;
//метод, определяющий наличие элемента в массиве;
//метод, определяющий количество вхождений заданного элемента в массиве;
//метод, который возвращает массив номеров позиций вхождения заданного элемента в массиве.


int[] arrayNum = { 3, 5, 4, 6, 2, 7 };
string[] arrayStr = { "Hello", "my", "friends" };
Console.Write("Если массив чисел введите num, если массив строк введите str: ");
string? choise = Console.ReadLine();
if (choise == "str") StrArray(arrayStr);
else if (choise == "num") NumArray(arrayNum);
else Console.WriteLine("Операция неизвестна.");



void StrArray(string[] arrayStr)
{
    Console.Write("Какую операцию вы хотите совершить: ");
    string? op = Console.ReadLine();
    switch (op)
    {
        case "add":
            Console.Write("Введите строку которое хотите добавить: ");
            string? value = Console.ReadLine();
            Console.Write("Введите индекс: ");
            int index = Convert.ToInt32(Console.ReadLine());
            Arr<string> arr = new Arr<string>(value, index, arrayStr);
            break;
        case "del":
            Console.Write("Введите индекс: ");
            int index1 = Convert.ToInt32(Console.ReadLine());
            Arr<string> arr1 = new Arr<string>(index1, op, arrayStr);
            break;
        case "len":
            Arr<string> arr2 = new Arr<string>(arrayStr);
            break;
        case "index":
            Console.Write("Введите индекс: ");
            int index2 = Convert.ToInt32(Console.ReadLine());
            Arr<string> arr3 = new Arr<string>(index2, op, arrayStr);
            break;
        default:
            Console.WriteLine("Нет такой операции!");
            break;
    }
}

void NumArray(int[] arrayNum)
{
    Console.Write("Какую операцию вы хотите совершить: ");
    string? op = Console.ReadLine();
    switch (op)
    {
        case "add":
            Console.Write("Введите строку которое хотите добавить: ");
            int value = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите индекс: ");
            int index = Convert.ToInt32(Console.ReadLine());
            Arr<int> arr = new Arr<int>(value, index, arrayNum);
            break;
        case "del":
            Console.Write("Введите индекс: ");
            int index1 = Convert.ToInt32(Console.ReadLine());
            Arr<int> arr1 = new Arr<int>(index1, op, arrayNum);
            break;
        case "len":
            Arr<int> arr2 = new Arr<int>(arrayNum);
            break;
        case "index":
            Console.Write("Введите индекс: ");
            int index2 = Convert.ToInt32(Console.ReadLine());
            Arr<int> arr3 = new Arr<int>(index2, op, arrayNum);
            break;
        default:
            Console.WriteLine("Нет такой операции!");
            break;
    }
}


class Arr<T>
{
    private T[]? array;
    private T? val;
    private int index;
    private string? op;
    public T[]? Array
    {
        get { return array; }
    
        set { array = value; }
    }
    
    public int Index
    {
        get { return index; }
        set { index = value; }
    }

    public T Val
    {
        get { return val; }
        set { val = value; }
    }

    public string Op
    {
        get { return op; }
        set { op = value; }
    }

    public Arr(T[] array)
    {
        this.array = array;
        LengthArray(array);
    }
    public Arr(int index, string op, T[] array) 
    {
        this.array = array;
        this.index = index;
        this.op = op;
        switch (op)
        {
            case "del":
                DeliteValue(index, array);
                break;
            case "index":
                IndexArray(index, array);
                break;
        }
    }
    
    public Arr(T val, int index, T[] array) 
    {
        this.array = array;
        this.index = index;
        this.val = val;
        AddValue(val, index, array);
    }
    

    public void AddValue(T val, int index, T[] array)
    {
        T[] newArray = new T[array.Length + 1];

        for (int i = 0; i < index; i++)
        {
            newArray[i] = array[i];
        }
        newArray[index] = val;
        for (int i = index + 1; i < newArray.Length; i++) newArray[i] = array[i - 1];
        
        Console.WriteLine(string.Join(", ", newArray));
    }
    public void DeliteValue(int index, T[] array)
    {
        T[] newArray = new T[array.Length - 1];

        for (int i = 0; i < index; i++) newArray[i] = array[i];

        for (int i = index; i < newArray.Length; i++) newArray[i] = array[i + 1];
        Console.WriteLine(string.Join(", ", newArray));
    }
    public void IndexArray(int index, T[] array) => Console.WriteLine(array[index]);

    public void LengthArray(T[] array) => Console.WriteLine(array.Length);

    public void BoolArray(T[] array, T val)
    {
        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] == val) Console.WriteLine("True"); 
        }
    }
}

