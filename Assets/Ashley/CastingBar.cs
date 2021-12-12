using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class CastingBar : MonoBehaviour
{
    [SerializeField]
    private Image imageProgressUp;

    private bool isCasting = false;     // when first throwing in line
    private bool isDirectionRight = true;
    private float progressAmt = 0.0f;
    private float progressSpeed = 0.8f;
    public float fishStrength = 0; // dictates which fish you will catch (if you catch it)

    public bool bite = false;      // when player gets a bit
    private bool lineInWater = false;       // when waiting for a bite
    private bool reeling = false;           // when playing the mini game

    public GameObject fishingGame;
    public GameObject castBarVisible;   // object for the casting progress bar
    public GameObject exclaimationPoint;

    public FishingMiniGame miniGame;

    public AudioSource mySource;
    public AudioClip castBarSFX;
    public AudioClip clinkSFX;
    public AudioClip lineCastWooshSplooshSFX;
    public AudioClip biteAlertSFX;
    public AudioClip lineBrokeSFX;
    public AudioClip hitAlertSFX;

    void Start()
    {
        fishStrength = 0;
        fishingGame.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && lineInWater && bite && !reeling)
        {
            Debug.Log("Set fishing game active");
            reeling = true;
            fishingGame.SetActive(true);
            StopAllCoroutines(); //Stops the LineBreak timer
            mySource.PlayOneShot(hitAlertSFX);
        }

        if (miniGame.caughtFish > 0)
        {
            Debug.Log("Caught Fish = " + miniGame.caughtFish);

            reeling = false;
            lineInWater = false;
            bite = false;

            //miniGame.pause = true;

            fishingGame.SetActive(false);
            miniGame.caughtFish = 0;
        }
        
        if (Input.GetMouseButtonDown(0) && !lineInWater && !reeling)
        {
            StartProgress();
            mySource.PlayOneShot(castBarSFX);
        }
        else if (Input.GetMouseButtonUp(0) && !lineInWater && !reeling)
        {
            EndProgress();
            mySource.PlayOneShot(clinkSFX);
        }

        if (isCasting && !lineInWater && !reeling)
        {
            CastingActive();
            castBarVisible.SetActive(true);
        }
        else
        {
            castBarVisible.SetActive(false);
        }
    }

    // when first throwing in the line
    void CastingActive()
    {
        if (isDirectionRight)
        {
            progressAmt += Time.deltaTime * progressSpeed;

            if (progressAmt > 1f)
            {
                isDirectionRight = false;
                progressAmt = 1f;
            }
        }

        else
        {
            progressAmt -= Time.deltaTime * progressSpeed;

            if (progressAmt < 0f)
            {
                isDirectionRight = true;
                progressAmt = 0.0f;
            }
        }

        imageProgressUp.fillAmount = progressAmt;
    }

    public void StartProgress()
    {
        fishStrength = 0;
        isCasting = true;
        progressAmt = 0.0f;
        isDirectionRight = true;
    }

    public void EndProgress()
    {
        isCasting = false;

        if (progressAmt < 0.3f)
        {

            Debug.Log("Weak Casting");
            fishStrength = 0;
        }
        else if (progressAmt > 0.3f && progressAmt < 0.7f)
        {
            Debug.Log("Average Casting");
            fishStrength = 1;
        }
        else if (progressAmt > 0.7f)
        {
            Debug.Log("Strong Casting");
            fishStrength = 2;
        }

        CastWait();
    }

    // waiting for a bite while the line is in the water
    private void CastWait()
    {
        lineInWater = true;
        StartCoroutine(WaitForBite(5));
        mySource.PlayOneShot(lineCastWooshSplooshSFX);
    }

    private IEnumerator WaitForBite(float maxWaitTime)
    {
        yield return new WaitForSeconds(Random.Range(maxWaitTime * 0.25f, maxWaitTime)); //Wait between 25% of maxWaitTime and the maxWaitTime
        Debug.Log("Hit!"); // animation for alert here

        //thoughtBubbles.GetComponent<Animator>().SetTrigger("Alert"); //Show the alert thoughtbubble

        bite = true;

        if (bite)
        {
            GameObject newHIT = Instantiate(exclaimationPoint, transform.position, transform.rotation);
            newHIT.transform.SetParent(gameObject.transform);
            newHIT.transform.localPosition = new Vector3(0.0f, 15.0f);
        }

        mySource.PlayOneShot(biteAlertSFX);

        StartCoroutine(LineBreak(2)); // if no clickings in 2 seconds break the line
    }

    private IEnumerator LineBreak(float lineBreakTime)
    {
        yield return new WaitForSeconds(lineBreakTime);
        Debug.Log("Line Broke!");

        lineInWater = false;
        bite = false;

        mySource.PlayOneShot(lineBrokeSFX);

        //fishingGame.SetActive(false);
    }
}