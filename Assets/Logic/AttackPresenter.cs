using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

namespace u1w
{
    public class AttackPresenter : MonoBehaviour
    {
        [SerializeField] u1w.Rock.RockFactory _rock;
        [SerializeField] u1w.player.PlayerCore _playerCore;
        
        PhaseManager _phaseManager;

        void Start(){
            _phaseManager = PhaseManager.I;
            _phaseManager.State
            .Where(s => s==PhaseState.EnemyAttack)
            .Subscribe(_ => RockAttack())
            .AddTo(this);
        }

        void RockAttack(){
            var damage = _rock.GetAtk();
            if(damage == 0) return;

            StartCoroutine ("waitAnimation");
            _playerCore.Damage(damage);
        }

        private IEnumerator waitAnimation() {
            yield return new WaitForSeconds (4.0f);

            CameraShake.I.Shake(0.25f, 0.1f);
            
        }
    }
}

