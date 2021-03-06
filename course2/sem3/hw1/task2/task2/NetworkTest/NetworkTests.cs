﻿using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task2;

namespace NetworkTest
{
    public class TestRandom : ICustomRandom
    {
        int ICustomRandom.Random()
        {
            return 0;
        }
    }

    [TestClass]
    public class NetworkTests
    {
        private const string SequencePath = "consequence.txt";
        private const string ParallelPath = "parallel.txt";
        private TestRandom TRand = new TestRandom();

        /// <summary>
        /// Try to initialize network class
        /// </summary>
        [TestMethod]
        public void CreationTest()
        {
            GenerateComputerSequence();
            var network = new Network(SequencePath, TRand);
        }

        /// <summary>
        /// Try to infect a sequence of 3 computers with 100% chance
        /// </summary>
        [TestMethod]
        public void SequenceTest()
        {
            GenerateComputerSequence();
            var network = new Network(SequencePath, TRand);

            string[] state = network.State().Split('\n');
            Assert.IsTrue(IsInfected(state[0]) 
                && !IsInfected(state[1]) 
                && !IsInfected(state[2]));

            network.StartGame();
            state = network.State().Split('\n');
            Assert.IsTrue(IsInfected(state[0]) 
                && IsInfected(state[1]) 
                && IsInfected(state[2]));
        }

        /// <summary>
        /// Try to infect a sequence of 3 computers with 100% chance manually
        /// </summary>
        [TestMethod]
        public void DetailSequenceTest()
        {
            GenerateComputerSequence();
            var network = new Network(SequencePath, TRand);
            string[] state = network.State().Split('\n');

            Assert.IsTrue(IsInfected(state[0]) 
                && !IsInfected(state[1]) 
                && !IsInfected(state[2]));

            network.StartOneCycleOfGame();
            state = network.State().Split('\n');

            Assert.IsTrue(IsInfected(state[0]) 
                && IsInfected(state[1]) 
                && !IsInfected(state[2]));

            network.StartOneCycleOfGame();
            state = network.State().Split('\n');

            Assert.IsTrue(IsInfected(state[0]) 
                && IsInfected(state[1])
                && IsInfected(state[2]));
        }

        /// <summary>
        /// Try to infect parallel computers with 100% chance
        /// </summary>
        [TestMethod]
        public void ParallelTest()
        {
            GenerateComputerParallel();
            var network = new Network(ParallelPath, TRand);
            string[] state = network.State().Split('\n');

            Assert.IsTrue(IsInfected(state[0])
                && !IsInfected(state[1])
                && !IsInfected(state[2])
                && !IsInfected(state[3])
                && !IsInfected(state[4])
                && !IsInfected(state[5])
                && !IsInfected(state[6]));

            network.StartGame();
            state = network.State().Split('\n');

            Assert.IsTrue(IsInfected(state[0])         
                && IsInfected(state[1])
                && IsInfected(state[2])
                && IsInfected(state[3])
                && IsInfected(state[4])
                && IsInfected(state[5])
                && IsInfected(state[6]));
        }

        [TestMethod]
        public void DetailParralelTest()
        {
            GenerateComputerParallel();
            var network = new Network(ParallelPath, TRand);
            string[] state = network.State().Split('\n');

            Assert.IsTrue(IsInfected(state[0])
                          && !IsInfected(state[1])
                          && !IsInfected(state[2])
                          && !IsInfected(state[3])
                          && !IsInfected(state[4])
                          && !IsInfected(state[5])
                          && !IsInfected(state[6]));

            network.StartOneCycleOfGame();
            state = network.State().Split('\n');

            Assert.IsTrue(IsInfected(state[0])
                          && IsInfected(state[1])
                          && IsInfected(state[2])
                          && IsInfected(state[3])
                          && !IsInfected(state[4])
                          && !IsInfected(state[5])
                          && !IsInfected(state[6]));

            network.StartOneCycleOfGame();
            state = network.State().Split('\n');

            Assert.IsTrue(IsInfected(state[0])
                          && IsInfected(state[1])
                          && IsInfected(state[2])
                          && IsInfected(state[3])
                          && IsInfected(state[4])
                          && IsInfected(state[5])
                          && IsInfected(state[6]));
        }

        private void GenerateComputerSequence()
        {
            using (StreamWriter sw = new StreamWriter(SequencePath, false))
            {
                sw.WriteLine(3);
                sw.WriteLine("Windows");
                sw.WriteLine("MacOs");
                sw.WriteLine("Linux");
                sw.WriteLine();
                sw.WriteLine("1");
                sw.WriteLine();
                sw.WriteLine("2");
                sw.WriteLine("1 2");
                sw.WriteLine("2 3");
            }
        }

        private void GenerateComputerParallel()
        {
            using (StreamWriter sw = new StreamWriter(ParallelPath, false))
            {
                sw.WriteLine("7");
                sw.WriteLine("Windows");
                sw.WriteLine("MacOs");
                sw.WriteLine("Linux");
                sw.WriteLine("Linux");
                sw.WriteLine("MacOs");
                sw.WriteLine("MacOs");
                sw.WriteLine("Linux");
                sw.WriteLine();
                sw.WriteLine("1");
                sw.WriteLine();
                sw.WriteLine("6");
                sw.WriteLine("1 2");
                sw.WriteLine("1 3");
                sw.WriteLine("1 4");
                sw.WriteLine("2 5");
                sw.WriteLine("3 6");
                sw.WriteLine("4 7");
            }
        }

        /// <summary>
        /// Returns true if computer is infected
        /// </summary>
        private bool IsInfected(string config)
        {
            //In case of infected computer the length of string is more than 11
            int length = config.Length;
            return length > 11;
        }
    }
}
