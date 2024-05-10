namespace ShapeLibrary;

public abstract class ShapeCreator
{
    public static IShape CreateShape(List<double> edges)
    {
        if (IsDataIncorrect(edges)) throw new ArgumentException("Рёбра не могут быть отрицательной длины");
        return edges.Count switch
        {
            0 or 2 => throw new ArgumentException("Количество рёбер не соответствует известной фигуре. Проверьте данные и повторите попытку."),
            1 => new Circle(edges[0]),
            3 => new Triangle(edges[0], edges[1], edges[2]),
            4 => new Quadrilateral(edges),
            _ => new Polygon(edges),
        };
    }

    private static bool IsDataIncorrect(List<double> edges)
    {
        return edges.Count(e => e < 0) > 0;
    }
}

public interface IShape
{
    public double GetArea();
}

public class Triangle(double a, double b, double c) : IShape
{
    public double a = a;
    public double b = b;
    public double c = c;

    public double GetArea()
    {
        if (!IsTriangle()) throw new ArgumentException("Треугольника с такими сторонами не существует");
        var p = (a + b + c)  / 2;
        var s = Math.Sqrt(p * (p - a) * (p - b) * (p - c));
        return s;
    }

    public bool IsRigrhAngled()
    {
        if (!IsTriangle()) throw new ArgumentException("Треугольника с такими сторонами не существует");
        var edges = new List<double> { a, b, c }
        .OrderByDescending(x => x).ToList();
        var isAngled = Math.Pow(edges[0], 2) == (Math.Pow(edges[1], 2) + Math.Pow(edges[2], 2));
        return isAngled;
    }

    private bool IsTriangle()
    {
        var edges = new List<double> { a, b, c }
        .OrderByDescending(x => x).ToList();
        return edges[0] < edges[1] + edges[2];
    }
}

public class Circle(double r) : IShape
{
    public double r = r;

    public double GetArea()
    {
        var s = Math.PI * r * r;
        return s;
    }
}

// проверяем лёгкость добавления новых фигур
public class Quadrilateral : IShape
{
    public List<double> edges;

    public Quadrilateral(List<double> edges)
    {
        this.edges = edges;
    }

    public double GetArea()
    {
        var p = edges.Sum() / 2;
        var s = (Math.Sqrt((p - edges[0]) * (p - edges[1]) * (p - edges[2]) * (p - edges[3])));
        return s;
    }
}

public class Polygon(List<double> edges) : IShape
{
    public List<double> edges = edges;

    public double GetArea()
    {
        throw new NotImplementedException();
    }
}