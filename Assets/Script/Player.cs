using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    public Rigidbody rb;
    public int Force;
    public Animator ani;
    private bool death=false;
    public delegate void DeathNotify();
    public event DeathNotify OnDeath;
    private Vector3 InitPos;


    public UnityAction<int> OnScore;
    // Start is called before the first frame update
    void Start()
    {
        Idle();
        InitPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            rb = GetComponent<Rigidbody>();
            rb.velocity =Vector3.zero;
            rb.AddForce(new Vector3(0, Force, 0),ForceMode.Impulse);
        }
    }
    public void Death()
    {
        death = true;
        Debug.Log("该角色死亡");
        if(OnDeath != null)
        {
            OnDeath();
        }
    }
    public void Idle()
    {
        this.rb.Sleep();
        this.ani.SetTrigger("Idle");
        rb.useGravity = false;
        Debug.Log("The Bird is Idle");
    }
    public void Fly()
    {
        rb.WakeUp();
        this.ani.SetTrigger("Fly");
        rb.useGravity = true;
        Debug.Log("The Bird is flying");
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Equals("ScoreArea"))
        {
            Debug.Log("进入到触发区域");
           
        }
        else
            Death();
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name.Equals("ScoreArea"))
        {
            Debug.Log("越过了柱子,获得积分");
            if(OnScore != null)
            {
                this.OnScore(1);
            }
        }
    }
    public void OnCollisionEnter(Collision collision)
    {
        Death();
    }
    public void Init()
    {
        transform.position = InitPos;
        Idle();
        death = false;
    }
}
