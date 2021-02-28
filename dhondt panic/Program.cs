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

            var engine = new VoteProcessor(args[0]);
            if (!engine.LoadFile())
            {
                Console.Error.WriteLine($"Failed to load file: {args[0]}");
            }
       
        }
    }
}
