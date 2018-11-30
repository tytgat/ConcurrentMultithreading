using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;



namespace MatrixMult
{
    class Program
    {
        public static int MATWIDTH = 100;
        public static int MATHEIGHT = 100;

        
        public static int nbOfExec = 30;

        static void Main(string[] args) {
            /** With Thread **/
            bool useThread = true;
            double avgExecTimeThread = launchTry(useThread);

            /** No Thread **/
            useThread = false;
            double avgExecTimeNoThread = launchTry(useThread);

            /** Total **/
            Console.WriteLine("   Thread Execution Time : " + avgExecTimeThread);
            Console.WriteLine("No Thread Execution Time : " + avgExecTimeNoThread);
        }

        public static double launchTry(bool useThread)
        {
            double avgExecTime = 0;
            for (int i = 0; i < nbOfExec; i++)
            {
                avgExecTime += multiplyMatrix(useThread);
            }
            avgExecTime /= nbOfExec;
            return avgExecTime;
        }

        public static double multiplyMatrix(bool useThread)
        {
            double execTime = 0;
            var watch = System.Diagnostics.Stopwatch.StartNew();
            
            int maxSize = Math.Max(MATWIDTH, MATHEIGHT);
            int minSize = Math.Min(MATWIDTH, MATHEIGHT);

            Thread[] threadList = new Thread[maxSize];

            double[][] m1 = generateMatrix(minSize, maxSize);
            double[][] m2 = generateMatrix(maxSize, minSize);

            double[][] matFinal = new double[maxSize][];

            for (int i = 0; i < maxSize; i++)
            {
                matFinal[i] = new double[maxSize];

                double[] row = m2[i];
                double[] column = getColumnFromMat(m2, i);
                
                object[] o = new object[4];
                o[0] = matFinal;
                o[1] = row;
                o[2] = m1;
                o[3] = i;

                if (useThread)
                {
                    Thread t = new Thread(computeOneColumn);
                    t.Start(o);
                    threadList[i] = t;
                }
                else
                {
                    computeOneColumn(o);
                }
            }

            if (useThread)
            {
                foreach (Thread t in threadList)
                {
                    t.Join();
                }
            }

            /*Console.WriteLine("m1");
            printMat(m1);
            Console.WriteLine("m2");
            printMat(m2);
            Console.WriteLine("matFinal");
            printMat(matFinal);*/
            watch.Stop();
            execTime = watch.ElapsedMilliseconds;

            return execTime;
        }


        public static void computeOneColumn(Object o)
        {
            //Console.WriteLine("Start");
            object[] obj = (object[])o;
            double[][] matFinal = (double[][])obj[0];
            double[] row = (double[])obj[1];
            double[][] matrix = (double[][])obj[2];
            int index = (int)obj[3];

            if(row.Length != matrix.Length)
            {
                return;
            }

            for (int i = 0; i < matFinal[0].Length; i++) {
                double value = 0;
                for (int j = 0; j < row.Length; j++) {
                    value += matrix[j][i] * row[j];
                }
                matFinal[index][i] = value;
            }

            //Console.WriteLine("End");
        }


        public static double[][] generateMatrix(int width, int height)
        {
            double[][] matrix = new double[width][];
            Random r = new Random();

            for(int i = 0; i < width; i++)
            {
                matrix[i] = new double[height];
                for(int j = 0; j < height; j++)
                {
                    matrix[i][j] = Math.Round(r.NextDouble() * 100,2);
                }
            }

            return matrix;
        }

        public static double[] getColumnFromMat(double[][] mat, int columnNumber)
        {
            if(mat.Length< 0)
            {
                return null;
            }
            double[] column = new double[mat[0].Length];
            for(int i = 0; i < column.Length; i++)
            {
                column[i] = mat[columnNumber][i];
            }
            return column;
        }

        public static void printMat(double[][] mat)
        {
            Console.WriteLine("[");
            for (int i = 0; i < mat.Length; i++)
            {
                Console.Write("[");
                for (int j = 0; j < mat[i].Length; j++)
                {
                    Console.Write(mat[i][j] + ",\t");
                }
                Console.WriteLine("]");
            }
            Console.WriteLine("]");
        }
    }
}
