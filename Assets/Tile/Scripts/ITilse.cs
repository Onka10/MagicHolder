using UnityEngine;

/// <summary>
/// tileから受け取る
/// </summary>
public interface ITileForPlayer
{
    public Color Color{get;}

    public Vector3 GetPos(Direction dir);

    public void DeleteColor();
}

/// <summary>
/// 管理者へ
/// </summary>
public interface ITileForManager
{
    //自分のガチ座標
    public Vector3 Pos{get;}
} 