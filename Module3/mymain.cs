using System;
using System.IO;
using SimpleScanner;
using ScannerHelper;

namespace GeneratedLexer
{
    class mymain
    {
        static void Main(string[] args)
        {
            int cnt_id = 0;//���-�� ���������������
            int min_id_len = Int32.MaxValue, max_id_len = 0; //�����������, ������������ ����� ���������������
            double avg_id_len = 0; //������� ����� ��������������

            int sum_int = 0; //����� ���� �����
            double sum_d = 0; //����� ���� ������������

            // ����� ������������ ����� �������������� � ������������ � ������� 3.14 (� �� 3,14 ��� � ������� Culture)
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");

            var fname = @"..\..\a.txt";
            Console.WriteLine(File.ReadAllText(fname));
            Console.WriteLine("-------------------------");

            Scanner scanner = new Scanner(new FileStream(fname, FileMode.Open));

            int tok = 0;
            do {
                tok = scanner.yylex();
                switch (tok)
                {
                    case (int)Tok.ID:
                        if (scanner.yytext.Length < min_id_len)
                        {
                            min_id_len = scanner.yytext.Length;
                        }
                        if (scanner.yytext.Length > max_id_len)
                        {
                            max_id_len = scanner.yytext.Length;
                        }
                        avg_id_len += scanner.yytext.Length;
                        cnt_id++;
                        break;
                    case (int)Tok.INT_VAL:
                        sum_int += scanner.LexValueInt;
                        break;
                    case (int)Tok.FLOAT_VAL:
                        sum_d += scanner.LexValueDouble;
                        break;
                    default:
                        break;
                }
                if (tok == (int)Tok.EOF)
                {
                    Console.WriteLine();
                    Console.WriteLine("number of id: {0:D}", cnt_id);
                    Console.WriteLine("average length of the id: {0:N}", avg_id_len / cnt_id);
                    Console.WriteLine("min length of the id: {0:D}", min_id_len);
                    Console.WriteLine("min length of the id: {0:D}", max_id_len);

                    Console.WriteLine();
                    Console.WriteLine("sum of int: {0:D}", sum_int);
                    Console.WriteLine("sum of double: {0:N}", sum_d);

                    Console.WriteLine();

                    break;
                }
                Console.WriteLine(scanner.TokToString((Tok)tok));
            } while (true);

            Console.ReadKey();
        }
    }
}
