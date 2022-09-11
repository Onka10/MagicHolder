using UnityEngine;

/// <summary>
/// tileから受け取る
/// </summary>
public interface IGetTileData
{
    public Color GetColor();
/// <summary>
/// trueならロック中
/// </summary>
    public bool GetNextPosition(Direction direction, out Vector3 result);
}

public interface ILock
{
    public void LockOfRock();
    public void UnLockOfRock();
} 

public interface ILocked
{
    public void PleaseLock(Direction from,TileData myTileData);
    public void PleaseUnLock(Direction from,TileData myTileData);
} 