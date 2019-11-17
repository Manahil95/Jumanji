using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStone : MonoBehaviour
{
    public Route currentRoute;
    public int Steps = 0;
    public float Speed;
    int routPosition;
    int randNumber;

    bool isMoving;

    public TextMeshProUGUI PuzzleText;
    [Multiline]
    public List<string> Puzzles;
    public List<string> JumanjiScenes;
    public GameObject BottlePuzzle;

    private void Start()
    {
        transform.position = currentRoute.childeNodeList[Game_Play.Instance.PlayerAvatarIndex].position;
        routPosition = Game_Play.Instance.PlayerAvatarIndex;
    }

    private void Update()
    {
        if (!isMoving) //&& Input.GetKeyDown(KeyCode.W)) 
        {
            Steps = DiceNumberTextScript.diceNumber1; //+ DiceNumberTextScript.diceNumber2;
            if (Steps > 0)
            {
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
        DiceNumberTextScript.diceNumber1 = 0;
        Game_Play.Instance.PlayerAvatarIndex = routPosition;
        //Game_Play.Instance.CurrentSene++;
        //if(Game_Play.Instance.CurrentSene >= 3)
        //    Game_Play.Instance.CurrentSene = 0;

        do
        {
            randNumber = Random.Range(0, 3);
        } while (randNumber == Game_Play.Instance.previousPuzzle);

        Game_Play.Instance.previousPuzzle = randNumber;
        PuzzleText.text = Puzzles[randNumber];

        if (randNumber != 2)
            Invoke("ScenesTransition", 5f);
        else if (randNumber == 2)
            BottlePuzzle.SetActive(true);
    }

    bool MoveToNextNode(Vector3 goal)
    {
        return goal != (transform.position = Vector3.MoveTowards(transform.position, goal, Speed * Time.deltaTime));
    }

    void ScenesTransition()
    {
        SceneManager.LoadScene(JumanjiScenes[randNumber]);
    }
}
