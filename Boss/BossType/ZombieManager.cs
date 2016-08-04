using UnityEngine;
using System.Collections;
using System;

namespace Boss {
	public class ZombieManager : BasicBoss {
		
		void Start() {
			//Defualt Search
			base.Start();
			getBossData("Zombie");
			currentState = gameObject.AddComponent<IdleSkill>();
			currentState.enter(this);
			
		}
		
		protected void FixedUpdate () {
			currentState.execute();
			base.FixedUpdate();
		}
		
		public override void beDamaged(JSONObject json) {
			base.beDamaged(json);
			
		}
		
		
	}
}