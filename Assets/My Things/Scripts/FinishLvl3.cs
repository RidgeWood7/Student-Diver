using UnityEngine;
using UnityEngine.Events;

public class FinishLvl3 : MonoBehaviour
{
    public UnityEvent OnFinish;

    void Start()
    {
        LevelData.UnlockTest();
        OnFinish.Invoke();
        FunFacts.LoadScene("Main Menu");
    }
}
