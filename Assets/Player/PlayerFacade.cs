using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamage
{

}

public interface IStyle
{

}

public interface IMagic
{

}

public interface IStep
{
    public void AddS();
}


namespace u1w.player
{
    public class PlayerFacade : Singleton<PlayerFacade>
    {
        //マジで変数返すだけ

        [SerializeField] StepCounter step;

        public void AddSteps(){
            step.Count();
        }

        public bool CanMove(){
            return step.CanMove();
        }

    }
}

