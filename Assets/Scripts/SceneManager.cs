using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{

    void Start()
    {
        
    }


    void Update()
    {
        
    }

    public void LoadLevel(string loadscene)
    {
        SceneManager.LoadScene(loadscene);
    }
}
