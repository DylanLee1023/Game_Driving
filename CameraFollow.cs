using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
    public Transform player; // 主角位置
    public float speed = 5f; // 相机速度   
    Vector3 distance; // 主角和摄像机之间的距离  
    
    public Transform controlButton;
    public Vector3 disCB_Cam;
    void Start () {
        distance =  transform.position - player.position;
        disCB_Cam = controlButton.position - transform.position;
        //disCN_Cam = controlNow.position - transform.position;
    }

                      // Update is called once per frame
    void Update () {
        // 摄像机应该在的位置
        // 不直接赋值给当前摄像机的原因是，需要这个参数来实现一个延迟功能
        
        Vector3 targetCamPos = player.position + distance;
        //targetCamPos.Set(transform.position.x, targetCamPos.y, targetCamPos.z);
        // 给摄像机移动到应该在的位置的过程中加上延迟效果
        transform.position = Vector3.Lerp(transform.position, targetCamPos, speed * Time.deltaTime);
        // transform.position = targetCamPos;
        controlButton.position = transform.position + disCB_Cam;
    }

                


}
