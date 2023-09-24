using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pipelineManager : MonoBehaviour
{
    public GameObject template;

    List<Pipeline> pipelines=new List<Pipeline>();


    Coroutine coroutine = null;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void StarRun()
    {
        if (pipelines.Count==0)
        coroutine =StartCoroutine(GeneratePipelines());
    }
    public void Init()
    {
        for (int i = 0; i < pipelines.Count; i++)
        {
           Destroy( pipelines[i].gameObject);
        }
        pipelines.Clear();
    }
    public void Stop()
    {
        StopCoroutine(coroutine);
        for (int i = 0; i < pipelines.Count; i++){
            pipelines[i].enabled = false;
        }
        
    }
    IEnumerator GeneratePipelines()
    {
        for(int i = 0;i<3;i++) 
        {
            if(pipelines.Count<3)
            CreatePipeline();
            else
            {
                pipelines[i].enabled = true;
                pipelines[i].Init();
            }

            yield return new WaitForSeconds(2);
        }
        
    }
   
    void CreatePipeline()
    {
        if(pipelines.Count <3) 
        {
            GameObject obj = Instantiate(template, transform);
            Pipeline P = obj.GetComponent<Pipeline>();
            pipelines.Add(P);
        }
        
    }
}
