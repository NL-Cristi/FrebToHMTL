using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Xml;
using System.Xml.Xsl;

namespace FrebToHtml
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var myChecks = new MyChecks();

            if (args.Any(a => a.Contains(myChecks.HelpString)) || args.Length == 0)
            {
                MyHelpText.ShowMessage();
            }
            else
            {
                if (!args.Any(a => a.Contains(myChecks.KindString)) || !args.Any(a => a.Contains(myChecks.SourceString)))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Please check --kind or --source values");
                }
                else
                {
                    var paramsToUse = new MyAppParams(args, myChecks);
                    if (String.IsNullOrEmpty(paramsToUse.Kind) || (String.IsNullOrEmpty(paramsToUse.Source)))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"Please check if --kind or --source values are missing");
                    }
                    else
                    {

                        if ((paramsToUse.Kind.ToLowerInvariant() == "file") || (paramsToUse.Kind.ToLowerInvariant() == "folder"))
                        {
                            Console.ForegroundColor = ConsoleColor.Green;

                            Console.WriteLine($"Merge cu {paramsToUse.Kind}");
                            XmltoHTML.Convert(paramsToUse);
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine($"Please check --kind LAST value supplied");

                        }
                    }

                }
            }




        }

    }
}
