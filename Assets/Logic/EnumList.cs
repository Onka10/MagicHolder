public enum Direction
{
    north 	=0,
    east 	=1,
    south 	=2,
    west    =3
}


public enum GameState
{
    Title=0,
    Ready=1,
    InGame=2,
    Result=3
}

public enum PhaseState
{
    Ready,
    EnemyInsight,
    PlayerTurn,
    PlayerAttack,
    EnemyAttack,
    TurnEnd
}