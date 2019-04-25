using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TomatoChunk : MonoBehaviour
{
    //public variables
    public int damage;

    //private variables
    private float speed = 30.0f;
    private float existTimer;
    private WeaponManager weaponManagerScript;
    public AudioSource SFX_hit;
    private LevelLogic levelLogicScript;

    // Start is called before the first frame update
    void Start()
    {
        levelLogicScript = GameObject.Find("LevelLogic").GetComponent<LevelLogic>();
        SFX_hit.volume = levelLogicScript.sfxVolumeSlider.value;

        existTimer = 0;
        damage = 8;
        //GetComponent<BoxCollider2D>().enabled = false;
        //finds closest player
        float distanceToClosestPlayer = Mathf.Infinity;
        PlayerMovement closestPlayer = null;
        PlayerMovement[] allPlayers = GameObject.FindObjectsOfType<PlayerMovement>();

        foreach (PlayerMovement currentPlayer in allPlayers)
        {
            float distanceToPlayer = (currentPlayer.transform.position - transform.position).sqrMagnitude;
            if (distanceToPlayer < distanceToClosestPlayer)
            {
                distanceToClosestPlayer = distanceToPlayer;
                closestPlayer = currentPlayer;
            }
        }
        weaponManagerScript = closestPlayer.GetComponent<WeaponManager>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.up * speed * Time.deltaTime;

        existTimer += Time.deltaTime;
        if (existTimer > 0.85f)
        {
            Destroy(gameObject);
        }
        /*
        if (GetComponent<BoxCollider2D>().enabled == false)
        {
            if (existTimer > .025f)
            {
                GetComponent<BoxCollider2D>().enabled = true;
            }
        }
        */
    }

    IEnumerator DestroyProjectile()
    {
        SFX_hit.Play();
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<BoxCollider2D>().enabled = false;
        yield return new WaitForSeconds(.5f);
        Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D other)
    {

        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<PlayerStatus>().HP -= damage * weaponManagerScript.damageBoostMultiplier;
            StartCoroutine(DestroyProjectile());
        }
        else if (other.gameObject.tag == "Enemy_Bread")
        {
            other.gameObject.GetComponent<Enemy_Bread>().HP -= damage * weaponManagerScript.damageBoostMultiplier;
            StartCoroutine(DestroyProjectile());
        }
        else if (other.gameObject.tag == "Enemy_Tomato")
        {
            other.gameObject.GetComponent<Enemy_Tomato>().HP -= damage * weaponManagerScript.damageBoostMultiplier;
            StartCoroutine(DestroyProjectile());
        }
        else if (other.gameObject.tag == "Enemy_Spaghetti")
        {
            other.gameObject.GetComponent<Enemy_Spaghetti>().HP -= damage * weaponManagerScript.damageBoostMultiplier;
            StartCoroutine(DestroyProjectile());
        }
        else if (other.gameObject.tag == "Enemy_Cheese")
        {
            other.gameObject.GetComponent<Enemy_Cheese>().HP -= damage * weaponManagerScript.damageBoostMultiplier;
            StartCoroutine(DestroyProjectile());
        }
        else if (other.gameObject.tag == "Enemy_Onion")
        {
            other.gameObject.GetComponent<Enemy_Onion>().HP -= damage * weaponManagerScript.damageBoostMultiplier;
            StartCoroutine(DestroyProjectile());
        }
        //if hits anything other than player or enemy destroy itself
        else
        {
            Destroy(gameObject);
        }
    }


}
