using UnityEngine;
using System.Collections;

namespace Boss
{
    public class BakeSkill : MonoBehaviour, SkillState
    {
        private MoveBehavior moveBehavior;
        private BasicBoss self;
        float baketime;
        float BakeTime = 5f;
        Vector3 stpos;
        
        #region SkillState implementation

        public void execute()
        {
            if (self.NMA)
            {
                self.NMA.destination = self.target.position;
                self.NMA.velocity = new Vector3(0, 0, 0);
                if (NewerUI.Gamepaused == true)
                {
                    self.NMA.enabled = false;
                }
                else
                {
                    self.NMA.enabled = true;
                }
            }
            moveBehavior.waypoint = self.stpos;
            moveBehavior.turnToDirection(2f);
            moveBehavior.moveToPoint();
            if (Vector3.Distance(self.target.position, self.transform.position) < self.selfDistance.TraceMax)
            {
                Debug.Log("bake1");
                self.changeState(gameObject.AddComponent<TraceSkill>());
            }
            else 
            if(Vector3.Distance(self.stpos, self.transform.position)<0.1f)
            {
                self.changeState(gameObject.AddComponent<IdleSkill>());
                Debug.Log("bake2");
            }
                
           
            //			moveBehavior.checkOutOfVision();

        }

       
        public void enter(BasicBoss boss)
        {
            self = boss;
            if (self.NMA)
            {
                self.NMA.enabled = true;
                self.NMA.velocity = new Vector3(0, 0, 0);
            }
            stpos = transform.position;
            
            if (self.IFIK == true)
            {
                self.IKSwitch(false);
            }
            moveBehavior = new MoveBehavior(boss, self.maxAttackVelocity, delegate {
               
            });
            self.state = BasicBoss.BossState.Move;
        }

        public void exit()
        {
           
            if (self.NMA)
            {

                self.NMA.enabled = false;
            }
            Destroy(this);
        }

        #endregion
        public void Fire()
        {
        }
        public void FireGun()
        {

        }
        public void Hold()
        {

        }
    }
}
