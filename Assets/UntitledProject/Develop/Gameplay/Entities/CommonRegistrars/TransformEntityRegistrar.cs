using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.UntitledProject.Develop.Gameplay.Entities.CommonRegistrars
{
	public sealed class TransformEntityRegistrar : MonoEntityRegistrar
	{
		[SerializeField] private Transform _transform;

		public override void Register(Entity entity)
		{
			entity.AddValue(EntityValue.Transform, _transform);
		}
	}
}
