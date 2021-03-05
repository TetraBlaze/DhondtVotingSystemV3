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

            try
            {
                var engine = new VoteProcessor(args[0]);
                engine.LoadData(); 
                Console.WriteLine($"File title: {engine.FileTitle}");
                Console.WriteLine($"Seats: {engine.NumberOfSeats}, total votes: {engine.TotalVotes}");
                foreach( var seat in engine.ProcessVotes())
                {
                    Console.WriteLine($"Awarded seat = {seat}");
                }
               
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Failed to process file: {args[0]}");
                Console.Error.WriteLine(ex.Message);
            }

        }
    }
}
