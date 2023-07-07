using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Grenade : MonoBehaviour
{

    private Vector3 targetPos;
    public float greneadeSpeed;

    public GameObject explosion;
    // Start is called before the first frame update

    void Start()
    {
       targetPos = GameObject.Find("Direction").transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(greneadeSpeed > 0)
        {
            greneadeSpeed -= Random.Range(.1f, .25f);
            transform.position = Vector2.MoveTowards(transform.position, targetPos, greneadeSpeed * Time.deltaTime);
        }
        else if(greneadeSpeed <= 0)
        {
            greneadeSpeed = 0;
            StartCoroutine(Explode(2));
        }   
    }

    IEnumerator Explode(float time)
    {
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
        Instantiate(explosion, transform.position, Quaternion.identity);

    }

    private void OnTriggerEnter2D(Collider2D target)
    {
        if(target.tag == "Zombie") StartCoroutine(Explode(0));
    }
}
