using Autofac;
using System.Linq;
using Transformalize.Configuration;
using Transformalize.Context;
using Transformalize.Contracts;
using Transformalize.Nulls;

namespace Transformalize.Provider.ActiveDirectory.Autofac {
    public class ActiveDirectoryModule : Module {

        private const string ActiveDirectory = "activedirectory";
        protected override void Load(ContainerBuilder builder) {
            if (!builder.Properties.ContainsKey("Process")) {
                return;
            }

            var process = (Process)builder.Properties["Process"];

            // TODO: Make a schema reader based off the ActiveDirectoryReader.GetActiveDirectoryFields method
            foreach (var connection in process.Connections.Where(c => c.Provider == ActiveDirectory)) {
                builder.Register<ISchemaReader>(ctx => new NullSchemaReader()).Named<ISchemaReader>(connection.Key);
            }

            // Entity input
            foreach (var entity in process.Entities.Where(e => process.Connections.First(c => c.Name == e.Connection).Provider == ActiveDirectory)) {

                // input version detector
                builder.RegisterType<NullInputProvider>().Named<IInputProvider>(entity.Key);

                // input reader
                builder.Register<IRead>(ctx => {
                    var input = ctx.ResolveNamed<InputContext>(entity.Key);
                    var rowFactory = ctx.ResolveNamed<IRowFactory>(entity.Key, new NamedParameter("capacity", input.RowCapacity));

                    return new ActiveDirectoryReader(input, rowFactory);
                }).Named<IRead>(entity.Key);
            }
        }
    }
}
