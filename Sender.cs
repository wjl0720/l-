using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sender : MonoBehaviour
{

    public BulletObject bullet;

    public float currentAngle = 0;
    public float currentAngularVelocity = 0;  
   public  float currentTime = 0;


    public void Awake()
    {
        currentAngle = bullet.InitRotation;
        currentAngularVelocity=bullet.SenderAngularVelocity;

    }

    private void FixedUpdate()
    {
        
        currentAngularVelocity =Mathf.Clamp(currentAngularVelocity+ bullet.SenderAcceleration * Time.fixedDeltaTime,
            -bullet.SenderMaxAngularVelocity,bullet.SenderMaxAngularVelocity);
        currentAngle += currentAngularVelocity * Time.fixedDeltaTime;
        if(Mathf.Abs(currentAngle)>720f)
        {
            currentAngle -= Mathf.Sign(currentAngle) * 360f;

        }
        currentTime += Time.fixedDeltaTime;
        if(currentTime>bullet.SenderInterval)
        {
            currentTime-=bullet.SenderInterval;
            SendByCount(bullet.Count, currentAngle);


        }

    }
    private void SendByCount(int count,float angle)
    {
        float temp = count%2==0? angle+bullet.LineAngle/2 : angle;
        for(int i = 0; i < count; i++)
        {
            temp += Mathf.Pow(-1, 1) * i * bullet.LineAngle;
          Send(temp);
        }




        
    }
    private void Send (float angle)
    {
        GameObject go = Instantiate(bullet.prefabs);
        go.transform.position = transform.position;
        go.transform.rotation = Quaternion.Euler(0, 0, angle);
        var bh=go.AddComponent<BulletBehaviour>();
        
        InitBullet(bh);
    }
    private void InitBullet(BulletBehaviour bh)
    {
        bh.LinearVelocity = bullet.LinearVelocity;
        bh.Acceleration= bullet.Acceleration;
        bh.AngularVelocity= bullet.AngularVelocity;
        bh.AngularAcceleration= bullet.AngularAcceleration;
        bh.LifeTime = bullet.LifeCycle;
        bh.MaxVelocity = bullet.MaxVelocity;
    }
}
