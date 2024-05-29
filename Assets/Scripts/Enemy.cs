using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter (Collision other)
    {
        GameManager.instance.DecreaseHealth(3);
        AkSoundEngine.PostEvent("Play_mushroom_hit", gameObject);

    }

}
