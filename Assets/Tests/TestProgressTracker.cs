using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class TestProgressTracker
{
    // Runs before every single test case
    [SetUp]
    public void ResetState()
    {
        //resets field to all false
        ProgressTracker.completed = new bool[] {false, false, false, false, false}; 
    }

    // tests for method ResetArray
    [TestCase(new bool[] {true, false, false, false, false}, 
        TestName = "boundary case: first index true")] 
    [TestCase(new bool[] {false, false, false, false, true}, 
        TestName = "boundary case: last index true")] 
    [TestCase(new bool[] {false, false, true, false, false}, 
        TestName = "nominal value case: middle index true")] 
    [TestCase(new bool[] {false, false, false, false, false}, 
        TestName = "nominal value case: all index false")] 
    [TestCase(new bool[] {true, true, true, true, true}, 
        TestName = "nominal value case: all index true")] 
    public void testResetArray(bool[] mockArray)
    {
        // set up expected end array values
        bool[] expected = new bool[] {false, false, false, false, false};
        // set up the array to test
        ProgressTracker.completed = mockArray;

        // runs the method
        ProgressTracker.ResetArray();

        // check that the changes to the array meet the expected changes
        Assert.AreEqual(expected, ProgressTracker.completed);
    }

    // tests for method MarkComplete
    [TestCase(0, new bool[] {true, false, false, false, false}, 
        TestName = "boundary case: change first index")] 
    [TestCase(4, new bool[] {false, false, false, false, true}, 
        TestName = "boundary case: change last index")] 
    [TestCase(2, new bool[] {false, false, true, false, false}, 
        TestName = "nominal value case: change middle index")] 
    [TestCase(-1, new bool[] {false, false, false, false, false}, 
        TestName = "negative test: use index < 0")] 
    [TestCase(5, new bool[] {false, false, false, false, false}, 
        TestName = "negative test: use index > end of array")] 
    public void testMarkComplete(int index, bool[] expected)
    {
        // runs the method
        ProgressTracker.MarkComplete(index);

        // check that the changes to the array meet the expected changes
        Assert.AreEqual(expected, ProgressTracker.completed);
    }

    // tests for method IsComplete
    [TestCase(0, true, TestName = "boundary case: return first index")] 
    [TestCase(4, true, TestName = "boundary case: return last index")] 
    [TestCase(2, true, TestName = "nominal value case: return middle index")] 
    [TestCase(-1, false, TestName = "negative test: return index < 0")] 
    [TestCase(5, false, TestName = "negative test: return index > end of array")] 
    public void testIsComplete(int index, bool expected)
    {
        // set up the array to test
        ProgressTracker.completed = new bool[] {true, false, true, false, true};

        // check that the values match
        Assert.AreEqual(expected, ProgressTracker.IsComplete(index));
    }

    // tests for method LevelComplete
    [TestCase(new bool[] {false, true, true, true, true}, false,
        TestName = "boundary case: first index false")] 
    [TestCase(new bool[] {true, true, true, true, false}, false, 
        TestName = "boundary case: last index false")] 
    [TestCase(new bool[] {true, true, false, true, true}, false,
        TestName = "nominal value case: middle index false")] 
    [TestCase(new bool[] {false, false, false, false, false}, false, 
        TestName = "nominal value case: all index false")] 
    [TestCase(new bool[] {true, true, true, true, true}, true, 
        TestName = "nominal value case: all index true")] 
    public void testLevelComplete(bool[] mockArray, bool expected)
    {
        // set up the array to test
        ProgressTracker.completed = mockArray;

        // check that the values match
        Assert.AreEqual(expected, ProgressTracker.LevelComplete());
    }
}
