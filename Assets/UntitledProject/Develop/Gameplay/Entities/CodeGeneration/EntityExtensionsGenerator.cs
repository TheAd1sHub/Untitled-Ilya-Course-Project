using Assets.UntitledProject.Develop.Utils.Conditions;
using Assets.UntitledProject.Develop.Utils.Reactive;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace Assets.UntitledProject.Develop.Gameplay.Entities.CodeGeneration
{
	public static class EntityExtensionsGenerator
	{
		private static Dictionary<EntityValue, Type> _entityValuesToType = new()
		{
			{EntityValue.MoveSpeed, typeof(ReactiveVariable<float>)},
			{EntityValue.MoveDirection, typeof(ReactiveVariable<Vector3>)},
			{EntityValue.MoveCondition, typeof(ICompositeCondition)},

			{EntityValue.RotationSpeed, typeof(ReactiveVariable<float>)},
			{EntityValue.RotationDirection, typeof(ReactiveVariable<Vector3>)},
			{EntityValue.RotationCondition, typeof(ICompositeCondition)},

			{EntityValue.Transform, typeof(Transform)},
			{EntityValue.CharacterController, typeof(CharacterController)},

			{EntityValue.Health, typeof(ReactiveVariable<float>)},
			{EntityValue.MaxHealth, typeof(ReactiveVariable<float>)},

			{EntityValue.TakeDamageRequest, typeof(ReactiveEvent<float>)},
			{EntityValue.TakeDamageEvent, typeof(ReactiveEvent<float>)},
			{EntityValue.TakeDamageCondition, typeof(ICompositeCondition)},

			{EntityValue.IsDead, typeof(ReactiveVariable<bool>)},
			{EntityValue.DeathCondition, typeof(ICompositeCondition)},
			{EntityValue.SelfDestroyCondition, typeof(ICompositeCondition)},
		};

		[InitializeOnLoadMethod]
		[MenuItem("Tools/ECS/Generate Entity Extensions")]
		private static void Generate()
		{
			string path = GetPathToExtensionsFile();

			StreamWriter writer = new StreamWriter(path);

			writer.WriteLine(GetClassHeader());
			writer.WriteLine("{");

			foreach (KeyValuePair<EntityValue, Type> entityValueToType in _entityValuesToType)
			{
				string type = entityValueToType.Value.FullName;

				if (entityValueToType.Value.IsGenericType)
				{
					type = type.Substring(0, type.IndexOf('`'));

					type += "<";

					for (int i = 0; i < entityValueToType.Value.GenericTypeArguments.Length; i++)
					{
						type += entityValueToType.Value.GenericTypeArguments[i].FullName;

						if (i != entityValueToType.Value.GenericTypeArguments.Length - 1)
							type += ", ";
					}

					type += ">";
				}

				if (HasEmptyConstructor(entityValueToType.Value))
					writer.WriteLine($"\tpublic static {typeof(Entity).FullName} Add{entityValueToType.Key}(this {typeof(Entity).FullName} entity) => entity.AddValue({typeof(EntityValue)}.{entityValueToType.Key}, new {type}());");

				writer.WriteLine($"\tpublic static {typeof(Entity).FullName} Add{entityValueToType.Key}(this {typeof(Entity).FullName} entity, {type} value) => entity.AddValue({typeof(EntityValue)}.{entityValueToType.Key}, value);");
				writer.WriteLine($"\tpublic static {type} Get{entityValueToType.Key}(this {typeof(Entity).FullName} entity) => entity.GetValue<{type}>({typeof(EntityValue)}.{entityValueToType.Key});");
				writer.WriteLine($"\tpublic static {typeof(bool)} TryGet{entityValueToType.Key}(this {typeof(Entity).FullName} entity, out {type} value) => entity.TryGetValue<{type}>({typeof(EntityValue)}.{entityValueToType.Key}, out value);");
			}

			writer.WriteLine("}");

			writer.Close();

			AssetDatabase.SaveAssets();
			AssetDatabase.Refresh();
		}

		private static string GetClassHeader() => "public static class EntityExtensionsGenerated";

		private static string GetPathToExtensionsFile() => $"{Application.dataPath}/UntitledProject/Develop/Gameplay/Entities/CodeGeneration/GeneratedEntityExtensions.cs";

		private static bool HasEmptyConstructor(Type type)
			=> type.IsAbstract == false
			&& type.IsSubclassOf(typeof(UnityEngine.Object)) == false
			&& type.IsInterface == false
			&& type.GetConstructors().Any(constructor => constructor.GetParameters().Length == 0);
	}
}
