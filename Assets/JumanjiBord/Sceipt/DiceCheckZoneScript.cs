using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceCheckZoneScript : MonoBehaviour
{

    Vector3 diceVelocity;

    public void OnTriggerStay(Collider col)
    {
        if (col.gameObject.tag == "Dice 1" && Dice12.InTheZone)
        {
            diceVelocity = col.GetComponentInParent<Dice12>().diceVelocity;

            if (diceVelocity.x <= 0.01f && diceVelocity.y <= 0.01f && diceVelocity.z <= 0.01f)
            {

                switch (col.gameObject.name)
                {
                    case "Side1":
                        DiceNumberTextScript.diceNumber1 = 12;
                        break;
                    case "Side2":
                        DiceNumberTextScript.diceNumber1 = 11;
                        break;
                    case "Side3":
                        DiceNumberTextScript.diceNumber1 = 10;
                        break;
                    case "Side4":
                        DiceNumberTextScript.diceNumber1 = 9;
                        break;
                    case "Side5":
                        DiceNumberTextScript.diceNumber1 = 8;
                        break;
                    case "Side6":
                        DiceNumberTextScript.diceNumber1 = 7;
                        break;
                    case "Side7":
                        DiceNumberTextScript.diceNumber1 = 6;
                        break;
                    case "Side8":
                        DiceNumberTextScript.diceNumber1 = 5;
                        break;
                    case "Side9":
                        DiceNumberTextScript.diceNumber1 = 4;
                        break;
                    case "Side10":
                        DiceNumberTextScript.diceNumber1 = 3;
                        break;
                    case "Side11":
                        DiceNumberTextScript.diceNumber1 = 2;
                        break;
                    case "Side12":
                        DiceNumberTextScript.diceNumber1 = 1;
                        break;
                }

                Dice12.thrown = false;
                Dice12.InTheZone = false;
                Game_Play.Instance.PuzzleFinished = false;
            }
        }
        print(DiceNumberTextScript.diceNumber1);
    }
}