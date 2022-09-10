using UnityEngine;

/// <summary>
/// tileから受け取る
/// </summary>
public interface ITileForPlayer
{
    public Color Color{get;}

    public void DeleteColor();
    public IGetNext GetNextPosition();
}

/// <summary>
/// 管理者へ
/// </summary>
public interface ITileForManager
{
    //自分のガチ座標
    public Vector3 Pos{get;}
} 

public interface IGetNext
{
    public bool CanGetPos(Direction direction);
    public Vector3 GetPos(Direction direction);
} 

public interface IOnRock
{
    public void LockOfRock();
    public void UnLockOfRock();
} 

public interface ILocked
{
    public void PleaseLock(Direction from);
    public void PleaseUnLock(Direction from);
} 