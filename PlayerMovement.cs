using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;
    private int count;
    public Text countCoins;
    private int removeCountInt = 1;
    
    private int finishInt = 0;
    public Text finishTxt;
    private int subtractInt = 0;
    public Text subtractText;
    private int remainingInt;
    public Text remainingTxt;
    public Text busted;
    public Text winner;
 

    public float forwardForce = 250f;
    public float sidewaysForce = 1f;
    public float backwardsForce = -1f;
    public float addForwardForce= 10f;
    public float speed = 10.0f;



    // Update is called once per frame

    void Start()
    {
        count = 0;
        SetCountCoins();
        finishInt = 1;
        finishTxt.text = "FINISH REQUIRED: " + finishInt.ToString();
        subtractInt = 0;
        subtractText.text = "LAST SCORED: " + subtractInt.ToString();
        busted.text = "";
        winner.text = "";
        Finishes();
    }


    void FixedUpdate()
    {
        rb.AddForce(0, 0, forwardForce * Time.deltaTime);

        if (Input.GetKey("d") )
        {
            rb.AddForce(sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }
        if (Input.GetKey("a"))
        {
            rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }
        if (Input.GetKey("s"))
        {
            rb.AddForce(0, 0, -forwardForce  * Time.deltaTime - backwardsForce);
        }
        if (Input.GetKey("w"))
        {
            rb.AddForce(0, 0, forwardForce * Time.deltaTime + addForwardForce);
        }

    }

    private void OnTriggerEnter(Collider other)   
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountCoins();
            SlowPlayerDown();
        }

        else if (other.gameObject.CompareTag("BadCoin"))
        {
            other.gameObject.SetActive(false);
            RemoveCountCoins();
            SpeedPlayerUp();
        }


        else if (other.gameObject.CompareTag("UltraBadCoin"))
        {
            other.gameObject.SetActive(false);
            RemoveCountCoins();
            SpeedPlayerUpUltra();
        }

        else if (other.gameObject.CompareTag("60"))
        {
            other.gameObject.SetActive(false);
            finishInt = 60;
            Finishes();
        }

        else if (other.gameObject.CompareTag("61"))
        {
            other.gameObject.SetActive(false);
            finishInt = 61;
            Finishes();
        }

        else if (other.gameObject.CompareTag("62"))
        {
            other.gameObject.SetActive(false);
            finishInt = 62;
            Finishes();
        }

        else if (other.gameObject.CompareTag("63"))
        {
            other.gameObject.SetActive(false);
            finishInt = 63;
            Finishes();
        }

        else if (other.gameObject.CompareTag("64"))
        {
            other.gameObject.SetActive(false);
            finishInt = 64;
            Finishes();
        }

        else if (other.gameObject.CompareTag("20"))
        {
            other.gameObject.SetActive(false);
            subtractInt = 20;
            Finishes();
        }

        else if (other.gameObject.CompareTag("D8"))
        {
            other.gameObject.SetActive(false);
            subtractInt = 16;
            Finishes();
        }
        else if (other.gameObject.CompareTag("D9"))
        {
            other.gameObject.SetActive(false);
            subtractInt = 18;
            Finishes();
        }


        else if (other.gameObject.CompareTag("D10"))
        {
            other.gameObject.SetActive(false);
            subtractInt = 20;
            Finishes();
        }

        else if (other.gameObject.CompareTag("D16"))
        {
            other.gameObject.SetActive(false);
            subtractInt = 32;
            Finishes();
        }

        else if (other.gameObject.CompareTag("D20"))
        {
            other.gameObject.SetActive(false);
            subtractInt = 40;
            Finishes();
        }

        else if (other.gameObject.CompareTag("T15"))
        {
            other.gameObject.SetActive(false);
            subtractInt = 45;
            Finishes();
        }

        else if (other.gameObject.CompareTag("T16"))
        {
            if (finishInt == 64 && subtractInt == 48)
            {
                backwardsForce = 150f;
            }
            other.gameObject.SetActive(false);
            subtractInt = 48;
            Finishes();
        }

        else if (other.gameObject.CompareTag("T20"))
        {
            other.gameObject.SetActive(false);
            subtractInt = 60;
            Finishes();
        }

        else if (other.gameObject.CompareTag("T10"))
        {
            other.gameObject.SetActive(false);
            subtractInt = 30;
            Finishes();
        }

    }
    void SetCountCoins ()
    {
        countCoins.text = "Coins Collected: " + count.ToString();
       
    }

    void RemoveCountCoins()
    {
        count = count - removeCountInt;
        countCoins.text = "Coins Collected: " + count.ToString();
        
    }

    public void SlowPlayerDown()
    {
        rb.AddForce(0, 0, ((forwardForce * Time.deltaTime) * speed) - 500f);
    }

    public void SpeedPlayerUp()
    {
        rb.AddForce(0, 0, ((forwardForce * Time.deltaTime) * speed ));
    }
    public void SpeedPlayerUpUltra()
    {
        rb.AddForce(0, 0, ((forwardForce * Time.deltaTime) * speed * speed));
    }
    

    void Finishes()
    {
        do
        {
            finishTxt.text = finishInt.ToString();
            remainingInt = finishInt - subtractInt;
            finishInt = remainingInt;

            finishTxt.text = "FINISH REQUIRED: " + finishInt.ToString();
            subtractText.text = "LAST SCORED: " +  subtractInt.ToString();
            
            remainingInt = 0;
        }
        while (remainingInt > 0);

        if (finishInt < 0 )
            {   
                busted.text = "YOU HAVE BUSTED! TRY AGAIN?";
                finishTxt.text = "";
                subtractText.text = "";
                
            }

        if (finishInt == 0)
        {
            winner.text = "SHOT DARTS!";
            finishTxt.text = "";
            subtractText.text = "";
            
        }
    }

}
