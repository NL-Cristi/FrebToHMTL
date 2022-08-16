using System;
using System.IO;
using System.Linq;
using System.Xml.Xsl;
using System.Xml;

namespace FrebToHtml
{
    public class MyUtils
    {
    }
    public class MyAppParams
    {
        public string? Source { get; set; }
        public string? Destination { get; set; }
        public bool? IncludeScript { get; set; }
        public string? Kind { get; set; }

        public MyAppParams(string[] args, MyChecks mayChecks)
        {
            var tempKind = args.FirstOrDefault(s => s.Contains(mayChecks.KindString));
            if (String.IsNullOrEmpty(tempKind))
            {
                Kind = null;
            }
            else
            {
                Kind = tempKind.Replace(mayChecks.KindString + ":", "");
            }
            var tempSource = args.FirstOrDefault(s => s.Contains(mayChecks.SourceString));
            if (String.IsNullOrEmpty(tempSource))
            {
                Source = null;
            }
            else
            {
                Source = tempSource.Replace(mayChecks.SourceString + ":", "");
            }
            var tempDestination = args.FirstOrDefault(s => s.Contains(mayChecks.DestinationString));
            if (String.IsNullOrEmpty(tempDestination))
            {
                Destination = null;
            }
            else
            {
                Destination = tempDestination.Replace(mayChecks.DestinationString + ":", "");
            }
            var tempScriptchek = args.FirstOrDefault(s => s.Contains(mayChecks.IncludeScriptString));
            if (String.IsNullOrEmpty(tempScriptchek))
            {
                IncludeScript = true;
            }
            else
            {
                IncludeScript = Convert.ToBoolean(args.FirstOrDefault(s => s.Contains(mayChecks.IncludeScriptString)).Replace(mayChecks.IncludeScriptString + ":", ""));

            }


        }

    }

    public class MyChecks
    {

        public string KindString;
        public string SourceString;
        public string DestinationString;
        public string IncludeScriptString;
        public string HelpString;

        public MyChecks()
        {
            KindString = "--kind";
            SourceString = "--source";
            DestinationString = "--destination";
            IncludeScriptString = "--fullDetails";
            HelpString = "--help";
        }


    }
    public class MyHelpText
    {

        public static void ShowMessage()
        {
            Console.WriteLine();
            Console.WriteLine("Help Information for FrebXmltoHTML");
            Console.WriteLine();
            ShowArgumentsDetails();
            Console.WriteLine();
            Console.WriteLine("Examples: ");
            Console.WriteLine();
            ShowFileHelpUsage();
            Console.WriteLine();
            ShowFolderHelpUsage();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            static void ShowArgumentsDetails()
            {
                Console.ResetColor();
                Console.WriteLine("Arguments: ");
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write("--kind:");
                Console.ResetColor();
                Console.Write("[");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("file");
                Console.ResetColor();
                Console.Write("-");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("folder");
                Console.ResetColor();
                Console.Write("] ");
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write("Mandatory");
                Console.ResetColor();
                Console.Write(" - Decide if you will convert one file or all files under a folder");
                Console.ResetColor();
                Console.WriteLine();


                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write("--source:");
                Console.ResetColor();
                Console.Write("[");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("full path");
                Console.ResetColor();
                Console.Write("] ");
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write("Mandatory");
                Console.ResetColor();
                Console.Write(" - Full path of ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("Folder");
                Console.ResetColor();
                Console.Write(" or ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("File");
                Console.ResetColor();
                Console.Write(" used as input XML");
                Console.WriteLine();

                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write("--destination:");
                Console.ResetColor();
                Console.Write("[");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("full path");
                Console.ResetColor();
                Console.Write("] ");
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.Write("Optional");
                Console.ResetColor();
                Console.Write(" - Full path of ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("Folder");
                Console.ResetColor();
                Console.Write(" or ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("File");
                Console.ResetColor();
                Console.Write(" used as HTML output");
                Console.WriteLine();


                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write("--fullDetails:");
                Console.ResetColor();
                Console.Write("[");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("true");
                Console.ResetColor();
                Console.Write("-");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("false");
                Console.ResetColor();
                Console.Write("] ");
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.Write("Optional");
                Console.ResetColor();
                Console.Write(" - Include all scripts in HTML output. Default is ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("true. ");
                Console.ResetColor();
                Console.Write("Set ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("false");
                Console.ResetColor();
                Console.Write(" if you want a smaller HTML file with details info only. ");
                Console.WriteLine();

                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write("--help");
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.Write(" Optional");
                Console.ResetColor();
                Console.Write(" - Display the help information about the tool and parameter options.");
                Console.WriteLine();


            }
            static void ShowFileHelpUsage()
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write("--kind:");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("file");
                Console.ResetColor();
                Console.Write(" ");

                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write("--source:");
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write("c:\\inetpub\\logs\\FailedReqLogFiles\\W3SVC3\\");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("fr000011.xml");
                Console.ResetColor();
                Console.Write(" ");

                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write("--destination:");
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write("c:\\inetpub\\logs\\FailedReqLogFiles\\W3SVC3\\");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("fr000011.html");
                Console.ResetColor();
                Console.Write(" ");

                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write("--fullDetails:");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("false");
                Console.ResetColor();
                Console.Write(" ");
            }

            static void ShowFolderHelpUsage()
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write("--kind:");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("folder");
                Console.ResetColor();
                Console.Write(" ");

                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write("--source:");
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write("c:\\inetpub\\logs\\FailedReqLogFiles\\");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("W3SVC3");

                Console.ResetColor();
                Console.Write(" ");

                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write("--destination:");
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write("c:\\inetpub\\logs\\FailedReqLogFiles\\W3SVC3\\");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("HTML");
                Console.ResetColor();
                Console.Write(" ");


                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write("--fullDetails:");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("true");
                Console.ResetColor();
                Console.Write(" ");
            }
        }

    }
    public class XmltoHTML
    {
        public static void Convert(MyAppParams myAppParams)
        {
            var myXslTrans = new XslCompiledTransform();
            XsltSettings settings = new XsltSettings(false, true);
            var xsltfile = @"C:\temp\ConvertFreb\freb.xsl";



            if ((myAppParams.IncludeScript == true) || (myAppParams.IncludeScript == null))
            { settings.EnableScript = true; }
            else { settings.EnableScript = false; }

            if (myAppParams.Kind == "file")
            {
                if (File.Exists(myAppParams.Source))
                {
                    var myXML = @$"{myAppParams.Source}";




                    if (CanCreateFile2(new FileInfo(myAppParams.Destination)))
                    {
                        var testHtml = new FileInfo(myAppParams.Destination);

                        string myhtmlFile = @$"{myAppParams.Destination}";
                        myXslTrans.Load(xsltfile, settings, new XmlUrlResolver());
                        myXslTrans.Transform(myXML, myhtmlFile);
                        Console.WriteLine($"Your file can be found at: {myhtmlFile}");
                    }
                    else
                    {
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine($"{myAppParams.Destination} does not exist, please check again");
                        }

                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"{myAppParams.Source} does not exist, please check again");
                }


            }
            else if (myAppParams.Kind == "folder")
            {

                var myXML = @$"{myAppParams.Source}";

                string myhtmlFile = @$"{myAppParams.Destination}";



                myXslTrans.Load(xsltfile, settings, new XmlUrlResolver());
                myXslTrans.Transform(myXML, myhtmlFile);
            }
            else
            {

                Console.WriteLine("mama are mere");
            }

        }
        static bool CanCreateFile(FileInfo fileInfo)
        {
            if (fileInfo.Exists) return false;
            return !fileInfo.Attributes.HasFlag(FileAttributes.ReadOnly);
        }

        static bool CanCreateFile2(FileInfo fileInfo)
        {
            if (fileInfo.Exists) return false;
            return IsDirectoryWriteable(
                Path.GetDirectoryName(fileInfo.FullName));
        }

        static bool IsDirectoryWriteable(string path)
        {
            var directoryInfo = new DirectoryInfo(path);
            if (!directoryInfo.Exists)
            {
                return IsDirectoryWriteable(directoryInfo.Parent.FullName);
            }
            return !directoryInfo.Attributes.HasFlag(FileAttributes.ReadOnly);
        }

    }
}
