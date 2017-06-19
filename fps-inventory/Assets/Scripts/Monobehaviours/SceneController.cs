using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public event Action BeforeSceneUnload;                  // Event delegate that is called just before a scene is unloaded.
    public event Action AfterSceneLoad;                     // Event delegate that is called just after a scene is loaded.

    public CanvasGroup faderCanvasGroup;                    // The canvas group that controls the Image used for scene fades.
    public float fadeDuration = 1.0f;                       // How long it will take for the scene to fade to or from black.
    public string initialScene = "StartingScene";           // The first scene to be loaded from the persistent scene.

    private bool isFading = false;                          // Whether the scene is currently fading to or from black.

    /* Use this for initialization. */
    private IEnumerator Start()
    {
        // Set the initial alpha to start with a black scene.
        faderCanvasGroup.alpha = 1.0f;

        // Start loading the first scene and wait for it to finish.
        yield return StartCoroutine(LoadSceneAndSetActive(initialScene));

        // Fade the scene is once it has finished loading.
        StartCoroutine(Fade(0.0f));
    }

    /* Loads the given scene and sets it to be the new active scene within the SceneManager. */
    private IEnumerator LoadSceneAndSetActive(string sceneName)
    {
        // Allow the scene to load over several frames and add it to the already loaded scenes (just the Persistent scene to start with).
        yield return SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);

        // Set the newly loaded scene as the active scene indicating that it should be unloaded next.
        Scene newlyLoadedScene = SceneManager.GetSceneAt(SceneManager.sceneCount - 1);
        SceneManager.SetActiveScene(newlyLoadedScene);
    }

    /* Handles the fade effect between scene transitions. */
    private IEnumerator Fade(float finalAlpha)
    {
        // Stops attempts to fade and switch the scenes again.
        isFading = true;

        // Halts input into the old scene.
        faderCanvasGroup.blocksRaycasts = true;

        // Fade between the current and final alpha values.
        float fadeSpeed = Mathf.Abs((faderCanvasGroup.alpha - finalAlpha) / fadeDuration);
        while(!Mathf.Approximately(faderCanvasGroup.alpha, finalAlpha))
        {
            // Work the canvs group alpha towards the final alpha.
            faderCanvasGroup.alpha = Mathf.MoveTowards(faderCanvasGroup.alpha, finalAlpha, fadeSpeed * Time.deltaTime);

            // Wait for a frame then continue...
            yield return null;
        }

        // Enable attempts to fade and switch to new scenes.
        isFading = false;

        // Enable input on the new scene.
        faderCanvasGroup.blocksRaycasts = false;
    }
}