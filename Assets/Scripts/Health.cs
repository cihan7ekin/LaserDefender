using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int health = 50;
    Rigidbody2D myRigibody;
    Collider2D myCollider;

    void Start()
    {
        myRigibody = GetComponent<Rigidbody2D>();
        myCollider = GetComponent<Collider2D>();
    }

    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        DamageDealer damageDealer = other.GetComponent<DamageDealer>();

        if(damageDealer != null)
        {
            TakeDamage(damageDealer.GetDamage());
            damageDealer.Hit();
        }
    }

    void TakeDamage(int damage)
    {
        health -= damage;
        if(health<=0)
        {
            Destroy(gameObject);
        }
    }

}
