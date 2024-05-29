using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowObject : MonoBehaviour
{

    [SerializeField]
    private GameObject objectToFollow;

    private Transform otherObjectTransform;
    private Transform ownTransform;
    private Vector3 offsetOfFollowObjectAndOwn;

    void Start()
    {
        otherObjectTransform = objectToFollow.GetComponent<Transform>();
        ownTransform = gameObject.GetComponent<Transform>();
        offsetOfFollowObjectAndOwn = ownTransform.position - otherObjectTransform .position;
    }

    void Update()
    {
        ownTransform.position = otherObjectTransform.position + offsetOfFollowObjectAndOwn;
        // not gameobject.position = ... because 'position' is part of the camera's COMPONENT 'transform'
        // gameObject.transform.position = ... would also work, but we already have reference to 'transform' component -> ownTransform
    }

    void OnDestroy() {
        Debug.Log("destroy");
    }

    void OnDisable() {
        Debug.Log("disable");
    }
}
