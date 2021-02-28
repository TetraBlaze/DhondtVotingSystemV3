using System;

namespace dhondt_panic
{
    /// <summary>
    /// Program
    /// </summary>
    class Program
    {
        /// <summary>
        /// Main entry point
        /// </summary>
        /// <param name="args">arguments</param>
        static void Main(string[] args)
        {
            if (args == null || args.Length == 0)
            {
                Console.Error.WriteLine("File path required");
                return;
            }

            Console.WriteLine($"Path = {args[0]}");          
        }
    }
}
