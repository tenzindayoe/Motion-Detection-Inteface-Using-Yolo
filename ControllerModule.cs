using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;
using UnityEngine.Animations;
using System.Linq;

public class ControllerModule : MonoBehaviour
{
    public GameObject character; // Assign the DUNGEONSKELETON_DEMO GameObject in the Inspector window
    public Transform rightFoot; // Assign the right foot Transform in the Inspector window
    public float stepDistance = 1f; // The distance the foot will move on each step

    private Animator animator;
    private Vector3 lastFootPosition;



    public Transform head; 
    // public Transform left_shoulder; 
    // public Transform right_shoulder; 
    

    public float previousEyeDistance = 0;
    public float initial_temp = 40;
    // public float[] ref = {0,0,0};
    // public float scaler = 1; 
    public Dictionary<string, float[]> previousFrameCoor;
    private string[] jointKeys = {"nose","left_eye","right_eye","left_ear","right_ear","left_shoulder","right_shoulder","left_elbow","right_elbow","left_wrist","right_wrist","left_hip","right_hip",
    "left_knee","right_knee","left_ankle","right_ankle"};
    // Start is called before the first frame update

    //Temporary 
    public float prevX = 0 ; 
    public float prevY = 0 ; 
    void Start()
    {
        animator = character.GetComponent<Animator>();
        lastFootPosition = rightFoot.position;
    }



   public void updatePosition(Dictionary<string, float[]> dat){

    Debug.Log(dat["nose"][0] + " , " + dat["nose"][1]);
    float dx = dat["nose"][0] - prevX;
    float dy = dat["nose"][1] = prevY;

    dx*=0.002f;
    dy*=0.002f;

    Vector3 currentPosition = head.position;
    Vector3 newPosition = new Vector3(currentPosition.x + dx, currentPosition.y + dy, currentPosition.z );
    head.position = newPosition;
    Debug.Log(newPosition);
    prevX = dat["nose"][0];
    prevY = dat["nose"][1];
    // zScalingUpdate();
    // zLimbUpdate();
    // xyUpdate();

    

   }

 
    public float centroid(int axis,Dictionary<string, float[]> data){
        float temp = 0 ; 
        float counter = 0 ; 
        foreach (string key in data.Keys)
        {
            temp+= data[key][axis];
            counter += 1 ;
        }
        temp/= counter; 
        return temp; 
    }
    public Dictionary<string, float[]> translateAndScale(Dictionary<string, float[]> data){
        float centroidX = centroid(0,data);
        float centroidY = centroid(1,data);
        foreach (string key in data.Keys){
            data[key][0]-=centroidX;
            data[key][1]-=centroidY;
        }
        Vector2 leftShoulder = new Vector2(data["left_shoulder"][0], data["left_shoulder"][1]);
        Vector2 rightFoot = new Vector2(data["right_foot"][0], data["right_foot"][1]);
        float distance = Vector2.Distance(leftShoulder, rightFoot);
        float charDistance = 10;

        float scale = charDistance/ distance; 
        foreach (string key in data.Keys){
                    data[key][0]*=scale;
                    data[key][1]*=scale;
                }

        return data;
    }
   public void zLimbUpdate(){
    //Update l_arm, r_arm, l_leg, r_leg
   }
   public void zScalingUpdate(Dictionary<string, float[]> data){
    //do shoulder scaling and hip scaling here 
    float deltaShoulder = Mathf.Abs(data["right_shoulder"][0] - data["left_shoulder"][0]) - Mathf.Abs(previousFrameCoor["right_shoulder"][0] - previousFrameCoor["left_shoulder"][0]);
    float deltahip = Mathf.Abs(data["right_hip"][0] - data["left_hip"][0]) - Mathf.Abs(previousFrameCoor["right_hip"][0] - previousFrameCoor["left_hip"][0]);
    
    float averageDeltaZ = (deltaShoulder + deltahip) / 2;

    //add delta Z to current character model z axis 
   }
   public void xyUpdate(Dictionary<string, float[]> data){

    foreach (string key in data.Keys){
        float newX = data[key][0];
        float newY = data[key][1];
        //Set these to the character;
    }
   }
}