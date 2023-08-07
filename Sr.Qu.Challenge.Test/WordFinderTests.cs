using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sr.Qu.Challenge.App;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sr.Qu.Challenge.Test
{
    [TestClass]
    public class WordFinderTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "The matrix is empty.")]
        public void TestNullMatrix()
        {
            WordFinder wordFinder = new WordFinder(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "The matrix rows must have the same lenght.")]
        public void TestMatrixWrongRowLenght()
        {
            List<string> matrix = new List<string>
            {
                "chill",
                "cold",
                "wind"
            };

            WordFinder wordFinder = new WordFinder(matrix);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "The matrix is larger than 64.")]
        public void TestMatrixMaxSize()
        {
            List<string> matrix = new List<string>
            {
                "12345678901234567890123456789012345678901234567890123456789012345",
                "12345678901234567890123456789012345678901234567890123456789012345",
                "12345678901234567890123456789012345678901234567890123456789012345",
                "12345678901234567890123456789012345678901234567890123456789012345",
            };

            WordFinder wordFinder = new WordFinder(matrix);
        }

        [TestMethod]
        public void TestFindWords()
        {
            List<string> matrix = new List<string>
            {
                "chill",
                "coldd",
                "windw"
            };

            List<string> wordstream = new List<string>
            {
                "chill",
                "cold",
                "wind",
                "chill"
            };

            WordFinder wordFinder = new WordFinder(matrix);
            List<string> result = wordFinder.Find(wordstream).ToList();

            List<string> expected = new List<string>
            {
                "chill",
                "cold",
                "wind"
            };

            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestNoWordsFound()
        {
            List<string> matrix = new List<string>
            {
                "chill",
                "coldd",
                "windd"
            };

            List<string> wordstream = new List<string>
            {
                "Nothing",
                "hot",
                "Wand"
            };

            WordFinder wordFinder = new WordFinder(matrix);
            List<string> result = wordFinder.Find(wordstream).ToList();

            Assert.AreEqual(0, result.Count);
        }

        [TestMethod]
        public void TestRepeatedWords()
        {
            List<string> matrix = new List<string>
            {
                "chill",
                "coldd",
                "windd"
            };

            List<string> wordstream = new List<string>
            {
                "chill",
                "chill",
                "cold",
                "wind",
                "wind",
                "chill"
            };

            WordFinder wordFinder = new WordFinder(matrix);
            List<string> result = wordFinder.Find(wordstream).ToList();

            List<string> expected = new List<string>
            {
                "chill",
                "cold",
                "wind"
            };

            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestHighLoad()
        {
            List<string> matrix = new List<string>
            {
                "chillpotmathcarpathrockratpeersickappleorangepapermath",
                "chillpotmathcarpathrockratpeersickappleorangepapermath",
                "colddyellowredgreenscissorsbikeroomcardooropencloseopw",
                "colddyellowredgreenscissorsbikeroomcardooropencloseopw",
                "winddhotroomwaterbottlemousekeyboardpclaptoplenovotest",
                "winddhotroomwaterbottlemousekeyboardpclaptoplenovotest",
                "pancellphonecirclesquareapprangertoyotasubarubmwcrysta",
                "pancellphonecirclesquareapprangertoyotasubarubmwcrysta",
                "clotheschooseshoeshandfeetfootfingerheadbrainhearteyes",
                "clotheschooseshoeshandfeetfootfingerheadbrainhearteyes",
                "houseenglishskippedsecondstookandpmsucceedbuildstarted",
                "houseenglishskippedsecondstookandpmsucceedbuildstarted",
                "startprogramwordfinderviewgiftdebugsearchchallengesolu",
                "startprogramwordfinderviewgiftdebugsearchchallengesolu",
                "anypageclassmethodservertestsexplorerdatefailedstarted",
                "anypageclassmethodservertestsexplorerdatefailedstarted",
                "propertiesreferencesbeyondtoolshelpwindowappreadyandro",
                "propertiesreferencesbeyondtoolshelpwindowappreadyandro",
                "houseenglishskippedsecondstookandpmsucceedbuildstarted",
                "startprogramwordfinderviewgiftdebugsearchchallengesolu",
                "startprogramwordfinderviewgiftdebugsearchchallengesolu",
                "anypageclassmethodservertestsexplorerdatefailedstarted",
                "anypageclassmethodservertestsexplorerdatefailedstarted",
                "propertiesreferencesbeyondtoolshelpwindowappreadyandro",
                "propertiesreferencesbeyondtoolshelpwindowappreadyandro",
                "houseenglishskippedsecondstookandpmsucceedbuildstarted",
                "startprogramwordfinderviewgiftdebugsearchchallengesolu",
                "startprogramwordfinderviewgiftdebugsearchchallengesolu",
                "anypageclassmethodservertestsexplorerdatefailedstarted",
                "anypageclassmethodservertestsexplorerdatefailedstarted",
                "propertiesreferencesbeyondtoolshelpwindowappreadyandro",
                "propertiesreferencesbeyondtoolshelpwindowappreadyandro",
            };

            List<string> wordstream = new List<string>
            {
                "potato",
                "chill",
                "cold",
                "wind",
                "feet",
                "foot",
                "and",
                "google",
                "challenge",
                "oo",
                "verylargewordverylargewordverylargeword",
                "find",
                "exe",
                "run",
                "apple",
                "prop",
                "house",
                "failed",
                "app",
                "notfound",
                "bag",
                "chair",
                "service",
                "sunset",
                "box",
                "facebook",
                "youtube",
                "tiktok",
                "iphone",
                "android",
                "razer",
                "coke",
                "pepsi",
                "microsoft",
                "whatsapp",
                "binance",
                "pokemon",
                "call",
                "Source",
                "Control",
                "Effect",
                "Fire",
                "asdfg",
                "zxcvb",
                "qwetreyryersdad",
                "zxcvnbvn",
                "12466",
                "poiyuty"

            };

            WordFinder wordFinder = new WordFinder(matrix);
            List<string> result = wordFinder.Find(wordstream).ToList();

            List<string> expected = new List<string>
            {
                "oo",
                "app",
                "and",
                "wind",
                "challenge",
                "find",
                "prop",
                "failed",
                "house",
                "chill"
            };

            CollectionAssert.AreEqual(expected, result);
        }
    }
}
