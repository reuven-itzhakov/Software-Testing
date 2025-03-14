using System;
using System.Collections.Generic;
using System.Text;

namespace HW1
{
    public class hungarian
    {
        //**********************************//
        //METHODS OF THE HUNGARIAN ALGORITHM//
        //**********************************//

        public static int[][] hgAlgorithm(int[][] array, String sumType)
        {
            int[][] cost = array;   //Create the cost matrix

            if (sumType.ToLower().Equals("max"))    //Then array is weight array. Must change to cost.
            {
                int maxWeight = findLargest(cost);
                for (int i = 0; i < cost.Length; i++)       //Generate cost by subtracting.
                {
                    for (int j = 0; j < cost[i].Length; j++)
                    {
                        cost[i][j] = (maxWeight - cost[i][j]);
                    }
                }
            }
            int maxCost = findLargest(cost);        //Find largest cost matrix element (needed for step 6).

            int[][] mask = new int[cost.Length][];
            for (int Array0 = 0; Array0 < cost.Length; Array0++)
            {
                mask[Array0] = new int[cost[0].Length];
            }   //The mask array.
            int[] rowCover = new int[cost.Length];                  //The row covering vector.
            int[] colCover = new int[cost[0].Length];               //The column covering vector.
            int[] zero_RC = new int[2];                             //Position of last zero from Step 4.
            int step = 1;
            bool done = false;
            while (done == false)   //main execution loop
            {
                switch (step)
                {
                    case 1:
                        step = hg_step1(step, cost);
                        break;
                    case 2:
                        step = hg_step2(step, cost, mask, rowCover, colCover);
                        break;
                    case 3:
                        step = hg_step3(step, mask, colCover);
                        break;
                    case 4:
                        step = hg_step4(step, cost, mask, rowCover, colCover, zero_RC);
                        break;
                    case 5:
                        step = hg_step5(step, mask, rowCover, colCover, zero_RC);
                        break;
                    case 6:
                        step = hg_step6(step, cost, rowCover, colCover, maxCost);
                        break;
                    case 7:
                        done = true;
                        break;
                }
            }//end while

            int[][] assignment = new int[array.Length][];
            for (int Array0 = 0; Array0 < array.Length; Array0++)
            {
                assignment[Array0] = new int[2];
            }
            for (int i = 0; i < mask.Length; i++)
            {
                for (int j = 0; j < mask[i].Length; j++)
                {
                    if (mask[i][j] == 1)
                    {
                        assignment[i][0] = i;
                        assignment[i][1] = j;
                    }
                }
            }

            //If you want to return the min or max sum, in your own main method
            //instead of the assignment array, then use the following code:
            /*
            int sum = 0; 
            for (int i=0; i<assignment.Length; i++)
            {
                sum = sum + array[assignment[i][0]][assignment[i][1]];
            }
            return sum;
            */
            //Of course you must also change the header of the method to:
            //public static int hgAlgorithm (int[][] array, String sumType)

            return assignment;
        }
        public static int hg_step1(int step, int[][] cost)
        {
            //What STEP 1 does:
            //For each row of the cost matrix, find the smallest element
            //and subtract it from from every other element in its row. 

            int minval;

            for (int i = 0; i < cost.Length; i++)
            {
                minval = cost[i][0];
                for (int j = 0; j < cost[i].Length; j++)	//1st inner loop finds min val in row.
                {
                    if (minval > cost[i][j])
                    {
                        minval = cost[i][j];
                    }
                }
                for (int j = 0; j < cost[i].Length; j++)	//2nd inner loop subtracts it.
                {
                    cost[i][j] = cost[i][j] - minval;
                }
            }

            step = 2;
            return step;
        }
        public static int hg_step2(int step, int[][] cost, int[][] mask, int[] rowCover, int[] colCover)
        {
            //What STEP 2 does:
            //Marks uncovered zeros as starred and covers their row and column.

            for (int i = 0; i < cost.Length; i++)
            {
                for (int j = 0; j < cost[i].Length; j++)
                {
                    if ((cost[i][j] == 0) && (colCover[j] == 0) && (rowCover[i] == 0))
                    {
                        mask[i][j] = 1;
                        colCover[j] = 1;
                        rowCover[i] = 1;
                    }
                }
            }

            clearCovers(rowCover, colCover);    //Reset cover vectors.

            step = 3;
            return step;
        }
        public static int hg_step3(int step, int[][] mask, int[] colCover)
        {
            //What STEP 3 does:
            //Cover columns of starred zeros. Check if all columns are covered.

            for (int i = 0; i < mask.Length; i++)	//Cover columns of starred zeros.
            {
                for (int j = 0; j < mask[i].Length; j++)
                {
                    if (mask[i][j] == 1)
                    {
                        colCover[j] = 1;
                    }
                }
            }

            int count = 0;
            for (int j = 0; j < colCover.Length; j++)	//Check if all columns are covered.
            {
                count = count + colCover[j];
            }

            if (count <= mask.Length)	//Should be cost.Length but ok, because mask has same dimensions.	
            {
                step = 7;
            }
            else
            {
                step = 4;
            }

            return step;
        }
        public static int hg_step4(int step, int[][] cost, int[][] mask, int[] rowCover, int[] colCover, int[] zero_RC)
        {
            //What STEP 4 does:
            //Find an uncovered zero in cost and prime it (if none go to step 6). Check for star in same row:
            //if yes, cover the row and uncover the star's column. Repeat until no uncovered zeros are left
            //and go to step 6. If not, save location of primed zero and go to step 5.

            int[] row_col = new int[2];	//Holds row and col of uncovered zero.
            bool done = false;
            while (done == false)
            {
                row_col = findUncoveredZero(row_col, cost, rowCover, colCover);
                if (row_col[0] == -1)
                {
                    done = true;
                    step = 6;
                }
                else
                {
                    mask[row_col[0]][row_col[1]] = 2;   //Prime the found uncovered zero.

                    bool starInRow = false;
                    for (int j = 0; j < mask[row_col[0]].Length; j++)
                    {
                        if (mask[row_col[0]][j] == 1)		//If there is a star in the same row...
                        {
                            starInRow = true;
                            row_col[1] = j;		//remember its column.
                        }
                    }

                    if (starInRow == true)
                    {
                        rowCover[row_col[0]] = 1;	//Cover the star's row.
                        colCover[row_col[1]] = 0;	//Uncover its column.
                    }
                    else
                    {
                        zero_RC[0] = row_col[0];	//Save row of primed zero.
                        zero_RC[1] = row_col[1];	//Save column of primed zero.
                        done = true;
                        step = 5;
                    }
                }
            }

            return step;
        }
        public static int[] findUncoveredZero	//Aux 1 for hg_step4.
        (int[] row_col, int[][] cost, int[] rowCover, int[] colCover)
        {
            row_col[0] = -1;	//Just a check value. Not a real index.
            row_col[1] = 0;

            int i = 0; bool done = false;
            while (done == false)
            {
                int j = 0;
                while (j < cost[i].Length)
                {
                    if (cost[i][j] == 0 && rowCover[i] == 0 && colCover[j] == 0)
                    {
                        row_col[0] = i;
                        row_col[1] = j;
                        done = true;
                    }
                    j = j + 1;
                }//end inner while
                i = i + 1;
                if (i >= cost.Length)
                {
                    done = true;
                }
            }//end outer while

            return row_col;
        }
        public static int hg_step5(int step, int[][] mask, int[] rowCover, int[] colCover, int[] zero_RC)
        {
            //What STEP 5 does:	
            //Construct series of alternating primes and stars. Start with prime from step 4.
            //Take star in the same column. Next take prime in the same row as the star. Finish
            //at a prime with no star in its column. Unstar all stars and star the primes of the
            //series. Erasy any other primes. Reset covers. Go to step 3.

            int count = 0;                                              //Counts rows of the path matrix.
            int[][] path = new int[(mask[0].Length * mask.Length)][];
            for (int Array0 = 0; Array0 < (mask[0].Length * mask.Length); Array0++)
            {
                path[Array0] = new int[2];
            }   //Path matrix (stores row and col).
            path[count][0] = zero_RC[0];                                //Row of last prime.
            path[count][1] = zero_RC[1];                                //Column of last prime.

            bool done = false;
            while (done == false)
            {
                int r = findStarInCol(mask, path[count][1]);
                if (r >= 0)
                {
                    count = count + 1;
                    path[count][0] = r;                 //Row of starred zero.
                    path[count][1] = path[count - 1][1];    //Column of starred zero.
                }
                else
                {
                    done = true;
                }

                if (done == false)
                {
                    int c = findPrimeInRow(mask, path[count][0]);
                    count = count + 1;
                    path[count][0] = path[count - 1][0];    //Row of primed zero.
                    path[count][1] = c;                 //Col of primed zero.
                }
            }//end while

            convertPath(mask, path, count);
            clearCovers(rowCover, colCover);
            erasePrimes(mask);

            step = 3;
            return step;

        }
        public static int findStarInCol			//Aux 1 for hg_step5.
        (int[][] mask, int col)
        {
            int r = -1;	//Again this is a check value.
            for (int i = 0; i < mask.Length; i++)
            {
                if (mask[i][col] == 1)
                {
                    r = i;
                }
            }

            return r;
        }
        public static int findPrimeInRow		//Aux 2 for hg_step5.
        (int[][] mask, int row)
        {
            int c = -1;
            for (int j = 0; j < mask[row].Length; j++)
            {
                if (mask[row][j] == 2)
                {
                    c = j;
                }
            }

            return c;
        }
        public static void convertPath			//Aux 3 for hg_step5.
        (int[][] mask, int[][] path, int count)
        {
            for (int i = 0; i <= count; i++)
            {
                if (mask[(path[i][0])][(path[i][1])] == 1)
                {
                    mask[(path[i][0])][(path[i][1])] = 0;
                }
                else
                {
                    mask[(path[i][0])][(path[i][1])] = 1;
                }
            }
        }
        public static void erasePrimes			//Aux 4 for hg_step5.
        (int[][] mask)
        {
            for (int i = 0; i < mask.Length; i++)
            {
                for (int j = 0; j < mask[i].Length; j++)
                {
                    if (mask[i][j] == 2)
                    {
                        mask[i][j] = 0;
                    }
                }
            }
        }
        public static void clearCovers			//Aux 5 for hg_step5 (and not only).
        (int[] rowCover, int[] colCover)
        {
            for (int i = 0; i < rowCover.Length; i++)
            {
                rowCover[i] = 0;
            }
            for (int j = 0; j < colCover.Length; j++)
            {
                colCover[j] = 0;
            }
        }
        public static int hg_step6(int step, int[][] cost, int[] rowCover, int[] colCover, int maxCost)
        {
            //What STEP 6 does:
            //Find smallest uncovered value in cost: a. Add it to every element of covered rows
            //b. Subtract it from every element of uncovered columns. Go to step 4.

            int minval = findSmallest(cost, rowCover, colCover, maxCost);

            for (int i = 0; i < rowCover.Length; i++)
            {
                for (int j = 0; j < colCover.Length; j++)
                {
                    if (rowCover[i] == 1)
                    {
                        cost[i][j] = cost[i][j] + minval;
                    }
                    if (colCover[j] == 0)
                    {
                        cost[i][j] = cost[i][j] - minval;
                    }
                }
            }

            step = 4;
            return step;
        }
        public static int findSmallest		//Aux 1 for hg_step6.
        (int[][] cost, int[] rowCover, int[] colCover, int maxCost)
        {
            int minval = maxCost;				//There cannot be a larger cost than this.
            for (int i = 0; i < cost.Length; i++)		//Now find the smallest uncovered value.
            {
                for (int j = 0; j < cost[i].Length; j++)
                {
                    if (rowCover[i] == 0 && colCover[j] == 0 && (minval > cost[i][j]))
                    {
                        minval = cost[i][j];
                    }
                }
            }

            return minval;
        }

        //***********//
        //MAIN METHOD//
        //***********//

        public static void Main(String[] args)
        {
            //Below enter "max" or "min" to find maximum sum or minimum sum assignment.
            String sumType = "max";

            //Hard-coded example.
            int[][] array =
            {
                new int[]{1, 2, 3},
                   new int[]{2, 4, 6},
                new int[]{3, 6, 9}
            };


            //<COMMENT> TO AVOID PRINTING THE MATRIX FOR WHICH THE ASSIGNMENT IS CALCULATED

            Console.Write("The matrix is:");
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                { Console.Write("{0}\t", array[i][j]); }
                Console.Write("");
            }
            Console.Write("");
            //</COMMENT>*/

            long startTime = DateTime.Now.Ticks;
            int[][] assignment = new int[array.Length][];
            for (int Array0 = 0; Array0 < array.Length; Array0++)
            {
                assignment[Array0] = new int[2];
            }
            assignment = hgAlgorithm(array, sumType);   //Call Hungarian algorithm.
            long endTime = DateTime.Now.Ticks;

            Console.Write("\n\nThe winning assignment (" + sumType + " sum) is:\n");
            int sum = 0;
            for (int i = 0; i < assignment.Length; i++)
            {
                //<COMMENT> to avoid printing the elements that make up the assignment

                Console.Write("array({0},{1}) = {2}\n", (assignment[i][0] + 1), (assignment[i][1] + 1),
                        array[assignment[i][0]][assignment[i][1]]);
                sum = sum + array[assignment[i][0]][assignment[i][1]];
                //</COMMENT>
            }

            Console.Write("\nThe {0} is: {1}\n", sumType, sum);
            Console.Write("Time elapsed:");
            Console.Write((endTime - startTime) / 1000000000.0);
            Console.ReadLine();

        }

        //*******************************************//
        //METHODS THAT PERFORM ARRAY-PROCESSING TASKS//
        //*******************************************//

        public static void generateRandomArray	//Generates random 2-D array.
        (int[][] array, String randomMethod)
        {
            Random generator = new Random(1);
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                {
                    array[i][j] = generator.Next();
                }
            }
        }
        public static int findLargest		//Finds the largest element in a positive array.
        (int[][] array)
        //works for arrays where all values are >= 0.
        {
            int largest = 0;
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                {
                    if (array[i][j] > largest)
                    {
                        largest = array[i][j];
                    }
                }
            }
            Console.Write("\n\nLargest Value {0}: ", largest);
            return largest;
        }
        public static int[][] transpose		//Transposes a int[][] array.
        (int[][] array)
        {
            int[][] transposedArray = new int[array[0].Length][];
            for (int Array0 = 0; Array0 < array[0].Length; Array0++)
            {
                transposedArray[Array0] = new int[array.Length];
            }
            for (int i = 0; i < transposedArray.Length; i++)
            {
                for (int j = 0; j < transposedArray[i].Length; j++)
                { transposedArray[i][j] = array[j][i]; }
            }
            return transposedArray;
        }
        public static int[][] copyOf			//Copies all elements of an array to a new array.
        (int[][] original)
        {
            int[][] copy = new int[original.Length][];
            for (int Array0 = 0; Array0 < original.Length; Array0++)
            {
                copy[Array0] = new int[original[0].Length];
            }
            for (int i = 0; i < original.Length; i++)
            {
                //Need to do it this way, otherwise it copies only memory location
                Array.Copy(original[i], 0, copy[i], 0, original[i].Length);

            }

            return copy;
        }

    }

}