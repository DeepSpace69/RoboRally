using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Roborally.Communication.ServerInterfaces;

namespace Roborally.Server
{
    internal class MapManager
    {
        private static MapManager instance;

        private MapManager()
        {
            this.MapsDatabase = new List<IMap>();
            this.idCounter = 0;
            this.InitForTest();
        }

        private int idCounter;
        private IList<IMap> MapsDatabase { get; set; }

        /// <summary>Gets the instance.</summary>
        public static MapManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new MapManager();
                }

                return instance;
            }
        }

        /// <summary>The get all robot models.</summary>
        /// <returns>The <see cref="IList"/>.</returns>
        public IList<IMap> GetAllMaps()
        {
            return this.MapsDatabase;
        }

        public IMap GetMapById(int id)
        {
            IMap result = null;
            foreach (var item in MapsDatabase)
            {
                if (item.Id == id)
                {
                    result = item;
                }
                break;
            }
            //проверка на 2 одинаковых ИД?
            if (result == null)
            {
                throw new NullReferenceException();
            }
            return result;
        }


        private void InitForTest()
        {
            this.CreateMap(1, "TestMap1");
            this.CreateMap(2, "TestMap2");
        }

        public void CreateMap(int id, string name)
        {
            idCounter = idCounter + 1;
            //проверить на существующий ИД?
            this.MapsDatabase.Add(new Map(idCounter, name));
        }
    }
}