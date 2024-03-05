using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlickerLightControl : MonoBehaviour
{
    public bool isFlickering = false;
    public float timeDelay;

    public bool canFlicker = false;
    public float delayBetweenMin = 0.5f;
    public float delayBetweenMax = 1f;
    private float timerBetween;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (canFlicker)
        {
            if (isFlickering == false)
            {
                if(timerBetween < 0)
                {
                    StartCoroutine(FlickeringLight());
                }
                else
                {
                    timerBetween -= Time.deltaTime;
                }
            }
        }
    }

    IEnumerator FlickeringLight()
    {
        isFlickering = true;
        this.gameObject.GetComponent<Light>().enabled = false;
        timeDelay = Random.Range(0.5f, 1f);
        yield return new WaitForSeconds(timeDelay);
        this.gameObject.GetComponent<Light>().enabled = true;
        timeDelay = Random.Range(0.01f, 0.2f);
        yield return new WaitForSeconds(timeDelay);
        timerBetween = Random.Range(delayBetweenMin, delayBetweenMax);
        isFlickering = false;
    }
}
