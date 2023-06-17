using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MilkTimer : MonoBehaviour
{
    public float timer;
    private int timerInt;
    public GameObject doubleJumpImage;

    public TextMeshProUGUI textTimerPro;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if (timer > 1){
            timer -= Time.deltaTime;
            timerInt = (int) timer;
            textTimerPro.text = timerInt.ToString();
            //textTimerPro.text = string.Format("{01:00}", timer); 
        }
        else{
            doubleJumpImage.SetActive(false);
            textTimerPro.enabled = false;
        }
    }
}
