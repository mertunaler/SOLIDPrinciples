public enum Color
{
    Red, Green, Blue
}

public enum Size
{
    Small, Medium, Large
}
public class Product
{
    public string Name;
    public Color Color;
    public Size Size;
    public Product(string name, Color color, Size size )
    {
        Name = name;
        Color = color;
        Size = size;
    }
}
/*
 We are asked to filter the products by given the parameters. Imagine you add other parameters which don't exists in the code,
you would have to create new functions over and over again. This violates the Open-Closed Principle which states that objects or entities should be open for extension
but closed for modifications. What you would do to overcome that problem is to use inheritance. 
*/

//Old Filter
public class ProductFilter
{
    public IEnumerable<Product> FilterByColor(IEnumerable<Product> products, Color color)
    {
        foreach (var product in products)
        {
            if(product.Color == color)
            {
                yield return product;
            }
        }
    }
    public IEnumerable<Product> FilterBySize(IEnumerable<Product> products, Size size)
    {
        foreach(var p in products)
        {
            if(p.Size == size)
            {
                yield return p;
            }
        }
    }
}

//New Filter using the Specification Pattern. 
    public interface ISpecification<T>
    {
        bool isSatisfied(T t);
    }
    public interface IFilter<T>
    {
        IEnumerable<T> Filter(IEnumerable<T> items, ISpecification<T> spec);
    }

    public class ColorSpecification : ISpecification<Product>
    {
        public Color color;
        public ColorSpecification(Color color)
        {
            this.color = color;
        }
        public bool isSatisfied(Product t)
        {
        return t.Color == color; 
        }
    }

    public class NewFilter : IFilter<Product>
    {
        public IEnumerable<Product> Filter(IEnumerable<Product> items, ISpecification<Product> spec)
        {
           foreach(var i in items)
        {
            if(spec.isSatisfied(i))
                { yield return i; }
        }
        }
    }


public class Demo
    {
        public static void Main(string[] args)
        {
        var apple = new Product(name: "Apple", color: Color.Red, size: Size.Small);
        var house = new Product(name:"House", color:Color.Blue, size: Size.Large);
        Product[]products = {apple, house}; 
        
        var pf = new ProductFilter();
        //Filtering by Color by old Filter 
        Console.WriteLine("Red Products (Violating the O-P Principle)");
            foreach(var product in pf.FilterByColor(products, Color.Red))
            {
            Console.WriteLine($" -{product.Name}");
            }
        //Filtering by Color by new Filter 
        Console.WriteLine("Red Products");
        var cf = new NewFilter();
        foreach(var p in cf.Filter(products,new ColorSpecification(Color.Red)))
        {
            Console.WriteLine($" -{p.Name}");
        }

    }

}
    