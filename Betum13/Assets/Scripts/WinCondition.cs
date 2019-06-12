using UnityEngine;
using System.Collections;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(BoxCollider))]
public class WinCondition : MonoBehaviour
{
    [Header("Scene to Load")]
    public string sceneToLoad;

    [Header("Game Object to trigger Win")]
    public GameObject winObject;

    // This function will be called when something touches the trigger collider
    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag(winObject.tag))
        {
            SceneManager.LoadScene(sceneToLoad);
        } 
    }
}