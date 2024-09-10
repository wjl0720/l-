using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sender : MonoBehaviour
{

    public BulletObject bullet;

    public float currentAngle = 0;//当前发射角度
    public float currentAngularVelocity = 0;  //当前角速度
   public  float currentTime = 0;


    public void Awake()
    {
        currentAngle = bullet.InitRotation;//初始旋转
        currentAngularVelocity=bullet.SenderAngularVelocity;//当前初始角速度

    }

    private void FixedUpdate()
    {
        //v=a*t
        currentAngularVelocity =Mathf.Clamp(currentAngularVelocity+ bullet.SenderAcceleration * Time.fixedDeltaTime,
            -bullet.SenderMaxAngularVelocity,bullet.SenderMaxAngularVelocity);
        //更新角度
        currentAngle += currentAngularVelocity * Time.fixedDeltaTime;
        //限制角度
        if(Mathf.Abs(currentAngle)>720f)
        {
            currentAngle -= Mathf.Sign(currentAngle) * 360f;

        }
        //更新时间
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
        //编译每一条线
        for(int i = 0; i < count; i++)
        {
            temp += Mathf.Pow(-1, 1) * i * bullet.LineAngle;
          Send(temp);
        }




        
    }
    private void Send (float angle)
    {//生成子弹
        GameObject go = Instantiate(bullet.prefabs);
        go.transform.position = transform.position;
        //设置子弹初始旋转
        go.transform.rotation = Quaternion.Euler(0, 0, angle);
        //初始化子弹的配置信息
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
