using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class MainSoundScript : MonoBehaviour
{
    public AudioClip BGM;
    public AudioSource audiosource;

    private string beforeScene = "TitleScreen";
    static public MainSoundScript instance;
    void Awake()
    {
        if (instance == null)
        {

            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {

            Destroy(gameObject);
        }
    }
    void Start()
    {
        DontDestroyOnLoad(gameObject);

        audiosource.PlayOneShot(BGM);

        SceneManager.activeSceneChanged += OnActiveSceneChanged;
    }

    void OnActiveSceneChanged(Scene prevScene, Scene nextScene)
    {
        
        if (beforeScene == "TitleScreen" && nextScene.name == "Synopsis&GuideScene")
        {
            audiosource.Stop();
        }

        if (beforeScene == "TitleScreen" && nextScene.name == "map2Scene")
        {
            audiosource.Stop();
        }

        if (beforeScene == "Synopsis&GuideScene" && nextScene.name == "")
        {
            audiosource.Stop();
        }
        if(beforeScene =="clearScene" && nextScene.name == "TitleScreen")
        {
            audiosource.PlayOneShot(BGM);
        }


        beforeScene = nextScene.name;
    }

   
}
