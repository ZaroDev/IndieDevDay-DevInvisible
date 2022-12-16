using UnityEngine;
using UnityEngine.SceneManagement;
public class DebugScenes : MonoBehaviour
{
    static DebugScenes instance;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Update()
    {
        //Change scene
        if (Input.GetKeyDown(KeyCode.F1))
        {
            if (SceneManager.sceneCount > SceneManager.GetActiveScene().buildIndex)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
            else
            {
                SceneManager.LoadScene(0);
            }
        }
        //Reload current scene
        else if (Input.GetKeyDown(KeyCode.F2))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
