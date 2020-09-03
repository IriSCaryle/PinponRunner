using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SynopsisandGuide : MonoBehaviour
{

   [SerializeField] Canvas synopsisCanvas;
   [SerializeField] Canvas KeyConf;
   [SerializeField] Canvas Rule;
   [SerializeField] Image rule1;
   [SerializeField] Image rule2;
   [SerializeField] Image rule3;
    public Text nextText;
    int counter;
    bool iscount;

    public AudioSource audiosource;
    public AudioClip enter;
    // Start is called before the first frame update
    void Start()
    {
        nextText.enabled = false;
        KeyConf.enabled = false;
        Rule.enabled = false;
        synopsisCanvas.enabled = true;

        FadeManager.FadeIn();
        counter = 0;
        iscount = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (iscount==false)
        {
            nextText.enabled = true;
        }
        else
        {
            nextText.enabled = false;
        }
        Debug.Log(counter);
        if (Input.GetMouseButtonDown(0) && iscount == false)
        {
            audiosource.PlayOneShot(enter);
            counter += 1;
            iscount = true;
        }
        if (counter == 1)
        {

            synopsisCanvas.enabled = false;
            KeyConf.enabled = true;
            iscount = false;
            
        }
        if (counter == 2)
        {
            KeyConf.enabled = false;
            Rule.enabled = true;
            rule1.enabled = true;
            rule2.enabled = false;
            rule3.enabled = false;
            iscount = false;
        }
        if (counter == 3)
        {
            rule1.enabled = false;
            rule2.enabled = true;
            rule3.enabled = false;
            iscount = false;
        }
        if (counter == 4)
        {
            rule1.enabled = false;
            rule2.enabled = false;
            rule3.enabled = true;
            iscount = false;

        }
        if(counter == 5)
        {
            FadeManager.FadeOut(3);
        }

    }
}
