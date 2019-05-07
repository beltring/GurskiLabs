using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class Server
    {
        private const int port = 11000;
        static void Main(string[] args)
        {
            TcpListener server = null;
            try
            {
                server = new TcpListener(port);
                server.Start();

                while (true)
                {
                    Console.WriteLine("Ожидание подключений... ");

                    TcpClient client = server.AcceptTcpClient();
                    Console.WriteLine("Подключен клиент. Выполнение запроса...");

                    byte[] data = new byte[128];
                    StringBuilder response = new StringBuilder();
                    
                    NetworkStream stream = client.GetStream();

                    do
                    {
                        int bytes = stream.Read(data, 0, data.Length);
                        response.Append(Encoding.UTF8.GetString(data, 0, bytes));
                    }
                    while (stream.DataAvailable);

                    string result = DataSendClient(response.ToString());

                    byte[] dataClient = Encoding.UTF8.GetBytes(result);

                    stream.Write(dataClient, 0, dataClient.Length);
             
                    stream.Close();
                    client.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                if (server != null)
                    server.Stop();
            }
        }

        private static string DataSendClient(string response)
        {
            string[] data = response.Split('_');
            double a, b, step;
            a = Convert.ToDouble(data[1]);
            b = Convert.ToDouble(data[2]);
            step = Convert.ToDouble(data[3]);

            CalculationMethod calculation = new CalculationMethod(a, b, step);
            string result = "";

            if (data[0] == "0")
            {
                result = calculation.Trapezium().ToString();
            }
            else if (data[0] == "1")
            {
                result = calculation.LeftRect().ToString();
            }
            else if (data[0] == "2")
            {
                result = calculation.RightRect().ToString();
            }
            else if (data[0] == "3")
            {
                result = calculation.MiddleRect().ToString();
            }

            return result;
        }
    }
}
