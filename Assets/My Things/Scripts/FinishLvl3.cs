using UnityEngine;

public class FinishLvl3 : MonoBehaviour
{
    void Start()
    {
        LevelData.UnlockTest();
        FunFacts.LoadScene("Main Menu");
    }
}
