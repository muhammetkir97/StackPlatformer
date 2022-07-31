using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackItem : MonoBehaviour
{
    [SerializeField] private Transform baseCube;
    [SerializeField] private Transform cutPiece;
    void Start()
    {
        CutItem(4);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CutItem(float cutPoint)
    {
        Vector3 newBaseScale = baseCube.localScale;
        newBaseScale.x = baseCube.localScale.x - cutPoint / 2f;
        baseCube.localScale = newBaseScale;
        baseCube.localPosition -= new Vector3(-cutPoint / 4f ,0,0);

        cutPiece.localScale = new Vector3(cutPoint / 2f,cutPiece.localScale.y, cutPiece.localScale.z);
        cutPiece.localPosition = new Vector3(cutPoint - 2 ,0,0);
    }
}
