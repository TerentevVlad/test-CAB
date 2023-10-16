using System.Collections.Generic;
using System.Linq;

namespace DI
{
    public class GameObjectContext : RunnableContext
    {
        private void Awake()
        {
            var parentRunnableContext = GetComponentsInParent<RunnableContext>(true).ToList();
            parentRunnableContext.Remove(this);
            if (parentRunnableContext.Count > 0)
            {
                DiContainer = new DIContainer(parentRunnableContext.First().DiContainer);
            }
            else
            {
                List<SceneContext> list = new List<SceneContext>();
                foreach (var rootGameObject in gameObject.scene.GetRootGameObjects())
                {
                    var componentsInChildren = rootGameObject.GetComponentsInChildren<SceneContext>(true);
                    list.AddRange(componentsInChildren);
                }

                DiContainer = new DIContainer(list.FirstOrDefault()?.DiContainer);
            }
            Run();
        }
    }
}