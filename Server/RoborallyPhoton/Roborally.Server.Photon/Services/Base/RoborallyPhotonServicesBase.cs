using System;
using System.Linq;
using System.Reflection;

using Photon.SocketServer;

using Roborally.Server.Photon.Interfaces;

namespace Roborally.Server.Photon.Services
{
    /// <summary>The roborally photon services base.</summary>
    public abstract class RoborallyPhotonServicesBase
    {
        private readonly IServiceRepository repository;

        /// <summary>Initializes a new instance of the <see cref="RoborallyPhotonServicesBase"/> class.</summary>
        /// <param name="repository">The repository.</param>
        protected RoborallyPhotonServicesBase(IServiceRepository repository)
        {
            this.repository = repository;
            this.RegisterServices();
        }

        /// <summary>The register services.</summary>
        protected virtual void RegisterServices()
        {
            var operations = this.GetType().GetMethods(BindingFlags.NonPublic | BindingFlags.Instance);

            foreach (var operation in operations)
            {
                var currentOperation = operation;

                var attribute = operation.GetCustomAttributes<OperationCodeAttribute>().SingleOrDefault();
                if (attribute == null)
                {
                    continue;
                }

                Func<OperationRequest, OperationResponse> service = (request) =>
                    {
                        var response = currentOperation.Invoke(this, new object[] { request });
                        return response as OperationResponse;
                    };

                this.repository.Register(attribute.Code, service);
            }
        }
    }
}