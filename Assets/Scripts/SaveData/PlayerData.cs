using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace SaveSystem.Data
{
	[Serializable]
	public class PlayerData
	{
		public Position PlayerPosition { get; set; }

		public int BulletCount { get; set; }

		public PlayerData(Vector3 position, int bulletCount)
		{
			this.BulletCount = bulletCount;
			PlayerPosition = new Position(position);
		}
	}
}
