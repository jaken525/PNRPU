using System.Collections.Generic;
using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace DiskretLaba3
{
    class Program
    {
        static void PrintTable(char[,] matr)
        {
            Console.Write("|");
            for (int j = 0; j < 5; j++)
                Console.Write(" " + matr[0, j] + " |");

            Console.Write("\n---------------------\n");

            for (int i = 1; i < matr.GetLength(0); i++)
            {
                Console.Write("|");
                for (int j = 0; j < matr.GetLength(1); j++)
                    Console.Write(" " + matr[i, j] + " |");

                Console.WriteLine();
            }

            Console.Write("---------------------\n");
        }

        static char[,] CreateTable(char[,] truthTable)
        {
            truthTable[0, 0] = 'A';
            truthTable[0, 1] = 'B';
            truthTable[0, 2] = 'C';
            truthTable[0, 3] = 'D';
            truthTable[0, 4] = 'F';

            for (int i = 0; i < 5; i++)
                for (int j = 1; j <= 16; j++)
                    if (
                        (j <= 8 && i == 0) ||
                        ((j > 0) && (j <= 4) && (i == 1)) ||
                        ((j > 8) && (j <= 12) && (i == 1)) ||
                        ((j > 0) && (j <= 2) && (i == 2)) ||
                        ((j > 4) && (j <= 6) && (i == 2)) ||
                        ((j > 8) && (j <= 10) && (i == 2)) ||
                        ((j > 12) && (j <= 14) && (i == 2))
                        )
                        truthTable[j, i] = '0';
                    else if (i == 3)
                    {
                        if (j % 2 == 0)
                            truthTable[j, i] = '1';
                        else
                            truthTable[j, i] = '0';
                    }
                    else
                        truthTable[j, i] = '1';

            List<string> F = new List<string>() { };

            foreach (var current in File.ReadLines("text.txt"))
            {
                var buff = Regex.Split(current, @"(?<=[\s+\n\r])");
                List<int> buff2 = new List<int>();

                foreach (var temp in buff)
                    F.Add(temp);
            }

            truthTable[1, 4] = F[0][0];
            truthTable[2, 4] = F[1][0];
            truthTable[3, 4] = F[2][0];
            truthTable[4, 4] = F[3][0];

            truthTable[5, 4] = F[4][0];
            truthTable[6, 4] = F[5][0];
            truthTable[7, 4] = F[6][0];
            truthTable[8, 4] = F[7][0];

            truthTable[9, 4] = F[8][0];
            truthTable[10, 4] = F[9][0];
            truthTable[11, 4] = F[10][0];
            truthTable[12, 4] = F[11][0];

            truthTable[13, 4] = F[12][0];
            truthTable[14, 4] = F[13][0];
            truthTable[15, 4] = F[14][0];
            truthTable[16, 4] = F[15][0];

            return truthTable;
        }

        static List<string> GetSDNF(char[,] truthTable)
        {
            string temp = "";
            string temp1 = "";

            List<string> SDNF = new List<string>();

            for (int i = 1; i < 17; i++)
            {
                for (int j = 0; j < 4; j++)
                    if (truthTable[i, 4] == '1')
                        temp += truthTable[i, j];
                temp1 = temp;

                if (temp != "")
                    SDNF.Add(temp1);

                temp = "";
            }

            return SDNF;
        }

        static List<string> SdnfToLetters(List<string> SDNF)
        {
            for (int k = 0; k < SDNF.Count; k++)
            {
                string tempOne1 = SDNF[k];
                string tempOneRes = "";
                string[] tempOneArrray = new string[4];

                for (int i = 0; i < 4; i++)
                    tempOneArrray[i] = tempOne1[i].ToString();

                for (int i = 0; i < tempOneArrray.Length; i++)
                {
                    if (tempOneArrray[i] == "0" && i == 0)
                        tempOneRes += "!A";

                    if (tempOneArrray[i] == "1" && i == 0)
                        tempOneRes += "A";

                    if (tempOneArrray[i] == "0" && i == 1)
                        tempOneRes += "!B";

                    if (tempOneArrray[i] == "1" && i == 1)
                        tempOneRes += "B";

                    if (tempOneArrray[i] == "0" && i == 2)
                        tempOneRes += "!C";

                    if (tempOneArrray[i] == "1" && i == 2)
                        tempOneRes += "C";

                    if (tempOneArrray[i] == "0" && i == 3)
                        tempOneRes += "!D";

                    if (tempOneArrray[i] == "1" && i == 3)
                        tempOneRes += "D";

                }

                SDNF[k] = tempOneRes;
            }

            return SDNF;
        }

        static List<string> SkleikaLevel3(List<string> SDNF, List<string> incompleteGluing)
        {
            int[] isStick = new int[SDNF.Count];
            for (int i = 0; i < isStick.Length; i++)
                isStick[i] = 0;

            int countCoincidences = 0;
            int countSyboles = 0;
            int indexSyb = 0;

            string temp1 = "";
            string temp2 = "";
            string temp3 = "";
            string tempOneRes = "";

            for (int i = 0; i < SDNF.Count; i++)
            {
                temp1 = SDNF[i];

                for (int j = i + 1; j < SDNF.Count; j++)
                {
                    countSyboles = 0;
                    temp2 = SDNF[j];

                    while (countSyboles < 4)
                    {
                        if (temp1[countSyboles] == temp2[countSyboles])
                            countCoincidences++;

                        countSyboles++;
                    }

                    if (countCoincidences == 3)
                    {
                        isStick[i]++;
                        isStick[j]++;

                        for (int t = 0; t < 4; t++)
                            if (temp1[t] != temp2[t])
                                indexSyb = t;

                        tempOneRes = "";
                        string[] tempOneArrray = new string[4];

                        for (int k = 0; k < 4; k++)
                            tempOneArrray[k] = temp1[k].ToString();

                        for (int h = 0; h < tempOneArrray.Length; h++)
                            if (h != indexSyb)
                            {
                                if (tempOneArrray[h] == "0" && h == 0)
                                    tempOneRes += "!A";

                                if (tempOneArrray[h] == "1" && h == 0)
                                    tempOneRes += "A";

                                if (tempOneArrray[h] == "0" && h == 1)
                                    tempOneRes += "!B";

                                if (tempOneArrray[h] == "1" && h == 1)
                                    tempOneRes += "B";

                                if (tempOneArrray[h] == "0" && h == 2)
                                    tempOneRes += "!C";

                                if (tempOneArrray[h] == "1" && h == 2)
                                    tempOneRes += "C";

                                if (tempOneArrray[h] == "0" && h == 3)
                                    tempOneRes += "!D";

                                if (tempOneArrray[h] == "1" && h == 3)
                                    tempOneRes += "D";

                            }

                        incompleteGluing.Add(tempOneRes);
                        countCoincidences = 0;
                    }
                    else
                        countCoincidences = 0;
                }

            }

            for (int i = 0; i < isStick.Length; i++)
                if (isStick[i] == 0)
                {
                    tempOneRes = "";
                    string[] tempOneArrray = new string[4];
                    temp3 = SDNF[i];

                    for (int k = 0; k < 4; k++)
                        tempOneArrray[k] = temp3[k].ToString();

                    for (int h = 0; h < tempOneArrray.Length; h++)
                    {

                        if (tempOneArrray[h] == "0" && h == 0)
                            tempOneRes += "!A";

                        if (tempOneArrray[h] == "1" && h == 0)
                            tempOneRes += "A";

                        if (tempOneArrray[h] == "0" && h == 1)
                            tempOneRes += "!B";

                        if (tempOneArrray[h] == "1" && h == 1)
                            tempOneRes += "B";

                        if (tempOneArrray[h] == "0" && h == 2)
                            tempOneRes += "!C";

                        if (tempOneArrray[h] == "1" && h == 2)
                            tempOneRes += "C";

                        if (tempOneArrray[h] == "0" && h == 3)
                            tempOneRes += "!D";

                        if (tempOneArrray[h] == "1" && h == 3)
                            tempOneRes += "D";
                    }

                    incompleteGluingRes.Add(tempOneRes);
                }

            return incompleteGluing;
        }

        static string[,] FillAtForStick(List<string> stick1, List<string> stick2)
        {
            string[,] isStickForStick = new string[2, 8];
            string temp = "";

            isStickForStick[0, 0] = "!A";
            isStickForStick[0, 1] = "A";
            isStickForStick[0, 2] = "!B";
            isStickForStick[0, 3] = "B";
            isStickForStick[0, 4] = "!C";
            isStickForStick[0, 5] = "C";
            isStickForStick[0, 6] = "!D";
            isStickForStick[0, 7] = "D";

            for (int i = 0; i < isStickForStick.GetLength(1); i++)
                isStickForStick[1, i] = "0";

            for (int i = 0; i < stick1.Count; i++)
            {
                temp = stick1[i];

                for (int j = 0; j < isStickForStick.GetLength(1); j++)
                    if (temp == isStickForStick[0, j])
                        isStickForStick[1, j] = "1";
            }

            for (int i = 0; i < stick2.Count; i++)
            {
                temp = stick2[i];

                for (int j = 0; j < isStickForStick.GetLength(1); j++)
                    if (temp == isStickForStick[0, j])
                        if (isStickForStick[1, j] == "1")
                            isStickForStick[1, j] = "2";
                        else
                            isStickForStick[1, j] = "1";
            }

            return isStickForStick;
        }

        static string[,] FillAtForStickForMinimal(List<string> MDNF, List<string> SDNF)
        {
            string[,] isConsistsInSDNF = new string[2, 8];
            string temp = "";
            isConsistsInSDNF[0, 0] = "!A";
            isConsistsInSDNF[0, 1] = "A";
            isConsistsInSDNF[0, 2] = "!B";
            isConsistsInSDNF[0, 3] = "B";
            isConsistsInSDNF[0, 4] = "!C";
            isConsistsInSDNF[0, 5] = "C";
            isConsistsInSDNF[0, 6] = "!D";
            isConsistsInSDNF[0, 7] = "D";

            for (int i = 0; i < isConsistsInSDNF.GetLength(1); i++)
                isConsistsInSDNF[1, i] = "0";

            for (int i = 0; i < MDNF.Count; i++)
            {
                temp = MDNF[i];
                for (int j = 0; j < isConsistsInSDNF.GetLength(1); j++)
                    if (temp == isConsistsInSDNF[0, j])
                        isConsistsInSDNF[1, j] = "1";
            }

            for (int i = 0; i < SDNF.Count; i++)
            {
                temp = SDNF[i];

                for (int j = 0; j < isConsistsInSDNF.GetLength(1); j++)
                    if (temp == isConsistsInSDNF[0, j])
                        if (isConsistsInSDNF[1, j] == "1")
                            isConsistsInSDNF[1, j] = "2";
                        else
                            isConsistsInSDNF[1, j] = "1";
            }

            return isConsistsInSDNF;
        }

        static bool CheckMinimal(string[,] isConsistsInSDNF, int MDNFCount)
        {
            bool MDNFconsistsInSDNF = false;

            int coincidences = MDNFCount;
            int countCoincidences = 0;
            for (int j = 0; j < isConsistsInSDNF.GetLength(1); j++)
                if (isConsistsInSDNF[1, j] == "2")
                    countCoincidences++;

            if (coincidences == countCoincidences)
                MDNFconsistsInSDNF = true;

            return MDNFconsistsInSDNF;
        }

        static bool CheckSkleikaLevel2(string[,] isStickForStick)
        {
            bool thereAreStick = false;
            bool thereAreInverse = false;

            int countCoincidences = 0;
            for (int j = 0; j < isStickForStick.GetLength(1); j++)
                if (isStickForStick[1, j] == "2")
                    countCoincidences++;

            if (
                (isStickForStick[1, 0] == "1" && isStickForStick[1, 1] == "1") ||
                (isStickForStick[1, 2] == "1" && isStickForStick[1, 3] == "1") ||
                (isStickForStick[1, 4] == "1" && isStickForStick[1, 5] == "1") ||
                (isStickForStick[1, 6] == "1" && isStickForStick[1, 7] == "1")
                )
                thereAreInverse = true;

            if (countCoincidences == 1 && thereAreInverse == true)
                thereAreStick = true;
            else
                thereAreStick = false;

            return thereAreStick;

        }

        static bool CheckSkleika(string[,] isStickForStick)
        {
            bool thereAreStick = false;
            bool thereAreInverse = false;

            int countCoincidences = 0;
            for (int j = 0; j < isStickForStick.GetLength(1); j++)
                if (isStickForStick[1, j] == "2")
                    countCoincidences++;

            if (
                (isStickForStick[1, 0] == "1" && isStickForStick[1, 1] == "1") ||
                (isStickForStick[1, 2] == "1" && isStickForStick[1, 3] == "1") ||
                (isStickForStick[1, 4] == "1" && isStickForStick[1, 5] == "1") ||
                (isStickForStick[1, 6] == "1" && isStickForStick[1, 7] == "1")
                )
                thereAreInverse = true;

            if (countCoincidences == 2 && thereAreInverse == true)
                thereAreStick = true;
            else
                thereAreStick = false;

            return thereAreStick;

        }

        static string SkleikaLevel2(string[,] isStickForStick)
        {
            string temp = "";
            for (int j = 0; j < isStickForStick.GetLength(1); j++)
                if (isStickForStick[1, j] == "2")
                    temp += isStickForStick[0, j];

            return temp;
        }

        static string SkleikaLevel1(string[,] isStickForStick)
        {
            string temp = "";
            string[,] isStickForStickTemp = isStickForStick;

            for (int j = 0; j < isStickForStickTemp.GetLength(1) - 1; j += 2)
                if (isStickForStickTemp[1, j] == "1" && isStickForStickTemp[1, j + 1] == "1")
                {
                    isStickForStickTemp[1, j] = "0";
                    isStickForStickTemp[1, j + 1] = "0";
                }

            for (int j = 0; j < isStickForStick.GetLength(1); j++)
                if (isStickForStick[1, j] == "2")
                    temp += isStickForStick[0, j];

            return temp;
        }

        static List<string> StickTogether2(List<string> SDNF, List<string> incompleteGluing)
        {
            int[] isStick = new int[SDNF.Count];
            for (int i = 0; i < isStick.Length; i++)
                isStick[i] = 0;

            bool thereAreStick = false;
            string[,] isStickForStick = new string[2, 8];

            List<string> tempAr1 = new List<string>(3);
            List<string> tempAr2 = new List<string>(3);

            for (int i = 0; i < SDNF.Count; i++)
            {
                tempAr1 = GetListOneMinterm(SDNF[i]);

                for (int j = i + 1; j < SDNF.Count; j++)
                {
                    tempAr2 = GetListOneMinterm(SDNF[j]);
                    isStickForStick = FillAtForStick(tempAr1, tempAr2);
                    thereAreStick = CheckSkleika(isStickForStick);

                    if (thereAreStick == true)
                    {
                        isStick[i]++;
                        isStick[j]++;

                        incompleteGluing.Add(SkleikaLevel2(isStickForStick));
                    }
                }

            }
            for (int i = 0; i < isStick.Length; i++)
                if (isStick[i] == 0)
                    incompleteGluingRes.Add(SDNF[i]);

            return incompleteGluing;
        }

        static List<string> GetListOneMinterm(string minterm)
        {
            List<string> listMinterm = new List<string>();

            int j = 0;
            string temp = "";
            while (j < minterm.Length)
                if (minterm[j] == '!')
                {
                    temp = minterm[j].ToString() + minterm[j + 1].ToString();
                    listMinterm.Add(temp);
                    j = j + 2;
                }
                else
                {
                    listMinterm.Add(minterm[j].ToString());
                    j++;
                }

            return listMinterm;
        }

        static List<string> StickTogether1(List<string> SDNF, List<string> incompleteGluing)
        {
            int[] isStick = new int[SDNF.Count];
            for (int i = 0; i < isStick.Length; i++)
                isStick[i] = 0;

            bool thereAreStick = false;
            string[,] isStickForStick = new string[2, 8];

            List<string> tempAr1 = new List<string>(2);
            List<string> tempAr2 = new List<string>(2);

            for (int i = 0; i < SDNF.Count; i++)
            {
                tempAr1 = GetListOneMinterm(SDNF[i]);

                for (int j = i + 1; j < SDNF.Count; j++)
                {
                    tempAr2 = GetListOneMinterm(SDNF[j]);
                    isStickForStick = FillAtForStick(tempAr1, tempAr2);
                    thereAreStick = CheckSkleikaLevel2(isStickForStick);

                    if (thereAreStick == true)
                    {
                        isStick[i]++;
                        isStick[j]++;

                        incompleteGluingRes.Add(SkleikaLevel1(isStickForStick));
                        incompleteGluing.Add(SkleikaLevel1(isStickForStick));
                    }
                }
            }

            for (int i = 0; i < isStick.Length; i++)
                if (isStick[i] == 0)
                    incompleteGluingRes.Add(SDNF[i]);

            return incompleteGluing;
        }

        static void Print(List<string> SDNF, string mesagge)
        {
            if (SDNF.Count == 0)
                return;

            Console.Write(mesagge);

            for (int k = 0; k < SDNF.Count - 1; k++)
                Console.Write("(" + SDNF[k] + ")" + " v ");

            Console.Write("(" + SDNF[SDNF.Count - 1] + ")");
        }

        public static List<string> incompleteGluingRes = new List<string>();
        public static List<string> minFunc = new List<string>();

        static string[,] GetTableForMinimal(List<string> SDNF, List<string> MDNF)
        {
            string[,] TableForMIn = new string[MDNF.Count + 1, SDNF.Count + 1];

            List<string> tempAr1 = new List<string>(3);
            List<string> tempAr2 = new List<string>(3);

            TableForMIn[0, 0] = "*";
            for (int i = 1; i < TableForMIn.GetLength(0); i++)
                TableForMIn[i, 0] = MDNF[i - 1];

            for (int i = 1; i < TableForMIn.GetLength(1); i++)
                TableForMIn[0, i] = SDNF[i - 1];

            for (int i = 1; i < TableForMIn.GetLength(0); i++)
                for (int j = 1; j < TableForMIn.GetLength(1); j++)
                    TableForMIn[i, j] = "  0  ";

            for (int i = 1; i < TableForMIn.GetLength(0); i++)
            {
                tempAr1 = GetListOneMinterm(TableForMIn[i, 0]);

                for (int j = 1; j < TableForMIn.GetLength(1); j++)
                {
                    tempAr2 = GetListOneMinterm(TableForMIn[0, j]);

                    if (CheckMinimal(FillAtForStickForMinimal(tempAr1, tempAr2), tempAr1.Count))
                        TableForMIn[i, j] = "  1  ";
                }
            }

            Console.WriteLine("\n\nТаблица импликант:");
            Console.WriteLine(new string('-', TableForMIn.GetLength(1) * 9 + 1));
            for (int i = 0; i < TableForMIn.GetLength(0); i++)
            {
                int countStrings = 0;

                for (int j = 0; j < TableForMIn.GetLength(1); j++)
                {
                    Console.Write("|{0,8}", TableForMIn[i, j]);

                    countStrings += 9;
                }

                Console.Write("|\n");
                Console.WriteLine(new string('-', countStrings + 1));
            }

            return TableForMIn;
        }

        static bool ifFullMinFuncTable(string[,] TableForMIn2)
        {
            bool isFull = false;
            for (int i = 0; i < TableForMIn2.GetLength(1); i++)
                if (TableForMIn2[1, i] == "   0  ")
                    isFull = false;
                else
                    isFull = true;

            return isFull;
        }

        static void GetMDNF(string[,] TableForMIn)
        {
            string[,] TableForMIn2 = new string[2, TableForMIn.GetLength(1) - 1];

            int countOne = 0;
            int indexMin = 0;

            for (int i = 0; i < TableForMIn2.GetLength(1); i++)
                TableForMIn2[0, i] = TableForMIn[0, i + 1];

            for (int i = 0; i < TableForMIn2.GetLength(1); i++)
                TableForMIn2[1, i] = "   0  ";

            while (!ifFullMinFuncTable(TableForMIn2))
                for (int i = 1; i < TableForMIn.GetLength(1); i++)
                {
                    countOne = 0;

                    for (int j = 1; j < TableForMIn.GetLength(0); j++)
                        if (TableForMIn[j, i] == "  1  ")
                        {
                            countOne++;
                            indexMin = j;
                        }

                    if (countOne == 1)
                    {
                        minFunc.Add(TableForMIn[indexMin, 0]);

                        for (int k = 1; k < TableForMIn.GetLength(1); k++)
                            if (TableForMIn[indexMin, k] == "  1  ")
                                TableForMIn2[1, k - 1] = "   1  ";
                    }
                    else if (countOne != 1 && TableForMIn2[1, i - 1] != "   1  ")
                    {
                        minFunc.Add(TableForMIn[indexMin, 0]);

                        for (int k = 1; k < TableForMIn.GetLength(1); k++)
                            if (TableForMIn[indexMin, k] == "  1  ")
                                TableForMIn2[1, k - 1] = "   1  ";
                    }

                }
        }

        static void Main(string[] args)
        {
            char[,] truthTable = CreateTable(new char[17, 5]);
            PrintTable(truthTable);

            List<string> SDNF = SdnfToLetters(GetSDNF(truthTable));
            Print(SDNF, "\nСДНФ:\n");

            List<string> incompleteGluingDistinct = SkleikaLevel3(GetSDNF(truthTable), new List<string>()).Distinct().ToList();
            Print(incompleteGluingDistinct, "\n\nСклейка:\n");

            List<string> incompleteGluingStick2Disint = new List<string>();

            if (incompleteGluingDistinct.Count > 1)
            {
                incompleteGluingStick2Disint = StickTogether2(incompleteGluingDistinct, new List<string>()).Distinct().ToList();
                Print(incompleteGluingStick2Disint, "\nСклейка:\n");
            }
            else if (incompleteGluingDistinct.Count == 1)
                incompleteGluingRes.Add(incompleteGluingDistinct[0]);

            if (incompleteGluingStick2Disint.Count > 1)
            {
                List<string> incompleteGluingStick3Distinct = StickTogether1(incompleteGluingStick2Disint, new List<string>()).Distinct().ToList();
                Print(incompleteGluingStick3Distinct, "\nСклейка:\n");
            }
            else if (incompleteGluingStick2Disint.Count == 1)
                incompleteGluingRes.Add(incompleteGluingStick2Disint[0]);

            incompleteGluingRes = incompleteGluingRes.Distinct().ToList();
            GetMDNF(GetTableForMinimal(SDNF, incompleteGluingRes));

            minFunc = minFunc.Distinct().ToList();
            Print(minFunc, "\nМДНФ:\n");

            Console.WriteLine();
            Console.ReadKey();
        }

    }

}