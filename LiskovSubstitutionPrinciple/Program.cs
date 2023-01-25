public class Rectangle
{
    public int Width { get; set; }  
    public int Height { get; set; }

    public Rectangle()
    {

    }
    public Rectangle(int width, int height)
    {
        Width= width;
        Height= height;
    }

    public override string ToString()
    {
        return $"{nameof(Width)} : {Width}, {nameof(Height)}: {Height}";
    }


}



public class Demo
{
    static public int Area(Rectangle r) { return r.Height* r.Width; }
    public static void Main(string[] args)
    {
        Rectangle r = new Rectangle(1,3);
        Console.WriteLine($"{r} has area {Area(r)}");

    }
}