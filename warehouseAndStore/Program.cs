namespace warehouseAndStore;
public class Program
{
    public static void Main(String[] args)
    {   
        var programBody = new ProgramBody();
        programBody.BodyCallInitialize();
        while (true)
        {
            programBody.Body(); 
        }
    }
}