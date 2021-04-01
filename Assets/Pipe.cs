using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    // Start is called before the first frame update
    private float pipeXPos = 5;
    private float pipeSpeed = 2;

    private SomeScriptableObject pipeSettings;

    private float pipeHeight;

    void Awake(){
        pipeHeight = Random.Range(-1f, 3.5f);
        pipeSettings = Resources.FindObjectsOfTypeAll<SomeScriptableObject>()[0];
    }

    void Start(){
        pipeSpeed = pipeSettings.PipeSpeed;
        pipeXPos = pipeSettings.PipeOffset;
    }

    void FixedUpdate()
    {
        if(!Bird.IsAlive || !Bird.IsPlaying)
            return;
        
        pipeXPos -= pipeSpeed * Time.deltaTime;
        gameObject.transform.position = new Vector3(pipeXPos, pipeHeight, 2);

        if(pipeXPos < -5)
            Destroy(gameObject);
    }
}
