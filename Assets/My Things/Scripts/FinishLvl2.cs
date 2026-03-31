using UnityEngine;
using UnityEngine.Events;

public class FinishLvl2 : MonoBehaviour
{
    public UnityEvent OnFinish;

    void Start()
    {
        LevelData.UnlockLvl3();
        OnFinish.Invoke();
        FunFacts.LoadScene("Main Menu");
    }
}
