namespace InterfaceSegragation
{
    //Bodies are left uncoded intentionally. 
    public class Document{}  

    //1st part of the example shows what happens if we have one single interface for all the classes. 
    public interface IMachine
    {
        void Print(Document document);
        void Scan(Document document);
        void Fax(Document document);
    }
    //We have an printer which could do all the activities specified in the IMachine interface.
    public class MultiFunctionPrinter : IMachine
    {
        public void Fax(Document document)
        {
            throw new NotImplementedException();
        }

        public void Print(Document document)
        {
            throw new NotImplementedException();
        }

        public void Scan(Document document)
        {
            throw new NotImplementedException();
        }
    }
    /*
    What if we have another printer but not capable of some methods specified in the IMachine interface.
    To overcome that problem we could create more specific interfaces.
    */

    /*
    public class OldSchoolPrinter : IMachine
    {
        public void Fax(Document document)  //NOT CAPABLE OF DOING.
        {
            throw new NotImplementedException();
        }

        public void Print(Document document)
        {
            throw new NotImplementedException();
        }

        public void Scan(Document document)  //NOT CAPABLE OF DOING.
        {
            throw new NotImplementedException();
        }
    }
    */
    //SOLUTION

    public interface IPrinter
    {
        void Print(Document document);
    }
    public interface IScanner
    {
        void Scan(Document document);
    }
    public interface IFaxer
    {
        void Fax(Document document);    
    }


    //Now we could implement the old-fashioned printer.

    public class OldSchoolPrinter : IPrinter
    {
        public void Print(Document document)
        {
            throw new NotImplementedException();
        }
    }

    public class FotocopierMachine : IPrinter, IScanner, IFaxer
    {
        public void Fax(Document document)
        {
            throw new NotImplementedException();
        }

        public void Print(Document document)
        {
            throw new NotImplementedException();
        }

        public void Scan(Document document)
        {
            throw new NotImplementedException();
        }
    }


}