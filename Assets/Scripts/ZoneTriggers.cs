// using UnityEngine;

// public class ZoneTriggers : MonoBehaviour
// {
//     // private GameObject Train;
//     void OnTriggerEnter(Collider other)
//     {
//         // if (!other.CompareTag("Player")) return;
//         // if (other.CompareTag("PlayerBall")) return;
//         // if (other.CompareTag("PlayerBall") || other.CompareTag("enemy")) 
//         // {
//         //     Debug.Log($"Hit something: {other.gameObject.name} | is it: {other.CompareTag("PlayerBall")}");
//         //     return;
//         // }
//         // // if (other.CompareTag("Player") || other.CompareTag("Train"))
//         // // {
//         // //     Debug.Log($"{other.gameObject.name} entered {gameObject.name}");
//         // // }

//         // // if (other.CompareTag("Train"))
//         // // {
//         // //     GameObject Train = GameObject.FindWithTag("Train");
//         // //     Debug.Log(Train);
//         // // }

//     }

//     void OnTriggerExit(Collider other)
//     {
//         if (other.CompareTag("Train"))
//         {
//             GameObject Train = GameObject.FindWithTag("TrainController");
//             Train.AddComponent<SphereCollider>();
//             GameObject coll = Train.GetComponent<SphereCollider>();
//             Debug.Log(coll);
//         }
//         if (other.CompareTag("Player") || other.CompareTag("Train"))
//         {
//             Debug.Log($"{other.gameObject.name} left {gameObject.name}");
//         }
//     }
// }
