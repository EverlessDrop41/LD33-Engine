using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LD33_OpenTK.Framework
{
    class Level
    {
        List<GameObject> Objects = new List<GameObject>();

        public Level() { }

        public void AddObject(GameObject obj)
        {
            obj.currentLevel = this;
            Objects.Add(obj);
        }

        public void OnLoad()
        {
            foreach (GameObject go in Objects)
            {
                go.OnLoad();
            }
        }

        public void Update()
        {
            foreach (GameObject go in Objects)
            {
                go.Update();
            }
        }

        public void Draw()
        {
            foreach (GameObject go in Objects)
            {
                go.Draw();
            }
        }
    }
}
