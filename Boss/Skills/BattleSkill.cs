using UnityEngine;
using System.Collections;

namespace Boss
{
    public class BattleSkill : MonoBehaviour, SkillState
    {
        private MoveBehavior moveBehavior;
        private BasicBoss self;
        private Vector3 playerhere;
        int MoveLR=0;
        int MoveF = 2;
        float RotaF = 0;
        float RotaR = 0;
        float RotaU = 0;
        float distance = 0;
        
        
        #region SkillState implementation

        public void enter(BasicBoss boss)
        {
            self = boss;
            if (self.NMA)
            {
                self.NMA.enabled = true;
                self.NMA.velocity = new Vector3(0, 0, 0);
            }
            
 
            self.m_Ani.SetInteger("Move", MoveF);
            StartCoroutine(checkRangeAttackTime(Random.Range(self.RangeTimeMin, self.RangeTimeMax)));
            StartCoroutine(checkTime(1f));
            self.state = BasicBoss.BossState.Move;
        }


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
            Movedata();
            self.m_Ani.SetInteger("Move", MoveF);
            AttackMove();

            
        }


        void Movedata()
        {
            

            Debug.DrawRay(gameObject.transform.position, playerhere, Color.green);

            distance = Vector3.Distance(self.target.position, self.transform.position);
            
            playerhere = self.target.position - gameObject.transform.position;

            RotaF = Vector3.Angle(transform.forward, playerhere);
            RotaR = Vector3.Angle(transform.right, playerhere);
            RotaU = Vector3.Angle(transform.up, playerhere);

            if (distance > self.selfDistance.TraceDistance&& self.state != BasicBoss.BossState.Attack)
            {
                self.changeState(gameObject.AddComponent<TraceSkill>());
            }
        }

        void AttackMove()
        {

            
            float MoveXV = 0;
           
            if (RotaF > 90)
            {
                MoveF = 2;
                MoveXV = Vector3.Angle(transform.right, playerhere) <= 90 ? -2 : 2 ;
                
            }
            else
            if (RotaF > 10)
            {
                
                MoveXV = Vector3.Angle(transform.right, playerhere) <= 90 ? -1 : 1;
            }
            else
            {

                MoveXV = 0;
                if (distance < self.selfDistance.AttackDistance&&Time.time >self.atttime)
                {
                    self.atttime = Time.time + self.attCD;
                    
                    
                    self.changeState(gameObject.AddComponent<AttackSkill>());
                    
                }
               //調整攻擊時機 防止連續判定

            }

           
            self.m_Ani.SetFloat("MoveX", MoveXV, 0.25f, Time.deltaTime);

            self.m_Ani.SetFloat("MoveY", MoveLR, 0.25f, Time.deltaTime);
           /* if (MoveF == 3)
            {
                gameObject.transform.LookAt(self.target);
            }
            
    */
            
            
        }

       

        IEnumerator checkRangeAttackTime(float waitTime)
        {
            
            yield return new WaitForSeconds(waitTime);
            Debug.Log("RA");
            if (distance <= 9)
            {
                self.m_Ani.SetTrigger("RunAttack");
                
            }
            
            if (distance > self.selfDistance.RangeDistance.x && distance <= self.selfDistance.RangeDistance.y && self.isRange)
            {
                self.changeState(gameObject.AddComponent<AttackSkill>());
               
            }
            else {
                
            }
            StartCoroutine(checkRangeAttackTime(Random.Range(self.RangeTimeMin, self.RangeTimeMax)));
        }

        IEnumerator checkTime(float waitTime)
        {
            
            yield return new WaitForSeconds(waitTime);
            MoveF = MoveF>2? 2 : 3 ;
            MoveLR = Random.Range(0, 2);
            StartCoroutine(checkTime(Random.Range(1, 5)));
            
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
            //Vector3 playerPOS = new Vector3(GameObject.Find("Albert2").transform.position.x, GameObject.Find("Albert2").transform.position.y+2, GameObject.Find("Albert2").transform.position.z) ;
            //self.B_FireObj.transform.LookAt(playerPOS);
            /*self.B_bullet.transform.position = self.B_FireObj.transform.position;
            self.B_bullet.active =true;*/
           
            GameObject bulle = Instantiate(self.B_bullet, self.B_FireObj.transform.position, self.B_FireObj.transform.rotation) as GameObject;
            GameObject bulle1 = Instantiate(self.B_bulletFire, self.B_FireObj.transform.position, self.B_FireObj.transform.rotation) as GameObject;
            bulle.GetComponent<Rigidbody>().AddForce((self.B_FireObj.transform.forward + new Vector3(self.BossRandom("FireX"), self.BossRandom("FireY"), 0)) * self.B_bulletSpeed);


        }
        public void Hold()
        {

        }
    }
}