// using UnityEngine;

// public class MouseHover : MonoBehaviour
// {
// 	Ray ray;
// 	RaycastHit hit;
//     public TrainMove MovingController;
//     // Start is called once before the first execution of Update after the MonoBehaviour is created
//     void Start()
//     {
//         GameObject TrainMoveObject = GameObject.Find("Project (Train)");
//         MovingController = FindAnyObjectByType<TrainMove>();

//         // Check if seatController was found
//         if (TrainMoveObject != null)
//         {
//             MovingController = TrainMoveObject.GetComponent<TrainMove>();
//         }
//     }

//     // Update is called once per frame
// 	void Update()
// 	{
// 		ray = Camera.main.ScreenPointToRay(Input.mousePosition);
// 		if(Physics.Raycast(ray, out hit))
// 		{
//             // if(hit.collider.name == button) {}
// 			 if (hit.collider.gameObject == GameObject.FindWithTag("TrainButton") && Input.GetKeyDown(KeyCode.F)) {
// 			    Debug.Log($"The train is now moving....");
//                 MovingController.movingForward = !MovingController.movingForward;
//                 return;
//              }
// 		}
// 	}
// }
