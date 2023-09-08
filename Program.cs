namespace testSocketConsolaCliente;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, Cliente!");
        Cliente s = new Cliente("127.0.0.1", 10800);
        s.Start();
        String texto = "";
        while(texto != "exit")
        {
            Console.WriteLine("Introduzca un texto");
            texto = Console.ReadLine();
            if (texto != "exit") s.Send(texto);
            s.Receive();
        }
        Console.ReadKey();
    }
}