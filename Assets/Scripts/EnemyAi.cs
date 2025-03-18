using UnityEngine;
using UnityEngine.AI;

public class EnemyAi : DamageableBase
{
    public NavMeshAgent agent;

    public Transform player;

    public LayerMask whatIsGround, whatIsPlayer;
    
    public float health;
    //Patrolling
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    //Attacking
    public float timeBetweenAttacks;
    bool alreadyAttacked;
    [SerializeField] GameObject projectilePrefab;
    private GameObject projectile;


    //States 
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    //Values
    public int score;

    void Start()
    {
        Awake();
        // sightRange = 100;
        // attackRange = 2;
        Debug.Log(player);
        
    }

    private void Awake()
    {
        player = GameObject.Find("Player").transform;
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    private void Update()
    {
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);


        if (!playerInSightRange && !playerInAttackRange) Patrolling();
        if (playerInSightRange && !playerInAttackRange) ChasePlayer();
        if (playerInAttackRange && playerInSightRange) AttackPlayer();
    }

    private void Patrolling()
    {
        // Debug.Log("Patrolling");
        if (!walkPointSet) SearchWalkPoint();

        if (walkPointSet)
            agent.SetDestination(walkPoint);
        
        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        //Walkpoint Reached
        if (distanceToWalkPoint.magnitude < 1f)
            walkPointSet = false;
    }

    private void SearchWalkPoint()
    {
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if(Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
           walkPointSet = true;
    }

    private void ChasePlayer()
    {
        agent.SetDestination(player.position);
    }

    private void AttackPlayer()
    {
        //Make sure enemy doesn't move
        agent.SetDestination(transform.position);

        transform.LookAt(player);

        if(!alreadyAttacked)
        {
            //Attack code here
            alreadyAttacked = true;
            projectile = Instantiate(projectilePrefab) as GameObject;   // spawn object
            projectile.GetComponent<GenericProjectile>().type = GenericProjectile.projectileType.Enemy;    // set projectile type
            Vector3 yPos = Vector3.up * 1f;
            yPos.y /= 4;
            projectile.transform.position = transform.TransformPoint(Vector3.forward * 0.8f + yPos);     // set object infront of enemy
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
        Messenger<int>.Broadcast(GameEvent.INCREASE_SCORE, score);  // Adds point(s) to score
        Destroy(gameObject);
    }
}
