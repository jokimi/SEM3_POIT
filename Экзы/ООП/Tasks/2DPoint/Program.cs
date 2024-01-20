using System;
using System.Collections.Generic;
using System.Reflection;

class DeleteException : Exception
{
    public DeleteException(string message) : base(message)
    {
    }
}

class c2DPoint
{
    public int X { get; set; }
    public int Y { get; set; }

    public c2DPoint(int x, int y)
    {
        X = x;
        Y = y;
    }

    public void ChangeSign()
    {
        X = -X;
        Y = -Y;
    }
}

class c2DPath
{
    private List<c2DPoint> points;

    public c2DPath()
    {
        points = new List<c2DPoint>();
    }

    public void Add(c2DPoint point)
    {
        points.Add(point);
    }

    public void Delete(c2DPoint point)
    {
        if (points.Count == 0)
        {
            throw new DeleteException("The path is empty.");
        }

        points.Remove(point);
    }

    public void Clear()
    {
        points.Clear();
    }

    public static bool operator ==(c2DPath path1, c2DPath path2)
    {
        if (ReferenceEquals(path1, null) && ReferenceEquals(path2, null))
        {
            return true;
        }

        if (ReferenceEquals(path1, null) || ReferenceEquals(path2, null))
        {
            return false;
        }

        if (path1.points.Count != path2.points.Count)
        {
            return false;
        }

        for (int i = 0; i < path1.points.Count; i++)
        {
            if (path1.points[i].X != path2.points[i].X || path1.points[i].Y != path2.points[i].Y)
            {
                return false;
            }
        }

        return true;
    }

    public static bool operator !=(c2DPath path1, c2DPath path2)
    {
        return !(path1 == path2);
    }

    public (int, int, int, int) CountPoints()
    {
        int quadrant1 = 0;
        int quadrant2 = 0;
        int quadrant3 = 0;
        int quadrant4 = 0;

        foreach (var point in points)
        {
            if (point.X > 0 && point.Y > 0)
            {
                quadrant1++;
            }
            else if (point.X < 0 && point.Y > 0)
            {
                quadrant2++;
            }
            else if (point.X < 0 && point.Y < 0)
            {
                quadrant3++;
            }
            else if (point.X > 0 && point.Y < 0)
            {
                quadrant4++;
            }
        }

        return (quadrant1, quadrant2, quadrant3, quadrant4);
    }

    public delegate void ChangeEventHandler();

    public event ChangeEventHandler Change;

    public void ChangePoints()
    {
        foreach (var point in points)
        {
            point.ChangeSign();
        }

        Change?.Invoke();
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Создание объектов типа c2DPoint
        var point1 = new c2DPoint(1, 2);
        var point2 = new c2DPoint(-3, 4);
        var point3 = new c2DPoint(5, -6);

        // Создание объекта типа c2DPath
        var path = new c2DPath();

        // Добавление точек в путь
        path.Add(point1);
        path.Add(point2);
        path.Add(point3);

        // Вывод количества точек в каждой четверти
        var counts = path.CountPoints();
        Console.WriteLine($"Quadrant 1: {counts.Item1}");
        Console.WriteLine($"Quadrant 2: {counts.Item2}");
        Console.WriteLine($"Quadrant 3: {counts.Item3}");
        Console.WriteLine($"Quadrant 4: {counts.Item4}");
        Console.WriteLine();

        // Удаление точки из пути
        path.Delete(point2);

        // Вывод количества точек после удаления
        counts = path.CountPoints();
        Console.WriteLine($"Quadrant 1: {counts.Item1}");
        Console.WriteLine($"Quadrant 2: {counts.Item2}");
        Console.WriteLine($"Quadrant 3: {counts.Item3}");
        Console.WriteLine($"Quadrant 4: {counts.Item4}");
        Console.WriteLine();

        // Очистка пути
        path.Clear();

        // Генерация исключения при удалении точки из пустого пути
        try
        {
            path.Delete(point1);
        }
        catch (DeleteException ex)
        {
            Console.WriteLine($"Delete Exception: {ex.Message}");
        }
        Console.WriteLine();

        // Подписка на событие Change
        path.Change += () =>
        {
            Console.WriteLine($"Point 1: X={point1.X}, Y={point1.Y}");
            Console.WriteLine($"Point 2: X={point2.X}, Y={point2.Y}");
            Console.WriteLine($"Point 3: X={point3.X}, Y={point3.Y}");
        };

        // Вызов события Change
        path.ChangePoints();
        Console.WriteLine();

        // Использование рефлексии для получения информации о классе c2DPath
        Type pathType = typeof(c2DPath);

        Console.WriteLine("Constructor(s):");
        ConstructorInfo[] constructors = pathType.GetConstructors();
        foreach (ConstructorInfo constructor in constructors)
        {
            Console.WriteLine(constructor);
        }
        Console.WriteLine();

        Console.WriteLine("Field(s):");
        FieldInfo[] fields = pathType.GetFields(BindingFlags.Instance | BindingFlags.NonPublic);
        foreach (FieldInfo field in fields)
        {
            Console.WriteLine(field);
        }
    }
}