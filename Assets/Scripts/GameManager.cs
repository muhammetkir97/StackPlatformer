using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GameManager : MonoBehaviour
{
    [Header("Game")]
    [SerializeField] private CharacterController characterController;
    [SerializeField] private ObjectPool stackItemPool;
    [SerializeField] private Transform stackParent;

    [Header("UI")]
    [SerializeField] private Transform startText;

    private int currentLevel = 0;
    private bool isGameStarted = false;
    private Vector3 spawnPosition = Vector3.zero;
    private float stackItemSize = 2f;
    private bool isNewItemPlaced = false;
    private int stackItemCount = 0;
    private StackItem lastStackItem;
    void Start()
    {
        startText.DOScale(Vector3.one * 1.2f,0.3f).SetLoops(-1,LoopType.Yoyo);

    }

    // Update is called once per frame
    void Update()
    {
        if(isGameStarted && Input.GetMouseButtonDown(0))
        {
            if(lastStackItem != null)
            {
                lastStackItem.StopItem();
                isNewItemPlaced = true;
                if(stackItemCount > 0)
                {
                    float distance = stackParent.GetChild(stackParent.childCount - 2).transform.position.x - lastStackItem.transform.position.x;
                    lastStackItem.CutItem(distance * 2);
                }

            }

        }

        if(!isGameStarted && Input.GetMouseButtonDown(0))
        {
            isGameStarted = true;
            StartLevel();
            startText.DOKill();
            startText.DOScale(Vector3.zero,0.1f);
        }


    }

    void StartLevel()
    {
        StartCoroutine(SpawnStackItems());


    }

    IEnumerator SpawnStackItems()
    {
        spawnPosition.z += 3;
        while(isGameStarted)
        {
            if(stackItemCount > 1)
            {
                characterController.SetCharacterSpeed(Globals.instance.GetCharacterSpeed(currentLevel));
                characterController.SetCharacterAnimationStatus(CharacterState.Run);
                characterController.SetCharacterMovementStatus(CharacterState.Run);
            }
            GameObject newStackItem = stackItemPool.GetFromPool();
            newStackItem.transform.parent = stackParent;

            bool fromLeft = Random.Range(0,10) > 5;
            spawnPosition.x = fromLeft ? -Globals.instance.GetSpawnDistance() : Globals.instance.GetSpawnDistance();
            newStackItem.transform.position = spawnPosition;
            isNewItemPlaced = false;
            lastStackItem = newStackItem.GetComponent<StackItem>();
            lastStackItem.MoveItem(fromLeft ? 1 : -1, Globals.instance.GetBlockSpeed(currentLevel));

            while(!isNewItemPlaced) yield return null;
            spawnPosition.z += stackItemSize;
            stackItemCount++;

        }
    }
}
