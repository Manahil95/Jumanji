using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStone : MonoBehaviour
{
    public Route currentRoute;
    public int Steps;
    public float Speed;
    int routPosition;
    bool isMoving;

    public TextMeshProUGUI PuzzleText;
    public List<string> Puzzles;
    public List<string> JumanjiScenes;

    private void Start()
    {
        transform.position = currentRoute.childeNodeList[Game_Play.Instance.PlayerAvatarIndex].position;
    }

    private void Update()
    {
        if (!isMoving && OVRInput.Get(OVRInput.Button.PrimaryHandTrigger)) //&& Input.GetKeyDown(KeyCode.W)) 
        {
            DiceNumberTextScript.diceNumber1 = 2;

            Steps = DiceNumberTextScript.diceNumber1; //+ DiceNumberTextScript.diceNumber2;
            Debug.Log("Dice Rolled " + Steps);

            if (routPosition + Steps < currentRoute.childeNodeList.Count)
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
        if (isMoving)
        {
            yield break;
        }
        isMoving = true;

        while (Steps > 0)
        {
            Vector3 nextPos = currentRoute.childeNodeList[routPosition + 1].position;
            while (MoveToNextNode(nextPos)) { yield return null; }

            yield return new WaitForSeconds(0.1f);
            Steps--;
            routPosition++;
        }
        isMoving = false;

        Invoke("ScenesTransition", 0f);
    }

    bool MoveToNextNode(Vector3 goal)
    {
        return goal != (transform.position = Vector3.MoveTowards(transform.position, goal, Speed * Time.deltaTime));

    }

    void ScenesTransition()
    {
        Game_Play.Instance.PlayerAvatarIndex = routPosition;
        int randNumber = Random.Range(0, 3);
        PuzzleText.text = Puzzles[randNumber];

        if (randNumber != 2)
            SceneManager.LoadScene(JumanjiScenes[randNumber]);
    }
}
