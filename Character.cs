using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public Transform left_shoulder; 
    public Transform right_shoulder; 
    public Transform left_hip;
    public Transform right_hip; 
    public Transform nose; 
    public Transform left_elbow; 
    public Transform right_elbow; 
    public Transform left_wrist; 
    public Transform right_wrist; 
    public Transform left_knee; 
    public Transform right_knee; 
    public Transform left_ankle;
    public Transform right_ankle; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Dictionary<string, Vector3> getCharacterJointsData(){
        Dictionary<string, Vector3> datContainer = new Dictionary<string, Vector3>();
        datContainer.Add("left_shoulder", left_shoulder.position);
        datContainer.Add("right_shoulder",right_shoulder.position);
        datContainer.Add("left_hip", left_hip.position);
        datContainer.Add("right_hip", right_hip.position); 
        datContainer.Add("nose", nose.position); 
        datContainer.Add("left_elbow", left_elbow.position);
        datContainer.Add("right_elbow", right_elbow.position);
        datContainer.Add("left_wrist", left_wrist.position);
        datContainer.Add("left_knee", left_knee.position);
        datContainer.Add("right_knee", right_knee.position);
        datContainer.Add("left_ankle", left_ankle.position);
        datContainer.Add("right_ankle", right_ankle.position);
        return datContainer;
    }
    
    public void updateJoints(Dictionary<string, float[]> data){
        left_shoulder.transform.position = new Vector3(data["left_shoulder"][0],data["left_shoulder"][1],data["left_shoulder"][2]);
        right_shoulder.transform.position = new Vector3(data["right_shoulder"][0],data["right_shoulder"][1],data["right_shoulder"][2]);
        left_hip.transform.position = new Vector3(data["left_hip"][0],data["left_hip"][1],data["left_hip"][2]);
        right_hip.transform.position = new Vector3(data["right_hip"][0],data["right_hip"][1],data["right_hip"][2]);
        nose.transform.position = new Vector3(data["nose"][0],data["nose"][1],data["nose"][2]);
        left_elbow.transform.position = new Vector3(data["left_elbow"][0],data["left_elbow"][1],data["left_elbow"][2]);
        right_elbow.transform.position = new Vector3(data["right_elbow"][0],data["right_elbow"][1],data["right_elbow"][2]);
        left_wrist.transform.position = new Vector3(data["left_wrist"][0],data["left_wrist"][1],data["left_wrist"][2]);
        right_wrist.transform.position = new Vector3(data["right_wrist"][0],data["right_wrist"][1],data["right_wrist"][2]);
        left_knee.transform.position = new Vector3(data["left_knee"][0],data["left_knee"][1],data["left_knee"][2]);
        right_knee.transform.position = new Vector3(data["right_knee"][0],data["right_knee"][1],data["right_knee"][2]);
        left_ankle.transform.position = new Vector3(data["left_ankle"][0],data["left_ankle"][1],data["left_ankle"][2]);
        right_ankle.transform.position = new Vector3(data["right_ankle"][0],data["right_ankle"][1],data["right_ankle"][2]);
    }
}
