using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// InputFieldを使えるようにする
using UnityEngine.UI;

public class tempNameEntry : MonoBehaviour
{

    // inputfieldを格納する変数
   public InputField inputfield;

    // テキストを格納する変数
    public Text EntryName;
    public string nowplayername;


    // Use this for initialization
    void Start()
    {

        // InputFieldコンポーネントを格納
        inputfield = GetComponent<InputField>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    

}
 
  
 