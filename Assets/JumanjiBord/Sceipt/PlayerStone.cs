using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStone : MonoBehaviour
{
    public Route currentRoute;
    public int Steps;
    public float Speed;
    int routPosition;
    bool isMoving;
    

    private void Update()
    {
        if (!isMoving) //&& Input.GetKeyDown(KeyCode.W)) 
        {
            Steps = DiceNumberTextScript.diceNumber1 + DiceNumberTextScript.diceNumber2;
            Debug.Log("Dice Rolled " + Steps);

            if(routPosition + Steps < currentRoute.childeNodeList.Count)
            {
                StartCoroutine(Move());
            }
            else
            {
                Debug.Log("Rolled Number is to high");
            }
        }
    }

    IEnumerator Move()
    {
        if(isMoving)
        {
            yield break;
        }
        isMoving = true;

        while(Steps > 0)
        {
            Vector3 nextPos = currentRoute.childeNodeList[routPosition + 1].position;
            while (MoveToNextNode(nextPos)) { yield return null; }

            yield return new WaitForSeconds(0.1f);
            Steps--;
            routPosition++;
        }
        isMoving = false;
    }

    bool MoveToNextNode(Vector3 goal)
    {
       return goal != (transform.position = Vector3.MoveTowards(transform.position, goal, Speed * Time.deltaTime));
    }
}
