using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClockBehavior : MonoBehaviour
{
    //from Code Monkey's "How to make a clock in the UI" 


    private Transform clockHandTransform;

    private const float realSeconds = 360f;
    private float oneRound;


    //calling fishing mini game script to use its variables
    public FishingMiniGame fishingGame;


    private void Awake()
    {
        clockHandTransform = transform.Find("clockHand");
    }

    // Update is called once per frame
    void Update()
    {
        oneRound += Time.deltaTime / realSeconds;

        //Debug.Log("oneRound = " + oneRound);

        float oneRoundNormalized = oneRound % 1f;
        float rotationDegreesPerDay = 360f;
        float hoursPerDay = 24f;

        clockHandTransform.eulerAngles = new Vector3(0, 0, -oneRoundNormalized * rotationDegreesPerDay * hoursPerDay);

        //Old timer (way too fast): if oneRound is around ~3 minutes real time (if oneRound = 0.129)
        //if oneRound is around ~10 minutes real time (if oneRound = 0.43)
        if (oneRound > 0.43)
        {
            //if player has 5 fish or more
            if (fishingGame.fishTotal >= 1) //set to 1 for debugging/playtesting purposes - MUST CHANGE FOR FINAL BUILD
            {
                //go to WinScreen
                SceneManager.LoadScene(2);
            }
            //if player has less than five fish
            if (fishingGame.fishTotal == 0)
            {
                //go to LoseScreen
                SceneManager.LoadScene(3);
            }
        }
    }
}
