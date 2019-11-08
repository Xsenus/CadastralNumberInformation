using CadastralNumberInformation.Core;
using CadastralNumberInformation.Core.Rosreestr.net;
using CadastralNumberInformation.Model;
using System;

namespace Test
{
    class Program
    {
        private static ParserWorker<CadastralInformation> parser;

        static void Main(string[] args)
        {
            var k = "54-32-010543-1275";            

            parser = new ParserWorker<CadastralInformation>(new RosreestrParser());

            parser.OnNewData += Parser_OnNewData;

            parser.Settings = new RosreestrSettings(k);
            parser.Start();

            Console.ReadLine();
        }

        private static void Parser_OnNewData(object arg1, object arg2)
        {
            Console.WriteLine(arg2);
        }
    }
}
