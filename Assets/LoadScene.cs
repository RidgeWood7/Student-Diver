using UnityEngine;

public class LoadScene : StateMachineBehaviour
{
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        FunFacts.LoadScene();
    }
}
