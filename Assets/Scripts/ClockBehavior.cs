using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ClockBehavior : MonoBehaviour
{
    //from Code Monkey's "How to make a clock in the UI" 


    private Transform clockHandTransform;

    private const float realSeconds = 360f;
    private float oneRound;


    //calling fishing mini game script to use its variables
    public FishingMiniGame fishingGame;

    //counts down minutes from 10 (or whatever is assigned)
    public int minuteCountDown = 10;

    public TextMeshProUGUI timeText;

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
        //float rotationDegreesPerDay = 360f;
        //float hoursPerDay = 24f;
        float rotationDegreesPerDay = 360f;
        //1.5f = 0.6744 = 4min
        float hoursPerDay = 1.5f; //6f makes one rotation a full minute, 2f makes it over 3min, 1f makes it 7min(0.98860)

        clockHandTransform.eulerAngles = new Vector3(0, 0, -oneRoundNormalized * rotationDegreesPerDay * hoursPerDay);

        if (oneRound > 0.674)
        {
            //if player has 10 fish or more
            if (fishingGame.fishTotal >= 10) //set to 1 for debugging/playtesting purposes - MUST CHANGE FOR FINAL BUILD
            {
                //go to WinScreen
                SceneManager.LoadScene(2);
            }
            //if player has less than 10 fish
            if (fishingGame.fishTotal < 10)
            {
                //go to LoseScreen
                SceneManager.LoadScene(3);
            }
        }

    }
}
