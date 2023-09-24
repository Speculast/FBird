using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipeline : MonoBehaviour
{
    float t = 0;
    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    public void Init()
    {
        float y = Random.Range(-2, 2);
        this.transform.localPosition = new Vector3(0, y, 0);

    }

    
    // Update is called once per frame
    void Update()
    {
        this.transform.position += new Vector3(-5, 0) * Time.deltaTime;
        t+= Time.deltaTime;
        if(t > 3)
        {
            t = 0;
            Init();
        }
    }
}
