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
        private ICollection<IMap> MapsDatabase { get; set; }

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
        /// <returns>The <see cref="ICollection"/>.</returns>
        public ICollection<IMap> GetAllMaps()
        {
            return this.MapsDatabase;
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