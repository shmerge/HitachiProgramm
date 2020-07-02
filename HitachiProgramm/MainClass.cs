using System;
using System.IO;

namespace HitachiProgramm
{
    class MainClass
	{
        static void Main(string[] args)
        {
            
            double average = 0;
            double max = 0;
            string maxNames = null;
            double min = 0;
            string minNames = null;
            int record = 0;
            string country = null;

            try
            {
                bool ifItIs = true;
                while (ifItIs)
                {
                     Console.WriteLine("Please write a country");
                     country = Console.ReadLine();

                     Console.WriteLine("Please write average score:");
                     average = Convert.ToDouble(Console.ReadLine());

                     Console.WriteLine("Please write max score:");
                     max = Convert.ToDouble(Console.ReadLine());

                     Console.WriteLine("Please write first and last name of the person with max score:");
                     maxNames = Console.ReadLine();

                     Console.WriteLine("Please write min score:");
                     min = Convert.ToDouble(Console.ReadLine());

                     Console.WriteLine("Please write first and last name of the person with min score:");
                     minNames = Console.ReadLine();

                     Console.WriteLine("Please write the Record count:");
                     record = Convert.ToInt32(Console.ReadLine());

                     Console.WriteLine("Do you want to stop filling the table? Please answer with [yes/no]:");
                     if (Console.ReadLine().Equals("yes"))
                     {
                         ifItIs = false;
                     }

                } 
                Console.WriteLine("Please write your user name in Gmail:");
                string senderEmail = Console.ReadLine();

                Console.WriteLine("Please write your password:");
                string pass = Console.ReadLine();

                Console.WriteLine("Please write an email address of the receiver:");
                string receiverEmail = Console.ReadLine();

                Console.WriteLine("Please write a message:");
                string message = Console.ReadLine();

                MailService mail = new MailService(senderEmail, pass, receiverEmail);
                File file = new File();
                
                file.addRecord(country, average, max, maxNames, min, minNames, record);
                 
                Console.WriteLine(string.Join(" \n", file.sort()));
                Console.ReadLine();
                file.reWrite();
                //mail.sendEmail(message);
            }
            catch (IOException e) 
            {
                Console.WriteLine(string.Format("You have put a wrong value. Try to be more careful next time."));
            }
            
        }
    } 
}
