using UnityEngine;

public class FinishLvl2 : MonoBehaviour
{
    void Start()
    {
        LevelData.UnlockLvl3();
        FunFacts.LoadScene("Main Menu");
    }
}
