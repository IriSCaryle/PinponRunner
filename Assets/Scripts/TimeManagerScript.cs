using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class TimeManagerScript : MonoBehaviour
{
    [SerializeField]
    float waitTime = 2.0f;
    [SerializeField]
    Text readyGoText;
    [SerializeField]
    string seName = "";

    Player character;
    Rigidbody playerRigidbody;
    GameObject gameManagerObj;
    GameSystem gameManager;
   // SoundManager soundManager;

    void Start()
    {
        character = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        playerRigidbody = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody>();
        gameManagerObj = GameObject.Find("GameManager");
        gameManager = gameManagerObj.GetComponent<GameSystem>();
        //soundManager = gameManagerObj.GetComponent<SoundManager>();

      //  if (gameManager.isDebugMode)
       // {
         //   character.allowInput = true;
       // }
       // else
        //{
            StartCoroutine(ReadyGo());
       // }
    }

    IEnumerator ReadyGo()
    {
        yield return new WaitForEndOfFrame();

        //プレイヤーの入力を禁止する
        //   character.allowInput = false;
        character.enabled = false;

        playerRigidbody.isKinematic = true;

        yield return new WaitForSeconds(waitTime);
        readyGoText.enabled = true;

        readyGoText.text = "3";

        yield return new WaitForSeconds(1.0f);

        readyGoText.text = "2";

        yield return new WaitForSeconds(1.0f);

        readyGoText.text = "1";

        yield return new WaitForSeconds(1.0f);

        readyGoText.text = "GO!!";

        //プレイヤーの入力を許可する
        //character.allowInput = true;
        character.enabled = true;
        playerRigidbody.isKinematic = false;

        //カウントダウン開始
        gameManager.countDown = true;

        yield return new WaitForSeconds(waitTime);

        readyGoText.enabled = false;

    }

}