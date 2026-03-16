using UnityEngine;

public class FinishLvl1 : MonoBehaviour
{
    void Start()
    {
        LevelData.UnlockLvl2();
        FunFacts.LoadScene("Main Menu");
    }
}
