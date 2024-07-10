using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{

    public static SceneController instance;

    private void Awake()
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

    public void loadScene(string name)
    {
        SceneManager.LoadScene(name);
    }

    public void loadSceneAdditive(string name)
    {
        SceneManager.LoadScene(name, LoadSceneMode.Additive);
    }

    public void unloadScene(string name)
    {
        SceneManager.UnloadSceneAsync(name);
    }

    public bool isSceneLoaded(string name)
    {
        return getAllActiveScenes().Contains(SceneManager.GetSceneByName(name));
    }

    #region useless but maybe it will be needed later
    // public void switchScene(string name)
    // {
    //     StartCoroutine(switchingScene(name));
    // }

    // private IEnumerator switchingScene(string name)
    // {
    //     yield return SceneManager.LoadSceneAsync(name, LoadSceneMode.Additive);

    //     List<Scene> activeScene = getAllActiveScenes();
    //     SceneManager.SetActiveScene(SceneManager.GetSceneByName(name));

    //     foreach (Scene scene in activeScene)
    //         yield return SceneManager.UnloadSceneAsync(scene);
    // }
    #endregion

    public List<Scene> getAllActiveScenes()
    {
        List<Scene> help = new List<Scene>();

        for (int i = 0; i < SceneManager.loadedSceneCount; i++)
        {
            help.Add(SceneManager.GetSceneAt(i));
        }

        return help;
    }
}
