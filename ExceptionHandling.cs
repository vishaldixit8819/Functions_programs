using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{

    public class customException : System.Exception
    {
        // eXCEPTION CLASS pROPERTIES: Message, stackTrace, Inner Exception, Source, TargetSite
        public customException() : base() { }
        public customException(string message) : base(message) { }
        public customException(string message, Exception innerException) : base(message, innerException) { }
        public customException(string message, string customMessage) : base(message)
        {
            this.CustomMessage = customMessage;
        }
        public string CustomMessage { get; set; }
    }
    internal class ExceptionHandling
    {
        static void ThrowException()
        {
            int a = 10, b = 0;
            int c = a / b;
            Console.WriteLine($"{nameof(ThrowException)} called");
        }
        static void HandlerException()
        {

            Console.WriteLine($"{nameof(HandlerException)} called.");
            try
            {
                ThrowException(); // This will throw an exception
            }
            catch (DivideByZeroException dbze)
            {
                Console.WriteLine($"DBZE ERROR: {dbze.Message}");
            }
            catch (ArithmeticException ae)
            {
                Console.WriteLine($"ARITH ERROR: {ae.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"GENERAL ERROR: {ex.Message}");
            }
            finally
            {
                Console.WriteLine("FINALLY: The finaaly block executes always.");
            }
            Console.WriteLine($"{nameof(HandlerException)} completes execution.....");
            
        }

        internal static void Test()
        {
            Console.WriteLine($"{nameof(Test)} called.");
            HandlerException();
            try
            {
                throw new customException("Custom Exception", "some custom Message generated");
            }
            catch (customException ce)
            {
                Console.WriteLine($"Custom Exception: {ce.Message}");
                Console.WriteLine($"Custom Message: {ce.CustomMessage}");
                throw ce;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");  
            }
        }
     
            // call ExceptionHandling.Test() from Program.Main() to test this code
    }
}
