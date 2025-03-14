using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HW1;
namespace hungarianTest
{
    [TestClass]
    public class hgAlgorithmTest
    {
        int i;
        int j;

        [TestMethod]
        public void testValidMax1()//Test with valid input and Max
        {
            bool flag = true;
            /*buid matrix*/
            int[] a = { 1, 2, 3, 4 };
            int[] b = { 5, 6, 7, 8 };
            int[] c = { 9, 10, 11, 12 };
            int[] d = { 13, 14, 15, 16 };
            int[][] toTest = { a, b, c, d };
            int[][] result = hungarian.hgAlgorithm(toTest, "max");//Call the function we check with relevant parameters 
            int[][] expectedMat = { new int[] { 0, 0 }, new int[] { 1, 1 }, new int[] { 2, 2 }, new int[] { 3, 3 } };//The expected result
            /*
            in this loop the function compare expectedMat to resault
            If different set flaf to false
            */
            for (i = 0; i < 4; i++)
            {
                for (j = 0; j < 2; j++)
                {
                    if (result[i][j] != expectedMat[i][j])
                    {
                        flag = false;
                    }
                }
            }
            Assert.IsTrue(flag);//If flag is falsethe the test failed
        }

        [TestMethod]
        public void testValidMin1()//Test with valid input and min
        {
            bool flag = true;
            /*build matrix*/
            int[] a = { 1, 2, 3, 4 };
            int[] b = { 5, 6, 7, 8 };
            int[] c = { 9, 10, 11, 12 };
            int[] d = { 13, 14, 15, 16 };
            int[][] toTest = { a, b, c, d };
            int[][] result = hungarian.hgAlgorithm(toTest, "min");//Call the function we check with relevant parameters 
            int[][] expectedMat = { new int[] { 0, 0 }, new int[] { 1, 1 }, new int[] { 2, 2 }, new int[] { 3, 3 } };//The expected result
                                                                                                                     /*
                                                                                                                    in this loop the function compare expectedMat to resault
                                                                                                                    If different set flaf to false
                                                                                                                    */
            for (i = 0; i < 4; i++)
            {
                for (j = 0; j < 2; j++)
                {
                    if (result[i][j] != expectedMat[i][j])
                    {
                        flag = false;
                    }
                }
            }
            Assert.IsTrue(flag);//If flag is falsethe the test failed
        }

        [TestMethod]
        public void testValidMin2()//Test with valid input and min
        {
            bool flag = true;
            /*build matrix*/
            int[] a = { 1, 10 };
            int[] b = { 1, 1};
            int[][] toTest = { a, b};
            int[][] result = hungarian.hgAlgorithm(toTest, "min");//Call the function we check with relevant parameters 
            int[][] expectedMat = { new int[] { 0, 0 }, new int[] { 1, 1 }};//The expected result
                                                                                                                     /*
                                                                                                                    in this loop the function compare expectedMat to resault
                                                                                                                    If different set flaf to false
                                                                                                                    */
            for (i = 0; i < 2; i++)
            {
                for (j = 0; j < 2; j++)
                {
                    if (result[i][j] != expectedMat[i][j])
                    {
                        flag = false;
                    }
                }
            }
            Assert.IsTrue(flag);//If flag is falsethe the test failed
        }

        [TestMethod]
        public void testValidMax2()//Test with valid input and min
        {
            bool flag = true;
            /*build matrix*/
            int[] a = { 1, 10 };
            int[] b = { 1, 1 };
            int[][] toTest = { a, b };
            int[][] result = hungarian.hgAlgorithm(toTest, "min");//Call the function we check with relevant parameters 
            int[][] expectedMat = { new int[] { 0, 0 }, new int[] { 1, 1 } };//The expected result
                                                                             /*
                                                                            in this loop the function compare expectedMat to resault
                                                                            If different set flaf to false
                                                                            */
            for (i = 0; i < 2; i++)
            {
                for (j = 0; j < 2; j++)
                {
                    if (result[i][j] != expectedMat[i][j])
                    {
                        flag = false;
                    }
                }
            }
            Assert.IsTrue(flag);//If flag is falsethe the test failed
        }

        [TestMethod]
        public void testZeroMatrixMin()//Test with zero matrix  and min
        {
            bool flag = true;
            /*buid matrix*/
            int[] a = { 0, 0, 0 };
            int[] b = { 0, 0, 0 };
            int[] c = { 0, 0, 0 };
            int[][] toTest = { a, b, c };
            int[][] result = hungarian.hgAlgorithm(toTest, "min");//Call the function we check with relevant parameters 
            int[][] expectedMat = { new int[] { 0, 0 }, new int[] { 1, 1 }, new int[] { 2, 2 } };//The expected result
                                                                                                 /*
                                                                                                in this loop the function compare expectedMat to resault
                                                                                                If different set flaf to false
                                                                                                */
            for (i = 0; i < 3; i++)
            {
                for (j = 0; j < 2; j++)
                {
                    if (result[i][j] != expectedMat[i][j])
                    {
                        flag = false;
                    }
                }
            }
            Assert.IsTrue(flag);//If flag is falsethe the test failed
        }

        [TestMethod]
        public void testZeroMatrixMax()//Test with zero matrix  and max
        {
            bool flag = true;
            /*buid matrix*/
            int[] a = { 0, 0, 0 };
            int[] b = { 0, 0, 0 };
            int[] c = { 0, 0, 0 };
            int[][] toTest = { a, b, c };
            int[][] result = hungarian.hgAlgorithm(toTest, "max");//Call the function we check with relevant parameters 
            int[][] expectedMat = { new int[] { 0, 0 }, new int[] { 1, 1 }, new int[] { 2, 2 } };//The expected result
                                                                                                 /*
                                                                                                in this loop the function compare expectedMat to resault
                                                                                                If different set flaf to false
                                                                                                */
            for (i = 0; i < 3; i++)
            {
                for (j = 0; j < 2; j++)
                {
                    if (result[i][j] != expectedMat[i][j])
                    {
                        flag = false;
                    }
                }
            }
            Assert.IsTrue(flag);//If flag is falsethe the test failed
        }
        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void emptyMatrixMax()//Test with empty matrix(not NULL)  and max
        {
            bool flag = true;
            /*buid matrix*/
            int[] a = { };
            int[] b = { };
            int[] c = { };
            int[][] toTest = { a, b, c };
            int[][] result = hungarian.hgAlgorithm(toTest, "max");//Call the function we check with relevant parameters 
            Assert.Fail("Exception hasn't been thrown");//The test fail if IndexOutOfRangeException hasn't been thrown
        }
        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void emptyMatrixMin()//Test with empty matrix(not NULL)  and min
        {
            bool flag = true;
            /*buid matrix*/
            int[] a = { };
            int[] b = { };
            int[] c = { };
            int[][] toTest = { a, b, c };
            int[][] result = hungarian.hgAlgorithm(toTest, "min");//Call the function we check with relevant parameters 
            Assert.Fail("Exception hasn't been thrown");//The test fail if IndexOutOfRangeException hasn't been thrown
        }


        [TestMethod]
        public void testSameValueMin()//Test with matrix where all values are equal  and min
        {
            bool flag = true;
            /*buid matrix*/
            int[] a = { 1, 1, 1 };
            int[] b = { 1, 1, 1 };
            int[] c = { 1, 1, 1 };
            int[][] toTest = { a, b, c };
            int[][] result = hungarian.hgAlgorithm(toTest, "min");//Call the function we check with relevant parameters 
            int[][] expectedMat = { new int[] { 0, 0 }, new int[] { 1, 1 }, new int[] { 2, 2 } };//The expected result
            /*
            in this loop the function compare expectedMat to resault
            If different set flaf to false
            */
            for (i = 0; i < 3; i++)
            {
                for (j = 0; j < 2; j++)
                {
                    if (result[i][j] != expectedMat[i][j])
                    {
                        flag = false;
                    }
                }
            }
            Assert.IsTrue(flag);
        }

        [TestMethod]
        public void testSameValueMax()//Test with matrix where all values are equal  and max
        {
            bool flag = true;
            /*buid matrix*/
            int[] a = { 1, 1, 1 };
            int[] b = { 1, 1, 1 };
            int[] c = { 1, 1, 1 };
            int[][] toTest = { a, b, c };
            int[][] result = hungarian.hgAlgorithm(toTest, "max");//Call the function we check with relevant parameters 
            int[][] expectedMat = { new int[] { 0, 0 }, new int[] { 1, 1 }, new int[] { 2, 2 } };//The expected result
            /*
           in this loop the function compare expectedMat to resault
           If different set flaf to false
           */
            for (i = 0; i < 3; i++)
            {
                for (j = 0; j < 2; j++)
                {
                    if (result[i][j] != expectedMat[i][j])
                    {
                        flag = false;
                    }
                }
            }
            Assert.IsTrue(flag);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void NullMatrixMin()//Test with null as matrix   and min
        {

            int[][] result = hungarian.hgAlgorithm(null, "min");//Call the function we check with relevant parameters 
            Assert.Fail("Exception hasn't been thrown");//The test fail if NullReferenceException hasn't been thrown
        }
        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void NullMatrixMax()//Test with null as matrix   and max
        {

            int[][] result = hungarian.hgAlgorithm(null, "max");//Call the function we check with relevant parameters 
            Assert.Fail("Exception hasn't been thrown");//The test fail if NullReferenceException hasn't been thrown
        }

        
    }
}
