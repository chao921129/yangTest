/****************************************************
    文件：IState.cs
	作者：杨成超
    邮箱: 382657000@qq.com
    日期：2020/1/18 11:0:7
	功能：状态机接口
*****************************************************/

using UnityEngine;

public interface IState  
{  
    void Enter(EntityBase entity,params object[] objs);  
      
    void Precess(EntityBase entity, params object[] objs);

    void Exit(EntityBase entity, params object[] objs);  
}

public enum AniState
{
    None,
    Idle,
    Move,
    Atk,
}