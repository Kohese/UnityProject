// using UnityEngine;

// public class TrainStop : MonoBehaviour
// {
//     private SpawnController spawnController;
//     private GameObject Train;
//     private GameObject Room;
//     public int EnemiesInRange;
//     public bool inRoom = false;

//     void Start()
//     {
//         Train = GameObject.FindWithTag("TrainController");
//         Room = GameObject.FindWithTag("RoomSpawner");
//     }
//     void OnTriggerEnter(Collider other)
//     {
//         if (other.CompareTag("Train"))
//         {
//             inRoom = true;
//             if (!Train.GetComponent<SphereCollider>())
//                 Train.AddComponent<SphereCollider>();
//             SphereCollider col = Train.GetComponent<SphereCollider>();
//             col.radius = 500f;
//             col.isTrigger = true;
//             Room.GetComponent<SpawnController>().enabled = true;
//         }
        
//     }

//     void OnTriggerExit(Collider other)
//     {
//         if (other.CompareTag("Train"))
//         {
//             inRoom = false;
//         }

//         if(other.CompareTag("enemy"))
//         {
//             Debug.Log($"Updated count: {EnemiesInRange}");
//         }
//     }

//     void Update()
//     {
//         Debug.Log($"Current enemies left: {EnemiesInRange}");
//         if(EnemiesInRange == 0 && inRoom)
//         {
//             Debug.Log("All of the enemies have been defeated");
//         }
//     }
// }
