﻿using System;
using System.IO;
using System.Reflection;
using System.Text;
using NUnit.Framework;

namespace GildedRose
{
    [TestFixture]
    public class ApprovalTest
    {
        [Test]
        public void ThirtyDays()
        {
            var lines = File.ReadAllLines(GetExecutingDirectory() + "\\ThirtyDays.txt");

            StringBuilder fakeoutput = new StringBuilder();
            Console.SetOut(new StringWriter(fakeoutput));
            Console.SetIn(new StringReader("a\n"));

            Program.Main(new string[] { });
	        String output = fakeoutput.ToString().Replace("\r", "");

            var outputLines = output.Split('\n');
            for(var i = 0; i<Math.Min(lines.Length, outputLines.Length); i++) 
            {
                Assert.AreEqual(lines[i], outputLines[i]);
            }
        }

	    private static string GetExecutingDirectory()
	    {
		    return Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
	    }
	}
}
