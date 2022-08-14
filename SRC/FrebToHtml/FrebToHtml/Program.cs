using CommandLine;


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
        class Options
        {
            [Option('s', "Source",
                Required = true,
                HelpText = "Source file\folder(XML) that we want to convert to HTML.")]
            public string Source { get; set; }

            [Option('d', "Destination",
                Required = true,
                HelpText = "Destination file\folder of the HTML file we generat")]
            public string Destination { get; set; }

        }

        static void Main(string[] args)
        {
            CommandLine.Parser.Default.ParseArguments<Options>(args)
              .WithParsed(RunOptions)
              .WithNotParsed(HandleParseError);
        }
        static void RunOptions(Options opts)
        {
            //handle options
            Console.WriteLine(opts.Source);
            Console.WriteLine(opts.Destination);

        }
        static void HandleParseError(IEnumerable<Error> errs)
        {
            //handle errors
            Console.WriteLine("If you find any errors please share them via mail :\n cristian@clamsen.com or on github");
        }

        static void ConvertXmlToHTML(string Source,string destination)
        {
            String myHtmlFile = Source + ".hmtl";
            var myXslTrans = new XslCompiledTransform();
            XsltSettings settings = new XsltSettings(false, true);

            myXslTrans.Load(Source, settings, new XmlUrlResolver());
            myXslTrans.Transform(destination, myHtmlFile);

        }

    }
}
