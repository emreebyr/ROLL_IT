using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using PathCreation;
namespace PathCreation.Examples

{
    public class Follower : MonoBehaviour
    {
        public PathCreator pathCreator;
        public EndOfPathInstruction endOfPathInstruction;
        public float speed = 5;
        float distanceTravelled;

        float xOffset , yOffset;

        public float maxDistanceYatay = 1.9f;
        public float maxDistanceDikey = 0;



        [SerializeField]
        float controllerSpeed = 1;

        [SerializeField]
        float returnSpeed = 1;

        void start() {

            if (pathCreator != null)
            {
                pathCreator.pathUpdated += OnPathChanged;
            }
        }
        void Update ()
        {
            float h = Input.GetAxis ("Vertical");
            float v = Input.GetAxis ("Horizontal");
            if (pathCreator != null)
            {
                distanceTravelled += speed * Time.deltaTime;
                Vector3 desiredPoint = pathCreator.path.GetPointAtDistance(distanceTravelled,endOfPathInstruction);
                transform.rotation = pathCreator.path.GetRotationAtDistance(distanceTravelled,endOfPathInstruction);
                

                if (h == 0 && v == 0){
                    xOffset = Mathf.MoveTowards(xOffset , 0 , Time.deltaTime * returnSpeed);
                    yOffset = Mathf.MoveTowards(yOffset , 0 , Time.deltaTime * returnSpeed);
                }

                else{ 
                    xOffset += h * Time.deltaTime * controllerSpeed;
                    yOffset += v *Time.deltaTime * controllerSpeed;
                }
                
                transform.position = desiredPoint;
            
                
                

                xOffset = Mathf.Clamp(xOffset, - maxDistanceDikey , maxDistanceDikey);
                yOffset = Mathf.Clamp(yOffset, - maxDistanceYatay ,maxDistanceYatay );
                desiredPoint = transform.TransformPoint(new Vector3(xOffset , yOffset , 0));
                
                transform.position = desiredPoint;

                
    

            }
        }
        void OnPathChanged(){
            distanceTravelled = pathCreator.path.GetClosestDistanceAlongPath(transform.position);
        }
    }
}