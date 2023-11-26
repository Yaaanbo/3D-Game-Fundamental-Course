using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeManager : MonoBehaviour
{
    [SerializeField] private Transform leftGlassParent, rightGlassParent;
    [SerializeField] private Transform leftBridgeRailing, rightBridgeRailing;
    [SerializeField] private Transform finishGround;
    [SerializeField] private GameObject glassPrefab;
    [SerializeField] private float bridgeOffset;
    [SerializeField] private float totalRow;
    // Start is called before the first frame update
    void Start()
    {
        SpawnGlass();   
    }

    private void SpawnGlass()
    {
        float multiplier = 3f;
        finishGround.position = new Vector3(0f, 0f, (totalRow + 1) * multiplier + bridgeOffset);

        leftBridgeRailing.localScale = new Vector3(leftBridgeRailing.localScale.x, leftBridgeRailing.localScale.y, finishGround.transform.position.z);
        rightBridgeRailing.localScale = leftBridgeRailing.localScale;

        for (int i = 0; i < totalRow; i++)
        {
            GameObject rightGlass = Instantiate(glassPrefab, rightGlassParent);
            GameObject leftGlass = Instantiate(glassPrefab, leftGlassParent);

            rightGlass.transform.localPosition = new Vector3(0f, 0f, i * multiplier + bridgeOffset);
            leftGlass.transform.localPosition = new Vector3(0f, 0f, i * multiplier + bridgeOffset);

            GlassBehaviour right = rightGlass.GetComponent<GlassBehaviour>();
            GlassBehaviour left = leftGlass.GetComponent<GlassBehaviour>();

            if (IsRightBreakable()) right.isBreakable = true;
            else left.isBreakable = true;
        }
    }

    private bool IsRightBreakable()
    {
        bool isRightBreakable;
        int randomBreakable = Random.Range(0, 2);

        if (randomBreakable == 1)
            isRightBreakable = true;
        else
            isRightBreakable = false;

        return isRightBreakable;
    }
}
