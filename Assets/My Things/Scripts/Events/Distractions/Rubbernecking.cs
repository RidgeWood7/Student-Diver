using System.Collections;
using UnityEngine;

public class Rubbernecking : MonoBehaviour
{
    [SerializeField] private float _seconds;
    [SerializeField] private AnimationCurve _curve;

    public void SpawnTarget(GameObject target)
    {
        GameObject newObj = Instantiate(target);

        StartCoroutine(LookOverTime(newObj.transform, _seconds));
    }

    IEnumerator LookOverTime(Transform target, float time)
    {
        Vector3 originalRotation = transform.forward;

        for (float t = 0; t < time; t += Time.deltaTime)
        {
            Vector3 difference = transform.position - target.transform.position;
            transform.forward = Vector3.Lerp(originalRotation, difference, _curve.Evaluate(t / time));
            
            yield return new WaitForSeconds(t);
        }
    }
}
