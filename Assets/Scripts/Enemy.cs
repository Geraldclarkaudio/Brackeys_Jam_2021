using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Stats")]
    [SerializeField]
    protected int health;
    [SerializeField]
    protected float speed = 5.0f;
    [SerializeField]
    protected int goldAmount;

    //distance stuff
    [SerializeField]
    protected Vector3 currentTarget;
    protected float distance;

    //Handles
    protected Animator anim;
    protected Player player;

    protected bool isDead = false;

    [SerializeField]
    protected GameObject goldCoinPrefab;

    // Start is called before the first frame update
    public virtual void Init()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        currentTarget = player.transform.position;
        anim = GetComponentInChildren<Animator>();

    }
    void Start()
    {
        Init();
    }

    // Update is called once per frame
    public virtual void Update()
    {
        if(isDead == true)
        {
            return;
        }

        Movement();
        Debug.Log("Enemy is: " + distance + "Units Away");
    }

    public virtual void Movement()
    {
        currentTarget = player.transform.position;
        distance = Vector3.Distance(transform.position, currentTarget);

        if(distance <= 50.0f && distance > 7.0f)
        {
            anim.SetBool("Moving", true);
            transform.position = Vector3.MoveTowards(transform.position, currentTarget, speed * Time.deltaTime);
            transform.LookAt(currentTarget);
        }

        if(distance >= 50.0f)
        {
            anim.SetBool("Moving", false);
        }
    }

    public virtual void Attack()
    {

    }
}
