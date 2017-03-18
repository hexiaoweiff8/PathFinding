﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

/// <summary>
/// 弹道脚本
/// </summary>z`
public class Ballistic : MonoBehaviour
{
    // -------------------------公共属性--------------------------
    /// <summary>
    /// 当前方向
    /// </summary>
    public Vector3 Direction { get; set; }


    public Vector3 Position
    {
        get { return transform.localPosition; }
        set { transform.localPosition = value; }
    }

    /// <summary>
    /// 已移动时间
    /// </summary>
    public float PassedTime { get; set; }

    /// <summary>
    /// 弹道物体半径
    /// </summary>
    public float Radius = 2;

    /// <summary>
    /// 当前速度
    /// </summary>
    public float Speed = 10;

    /// <summary>
    /// 是否有重力
    /// </summary>
    public bool HasGravity = true;

    /// <summary>
    /// 重力系数 默认9.8
    /// </summary>
    public float Gravity = 9.8f;

    ///// <summary>
    ///// 发射角度
    ///// </summary>
    //public float ShootTheta = Utils.NotCompleted - 1;

    /// <summary>
    /// 发射起始点
    /// </summary>
    public Vector3 StartPos;

    /// <summary>
    /// 当前重力方向
    /// </summary>
    public Vector3 GravityDirection = Vector3.down;
    
    /// <summary>
    /// 到达判断类
    /// </summary>
    public BallisticArriveTarget BallisticArriveTarget = null;

    /// <summary>
    /// 移动
    /// </summary>
    public Action<Ballistic, BallisticArriveTarget> Move;

    /// <summary>
    /// 击中回调
    /// </summary>
    public Action<Ballistic, BallisticArriveTarget> Complete;

    // ---------------------------私有属性------------------------------

    /// <summary>
    /// 是否结束
    /// </summary>
    private bool notComplete = true;




    void Update()
    {
        if (BallisticArriveTarget != null && notComplete)
        {
            // 移动
            if (Move != null)
            {
                Move(this, BallisticArriveTarget);
            }
            // 到达目标
            if (BallisticArriveTarget.IsArrivedTarget(this))
            {
                notComplete = false;
                Complete(this, BallisticArriveTarget);
            }
        }
    }

}