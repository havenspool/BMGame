using UnityEngine;
	using System.Collections;
	using System.Collections.Generic;
		public class PhysisUtils
		{
				/// <summary>
					/// 获取鼠标点下的第一个 T 类型对象
					/// </summary>
					/// <returns>The game object by mouse point.</returns>
					/// <param name="camera">Camera.</param>
					/// <typeparam name="T">The 1st type parameter.</typeparam>
					public static T GetTByMousePoint<T>(Camera camera) where T :Component
			{
					Ray ray = camera.ScreenPointToRay (Input.mousePosition);
					RaycastHit raycastHit;
					if (Physics.Raycast (ray, out raycastHit))
					{
							GameObject gameObject = raycastHit.transform.gameObject;
							return gameObject.GetComponent<T>();
					}
					return null;
			}
					/// <summary>
					/// 获取鼠标点下的所有的 T 类型对象
					/// </summary>
					/// <returns>The T list by mouse point.</returns>
					/// <param name="camera">Camera.</param>
					/// <typeparam name="T">The 1st type parameter.</typeparam>
					public static IList<T> GetTListByMousePoint<T>(Camera camera) where T:Component
			{
					Ray ray = camera.ScreenPointToRay (Input.mousePosition);
					return FilterTListByRaycastHit<T> (Physics.RaycastAll (ray));
			}
					/// <summary>
					/// 获取对象前面一定距离内所有 T 类型对象
					/// </summary>
					/// <returns>The T list by direction and distance.</returns>
					/// <param name="transform">Transform.</param>
					/// <param name="distance">Distance.</param>
					/// <typeparam name="T">The 1st type parameter.</typeparam>
					public static IList<T> GetTListByDirectionAndDistance<T>(Transform transform, float distance) where T:Component
			{
					if (transform == null) return null;
						Vector3 forward = transform.TransformDirection (Vector3.forward);
					return FilterTListByRaycastHit<T>(Physics.RaycastAll (transform.position, forward, distance));
			}
					/// <summary>
					/// 获取对象前面一定角度以及一定距离内的所有 T 类型对象
					/// </summary>
					/// <returns>The T list by direction and distance and angle.</returns>
					/// <param name="transform">Transform.</param>
					/// <param name="distance">Distance.</param>
					/// <param name="angle">Angle.</param>
					/// <typeparam name="T">The 1st type parameter.</typeparam>
					public static IList<T> GetTListByDirectionAndDistanceAndAngle<T>(Transform transform, float distance, float angle = 0f) where T:Component
			{
					if (transform == null) return null;
						Collider[] colliderList = Physics.OverlapSphere (transform.position, distance);
					if (colliderList == null || colliderList.Length == 0) return null;
						IList<T> resultList = new List<T> ();
						foreach(Collider collider in colliderList)
						{
								GameObject gameObject = collider.gameObject;
								if(gameObject != null)
								{
										if(angle > 0f)
										{
												float targetAngle = Vector3.Angle(gameObject.transform.position - transform.position, transform.forward);
												if(targetAngle > angle)
												{
														continue;
												}
										}
										T t = gameObject.GetComponent<T>();
										if(t != null) resultList.Add(t);
								}
						}
					return resultList;
			}
					/// <summary>
					/// 筛选 T 类型对象
					/// </summary>
					/// <returns>The T list by raycast hit.</returns>
					/// <param name="raycastHitList">Raycast hit list.</param>
					/// <typeparam name="T">The 1st type parameter.</typeparam>
					private static IList<T> FilterTListByRaycastHit<T>(RaycastHit[] raycastHitList) where T:Component
			{
					if (raycastHitList == null || raycastHitList.Length == 0) return null;
						IList<T> resultList = new List<T> ();
						foreach (RaycastHit raycastHit in raycastHitList)
						{
								GameObject gameObject = raycastHit.transform.gameObject;
								if(gameObject != null)
								{
										T t = gameObject.GetComponent<T>();
										if(t != null) resultList.Add(t);
								}
						}
					return resultList;
			}
}
