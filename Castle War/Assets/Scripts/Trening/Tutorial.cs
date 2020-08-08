using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Trening
{
    public static class Tutorial
    {
        public static bool tutorialOn = false;
        private static List<GameObject> tutorialParts = new List<GameObject>();
        private static int indicator = 0;

        public static void UseTutorial()
        {
            tutorialParts.Add(AddTutorialPart("TutorialGoToCastle"));
            tutorialParts.Add(AddTutorialPart("TutorialSmithyClick"));
            //tutorialParts.Add(AddTutorialPart("TutorialSmithyClick"));
            //tutorialParts.Add(AddTutorialPart("TutorialFourPart"));
            //tutorialParts.Add(AddTutorialPart("TutorialFivePart"));
            //tutorialParts.Add(AddTutorialPart("TutorialSixPart"));
            foreach (var item in tutorialParts)
                item.SetActive(false);
            tutorialParts[indicator].SetActive(true);
        }
        public static void Next()
        {
            tutorialParts[indicator].SetActive(false);
            tutorialParts[++indicator].SetActive(true);
        }

        private static GameObject AddTutorialPart(string assetName)
        {
            return GameObject.FindGameObjectWithTag(assetName);
        }

    }
}
