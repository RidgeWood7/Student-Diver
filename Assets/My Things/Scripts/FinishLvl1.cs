using UnityEngine;
using UnityEngine.Events;

public class FinishLvl1 : MonoBehaviour
{
    public UnityEvent OnFinish;

    void Start()
    {
        LevelData.UnlockLvl2();
        OnFinish.Invoke();
        FunFacts.LoadScene("Main Menu");
    }
}
