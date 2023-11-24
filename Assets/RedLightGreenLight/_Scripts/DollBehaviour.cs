using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DollBehaviour : MonoBehaviour
{
    [SerializeField] private float minTimer, maxTimer;
    [HideInInspector] public bool isGreenLight = true;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ChangeLight());
    }

    private IEnumerator ChangeLight()
    {
        float randomTimer = Random.Range(minTimer, maxTimer);
        yield return new WaitForSeconds(randomTimer);

        isGreenLight = !isGreenLight;
        Debug.Log("Is Green Light : " + isGreenLight);

        StartCoroutine(ChangeLight());
    }
}
