using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangesScene : MonoBehaviour
{
    [SerializeField]
    private string _sceneName;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<MeshRenderer>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains("Player")) {
            AkSoundEngine.StopAll();
            SceneManager.LoadScene(_sceneName, LoadSceneMode.Single);
        }
    }
}