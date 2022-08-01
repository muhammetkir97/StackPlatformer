using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackItem : MonoBehaviour
{
    [SerializeField] private Transform baseCube;
    [SerializeField] private Transform cutPiece;
    private float xSize = 5;
    private float blockSpeed = 1;
    private int moveDirection = 1;
    private bool isMoving = false;
    void Start()
    {
        //CutItem(3.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate() 
    {
        if(isMoving) transform.Translate(Vector3.right * moveDirection * blockSpeed);

    }

    //positive values - cut from right, negative values - cut from left
    public void CutItem(float cutPoint)
    {
        Vector3 newBaseScale = baseCube.localScale;
        newBaseScale.x = baseCube.localScale.x - Mathf.Abs(cutPoint) / 2f;
        baseCube.localScale = newBaseScale;
        baseCube.localPosition -= new Vector3(-cutPoint / 4f ,0,0);

        cutPiece.localScale = new Vector3(cutPoint / 2f,cutPiece.localScale.y, cutPiece.localScale.z);
        float xPos = Mathf.Lerp(1.25f,0,Mathf.Abs(cutPoint) / xSize);
        cutPiece.localPosition = new Vector3(-xPos * Mathf.Sign(cutPoint) ,0,0);
        cutPiece.gameObject.AddComponent<Rigidbody>();
    }

    //-1 to left, 1 to right
    public void MoveItem(int dir, float speed)
    {
        blockSpeed = speed;
        moveDirection = dir;
        isMoving = true;
    }

    public void StopItem()
    {
        isMoving = false;
    }
}


