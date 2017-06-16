using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    public CanvasGroup faderCanvasGroup;                    // The canvas group that controls the Image used for scene fades.

    /* Use this for initialization. */
    void Start()
    {
        // Set the initial alpha to start with a black scene.
        faderCanvasGroup.alpha = 1.0f;
    }

    /* Update is called once per frame. */
    void Update()
    {

    }
}