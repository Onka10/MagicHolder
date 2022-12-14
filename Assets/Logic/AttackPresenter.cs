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

        int damage;

        void Start(){
            _phaseManager = PhaseManager.I;
            _phaseManager.State
            .Where(s => s==PhaseState.EnemyAttack)
            .Subscribe(_ => RockAttack())
            .AddTo(this);
        }

        void RockAttack(){
            damage = _rock.GetAtk();
            if(damage == 0) return;
            StartCoroutine ("waitAnimation");
        }

        private IEnumerator waitAnimation() {
            yield return new WaitForSeconds (1.5f);
            _playerCore.Damage(damage);
            SoundManager.I.PlayRockAttack();
            CameraShake.I.Shake(0.25f, 0.1f);
            
        }
    }
}

