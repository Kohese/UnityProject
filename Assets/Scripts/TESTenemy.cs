using UnityEngine;
using UnityEngine.AI;

// NOTICE: THIS SCRIPT WAS FOR TESTING PURPOSES ONLY. I needed enemies to shoot to test game over but this was done while the actual enemy script is being edited.
// This is so no code conflicts will occur in case i accidentally forgot to not upload the actual enemy script to version control
public class TestEnemyAI : DamageableBase
{
    public Transform player;

    public LayerMask whatIsGround, whatIsPlayer;
    
    public float health;

    //Attacking
    public float timeBetweenAttacks;
    bool alreadyAttacked;
    [SerializeField] GameObject projectilePrefab;
    private GameObject projectile;


    //States 
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;


    void Start()
    {
        // sightRange = 100;
        // attackRange = 2;
    }

    private void Awake()
    {
        player = GameObject.Find("Player").transform;
    }

    private void Update()
    {
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if (!playerInSightRange && !playerInAttackRange) Debug.Log("patrolling");
        if (playerInSightRange && !playerInAttackRange) Debug.Log("chasing");
        if (playerInAttackRange && playerInSightRange) AttackPlayer();
    }
    private void AttackPlayer()
    {
        //Make sure enemy doesn't move
        // agent.SetDestination(transform.position);

        transform.LookAt(player);

        if(!alreadyAttacked)
        {
            //Attack code here
            Debug.Log("Attacking");
            alreadyAttacked = true;
            projectile = Instantiate(projectilePrefab) as GameObject;   // spawn object
            projectile.GetComponent<GenericProjectile>().type = GenericProjectile.projectileType.Enemy;    // set projectile type
            projectile.transform.position = transform.TransformPoint(Vector3.forward * 1f);     // set object infront of enemy
            projectile.transform.rotation = transform.rotation;
            
            // Rigidbody rb = Instantiate(projectile, transform.position, Quaternion.identity).GetComponent<Rigidbody>();
            // rb.AddForce(transform.forward * 32f, ForceMode.Impulse);
            // rb.AddForce(transform.up * 8f, ForceMode.Impulse);


            
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }

    private void ResetAttack()
    {
        alreadyAttacked = false;
    }

    public override void TakeDamage(int damage)
    {
        Debug.Log("Took damage");
        health -= damage;
        Debug.Log(health);

        if (health <= 0) 
        {
            Invoke(nameof(DestroyEnemy), 0.5f);
        }
    }
    
    private void DestroyEnemy()
    {
        Messenger<int>.Broadcast(GameEvent.INCREASE_SCORE, 10);  // Adds point(s) to score
        Destroy(gameObject);
    }
}

